sp_configure 'clr enabled', 1
GO

RECONFIGURE
GO

CREATE AGGREGATE STRCONCAT (@input nvarchar(200)) RETURNS nvarchar(max)
EXTERNAL NAME STRCONCAT.Concatenate;
GO

SELECT dbo.STRCONCAT(FirstName + ' ' + LastName) 
FROM Employees