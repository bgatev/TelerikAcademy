USE [master]
GO
/****** Object:  Database [WolfRaider]    Script Date: 2.9.2014 г. 20:01:01 ч. ******/
CREATE DATABASE [WolfRaider]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WolfRaider', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\WolfRaider.mdf' , SIZE = 5312KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WolfRaider_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\WolfRaider_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WolfRaider] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WolfRaider].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WolfRaider] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WolfRaider] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WolfRaider] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WolfRaider] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WolfRaider] SET ARITHABORT OFF 
GO
ALTER DATABASE [WolfRaider] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WolfRaider] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [WolfRaider] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WolfRaider] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WolfRaider] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WolfRaider] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WolfRaider] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WolfRaider] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WolfRaider] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WolfRaider] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WolfRaider] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WolfRaider] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WolfRaider] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WolfRaider] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WolfRaider] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WolfRaider] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WolfRaider] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WolfRaider] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WolfRaider] SET RECOVERY FULL 
GO
ALTER DATABASE [WolfRaider] SET  MULTI_USER 
GO
ALTER DATABASE [WolfRaider] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WolfRaider] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WolfRaider] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WolfRaider] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'WolfRaider', N'ON'
GO
USE [WolfRaider]
GO
/****** Object:  Table [dbo].[AvailablePositions]    Script Date: 2.9.2014 г. 20:01:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AvailablePositions](
	[AvailablePositionId] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[PositionId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AvailablePositions] PRIMARY KEY CLUSTERED 
(
	[AvailablePositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 2.9.2014 г. 20:01:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[ManagerID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Players_1] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees_Nationalities]    Script Date: 2.9.2014 г. 20:01:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees_Nationalities](
	[EmployeesNaionalitiesId] [uniqueidentifier] NOT NULL,
	[PersonId] [uniqueidentifier] NOT NULL,
	[NationalityId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_PlayersNationalities] PRIMARY KEY CLUSTERED 
(
	[EmployeesNaionalitiesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Games]    Script Date: 2.9.2014 г. 20:01:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Games](
	[GameId] [uniqueidentifier] NOT NULL,
	[HomeTeam] [uniqueidentifier] NOT NULL,
	[GuestTeam] [uniqueidentifier] NOT NULL,
	[PlayedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED 
(
	[GameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nationalities]    Script Date: 2.9.2014 г. 20:01:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nationalities](
	[NationalityId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Nationalities] PRIMARY KEY CLUSTERED 
(
	[NationalityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Occupations]    Script Date: 2.9.2014 г. 20:01:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Occupations](
	[OccupationId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[OccupationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Positions]    Script Date: 2.9.2014 г. 20:01:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[PositionId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED 
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SquadHistory]    Script Date: 2.9.2014 г. 20:01:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SquadHistory](
	[SquadHistoryId] [uniqueidentifier] NOT NULL,
	[EmpoyeeID] [uniqueidentifier] NOT NULL,
	[Goals] [int] NOT NULL,
	[RedCards] [int] NOT NULL,
	[YellowCards] [int] NOT NULL,
	[GameId] [uniqueidentifier] NOT NULL,
	[PositionId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Squads] PRIMARY KEY CLUSTERED 
(
	[SquadHistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teams]    Script Date: 2.9.2014 г. 20:01:03 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[TeamId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[NationalityID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkHistory]    Script Date: 2.9.2014 г. 20:01:03 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkHistory](
	[WorkHistoryId] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[TeamId] [uniqueidentifier] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NULL,
	[OccupationId] [uniqueidentifier] NOT NULL,
	[Salary] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_TeamHistory] PRIMARY KEY CLUSTERED 
(
	[WorkHistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Age], [ManagerID]) VALUES (N'782bebbe-90f4-493a-9d8d-0d89914bfb13', N'Kolio', N'Pavlov', 24, N'3ea19bff-bc0e-4977-94f1-9192fb7a1fff')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Age], [ManagerID]) VALUES (N'e5b6107c-157a-44e1-acd5-18e54b43a1a7', N'Big Bad', N'Wolf', 20, NULL)
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Age], [ManagerID]) VALUES (N'dfb82950-dd6b-4b2c-964d-1f2b726529e0', N'Sve', N'Ivanov', 22, N'e5b6107c-157a-44e1-acd5-18e54b43a1a7')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Age], [ManagerID]) VALUES (N'367aef59-617d-4c40-aff7-1fef42fa2274', N'Hristo', N'Evlogiev', 25, N'3ea19bff-bc0e-4977-94f1-9192fb7a1fff')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Age], [ManagerID]) VALUES (N'6c77cb55-aa54-41e0-b389-200bb1f5539b', N'Stef', N'Naumov', 25, N'e5b6107c-157a-44e1-acd5-18e54b43a1a7')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Age], [ManagerID]) VALUES (N'1054a32e-b0f2-4165-9223-222e16520476', N'Marian', N'Ognyanov', 29, NULL)
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Age], [ManagerID]) VALUES (N'14f62774-f5cc-4a81-8b7f-289c3fc51a59', N'Chicho', N'Misho', 72, N'e6de8bd9-d630-492c-95da-ca4179a8606a')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Age], [ManagerID]) VALUES (N'd5212b3e-0fe0-41bf-8140-3dddce317838', N'Todor', N'Batkov', 55, NULL)
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Age], [ManagerID]) VALUES (N'2ff91233-9da8-4165-9b78-4a80f3d92a75', N'Bay', N'Ivan', 68, N'd5212b3e-0fe0-41bf-8140-3dddce317838')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Age], [ManagerID]) VALUES (N'c4b2ec20-d235-4384-81ae-5374a1e26c9b', N'Ventsi', N'Kulin', 25, N'e5b6107c-157a-44e1-acd5-18e54b43a1a7')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Age], [ManagerID]) VALUES (N'8819bf30-d743-420c-ba32-70d55f2b7913', N'Stefano', N'Kunchev', 25, N'd5212b3e-0fe0-41bf-8140-3dddce317838')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Age], [ManagerID]) VALUES (N'e377af06-b43f-4f8d-abe4-8a3576038644', N'Keni', N'Ivaylov', 25, N'3ea19bff-bc0e-4977-94f1-9192fb7a1fff')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Age], [ManagerID]) VALUES (N'3ea19bff-bc0e-4977-94f1-9192fb7a1fff', N'Kosta', N'Nikolov', 24, NULL)
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Age], [ManagerID]) VALUES (N'e2f87d68-e4d6-45e9-9950-a2fa36c7e32f', N'Vlado', N'Gadjev', 28, N'd5212b3e-0fe0-41bf-8140-3dddce317838')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Age], [ManagerID]) VALUES (N'98074f6a-4c38-4d33-a7ec-ab68b71d4e03', N'Stoyan', N'Todorov', 28, N'3ea19bff-bc0e-4977-94f1-9192fb7a1fff')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Age], [ManagerID]) VALUES (N'178ee112-5d7d-454d-a2ae-b26aa2197fde', N'Minko', N'Donchov', 25, N'3ea19bff-bc0e-4977-94f1-9192fb7a1fff')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Age], [ManagerID]) VALUES (N'3cd84736-53e6-4b7c-beca-b9a6c10cf66e', N'Pavkata', N'Hristov', 25, N'e5b6107c-157a-44e1-acd5-18e54b43a1a7')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Age], [ManagerID]) VALUES (N'e6de8bd9-d630-492c-95da-ca4179a8606a', N'Ventsi', N'Stefanov', 58, NULL)
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [Age], [ManagerID]) VALUES (N'9beced31-68a4-436b-bbd6-f70330766595', N'Boy', N'Gatev', 26, N'e5b6107c-157a-44e1-acd5-18e54b43a1a7')
INSERT [dbo].[Games] ([GameId], [HomeTeam], [GuestTeam], [PlayedOn]) VALUES (N'bee949b7-90e6-4131-b307-34d3c973492b', N'926fdc20-699a-454d-959c-08574e237c2e', N'c3ee1298-10a4-4cf4-a0ba-1065a16f2e35', CAST(0x0000A39500000000 AS DateTime))
INSERT [dbo].[Games] ([GameId], [HomeTeam], [GuestTeam], [PlayedOn]) VALUES (N'fbb9bb0f-0e59-4b58-9648-b9351c26475e', N'c3ee1298-10a4-4cf4-a0ba-1065a16f2e35', N'0832909b-ff84-415b-845c-567f96508cf9', CAST(0x0000A34A00000000 AS DateTime))
INSERT [dbo].[Games] ([GameId], [HomeTeam], [GuestTeam], [PlayedOn]) VALUES (N'27b0ef64-b67b-4e02-a66a-baa05471bb16', N'0832909b-ff84-415b-845c-567f96508cf9', N'729cac65-c0bb-4973-821f-4f76dffa8629', CAST(0x0000A39C00000000 AS DateTime))
INSERT [dbo].[Games] ([GameId], [HomeTeam], [GuestTeam], [PlayedOn]) VALUES (N'c5d50e13-fe33-4209-87e8-c90df47b4405', N'54cf128e-1d63-4f31-8e01-c29341be5007', N'b443f3e1-473d-4dcd-b9df-d84b4b6be6d9', CAST(0x0000A38200000000 AS DateTime))
INSERT [dbo].[Nationalities] ([NationalityId], [Name]) VALUES (N'220aeb07-70f3-4ecd-a9fb-216d6792bf73', N'Poland')
INSERT [dbo].[Nationalities] ([NationalityId], [Name]) VALUES (N'351f6470-b87d-4e5b-984c-2ec1127438b2', N'Germany')
INSERT [dbo].[Nationalities] ([NationalityId], [Name]) VALUES (N'f98c4ecc-d346-40a9-bf6a-3d9ea2dcae0b', N'Bulgaria')
INSERT [dbo].[Nationalities] ([NationalityId], [Name]) VALUES (N'91da6347-fb3a-4d49-99db-8497c4315a5c', N'Burundi')
INSERT [dbo].[Occupations] ([OccupationId], [Name]) VALUES (N'633b38ad-4b46-4d57-99bb-04c98fc80f32', N'Coach')
INSERT [dbo].[Occupations] ([OccupationId], [Name]) VALUES (N'e93b212a-234c-4783-ab51-103f08b03847', N'Manager')
INSERT [dbo].[Occupations] ([OccupationId], [Name]) VALUES (N'755070a0-bb6c-44bb-8284-1ebb0917db28', N'Player')
INSERT [dbo].[Occupations] ([OccupationId], [Name]) VALUES (N'bd493bf2-7da0-4d1b-bdc0-5a63332a8e79', N'Room Service')
INSERT [dbo].[Occupations] ([OccupationId], [Name]) VALUES (N'8e7dd991-6d68-4287-846d-82ccec34dca2', N'Medic')
INSERT [dbo].[Occupations] ([OccupationId], [Name]) VALUES (N'598d18e5-81e7-4442-ba1e-b27309b73bdb', N'President')
INSERT [dbo].[SquadHistory] ([SquadHistoryId], [EmpoyeeID], [Goals], [RedCards], [YellowCards], [GameId], [PositionId]) VALUES (N'71b50a89-1510-445c-933f-2e39fb964514', N'3cd84736-53e6-4b7c-beca-b9a6c10cf66e', 2, 0, 0, N'27b0ef64-b67b-4e02-a66a-baa05471bb16', NULL)
INSERT [dbo].[SquadHistory] ([SquadHistoryId], [EmpoyeeID], [Goals], [RedCards], [YellowCards], [GameId], [PositionId]) VALUES (N'a9ebc5e7-d39a-4437-b07f-49310f8bcf01', N'dfb82950-dd6b-4b2c-964d-1f2b726529e0', 1, 0, 0, N'27b0ef64-b67b-4e02-a66a-baa05471bb16', NULL)
INSERT [dbo].[SquadHistory] ([SquadHistoryId], [EmpoyeeID], [Goals], [RedCards], [YellowCards], [GameId], [PositionId]) VALUES (N'e2115880-4b08-400e-80a8-514b8e265995', N'e377af06-b43f-4f8d-abe4-8a3576038644', 2, 0, 0, N'fbb9bb0f-0e59-4b58-9648-b9351c26475e', NULL)
INSERT [dbo].[SquadHistory] ([SquadHistoryId], [EmpoyeeID], [Goals], [RedCards], [YellowCards], [GameId], [PositionId]) VALUES (N'fdf3a1cd-94f1-45e4-b04e-51bef7017893', N'e377af06-b43f-4f8d-abe4-8a3576038644', 1, 0, 0, N'27b0ef64-b67b-4e02-a66a-baa05471bb16', NULL)
INSERT [dbo].[SquadHistory] ([SquadHistoryId], [EmpoyeeID], [Goals], [RedCards], [YellowCards], [GameId], [PositionId]) VALUES (N'63c74196-56f2-4b83-abab-5fef1dc3969d', N'178ee112-5d7d-454d-a2ae-b26aa2197fde', 1, 0, 1, N'fbb9bb0f-0e59-4b58-9648-b9351c26475e', NULL)
INSERT [dbo].[SquadHistory] ([SquadHistoryId], [EmpoyeeID], [Goals], [RedCards], [YellowCards], [GameId], [PositionId]) VALUES (N'a83ea230-22de-4ab7-ae5a-6499d4182444', N'c4b2ec20-d235-4384-81ae-5374a1e26c9b', 1, 0, 0, N'27b0ef64-b67b-4e02-a66a-baa05471bb16', NULL)
INSERT [dbo].[SquadHistory] ([SquadHistoryId], [EmpoyeeID], [Goals], [RedCards], [YellowCards], [GameId], [PositionId]) VALUES (N'c87a7ae6-d96a-41cc-91e0-65e42af5b0fe', N'9beced31-68a4-436b-bbd6-f70330766595', 0, 1, 0, N'27b0ef64-b67b-4e02-a66a-baa05471bb16', NULL)
INSERT [dbo].[SquadHistory] ([SquadHistoryId], [EmpoyeeID], [Goals], [RedCards], [YellowCards], [GameId], [PositionId]) VALUES (N'e984a267-2b15-4e68-8e75-743863dc33cb', N'3ea19bff-bc0e-4977-94f1-9192fb7a1fff', 1, 0, 0, N'27b0ef64-b67b-4e02-a66a-baa05471bb16', NULL)
INSERT [dbo].[SquadHistory] ([SquadHistoryId], [EmpoyeeID], [Goals], [RedCards], [YellowCards], [GameId], [PositionId]) VALUES (N'98aea4b8-35b5-46c7-9b64-9f095479b3dc', N'98074f6a-4c38-4d33-a7ec-ab68b71d4e03', 1, 0, 0, N'27b0ef64-b67b-4e02-a66a-baa05471bb16', NULL)
INSERT [dbo].[SquadHistory] ([SquadHistoryId], [EmpoyeeID], [Goals], [RedCards], [YellowCards], [GameId], [PositionId]) VALUES (N'19b0a783-b114-4008-accd-b215c1c9442f', N'6c77cb55-aa54-41e0-b389-200bb1f5539b', 0, 0, 1, N'27b0ef64-b67b-4e02-a66a-baa05471bb16', NULL)
INSERT [dbo].[SquadHistory] ([SquadHistoryId], [EmpoyeeID], [Goals], [RedCards], [YellowCards], [GameId], [PositionId]) VALUES (N'eab1a922-3820-410a-be56-d9399ebb4f52', N'178ee112-5d7d-454d-a2ae-b26aa2197fde', 1, 0, 1, N'27b0ef64-b67b-4e02-a66a-baa05471bb16', NULL)
INSERT [dbo].[SquadHistory] ([SquadHistoryId], [EmpoyeeID], [Goals], [RedCards], [YellowCards], [GameId], [PositionId]) VALUES (N'959ad7fb-ff77-4cea-ba3f-eb1c9eadc4ae', N'367aef59-617d-4c40-aff7-1fef42fa2274', 0, 1, 0, N'fbb9bb0f-0e59-4b58-9648-b9351c26475e', NULL)
INSERT [dbo].[SquadHistory] ([SquadHistoryId], [EmpoyeeID], [Goals], [RedCards], [YellowCards], [GameId], [PositionId]) VALUES (N'04c03ed3-5fc5-4b06-95d0-fa0cc2087187', N'367aef59-617d-4c40-aff7-1fef42fa2274', 0, 1, 0, N'27b0ef64-b67b-4e02-a66a-baa05471bb16', NULL)
INSERT [dbo].[Teams] ([TeamId], [Name], [NationalityID]) VALUES (N'926fdc20-699a-454d-959c-08574e237c2e', N'Crazy Forest', N'f98c4ecc-d346-40a9-bf6a-3d9ea2dcae0b')
INSERT [dbo].[Teams] ([TeamId], [Name], [NationalityID]) VALUES (N'c3ee1298-10a4-4cf4-a0ba-1065a16f2e35', N'African Dream', N'91da6347-fb3a-4d49-99db-8497c4315a5c')
INSERT [dbo].[Teams] ([TeamId], [Name], [NationalityID]) VALUES (N'729cac65-c0bb-4973-821f-4f76dffa8629', N'Wolf Raider', N'f98c4ecc-d346-40a9-bf6a-3d9ea2dcae0b')
INSERT [dbo].[Teams] ([TeamId], [Name], [NationalityID]) VALUES (N'0832909b-ff84-415b-845c-567f96508cf9', N'Tilirik United', N'f98c4ecc-d346-40a9-bf6a-3d9ea2dcae0b')
INSERT [dbo].[Teams] ([TeamId], [Name], [NationalityID]) VALUES (N'54cf128e-1d63-4f31-8e01-c29341be5007', N'Real Ihtiman', N'f98c4ecc-d346-40a9-bf6a-3d9ea2dcae0b')
INSERT [dbo].[Teams] ([TeamId], [Name], [NationalityID]) VALUES (N'b443f3e1-473d-4dcd-b9df-d84b4b6be6d9', N'Bayern Munchen', N'351f6470-b87d-4e5b-984c-2ec1127438b2')
INSERT [dbo].[WorkHistory] ([WorkHistoryId], [EmployeeId], [TeamId], [StartDate], [EndDate], [OccupationId], [Salary]) VALUES (N'6f84c6a6-8424-4850-bee2-06e1123c1e86', N'9beced31-68a4-436b-bbd6-f70330766595', N'729cac65-c0bb-4973-821f-4f76dffa8629', CAST(0xED380B00 AS Date), NULL, N'755070a0-bb6c-44bb-8284-1ebb0917db28', CAST(14000.00 AS Decimal(18, 2)))
INSERT [dbo].[WorkHistory] ([WorkHistoryId], [EmployeeId], [TeamId], [StartDate], [EndDate], [OccupationId], [Salary]) VALUES (N'761e0bca-c978-4d73-a88b-1d92072760aa', N'e5b6107c-157a-44e1-acd5-18e54b43a1a7', N'729cac65-c0bb-4973-821f-4f76dffa8629', CAST(0xED380B00 AS Date), NULL, N'633b38ad-4b46-4d57-99bb-04c98fc80f32', CAST(35000.00 AS Decimal(18, 2)))
INSERT [dbo].[WorkHistory] ([WorkHistoryId], [EmployeeId], [TeamId], [StartDate], [EndDate], [OccupationId], [Salary]) VALUES (N'692af475-05e9-4fb5-9921-29327850a914', N'e377af06-b43f-4f8d-abe4-8a3576038644', N'0832909b-ff84-415b-845c-567f96508cf9', CAST(0xBF360B00 AS Date), NULL, N'755070a0-bb6c-44bb-8284-1ebb0917db28', CAST(22000.00 AS Decimal(18, 2)))
INSERT [dbo].[WorkHistory] ([WorkHistoryId], [EmployeeId], [TeamId], [StartDate], [EndDate], [OccupationId], [Salary]) VALUES (N'393405f0-9947-4a07-ab19-3848b3e6d6c0', N'98074f6a-4c38-4d33-a7ec-ab68b71d4e03', N'0832909b-ff84-415b-845c-567f96508cf9', CAST(0x8B310B00 AS Date), NULL, N'755070a0-bb6c-44bb-8284-1ebb0917db28', CAST(21500.00 AS Decimal(18, 2)))
INSERT [dbo].[WorkHistory] ([WorkHistoryId], [EmployeeId], [TeamId], [StartDate], [EndDate], [OccupationId], [Salary]) VALUES (N'1532a64f-f3b1-4640-bf3d-3aaf7de988ab', N'178ee112-5d7d-454d-a2ae-b26aa2197fde', N'0832909b-ff84-415b-845c-567f96508cf9', CAST(0x43360B00 AS Date), NULL, N'755070a0-bb6c-44bb-8284-1ebb0917db28', CAST(23000.00 AS Decimal(18, 2)))
INSERT [dbo].[WorkHistory] ([WorkHistoryId], [EmployeeId], [TeamId], [StartDate], [EndDate], [OccupationId], [Salary]) VALUES (N'daed7ee0-389e-4cbd-a5e4-4b1c60465c21', N'c4b2ec20-d235-4384-81ae-5374a1e26c9b', N'729cac65-c0bb-4973-821f-4f76dffa8629', CAST(0xED380B00 AS Date), NULL, N'755070a0-bb6c-44bb-8284-1ebb0917db28', CAST(29000.00 AS Decimal(18, 2)))
INSERT [dbo].[WorkHistory] ([WorkHistoryId], [EmployeeId], [TeamId], [StartDate], [EndDate], [OccupationId], [Salary]) VALUES (N'1b870a9f-923b-420d-abf8-4ea8058d721b', N'6c77cb55-aa54-41e0-b389-200bb1f5539b', N'729cac65-c0bb-4973-821f-4f76dffa8629', CAST(0xED380B00 AS Date), NULL, N'755070a0-bb6c-44bb-8284-1ebb0917db28', CAST(17500.00 AS Decimal(18, 2)))
INSERT [dbo].[WorkHistory] ([WorkHistoryId], [EmployeeId], [TeamId], [StartDate], [EndDate], [OccupationId], [Salary]) VALUES (N'11462626-f1b9-4f41-ac7c-5574acec4162', N'14f62774-f5cc-4a81-8b7f-289c3fc51a59', N'0832909b-ff84-415b-845c-567f96508cf9', CAST(0x2E330B00 AS Date), NULL, N'8e7dd991-6d68-4287-846d-82ccec34dca2', CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[WorkHistory] ([WorkHistoryId], [EmployeeId], [TeamId], [StartDate], [EndDate], [OccupationId], [Salary]) VALUES (N'335cbb53-bb1c-4714-84ae-75ea39dd5446', N'dfb82950-dd6b-4b2c-964d-1f2b726529e0', N'729cac65-c0bb-4973-821f-4f76dffa8629', CAST(0xED380B00 AS Date), NULL, N'755070a0-bb6c-44bb-8284-1ebb0917db28', CAST(18000.00 AS Decimal(18, 2)))
INSERT [dbo].[WorkHistory] ([WorkHistoryId], [EmployeeId], [TeamId], [StartDate], [EndDate], [OccupationId], [Salary]) VALUES (N'622a16b3-fc17-46ec-aa07-835cd7d97435', N'782bebbe-90f4-493a-9d8d-0d89914bfb13', N'0832909b-ff84-415b-845c-567f96508cf9', CAST(0x8C350B00 AS Date), NULL, N'755070a0-bb6c-44bb-8284-1ebb0917db28', CAST(20000.00 AS Decimal(18, 2)))
INSERT [dbo].[WorkHistory] ([WorkHistoryId], [EmployeeId], [TeamId], [StartDate], [EndDate], [OccupationId], [Salary]) VALUES (N'86b6a752-214b-4797-aa4f-8e01e81810e2', N'2ff91233-9da8-4165-9b78-4a80f3d92a75', N'0832909b-ff84-415b-845c-567f96508cf9', CAST(0x2E330B00 AS Date), NULL, N'bd493bf2-7da0-4d1b-bdc0-5a63332a8e79', CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[WorkHistory] ([WorkHistoryId], [EmployeeId], [TeamId], [StartDate], [EndDate], [OccupationId], [Salary]) VALUES (N'cc158647-a0ce-489e-a9aa-bace54dfd91c', N'3cd84736-53e6-4b7c-beca-b9a6c10cf66e', N'729cac65-c0bb-4973-821f-4f76dffa8629', CAST(0xED380B00 AS Date), NULL, N'755070a0-bb6c-44bb-8284-1ebb0917db28', CAST(16500.00 AS Decimal(18, 2)))
INSERT [dbo].[WorkHistory] ([WorkHistoryId], [EmployeeId], [TeamId], [StartDate], [EndDate], [OccupationId], [Salary]) VALUES (N'ef5980cc-433a-4c85-86a3-bca7c6d776bb', N'3ea19bff-bc0e-4977-94f1-9192fb7a1fff', N'0832909b-ff84-415b-845c-567f96508cf9', CAST(0x43360B00 AS Date), NULL, N'633b38ad-4b46-4d57-99bb-04c98fc80f32', CAST(50000.00 AS Decimal(18, 2)))
INSERT [dbo].[WorkHistory] ([WorkHistoryId], [EmployeeId], [TeamId], [StartDate], [EndDate], [OccupationId], [Salary]) VALUES (N'383d052d-b424-4420-b66d-fe0c892988a6', N'367aef59-617d-4c40-aff7-1fef42fa2274', N'0832909b-ff84-415b-845c-567f96508cf9', CAST(0xCB320B00 AS Date), NULL, N'755070a0-bb6c-44bb-8284-1ebb0917db28', CAST(24000.00 AS Decimal(18, 2)))
ALTER TABLE [dbo].[AvailablePositions]  WITH CHECK ADD  CONSTRAINT [FK_AvailablePositions_People] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[AvailablePositions] CHECK CONSTRAINT [FK_AvailablePositions_People]
GO
ALTER TABLE [dbo].[AvailablePositions]  WITH CHECK ADD  CONSTRAINT [FK_Players_Positions_Positions] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Positions] ([PositionId])
GO
ALTER TABLE [dbo].[AvailablePositions] CHECK CONSTRAINT [FK_Players_Positions_Positions]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_People_People] FOREIGN KEY([ManagerID])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_People_People]
GO
ALTER TABLE [dbo].[Employees_Nationalities]  WITH CHECK ADD  CONSTRAINT [FK_People_Nationalities_People] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Employees_Nationalities] CHECK CONSTRAINT [FK_People_Nationalities_People]
GO
ALTER TABLE [dbo].[Employees_Nationalities]  WITH CHECK ADD  CONSTRAINT [FK_PlayersNationalities_Nationalities] FOREIGN KEY([NationalityId])
REFERENCES [dbo].[Nationalities] ([NationalityId])
GO
ALTER TABLE [dbo].[Employees_Nationalities] CHECK CONSTRAINT [FK_PlayersNationalities_Nationalities]
GO
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [FK_Games_Teams] FOREIGN KEY([HomeTeam])
REFERENCES [dbo].[Teams] ([TeamId])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_Games_Teams]
GO
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [FK_Games_Teams1] FOREIGN KEY([GuestTeam])
REFERENCES [dbo].[Teams] ([TeamId])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_Games_Teams1]
GO
ALTER TABLE [dbo].[SquadHistory]  WITH CHECK ADD  CONSTRAINT [FK_Squads_Games] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([GameId])
GO
ALTER TABLE [dbo].[SquadHistory] CHECK CONSTRAINT [FK_Squads_Games]
GO
ALTER TABLE [dbo].[SquadHistory]  WITH CHECK ADD  CONSTRAINT [FK_Squads_People] FOREIGN KEY([EmpoyeeID])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[SquadHistory] CHECK CONSTRAINT [FK_Squads_People]
GO
ALTER TABLE [dbo].[SquadHistory]  WITH CHECK ADD  CONSTRAINT [FK_Squads_Positions] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Positions] ([PositionId])
GO
ALTER TABLE [dbo].[SquadHistory] CHECK CONSTRAINT [FK_Squads_Positions]
GO
ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [FK_Teams_Nationalities] FOREIGN KEY([NationalityID])
REFERENCES [dbo].[Nationalities] ([NationalityId])
GO
ALTER TABLE [dbo].[Teams] CHECK CONSTRAINT [FK_Teams_Nationalities]
GO
ALTER TABLE [dbo].[WorkHistory]  WITH CHECK ADD  CONSTRAINT [FK_TeamHistory_People] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[WorkHistory] CHECK CONSTRAINT [FK_TeamHistory_People]
GO
ALTER TABLE [dbo].[WorkHistory]  WITH CHECK ADD  CONSTRAINT [FK_TeamHistory_Roles] FOREIGN KEY([OccupationId])
REFERENCES [dbo].[Occupations] ([OccupationId])
GO
ALTER TABLE [dbo].[WorkHistory] CHECK CONSTRAINT [FK_TeamHistory_Roles]
GO
ALTER TABLE [dbo].[WorkHistory]  WITH CHECK ADD  CONSTRAINT [FK_TeamHistory_Teams] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([TeamId])
GO
ALTER TABLE [dbo].[WorkHistory] CHECK CONSTRAINT [FK_TeamHistory_Teams]
GO
USE [master]
GO
ALTER DATABASE [WolfRaider] SET  READ_WRITE 
GO
