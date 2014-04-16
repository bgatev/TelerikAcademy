-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Nov 25, 2013 at 03:06 PM
-- Server version: 5.6.11
-- PHP Version: 5.5.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `billingsystem`
--
CREATE DATABASE IF NOT EXISTS `billingsystem` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `billingsystem`;

-- --------------------------------------------------------

--
-- Table structure for table `subscriber`
--

CREATE TABLE IF NOT EXISTS `subscriber` (
  `subscriber_id` int(11) NOT NULL AUTO_INCREMENT,
  `subscriber_msisdn` varchar(12) NOT NULL,
  `subscriber_name` varchar(50) NOT NULL,
  `subscriber_egn` varchar(10) NOT NULL,
  `subscriber_tariffplan` varchar(50) NOT NULL,
  `subscriber_account` double NOT NULL,
  PRIMARY KEY (`subscriber_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `subscriber`
--

INSERT INTO `subscriber` (`subscriber_id`, `subscriber_msisdn`, `subscriber_name`, `subscriber_egn`, `subscriber_tariffplan`, `subscriber_account`) VALUES
(1, '359882961531', 'boiko', '1234567890', 'MyDefaultPlan', 0),
(2, '359882456783', 'ivan', '9876543210', 'MyDefaultPlan', 0);

-- --------------------------------------------------------

--
-- Table structure for table `subscriber_tariffplan`
--

CREATE TABLE IF NOT EXISTS `subscriber_tariffplan` (
  `subscriber_id` int(11) NOT NULL,
  `tariffplan_id` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `tariffplan`
--

CREATE TABLE IF NOT EXISTS `tariffplan` (
  `tariffplan_id` int(11) NOT NULL AUTO_INCREMENT,
  `tariffplan_name` varchar(50) NOT NULL,
  `callfirstblock` bigint(20) NOT NULL,
  `callfirstblockprice` double NOT NULL,
  `callsubseqblock` bigint(20) NOT NULL,
  `callsubseqblockprice` double NOT NULL,
  `smsfirstblock` bigint(20) NOT NULL,
  `smsfirstblockprice` double NOT NULL,
  `smssubseqblock` bigint(20) NOT NULL,
  `smssubseqblockprice` double NOT NULL,
  `gprsfirstblock` bigint(20) NOT NULL,
  `gprsfirstblockprice` double NOT NULL,
  `gprssubseqblock` bigint(20) NOT NULL,
  `gprssubseqblockprice` double NOT NULL,
  PRIMARY KEY (`tariffplan_id`),
  UNIQUE KEY `tariffplanname` (`tariffplan_name`),
  KEY `tariffplan_id` (`tariffplan_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `tariffplan`
--

INSERT INTO `tariffplan` (`tariffplan_id`, `tariffplan_name`, `callfirstblock`, `callfirstblockprice`, `callsubseqblock`, `callsubseqblockprice`, `smsfirstblock`, `smsfirstblockprice`, `smssubseqblock`, `smssubseqblockprice`, `gprsfirstblock`, `gprsfirstblockprice`, `gprssubseqblock`, `gprssubseqblockprice`) VALUES
(2, 'MyDefaultPlan', 60, 0.3, 1, 0.005, 1, 0.2, 1, 0.2, 1000, 0.01, 1000, 0.01),
(3, 'MTel', 60, 0.25, 1, 0.01, 1, 0.3, 1, 0.18, 10000, 0.05, 1000, 0.01);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
