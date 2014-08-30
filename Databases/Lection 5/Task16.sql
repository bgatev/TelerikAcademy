CREATE VIEW [Users Logged Today] AS
SELECT * 
FROM Users
WHERE convert(varchar(2),Users.LastLoginTime,104) = convert(varchar(2),GETDATE(),104)