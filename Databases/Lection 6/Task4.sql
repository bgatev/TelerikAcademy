USE [Bank]
GO
/****** Object:  StoredProcedure [dbo].[CalculateOneMonthInterest]    Script Date: 25.8.2014 ã. 17:00:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[CalculateOneMonthInterest] 
	-- Add the parameters for the stored procedure here
	@accountID int, 
	@interestPerYear float
AS
	BEGIN
		DECLARE @balance float;
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		-- Insert statements for procedure here
		set @balance =  (select Balance
						from Persons inner join Accounts on Persons.id = Accounts.Person_id
						where Person_id = @accountID);

		select dbo.CalculateInterest(@balance, @interestPerYear, 1)
	END

exec dbo.CalculateOneMonthInterest 1, 12