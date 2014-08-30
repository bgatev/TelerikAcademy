SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION CalculateInterest 
(
	@presentValue float,
	@interestPerYear float,
	@numberOfMonths int
)
RETURNS float
AS
	BEGIN
		-- Declare the return variable here
		DECLARE @futureValue float;

		-- Add the T-SQL statements to compute the return value here
		set @futureValue = @presentValue + @numberOfMonths * @interestPerYear / 100 / 12 * @presentValue;

		-- Return the result of the function
		RETURN (@futureValue);
	END;
GO

select dbo.CalculateInterest(100, 12, 6)