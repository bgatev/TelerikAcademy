USE [master]
GO
/****** Object:  Database [Test]    Script Date: 21.8.2014 г. 16:52:59 ******/
CREATE DATABASE [Test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Test', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Test.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Test_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Test_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Test] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Test] SET ARITHABORT OFF 
GO
ALTER DATABASE [Test] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Test] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Test] SET RECOVERY FULL 
GO
ALTER DATABASE [Test] SET  MULTI_USER 
GO
ALTER DATABASE [Test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Test] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Test', N'ON'
GO
USE [Test]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 21.8.2014 г. 16:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[address_text] [nvarchar](255) NOT NULL,
	[town_id] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continent]    Script Date: 21.8.2014 г. 16:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 21.8.2014 г. 16:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[continent_id] [int] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Courses]    Script Date: 21.8.2014 г. 16:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Courses_Students]    Script Date: 21.8.2014 г. 16:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses_Students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[courses_id] [int] NOT NULL,
	[students_id] [int] NOT NULL,
 CONSTRAINT [PK_Courses_Students] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Department]    Script Date: 21.8.2014 г. 16:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Department_Courses]    Script Date: 21.8.2014 г. 16:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department_Courses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[department_id] [int] NOT NULL,
	[courses_id] [int] NOT NULL,
 CONSTRAINT [PK_Department_Courses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Department_Professors]    Script Date: 21.8.2014 г. 16:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department_Professors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[department_id] [int] NOT NULL,
	[professors_id] [int] NOT NULL,
 CONSTRAINT [PK_Department_Professors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 21.8.2014 г. 16:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculty](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Faculty] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculty_Departments]    Script Date: 21.8.2014 г. 16:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculty_Departments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[faculty_id] [int] NOT NULL,
	[department_id] [int] NOT NULL,
 CONSTRAINT [PK_Faculty_Departments] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 21.8.2014 г. 16:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](255) NOT NULL,
	[last_name] [nvarchar](255) NOT NULL,
	[address_id] [int] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professors]    Script Date: 21.8.2014 г. 16:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[titles] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Professors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professors_Courses]    Script Date: 21.8.2014 г. 16:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professors_Courses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[professor_id] [int] NOT NULL,
	[courses_id] [int] NOT NULL,
 CONSTRAINT [PK_Professors_Courses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 21.8.2014 г. 16:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students_Faculty]    Script Date: 21.8.2014 г. 16:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students_Faculty](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[students_id] [int] NOT NULL,
	[faculty_id] [int] NOT NULL,
 CONSTRAINT [PK_Students_Faculty] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Town]    Script Date: 21.8.2014 г. 16:53:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Town](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[country_id] [int] NOT NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([id], [address_text], [town_id]) VALUES (1, N'36 Bulgaria Blvd', 1)
INSERT [dbo].[Address] ([id], [address_text], [town_id]) VALUES (2, N'12 Hristo Botev Str.', 2)
INSERT [dbo].[Address] ([id], [address_text], [town_id]) VALUES (3, N'22 Berlinner Str', 3)
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[Continent] ON 

INSERT [dbo].[Continent] ([id], [name]) VALUES (1, N'Europe')
INSERT [dbo].[Continent] ([id], [name]) VALUES (2, N'Asia')
INSERT [dbo].[Continent] ([id], [name]) VALUES (3, N'Australia')
SET IDENTITY_INSERT [dbo].[Continent] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (1, N'Bulgaria', 1)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (2, N'Russia', 2)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (3, N'Germany', 1)
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([id], [name]) VALUES (1, N'Excel 2013')
INSERT [dbo].[Courses] ([id], [name]) VALUES (2, N'C#')
INSERT [dbo].[Courses] ([id], [name]) VALUES (3, N'DSA')
INSERT [dbo].[Courses] ([id], [name]) VALUES (4, N'Networking')
SET IDENTITY_INSERT [dbo].[Courses] OFF
SET IDENTITY_INSERT [dbo].[Courses_Students] ON 

INSERT [dbo].[Courses_Students] ([id], [courses_id], [students_id]) VALUES (1, 1, 1)
INSERT [dbo].[Courses_Students] ([id], [courses_id], [students_id]) VALUES (2, 1, 2)
INSERT [dbo].[Courses_Students] ([id], [courses_id], [students_id]) VALUES (3, 2, 3)
INSERT [dbo].[Courses_Students] ([id], [courses_id], [students_id]) VALUES (4, 3, 3)
INSERT [dbo].[Courses_Students] ([id], [courses_id], [students_id]) VALUES (5, 4, 1)
INSERT [dbo].[Courses_Students] ([id], [courses_id], [students_id]) VALUES (6, 4, 2)
INSERT [dbo].[Courses_Students] ([id], [courses_id], [students_id]) VALUES (7, 4, 3)
SET IDENTITY_INSERT [dbo].[Courses_Students] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([id], [name]) VALUES (1, N'KST')
INSERT [dbo].[Department] ([id], [name]) VALUES (2, N'KTT')
INSERT [dbo].[Department] ([id], [name]) VALUES (3, N'Math')
INSERT [dbo].[Department] ([id], [name]) VALUES (4, N'IT')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Department_Courses] ON 

