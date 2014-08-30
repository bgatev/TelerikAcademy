SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SelectAllPersonsWithBalanceHigherThan
	@balance float
AS
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		select FirstName + ' ' + LastName as FullName, Accounts.Balance
		from Persons inner join Accounts on Persons.id = Accounts.Person_id
		where Balance > @balance
	END
GO


exec dbo.SelectAllPersonsWithBalanceHigherThan 55