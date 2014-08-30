CREATE TYPE TableType
AS TABLE(name nvarchar(50))

GO

IF OBJECT_ID (N'CheckNamesFromSymbols', N'TF') IS NOT NULL
    DROP FUNCTION CheckNamesFromSymbols;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION CheckNamesFromSymbols 
(	
	@symbols nvarchar(50),
	@inputTableName TableType ReadOnly
)
RETURNS 
@NamesFromSymbols TABLE 
(
	-- Add the column definitions for the TABLE variable here
	id int primary key identity NOT NULL,
	names nvarchar(50)
)
AS
BEGIN
	Declare @currentName nvarchar(50),
			@charCount int,
			@currentPos int,
			@currentCounter int;

	DECLARE input_cursor CURSOR FOR 
	SELECT *
	FROM @inputTableName;
	OPEN input_cursor

	While @@FETCH_STATUS = 0
	Begin
		FETCH NEXT FROM input_cursor 
		INTO @currentName

		Set @charCount = LEN(@currentName);
		Set @currentCounter = 0;

		While @charCount > 0
		Begin
			Set @currentPos = CHARINDEX(SUBSTRING(@currentName, @charCount, 1), @symbols);
			If (@currentPos > 0) Set @currentCounter = @currentCounter + 1;
			Else Break;
			
			Set @charCount = @charCount - 1;
		End;

		-- Fill the table variable with the rows for your result set 
		If @currentCounter = LEN(@currentName) Insert into @NamesFromSymbols(names) Values(@currentName);
	End;

	RETURN 
END
GO

DECLARE @TempTableNames TableType
INSERT into @TempTableNames
select name from Towns
select * from dbo.CheckNamesFromSymbols('oistmiahf', @TempTableNames)

DECLARE @TempTableNames TableType
INSERT into @TempTableNames
select LastName from Employees
select * from dbo.CheckNamesFromSymbols('oistmiahf', @TempTableNames)