INSERT [dbo].[Department_Courses] ([id], [department_id], [courses_id]) VALUES (1, 1, 1)
INSERT [dbo].[Department_Courses] ([id], [department_id], [courses_id]) VALUES (2, 1, 2)
INSERT [dbo].[Department_Courses] ([id], [department_id], [courses_id]) VALUES (3, 2, 4)
INSERT [dbo].[Department_Courses] ([id], [department_id], [courses_id]) VALUES (4, 3, 3)
INSERT [dbo].[Department_Courses] ([id], [department_id], [courses_id]) VALUES (5, 4, 1)
INSERT [dbo].[Department_Courses] ([id], [department_id], [courses_id]) VALUES (6, 4, 2)
INSERT [dbo].[Department_Courses] ([id], [department_id], [courses_id]) VALUES (7, 4, 3)
INSERT [dbo].[Department_Courses] ([id], [department_id], [courses_id]) VALUES (8, 4, 4)
SET IDENTITY_INSERT [dbo].[Department_Courses] OFF
SET IDENTITY_INSERT [dbo].[Department_Professors] ON 

INSERT [dbo].[Department_Professors] ([id], [department_id], [professors_id]) VALUES (1, 1, 1)
INSERT [dbo].[Department_Professors] ([id], [department_id], [professors_id]) VALUES (2, 2, 1)
INSERT [dbo].[Department_Professors] ([id], [department_id], [professors_id]) VALUES (3, 3, 2)
INSERT [dbo].[Department_Professors] ([id], [department_id], [professors_id]) VALUES (4, 4, 2)
INSERT [dbo].[Department_Professors] ([id], [department_id], [professors_id]) VALUES (5, 4, 3)
SET IDENTITY_INSERT [dbo].[Department_Professors] OFF
SET IDENTITY_INSERT [dbo].[Faculty] ON 

INSERT [dbo].[Faculty] ([id], [name]) VALUES (1, N'FKTT')
INSERT [dbo].[Faculty] ([id], [name]) VALUES (2, N'FMI')
SET IDENTITY_INSERT [dbo].[Faculty] OFF
SET IDENTITY_INSERT [dbo].[Faculty_Departments] ON 

INSERT [dbo].[Faculty_Departments] ([id], [faculty_id], [department_id]) VALUES (1, 1, 1)
INSERT [dbo].[Faculty_Departments] ([id], [faculty_id], [department_id]) VALUES (2, 1, 2)
INSERT [dbo].[Faculty_Departments] ([id], [faculty_id], [department_id]) VALUES (3, 2, 3)
INSERT [dbo].[Faculty_Departments] ([id], [faculty_id], [department_id]) VALUES (4, 2, 4)
SET IDENTITY_INSERT [dbo].[Faculty_Departments] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([id], [first_name], [last_name], [address_id]) VALUES (1, N'Ivan', N'Ivanov', 1)
INSERT [dbo].[Person] ([id], [first_name], [last_name], [address_id]) VALUES (2, N'Pesho', N'Dragoev', 2)
INSERT [dbo].[Person] ([id], [first_name], [last_name], [address_id]) VALUES (3, N'Claus', N'Muller', 3)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Professors] ON 

