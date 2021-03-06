USE [master]
GO
/****** Object:  Database [Bank]    Script Date: 25.8.2014 г. 17:59:30 ******/
CREATE DATABASE [Bank]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bank', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Bank.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Bank_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Bank_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Bank] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bank].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bank] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bank] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bank] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bank] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bank] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bank] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Bank] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Bank] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bank] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bank] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bank] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bank] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bank] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bank] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bank] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bank] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Bank] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bank] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Bank] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Bank] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Bank] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bank] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Bank] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Bank] SET RECOVERY FULL 
GO
ALTER DATABASE [Bank] SET  MULTI_USER 
GO
ALTER DATABASE [Bank] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Bank] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Bank] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Bank] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Bank', N'ON'
GO
USE [Bank]
GO
/****** Object:  StoredProcedure [dbo].[CalculateOneMonthInterest]    Script Date: 25.8.2014 г. 17:59:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CalculateOneMonthInterest] 
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

GO
/****** Object:  StoredProcedure [dbo].[DepositMoney]    Script Date: 25.8.2014 г. 17:59:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DepositMoney] 
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
/****** Object:  StoredProcedure [dbo].[SelectAllPersons]    Script Date: 25.8.2014 г. 17:59:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectAllPersons]
AS
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		select FirstName + ' ' + LastName as FullName
		from Persons
	END

GO
/****** Object:  StoredProcedure [dbo].[SelectAllPersonsWithBalanceHigherThan]    Script Date: 25.8.2014 г. 17:59:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectAllPersonsWithBalanceHigherThan]
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
/****** Object:  StoredProcedure [dbo].[WithdrawMoney]    Script Date: 25.8.2014 г. 17:59:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[WithdrawMoney] 
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
/****** Object:  UserDefinedFunction [dbo].[CalculateInterest]    Script Date: 25.8.2014 г. 17:59:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[CalculateInterest] 
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
/****** Object:  Table [dbo].[Accounts]    Script Date: 25.8.2014 г. 17:59:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Person_id] [int] NOT NULL,
	[Balance] [float] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Logs]    Script Date: 25.8.2014 г. 17:59:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[Log_id] [int] IDENTITY(1,1) NOT NULL,
	[Account_id] [int] NOT NULL,
	[OldSum] [float] NULL,
	[NewSum] [float] NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Log_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 25.8.2014 г. 17:59:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[SSN] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([id], [Person_id], [Balance]) VALUES (1, 1, 217.56)
INSERT [dbo].[Accounts] ([id], [Person_id], [Balance]) VALUES (2, 2, 6589.45)
INSERT [dbo].[Accounts] ([id], [Person_id], [Balance]) VALUES (3, 3, 50)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
SET IDENTITY_INSERT [dbo].[Logs] ON 

INSERT [dbo].[Logs] ([Log_id], [Account_id], [OldSum], [NewSum]) VALUES (1, 3, 45, 50)
SET IDENTITY_INSERT [dbo].[Logs] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([id], [FirstName], [LastName], [SSN]) VALUES (1, N'Ivan', N'Ivanov', N'1234567890')
INSERT [dbo].[Persons] ([id], [FirstName], [LastName], [SSN]) VALUES (2, N'Pesho', N'Petrov', N'0236547896')
INSERT [dbo].[Persons] ([id], [FirstName], [LastName], [SSN]) VALUES (3, N'Mara', N'Golemska', N'6987452360')
SET IDENTITY_INSERT [dbo].[Persons] OFF
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Persons] FOREIGN KEY([Person_id])
REFERENCES [dbo].[Persons] ([id])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Persons]
GO
ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [FK_Logs_Persons] FOREIGN KEY([Account_id])
REFERENCES [dbo].[Persons] ([id])
GO
ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Logs_Persons]
GO
USE [master]
GO
ALTER DATABASE [Bank] SET  READ_WRITE 
GO
