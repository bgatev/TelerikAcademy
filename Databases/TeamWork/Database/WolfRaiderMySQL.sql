CREATE DATABASE  IF NOT EXISTS `wolfraider` /*!40100 DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci */;
USE `WolfRaider`;
-- MySQL dump 10.13  Distrib 5.6.17, for Win32 (x86)
--
-- Host: 127.0.0.1    Database: WolfRaider
-- ------------------------------------------------------
-- Server version	5.5.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Employees`
--

DROP TABLE IF EXISTS `Employees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Employees` (
  `EmployeeId` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `FirstName` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `LastName` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Age` int(11) NOT NULL,
  `ManagerId` varchar(64) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`EmployeeId`),
  UNIQUE KEY `EmployeeId` (`EmployeeId`),
  KEY `IX_ManagerId` (`ManagerId`),
  CONSTRAINT `FK_dbo.Employees_dbo.Employees_ManagerId` FOREIGN KEY (`ManagerId`) REFERENCES `Employees` (`EmployeeId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Employees`
--

LOCK TABLES `Employees` WRITE;
/*!40000 ALTER TABLE `Employees` DISABLE KEYS */;
INSERT INTO `Employees` VALUES ('652d53c9-082f-48c8-91b7-61a41f20f60e','Pavel','Hristov',36,'652d53c9-082f-48c8-91b7-61a41f20f60e'),('6e8887c5-e3d4-46e4-b9e2-87813b8cf9d7','Ivan','Ivanov',36,'b513fce6-1879-45fd-a1d5-cbb91b0baa1e'),('7afc2ee9-7de6-4444-ba76-6660511bd1e0','Ivan','Ivanov',36,'7afc2ee9-7de6-4444-ba76-6660511bd1e0'),('879b3edb-89e3-4acd-9198-59dfd4b362bb','Pavel','Hristov',36,NULL),('b513fce6-1879-45fd-a1d5-cbb91b0baa1e','Pavel','Hristov',36,'b513fce6-1879-45fd-a1d5-cbb91b0baa1e'),('befdaf46-66cb-4ffa-ac0a-dfaf9e981559','Ivan','Ivanov',36,'b513fce6-1879-45fd-a1d5-cbb91b0baa1e'),('bf396184-f614-4269-8d39-445bc6582771','Pavel','Hristov',36,NULL);
/*!40000 ALTER TABLE `Employees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Games`
--

DROP TABLE IF EXISTS `Games`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Games` (
  `GameId` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `HomeTeamId` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `GuestTeamId` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `PlayedOn` datetime NOT NULL,
  PRIMARY KEY (`GameId`),
  UNIQUE KEY `GameId` (`GameId`),
  UNIQUE KEY `HomeTeamId` (`HomeTeamId`),
  UNIQUE KEY `GuestTeamId` (`GuestTeamId`),
  KEY `IX_HomeTeamId` (`HomeTeamId`),
  KEY `IX_GuestTeamId` (`GuestTeamId`),
  CONSTRAINT `FK_dbo.Games_dbo.Teams_GuestTeamId` FOREIGN KEY (`GuestTeamId`) REFERENCES `Teams` (`TeamId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_dbo.Games_dbo.Teams_HomeTeamId` FOREIGN KEY (`HomeTeamId`) REFERENCES `Teams` (`TeamId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Games`
--

LOCK TABLES `Games` WRITE;
/*!40000 ALTER TABLE `Games` DISABLE KEYS */;
/*!40000 ALTER TABLE `Games` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Nationalities`
--

DROP TABLE IF EXISTS `Nationalities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Nationalities` (
  `NationalityId` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `Name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`NationalityId`),
  UNIQUE KEY `NationalityId` (`NationalityId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Nationalities`
--

LOCK TABLES `Nationalities` WRITE;
/*!40000 ALTER TABLE `Nationalities` DISABLE KEYS */;
/*!40000 ALTER TABLE `Nationalities` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `NationalityEmployees`
--

DROP TABLE IF EXISTS `NationalityEmployees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `NationalityEmployees` (
  `Nationality_NationalityId` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `Employee_EmployeeId` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`Nationality_NationalityId`,`Employee_EmployeeId`),
  UNIQUE KEY `Nationality_NationalityId` (`Nationality_NationalityId`),
  UNIQUE KEY `Employee_EmployeeId` (`Employee_EmployeeId`),
  KEY `IX_Nationality_NationalityId` (`Nationality_NationalityId`),
  KEY `IX_Employee_EmployeeId` (`Employee_EmployeeId`),
  CONSTRAINT `FK_dbo.NationalityEmployees_dbo.Employees_Employee_EmployeeId` FOREIGN KEY (`Employee_EmployeeId`) REFERENCES `Employees` (`EmployeeId`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `FK_dbo.NationalityEmployees_dbo.Nationalities_Nationality_Nati1` FOREIGN KEY (`Nationality_NationalityId`) REFERENCES `Nationalities` (`NationalityId`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `NationalityEmployees`
--

LOCK TABLES `NationalityEmployees` WRITE;
/*!40000 ALTER TABLE `NationalityEmployees` DISABLE KEYS */;
/*!40000 ALTER TABLE `NationalityEmployees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Occupations`
--

DROP TABLE IF EXISTS `Occupations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Occupations` (
  `OccupationId` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `Name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`OccupationId`),
  UNIQUE KEY `OccupationId` (`OccupationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Occupations`
--

LOCK TABLES `Occupations` WRITE;
/*!40000 ALTER TABLE `Occupations` DISABLE KEYS */;
/*!40000 ALTER TABLE `Occupations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `PositionEmployees`
--

DROP TABLE IF EXISTS `PositionEmployees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `PositionEmployees` (
  `Position_PositionId` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `Employee_EmployeeId` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`Position_PositionId`,`Employee_EmployeeId`),
  UNIQUE KEY `Position_PositionId` (`Position_PositionId`),
  UNIQUE KEY `Employee_EmployeeId` (`Employee_EmployeeId`),
  KEY `IX_Position_PositionId` (`Position_PositionId`),
  KEY `IX_Employee_EmployeeId` (`Employee_EmployeeId`),
  CONSTRAINT `FK_dbo.PositionEmployees_dbo.Employees_Employee_EmployeeId` FOREIGN KEY (`Employee_EmployeeId`) REFERENCES `Employees` (`EmployeeId`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `FK_dbo.PositionEmployees_dbo.Positions_Position_PositionId` FOREIGN KEY (`Position_PositionId`) REFERENCES `Positions` (`PositionId`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `PositionEmployees`
--

LOCK TABLES `PositionEmployees` WRITE;
/*!40000 ALTER TABLE `PositionEmployees` DISABLE KEYS */;
/*!40000 ALTER TABLE `PositionEmployees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Positions`
--

DROP TABLE IF EXISTS `Positions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Positions` (
  `PositionId` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `Name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`PositionId`),
  UNIQUE KEY `PositionId` (`PositionId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Positions`
--

LOCK TABLES `Positions` WRITE;
/*!40000 ALTER TABLE `Positions` DISABLE KEYS */;
/*!40000 ALTER TABLE `Positions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `SquadHistory`
--

DROP TABLE IF EXISTS `SquadHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `SquadHistory` (
  `SquadHistoryId` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `EmpoyeeId` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `Goals` int(11) NOT NULL,
  `RedCards` int(11) NOT NULL,
  `YellowCards` int(11) NOT NULL,
  `GameId` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `PositionId` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`SquadHistoryId`),
  UNIQUE KEY `SquadHistoryId` (`SquadHistoryId`),
  UNIQUE KEY `EmpoyeeId` (`EmpoyeeId`),
  UNIQUE KEY `GameId` (`GameId`),
  UNIQUE KEY `PositionId` (`PositionId`),
  KEY `IX_EmpoyeeId` (`EmpoyeeId`),
  KEY `IX_GameId` (`GameId`),
  KEY `IX_PositionId` (`PositionId`),
  CONSTRAINT `FK_dbo.SquadHistory_dbo.Employees_EmpoyeeId` FOREIGN KEY (`EmpoyeeId`) REFERENCES `Employees` (`EmployeeId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_dbo.SquadHistory_dbo.Games_GameId` FOREIGN KEY (`GameId`) REFERENCES `Games` (`GameId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_dbo.SquadHistory_dbo.Positions_PositionId` FOREIGN KEY (`PositionId`) REFERENCES `Positions` (`PositionId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `SquadHistory`
--

LOCK TABLES `SquadHistory` WRITE;
/*!40000 ALTER TABLE `SquadHistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `SquadHistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Teams`
--

DROP TABLE IF EXISTS `Teams`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Teams` (
  `TeamId` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `Name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `NationalityId` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`TeamId`),
  UNIQUE KEY `TeamId` (`TeamId`),
  UNIQUE KEY `NationalityId` (`NationalityId`),
  KEY `IX_NationalityId` (`NationalityId`),
  CONSTRAINT `FK_dbo.Teams_dbo.Nationalities_NationalityId` FOREIGN KEY (`NationalityId`) REFERENCES `Nationalities` (`NationalityId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Teams`
--

LOCK TABLES `Teams` WRITE;
/*!40000 ALTER TABLE `Teams` DISABLE KEYS */;
/*!40000 ALTER TABLE `Teams` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `WorkHistory`
--

DROP TABLE IF EXISTS `WorkHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `WorkHistory` (
  `WorkHistoryId` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `EmployeeId` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `TeamId` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `StartDate` date NOT NULL,
  `EndDate` date DEFAULT NULL,
  `Salary` decimal(18,2) NOT NULL,
  `OccupationId` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`WorkHistoryId`),
  UNIQUE KEY `WorkHistoryId` (`WorkHistoryId`),
  UNIQUE KEY `EmployeeId` (`EmployeeId`),
  UNIQUE KEY `TeamId` (`TeamId`),
  UNIQUE KEY `OccupationId` (`OccupationId`),
  KEY `IX_EmployeeId` (`EmployeeId`),
  KEY `IX_TeamId` (`TeamId`),
  KEY `IX_OccupationId` (`OccupationId`),
  CONSTRAINT `FK_dbo.WorkHistory_dbo.Employees_EmployeeId` FOREIGN KEY (`EmployeeId`) REFERENCES `Employees` (`EmployeeId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_dbo.WorkHistory_dbo.Occupations_OccupationId` FOREIGN KEY (`OccupationId`) REFERENCES `Occupations` (`OccupationId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_dbo.WorkHistory_dbo.Teams_TeamId` FOREIGN KEY (`TeamId`) REFERENCES `Teams` (`TeamId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `WorkHistory`
--

LOCK TABLES `WorkHistory` WRITE;
/*!40000 ALTER TABLE `WorkHistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `WorkHistory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2014-09-03 16:51:20
