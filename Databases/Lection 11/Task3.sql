// Around 5 seconds for Select without FullTextIndex, 590040 rows in results
SELECT *
FROM   Logs
WHERE  Logs.text like '%29%'

// Around 8 seconds for Select with FullTextIndex, 590040 rows in results
SELECT *
FROM   Logs
WHERE  Logs.text like '%29%'