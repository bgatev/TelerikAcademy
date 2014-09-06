// Around 30 minutes for Insert
DECLARE @Counter int = 0
DECLARE @CurrentDate datetime = Getdate()
WHILE (@Counter < 10000000)
BEGIN
  INSERT INTO Logs(date, text) Values ((@CurrentDate + @Counter / 1000000), 'text' + CONVERT(varchar, @Counter))
  SET @Counter = @Counter + 1
END

// Around 5 minutes 10 seconds for Select - No caching, 1083421 rows in results
SELECT id, date, text
FROM   Logs
WHERE  (date > CONVERT(DATETIME, '2014-09-01 00:00:00', 102)) AND (date < CONVERT(DATETIME, '2014-09-05 00:00:00', 102))