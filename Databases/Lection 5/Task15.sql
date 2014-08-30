CREATE TABLE Users
(
id int IDENTITY,
Username nvarchar(30) UNIQUE NOT NULL,
Password nvarchar(30) NOT NULL,
FullName nvarchar(255) NOT NULL,
LastLoginTime datetime,
CONSTRAINT PK_Users PRIMARY KEY(id),
CONSTRAINT PasswordMinLength CHECK(DATALENGTH(Password) > 4)
)