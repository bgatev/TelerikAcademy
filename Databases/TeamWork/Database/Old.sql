USE [master]
GO
/****** Object:  Database [WolfRaider_Championship]    Script Date: 28.8.2014 г. 21:54:49 ******/
CREATE DATABASE [WolfRaider_Championship]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WolfRaider_Championship', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\WolfRaider_Championship.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WolfRaider_Championship_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\WolfRaider_Championship_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WolfRaider_Championship] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WolfRaider_Championship].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WolfRaider_Championship] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WolfRaider_Championship] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WolfRaider_Championship] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WolfRaider_Championship] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WolfRaider_Championship] SET ARITHABORT OFF 
GO
ALTER DATABASE [WolfRaider_Championship] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WolfRaider_Championship] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [WolfRaider_Championship] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WolfRaider_Championship] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WolfRaider_Championship] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WolfRaider_Championship] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WolfRaider_Championship] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WolfRaider_Championship] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WolfRaider_Championship] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WolfRaider_Championship] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WolfRaider_Championship] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WolfRaider_Championship] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WolfRaider_Championship] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WolfRaider_Championship] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WolfRaider_Championship] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WolfRaider_Championship] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WolfRaider_Championship] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WolfRaider_Championship] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WolfRaider_Championship] SET RECOVERY FULL 
GO
ALTER DATABASE [WolfRaider_Championship] SET  MULTI_USER 
GO
ALTER DATABASE [WolfRaider_Championship] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WolfRaider_Championship] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WolfRaider_Championship] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WolfRaider_Championship] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'WolfRaider_Championship', N'ON'
GO
USE [WolfRaider_Championship]
GO
/****** Object:  Table [dbo].[Matches]    Script Date: 28.8.2014 г. 21:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matches](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[HomeTeam] [int] NOT NULL,
	[GuestTeam] [int] NOT NULL,
	[Result] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Matches] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Numbers]    Script Date: 28.8.2014 г. 21:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Numbers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
 CONSTRAINT [PK_Numbers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Players]    Script Date: 28.8.2014 г. 21:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Players](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[PlayerNumber] [int] NOT NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Players_Positions]    Script Date: 28.8.2014 г. 21:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Players_Positions](
	[PlayerID] [int] NOT NULL,
	[PositionID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Positions]    Script Date: 28.8.2014 г. 21:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teams]    Script Date: 28.8.2014 г. 21:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Coach] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TeamsPlayers]    Script Date: 28.8.2014 г. 21:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamsPlayers](
	[TeamID] [int] NOT NULL,
	[PlayerID] [int] NOT NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Matches] ON 

INSERT [dbo].[Matches] ([id], [HomeTeam], [GuestTeam], [Result]) VALUES (1, 1, 2, N'2:0')
SET IDENTITY_INSERT [dbo].[Matches] OFF
SET IDENTITY_INSERT [dbo].[Numbers] ON 

INSERT [dbo].[Numbers] ([id], [Number]) VALUES (1, 1)
INSERT [dbo].[Numbers] ([id], [Number]) VALUES (2, 2)
INSERT [dbo].[Numbers] ([id], [Number]) VALUES (3, 3)
INSERT [dbo].[Numbers] ([id], [Number]) VALUES (4, 4)
INSERT [dbo].[Numbers] ([id], [Number]) VALUES (5, 5)
INSERT [dbo].[Numbers] ([id], [Number]) VALUES (6, 6)
INSERT [dbo].[Numbers] ([id], [Number]) VALUES (7, 7)
INSERT [dbo].[Numbers] ([id], [Number]) VALUES (8, 8)
INSERT [dbo].[Numbers] ([id], [Number]) VALUES (9, 9)
INSERT [dbo].[Numbers] ([id], [Number]) VALUES (10, 10)
INSERT [dbo].[Numbers] ([id], [Number]) VALUES (11, 11)
INSERT [dbo].[Numbers] ([id], [Number]) VALUES (12, 12)
INSERT [dbo].[Numbers] ([id], [Number]) VALUES (13, 13)
INSERT [dbo].[Numbers] ([id], [Number]) VALUES (14, 14)
INSERT [dbo].[Numbers] ([id], [Number]) VALUES (15, 15)
INSERT [dbo].[Numbers] ([id], [Number]) VALUES (16, 16)
SET IDENTITY_INSERT [dbo].[Numbers] OFF
SET IDENTITY_INSERT [dbo].[Players] ON 

INSERT [dbo].[Players] ([id], [FirstName], [LastName], [PlayerNumber]) VALUES (1, N'Borislav', N'Mihailov', 1)
INSERT [dbo].[Players] ([id], [FirstName], [LastName], [PlayerNumber]) VALUES (3, N'Emil', N'Kremenliev', 2)
INSERT [dbo].[Players] ([id], [FirstName], [LastName], [PlayerNumber]) VALUES (4, N'Trifon', N'Ivanov', 3)
INSERT [dbo].[Players] ([id], [FirstName], [LastName], [PlayerNumber]) VALUES (5, N'Canko', N'Cvetanov', 4)
INSERT [dbo].[Players] ([id], [FirstName], [LastName], [PlayerNumber]) VALUES (6, N'Petar', N'Hubchev', 5)
INSERT [dbo].[Players] ([id], [FirstName], [LastName], [PlayerNumber]) VALUES (7, N'Zlatko', N'Iankov', 6)
INSERT [dbo].[Players] ([id], [FirstName], [LastName], [PlayerNumber]) VALUES (8, N'Emil', N'Kostadinov', 7)
INSERT [dbo].[Players] ([id], [FirstName], [LastName], [PlayerNumber]) VALUES (9, N'Hristo', N'Stoichkov', 8)
INSERT [dbo].[Players] ([id], [FirstName], [LastName], [PlayerNumber]) VALUES (10, N'Jordan', N'Lechkov', 9)
INSERT [dbo].[Players] ([id], [FirstName], [LastName], [PlayerNumber]) VALUES (11, N'Nasko', N'Sirakov', 10)
INSERT [dbo].[Players] ([id], [FirstName], [LastName], [PlayerNumber]) VALUES (12, N'Daniel', N'Borimirov', 11)
INSERT [dbo].[Players] ([id], [FirstName], [LastName], [PlayerNumber]) VALUES (15, N'Sergio', N'Goycochea', 1)
SET IDENTITY_INSERT [dbo].[Players] OFF
INSERT [dbo].[Players_Positions] ([PlayerID], [PositionID]) VALUES (1, 1)
INSERT [dbo].[Players_Positions] ([PlayerID], [PositionID]) VALUES (3, 3)
INSERT [dbo].[Players_Positions] ([PlayerID], [PositionID]) VALUES (4, 2)
INSERT [dbo].[Players_Positions] ([PlayerID], [PositionID]) VALUES (4, 3)
INSERT [dbo].[Players_Positions] ([PlayerID], [PositionID]) VALUES (5, 4)
INSERT [dbo].[Players_Positions] ([PlayerID], [PositionID]) VALUES (6, 5)
INSERT [dbo].[Players_Positions] ([PlayerID], [PositionID]) VALUES (7, 10)
INSERT [dbo].[Players_Positions] ([PlayerID], [PositionID]) VALUES (8, 13)
INSERT [dbo].[Players_Positions] ([PlayerID], [PositionID]) VALUES (9, 13)
INSERT [dbo].[Players_Positions] ([PlayerID], [PositionID]) VALUES (10, 9)
INSERT [dbo].[Players_Positions] ([PlayerID], [PositionID]) VALUES (11, 14)
INSERT [dbo].[Players_Positions] ([PlayerID], [PositionID]) VALUES (12, 12)
INSERT [dbo].[Players_Positions] ([PlayerID], [PositionID]) VALUES (15, 1)
SET IDENTITY_INSERT [dbo].[Positions] ON 

INSERT [dbo].[Positions] ([id], [Type]) VALUES (1, N'Goalkeeper')
INSERT [dbo].[Positions] ([id], [Type]) VALUES (2, N'Sweeper')
INSERT [dbo].[Positions] ([id], [Type]) VALUES (3, N'Center Back')
INSERT [dbo].[Positions] ([id], [Type]) VALUES (4, N'Left Back')
INSERT [dbo].[Positions] ([id], [Type]) VALUES (5, N'Right Back')
INSERT [dbo].[Positions] ([id], [Type]) VALUES (6, N'Left Wing Back')
INSERT [dbo].[Positions] ([id], [Type]) VALUES (7, N'Right Wing Back')
INSERT [dbo].[Positions] ([id], [Type]) VALUES (8, N'Defending Midfielder')
INSERT [dbo].[Positions] ([id], [Type]) VALUES (9, N'Central Midfielder')
INSERT [dbo].[Positions] ([id], [Type]) VALUES (10, N'Attacking Midfielder')
INSERT [dbo].[Positions] ([id], [Type]) VALUES (11, N'Left Wing')
INSERT [dbo].[Positions] ([id], [Type]) VALUES (12, N'Right Wing')
INSERT [dbo].[Positions] ([id], [Type]) VALUES (13, N'Withdrawn Forwarder')
INSERT [dbo].[Positions] ([id], [Type]) VALUES (14, N'Center Forwarder')
SET IDENTITY_INSERT [dbo].[Positions] OFF
SET IDENTITY_INSERT [dbo].[Teams] ON 

INSERT [dbo].[Teams] ([id], [Name], [Coach]) VALUES (1, N'Bulgaria', N'Dimitar Penev')
INSERT [dbo].[Teams] ([id], [Name], [Coach]) VALUES (2, N'Argentina', N'Alfio Basile')
SET IDENTITY_INSERT [dbo].[Teams] OFF
INSERT [dbo].[TeamsPlayers] ([TeamID], [PlayerID]) VALUES (1, 1)
INSERT [dbo].[TeamsPlayers] ([TeamID], [PlayerID]) VALUES (1, 3)
INSERT [dbo].[TeamsPlayers] ([TeamID], [PlayerID]) VALUES (1, 4)
INSERT [dbo].[TeamsPlayers] ([TeamID], [PlayerID]) VALUES (1, 5)
INSERT [dbo].[TeamsPlayers] ([TeamID], [PlayerID]) VALUES (1, 6)
INSERT [dbo].[TeamsPlayers] ([TeamID], [PlayerID]) VALUES (1, 7)
INSERT [dbo].[TeamsPlayers] ([TeamID], [PlayerID]) VALUES (1, 8)
INSERT [dbo].[TeamsPlayers] ([TeamID], [PlayerID]) VALUES (1, 9)
INSERT [dbo].[TeamsPlayers] ([TeamID], [PlayerID]) VALUES (1, 10)
INSERT [dbo].[TeamsPlayers] ([TeamID], [PlayerID]) VALUES (1, 11)
INSERT [dbo].[TeamsPlayers] ([TeamID], [PlayerID]) VALUES (1, 12)
INSERT [dbo].[TeamsPlayers] ([TeamID], [PlayerID]) VALUES (2, 15)
ALTER TABLE [dbo].[Matches]  WITH CHECK ADD  CONSTRAINT [FK_Matches_Teams] FOREIGN KEY([HomeTeam])
REFERENCES [dbo].[Teams] ([id])
GO
ALTER TABLE [dbo].[Matches] CHECK CONSTRAINT [FK_Matches_Teams]
GO
ALTER TABLE [dbo].[Matches]  WITH CHECK ADD  CONSTRAINT [FK_Matches_Teams1] FOREIGN KEY([GuestTeam])
REFERENCES [dbo].[Teams] ([id])
GO
ALTER TABLE [dbo].[Matches] CHECK CONSTRAINT [FK_Matches_Teams1]
GO
ALTER TABLE [dbo].[Players]  WITH CHECK ADD  CONSTRAINT [FK_Players_Numbers] FOREIGN KEY([id])
REFERENCES [dbo].[Numbers] ([id])
GO
ALTER TABLE [dbo].[Players] CHECK CONSTRAINT [FK_Players_Numbers]
GO
ALTER TABLE [dbo].[Players_Positions]  WITH CHECK ADD  CONSTRAINT [FK_Players_Positions_Players] FOREIGN KEY([PlayerID])
REFERENCES [dbo].[Players] ([id])
GO
ALTER TABLE [dbo].[Players_Positions] CHECK CONSTRAINT [FK_Players_Positions_Players]
GO
ALTER TABLE [dbo].[Players_Positions]  WITH CHECK ADD  CONSTRAINT [FK_Players_Positions_Positions] FOREIGN KEY([PositionID])
REFERENCES [dbo].[Positions] ([id])
GO
ALTER TABLE [dbo].[Players_Positions] CHECK CONSTRAINT [FK_Players_Positions_Positions]
GO
ALTER TABLE [dbo].[TeamsPlayers]  WITH CHECK ADD  CONSTRAINT [FK_TeamsPlayers_Players] FOREIGN KEY([PlayerID])
REFERENCES [dbo].[Players] ([id])
GO
ALTER TABLE [dbo].[TeamsPlayers] CHECK CONSTRAINT [FK_TeamsPlayers_Players]
GO
ALTER TABLE [dbo].[TeamsPlayers]  WITH CHECK ADD  CONSTRAINT [FK_TeamsPlayers_Teams] FOREIGN KEY([TeamID])
REFERENCES [dbo].[Teams] ([id])
GO
ALTER TABLE [dbo].[TeamsPlayers] CHECK CONSTRAINT [FK_TeamsPlayers_Teams]
GO
USE [master]
GO
ALTER DATABASE [WolfRaider_Championship] SET  READ_WRITE 
GO
