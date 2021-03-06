USE [master]
GO
/****** Object:  Database [DBLogin]    Script Date: 31.8.2014 г. 16:29:00 ******/
CREATE DATABASE [DBLogin]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBLogin', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DBLogin.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBLogin_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DBLogin_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DBLogin] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBLogin].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBLogin] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBLogin] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBLogin] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBLogin] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBLogin] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBLogin] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBLogin] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DBLogin] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBLogin] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBLogin] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBLogin] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBLogin] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBLogin] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBLogin] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBLogin] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBLogin] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBLogin] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBLogin] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBLogin] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBLogin] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBLogin] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBLogin] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBLogin] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBLogin] SET RECOVERY FULL 
GO
ALTER DATABASE [DBLogin] SET  MULTI_USER 
GO
ALTER DATABASE [DBLogin] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBLogin] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBLogin] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBLogin] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBLogin', N'ON'
GO
USE [DBLogin]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 31.8.2014 г. 16:29:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 31.8.2014 г. 16:29:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](10) NOT NULL,
	[Password] [nvarchar](10) NOT NULL,
	[GroupID] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Groups] ON 

INSERT [dbo].[Groups] ([id], [Name]) VALUES (1, N'Administrators')
INSERT [dbo].[Groups] ([id], [Name]) VALUES (2, N'Users')
INSERT [dbo].[Groups] ([id], [Name]) VALUES (3, N'Admins')
SET IDENTITY_INSERT [dbo].[Groups] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [Username], [Password], [GroupID]) VALUES (1, N'ivan', N'ivanov', 3)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Groups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Groups]
GO
USE [master]
GO
ALTER DATABASE [DBLogin] SET  READ_WRITE 
GO