INSERT [dbo].[Professors] ([id], [name], [titles]) VALUES (1, N'Ivan Ivanov', N'D-r')
INSERT [dbo].[Professors] ([id], [name], [titles]) VALUES (2, N'Pesho Ivanov', N'Master of Science')
INSERT [dbo].[Professors] ([id], [name], [titles]) VALUES (3, N'Kaka Mara', N'Assistant')
SET IDENTITY_INSERT [dbo].[Professors] OFF
SET IDENTITY_INSERT [dbo].[Professors_Courses] ON 

INSERT [dbo].[Professors_Courses] ([id], [professor_id], [courses_id]) VALUES (1, 1, 1)
INSERT [dbo].[Professors_Courses] ([id], [professor_id], [courses_id]) VALUES (2, 1, 3)
INSERT [dbo].[Professors_Courses] ([id], [professor_id], [courses_id]) VALUES (3, 2, 3)
INSERT [dbo].[Professors_Courses] ([id], [professor_id], [courses_id]) VALUES (4, 3, 2)
INSERT [dbo].[Professors_Courses] ([id], [professor_id], [courses_id]) VALUES (5, 3, 4)
SET IDENTITY_INSERT [dbo].[Professors_Courses] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([id], [name]) VALUES (1, N'Gosho Kelesha')
INSERT [dbo].[Students] ([id], [name]) VALUES (2, N'Minka Dobreva')
INSERT [dbo].[Students] ([id], [name]) VALUES (3, N'Ivan Golemanov')
SET IDENTITY_INSERT [dbo].[Students] OFF
SET IDENTITY_INSERT [dbo].[Students_Faculty] ON 

INSERT [dbo].[Students_Faculty] ([id], [students_id], [faculty_id]) VALUES (1, 1, 1)
INSERT [dbo].[Students_Faculty] ([id], [students_id], [faculty_id]) VALUES (2, 2, 1)
INSERT [dbo].[Students_Faculty] ([id], [students_id], [faculty_id]) VALUES (3, 3, 2)
SET IDENTITY_INSERT [dbo].[Students_Faculty] OFF
SET IDENTITY_INSERT [dbo].[Town] ON 

INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (1, N'Sofia', 1)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (2, N'Plovdiv', 1)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (3, N'Berlin', 3)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (4, N'Moscow', 2)
SET IDENTITY_INSERT [dbo].[Town] OFF
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Town] FOREIGN KEY([town_id])
REFERENCES [dbo].[Town] ([id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Town]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Continent] FOREIGN KEY([continent_id])
REFERENCES [dbo].[Continent] ([id])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Continent]
GO
ALTER TABLE [dbo].[Courses_Students]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Students_Courses] FOREIGN KEY([courses_id])
REFERENCES [dbo].[Courses] ([id])
GO
ALTER TABLE [dbo].[Courses_Students] CHECK CONSTRAINT [FK_Courses_Students_Courses]
GO
ALTER TABLE [dbo].[Courses_Students]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Students_Students] FOREIGN KEY([students_id])
REFERENCES [dbo].[Students] ([id])
GO
ALTER TABLE [dbo].[Courses_Students] CHECK CONSTRAINT [FK_Courses_Students_Students]
GO
ALTER TABLE [dbo].[Department_Courses]  WITH CHECK ADD  CONSTRAINT [FK_Department_Courses_Courses] FOREIGN KEY([courses_id])
REFERENCES [dbo].[Courses] ([id])
GO
ALTER TABLE [dbo].[Department_Courses] CHECK CONSTRAINT [FK_Department_Courses_Courses]
GO
ALTER TABLE [dbo].[Department_Courses]  WITH CHECK ADD  CONSTRAINT [FK_Department_Courses_Department] FOREIGN KEY([department_id])
REFERENCES [dbo].[Department] ([id])
GO
ALTER TABLE [dbo].[Department_Courses] CHECK CONSTRAINT [FK_Department_Courses_Department]
GO
ALTER TABLE [dbo].[Department_Professors]  WITH CHECK ADD  CONSTRAINT [FK_Department_Professors_Department] FOREIGN KEY([department_id])
REFERENCES [dbo].[Department] ([id])
GO
ALTER TABLE [dbo].[Department_Professors] CHECK CONSTRAINT [FK_Department_Professors_Department]
GO
ALTER TABLE [dbo].[Department_Professors]  WITH CHECK ADD  CONSTRAINT [FK_Department_Professors_Professors] FOREIGN KEY([professors_id])
REFERENCES [dbo].[Professors] ([id])
GO
ALTER TABLE [dbo].[Department_Professors] CHECK CONSTRAINT [FK_Department_Professors_Professors]
GO
ALTER TABLE [dbo].[Faculty_Departments]  WITH CHECK ADD  CONSTRAINT [FK_Faculty_Departments_Department] FOREIGN KEY([department_id])
REFERENCES [dbo].[Department] ([id])
GO
ALTER TABLE [dbo].[Faculty_Departments] CHECK CONSTRAINT [FK_Faculty_Departments_Department]
GO
ALTER TABLE [dbo].[Faculty_Departments]  WITH CHECK ADD  CONSTRAINT [FK_Faculty_Departments_Faculty] FOREIGN KEY([faculty_id])
REFERENCES [dbo].[Faculty] ([id])
GO
ALTER TABLE [dbo].[Faculty_Departments] CHECK CONSTRAINT [FK_Faculty_Departments_Faculty]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Address] FOREIGN KEY([address_id])
REFERENCES [dbo].[Address] ([id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Address]
GO
ALTER TABLE [dbo].[Professors_Courses]  WITH CHECK ADD  CONSTRAINT [FK_Professors_Courses_Courses] FOREIGN KEY([courses_id])
REFERENCES [dbo].[Courses] ([id])
GO
ALTER TABLE [dbo].[Professors_Courses] CHECK CONSTRAINT [FK_Professors_Courses_Courses]
GO
ALTER TABLE [dbo].[Professors_Courses]  WITH CHECK ADD  CONSTRAINT [FK_Professors_Courses_Professors] FOREIGN KEY([professor_id])
REFERENCES [dbo].[Professors] ([id])
GO
ALTER TABLE [dbo].[Professors_Courses] CHECK CONSTRAINT [FK_Professors_Courses_Professors]
GO
ALTER TABLE [dbo].[Students_Faculty]  WITH CHECK ADD  CONSTRAINT [FK_Students_Faculty_Faculty] FOREIGN KEY([faculty_id])
REFERENCES [dbo].[Faculty] ([id])
GO
ALTER TABLE [dbo].[Students_Faculty] CHECK CONSTRAINT [FK_Students_Faculty_Faculty]
GO
ALTER TABLE [dbo].[Students_Faculty]  WITH CHECK ADD  CONSTRAINT [FK_Students_Faculty_Students] FOREIGN KEY([students_id])
REFERENCES [dbo].[Students] ([id])
GO
ALTER TABLE [dbo].[Students_Faculty] CHECK CONSTRAINT [FK_Students_Faculty_Students]
GO
ALTER TABLE [dbo].[Town]  WITH CHECK ADD  CONSTRAINT [FK_Town_Country] FOREIGN KEY([country_id])
REFERENCES [dbo].[Country] ([id])
GO
ALTER TABLE [dbo].[Town] CHECK CONSTRAINT [FK_Town_Country]
GO
USE [master]
GO
ALTER DATABASE [Test] SET  READ_WRITE 
GO
