SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE WithdrawMoney 
	-- Add the parameters for the stored procedure here
	@accountID int, 
	@money float
AS
	BEGIN
		DECLARE @newBalance float;
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		-- Insert statements for procedure here
		set @newBalance =  -@money + (select Balance
									  from Persons inner join Accounts on Persons.id = Accounts.Person_id
									  where Person_id = @accountID);

		update Accounts set Balance = @newBalance where Person_id = @accountID
	END
GO

begin tran
exec dbo.WithdrawMoney 1, 10
commit tran


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE DepositMoney 
	-- Add the parameters for the stored procedure here
	@accountID int, 
	@money float
AS
	BEGIN
		DECLARE @newBalance float;
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		-- Insert statements for procedure here
		set @newBalance =  @money + ( select Balance
									  from Persons inner join Accounts on Persons.id = Accounts.Person_id
									  where Person_id = @accountID);

		update Accounts set Balance = @newBalance where Person_id = @accountID
	END
GO

begin tran
exec dbo.DepositMoney 1, 12
commit tran