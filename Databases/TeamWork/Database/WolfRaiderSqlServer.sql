USE [master]
GO
/****** Object:  Database [WolfRaider]    Script Date: 9/3/2014 6:40:06 PM ******/
CREATE DATABASE [WolfRaider]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WolfRaiderTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\WolfRaiderTest.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WolfRaiderTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\WolfRaiderTest_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WolfRaider] SET COMPATIBILITY_LEVEL = 120
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
ALTER DATABASE [WolfRaider] SET AUTO_CLOSE ON 
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
ALTER DATABASE [WolfRaider] SET  ENABLE_BROKER 
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
ALTER DATABASE [WolfRaider] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [WolfRaider] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WolfRaider] SET RECOVERY SIMPLE 
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
ALTER DATABASE [WolfRaider] SET DELAYED_DURABILITY = DISABLED 
GO
USE [WolfRaider]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 9/3/2014 6:40:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 9/3/2014 6:40:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[ManagerId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Games]    Script Date: 9/3/2014 6:40:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Games](
	[GameId] [uniqueidentifier] NOT NULL,
	[HomeTeamId] [uniqueidentifier] NOT NULL,
	[GuestTeamId] [uniqueidentifier] NOT NULL,
	[PlayedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Games] PRIMARY KEY CLUSTERED 
(
	[GameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nationalities]    Script Date: 9/3/2014 6:40:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nationalities](
	[NationalityId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Nationalities] PRIMARY KEY CLUSTERED 
(
	[NationalityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NationalityEmployees]    Script Date: 9/3/2014 6:40:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NationalityEmployees](
	[Nationality_NationalityId] [uniqueidentifier] NOT NULL,
	[Employee_EmployeeId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.NationalityEmployees] PRIMARY KEY CLUSTERED 
(
	[Nationality_NationalityId] ASC,
	[Employee_EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Occupations]    Script Date: 9/3/2014 6:40:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Occupations](
	[OccupationId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Occupations] PRIMARY KEY CLUSTERED 
(
	[OccupationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PositionEmployees]    Script Date: 9/3/2014 6:40:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PositionEmployees](
	[Position_PositionId] [uniqueidentifier] NOT NULL,
	[Employee_EmployeeId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.PositionEmployees] PRIMARY KEY CLUSTERED 
(
	[Position_PositionId] ASC,
	[Employee_EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Positions]    Script Date: 9/3/2014 6:40:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[PositionId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Positions] PRIMARY KEY CLUSTERED 
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SquadHistory]    Script Date: 9/3/2014 6:40:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SquadHistory](
	[SquadHistoryId] [uniqueidentifier] NOT NULL,
	[EmpoyeeId] [uniqueidentifier] NOT NULL,
	[Goals] [int] NOT NULL,
	[RedCards] [int] NOT NULL,
	[YellowCards] [int] NOT NULL,
	[GameId] [uniqueidentifier] NOT NULL,
	[PositionId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.SquadHistory] PRIMARY KEY CLUSTERED 
(
	[SquadHistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teams]    Script Date: 9/3/2014 6:40:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[TeamId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[NationalityId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Teams] PRIMARY KEY CLUSTERED 
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkHistory]    Script Date: 9/3/2014 6:40:06 PM ******/
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
	[Salary] [decimal](18, 2) NOT NULL,
	[OccupationId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.WorkHistory] PRIMARY KEY CLUSTERED 
(
	[WorkHistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_ManagerId]    Script Date: 9/3/2014 6:40:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_ManagerId] ON [dbo].[Employees]
(
	[ManagerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GuestTeamId]    Script Date: 9/3/2014 6:40:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_GuestTeamId] ON [dbo].[Games]
(
	[GuestTeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HomeTeamId]    Script Date: 9/3/2014 6:40:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_HomeTeamId] ON [dbo].[Games]
(
	[HomeTeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employee_EmployeeId]    Script Date: 9/3/2014 6:40:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Employee_EmployeeId] ON [dbo].[NationalityEmployees]
(
	[Employee_EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Nationality_NationalityId]    Script Date: 9/3/2014 6:40:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Nationality_NationalityId] ON [dbo].[NationalityEmployees]
(
	[Nationality_NationalityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employee_EmployeeId]    Script Date: 9/3/2014 6:40:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Employee_EmployeeId] ON [dbo].[PositionEmployees]
(
	[Employee_EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Position_PositionId]    Script Date: 9/3/2014 6:40:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Position_PositionId] ON [dbo].[PositionEmployees]
(
	[Position_PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpoyeeId]    Script Date: 9/3/2014 6:40:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmpoyeeId] ON [dbo].[SquadHistory]
(
	[EmpoyeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GameId]    Script Date: 9/3/2014 6:40:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_GameId] ON [dbo].[SquadHistory]
(
	[GameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PositionId]    Script Date: 9/3/2014 6:40:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_PositionId] ON [dbo].[SquadHistory]
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_NationalityId]    Script Date: 9/3/2014 6:40:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_NationalityId] ON [dbo].[Teams]
(
	[NationalityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeId]    Script Date: 9/3/2014 6:40:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeId] ON [dbo].[WorkHistory]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OccupationId]    Script Date: 9/3/2014 6:40:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_OccupationId] ON [dbo].[WorkHistory]
(
	[OccupationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TeamId]    Script Date: 9/3/2014 6:40:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_TeamId] ON [dbo].[WorkHistory]
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Employees_dbo.Employees_ManagerId] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_dbo.Employees_dbo.Employees_ManagerId]
GO
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Games_dbo.Teams_GuestTeamId] FOREIGN KEY([GuestTeamId])
REFERENCES [dbo].[Teams] ([TeamId])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_dbo.Games_dbo.Teams_GuestTeamId]
GO
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Games_dbo.Teams_HomeTeamId] FOREIGN KEY([HomeTeamId])
REFERENCES [dbo].[Teams] ([TeamId])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_dbo.Games_dbo.Teams_HomeTeamId]
GO
ALTER TABLE [dbo].[NationalityEmployees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.NationalityEmployees_dbo.Employees_Employee_EmployeeId] FOREIGN KEY([Employee_EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NationalityEmployees] CHECK CONSTRAINT [FK_dbo.NationalityEmployees_dbo.Employees_Employee_EmployeeId]
GO
ALTER TABLE [dbo].[NationalityEmployees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.NationalityEmployees_dbo.Nationalities_Nationality_NationalityId] FOREIGN KEY([Nationality_NationalityId])
REFERENCES [dbo].[Nationalities] ([NationalityId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NationalityEmployees] CHECK CONSTRAINT [FK_dbo.NationalityEmployees_dbo.Nationalities_Nationality_NationalityId]
GO
ALTER TABLE [dbo].[PositionEmployees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PositionEmployees_dbo.Employees_Employee_EmployeeId] FOREIGN KEY([Employee_EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PositionEmployees] CHECK CONSTRAINT [FK_dbo.PositionEmployees_dbo.Employees_Employee_EmployeeId]
GO
ALTER TABLE [dbo].[PositionEmployees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PositionEmployees_dbo.Positions_Position_PositionId] FOREIGN KEY([Position_PositionId])
REFERENCES [dbo].[Positions] ([PositionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PositionEmployees] CHECK CONSTRAINT [FK_dbo.PositionEmployees_dbo.Positions_Position_PositionId]
GO
ALTER TABLE [dbo].[SquadHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SquadHistory_dbo.Employees_EmpoyeeId] FOREIGN KEY([EmpoyeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[SquadHistory] CHECK CONSTRAINT [FK_dbo.SquadHistory_dbo.Employees_EmpoyeeId]
GO
ALTER TABLE [dbo].[SquadHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SquadHistory_dbo.Games_GameId] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([GameId])
GO
ALTER TABLE [dbo].[SquadHistory] CHECK CONSTRAINT [FK_dbo.SquadHistory_dbo.Games_GameId]
GO
ALTER TABLE [dbo].[SquadHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SquadHistory_dbo.Positions_PositionId] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Positions] ([PositionId])
GO
ALTER TABLE [dbo].[SquadHistory] CHECK CONSTRAINT [FK_dbo.SquadHistory_dbo.Positions_PositionId]
GO
ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Teams_dbo.Nationalities_NationalityId] FOREIGN KEY([NationalityId])
REFERENCES [dbo].[Nationalities] ([NationalityId])
GO
ALTER TABLE [dbo].[Teams] CHECK CONSTRAINT [FK_dbo.Teams_dbo.Nationalities_NationalityId]
GO
ALTER TABLE [dbo].[WorkHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.WorkHistory_dbo.Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[WorkHistory] CHECK CONSTRAINT [FK_dbo.WorkHistory_dbo.Employees_EmployeeId]
GO
ALTER TABLE [dbo].[WorkHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.WorkHistory_dbo.Occupations_OccupationId] FOREIGN KEY([OccupationId])
REFERENCES [dbo].[Occupations] ([OccupationId])
GO
ALTER TABLE [dbo].[WorkHistory] CHECK CONSTRAINT [FK_dbo.WorkHistory_dbo.Occupations_OccupationId]
GO
ALTER TABLE [dbo].[WorkHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.WorkHistory_dbo.Teams_TeamId] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([TeamId])
GO
ALTER TABLE [dbo].[WorkHistory] CHECK CONSTRAINT [FK_dbo.WorkHistory_dbo.Teams_TeamId]
GO
USE [master]
GO
ALTER DATABASE [WolfRaider] SET  READ_WRITE 
GO
