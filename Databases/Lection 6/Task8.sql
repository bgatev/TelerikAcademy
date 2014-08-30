Create Procedure FetchPairs @pairs CURSOR VARYING OUTPUT
AS
BEGIN
	Set @pairs = CURSOR FOR 
		select Towns.Name, Employees.LastName
		from Employees inner join Addresses on Employees.AddressID = Addresses.AddressID
					   inner join Towns on Addresses.TownID = Towns.TownID
		order by Towns.Name;

	OPEN @pairs;
End;
GO

Declare @townName nvarchar(50),
		@emplLastName nvarchar(50),
		@currentTown nvarchar(50),
		@currentEmplLastName nvarchar(50)
Declare @fetchPairs_cursor Cursor;

EXEC FetchPairs @pairs = @fetchPairs_cursor OUTPUT

While @@FETCH_STATUS = 0
Begin
	FETCH NEXT FROM @fetchPairs_cursor 
	INTO @townName, @emplLastName

	If (@currentTown <> @townName)
		Begin
			Set @currentTown = @townName;
			If (@currentEmplLastName <> @emplLastName) Set @currentEmplLastName = @emplLastName;				
		End;
	Else 
		Begin
			If (@currentEmplLastName = @emplLastName) Print @emplLastName + ' -> ' + @townName;
			Else Set @currentEmplLastName = @emplLastName;
		End;
End;

CLOSE @fetchPairs_cursor;
DEALLOCATE @fetchPairs_cursor;