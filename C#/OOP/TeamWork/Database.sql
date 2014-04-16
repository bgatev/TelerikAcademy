-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Dec 04, 2013 at 12:38 PM
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
  PRIMARY KEY (`subscriber_id`),
  UNIQUE KEY `subscriber_msisdn` (`subscriber_msisdn`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=16 ;

--
-- Dumping data for table `subscriber`
--

INSERT INTO `subscriber` (`subscriber_id`, `subscriber_msisdn`, `subscriber_name`, `subscriber_egn`, `subscriber_tariffplan`, `subscriber_account`) VALUES
(1, '359882961531', 'boiko', '1234567890', 'MyDefaultPlan', 0),
(2, '359882456783', 'ivan', '9876543210', 'MyDefaultPlan', 0),
(7, '359881234567', 'gogo', '7897897894', 'MyDefaultPlan', 0),
(8, '359855234327', 'Bai Ivan', '4569874125', 'MTel', 0),
(9, '359871234567', 'Pesho', '8105147896', 'MTel', 0),
(10, '359882178877', 'Gosho', '7712123698', 'MTel', 0),
(11, '359882234985', 'Coko', '9002021458', 'MyDefaultPlan', 0),
(12, '359882764522', 'Penka', '9305057896', 'MTel', 6),
(13, '359883156734', 'Pepa', '8806068745', 'MTel', 2),
(14, '359883189952', 'Ivanka', '8704046987', 'MyDefaultPlan', 7),
(15, '359883234567', 'Milka', '8506137548', 'Globul', 1);

-- --------------------------------------------------------

--
-- Table structure for table `subscriber_tariffplan`
--

CREATE TABLE IF NOT EXISTS `subscriber_tariffplan` (
  `subscriber_id` int(11) NOT NULL,
  `tariffplan_id` int(11) NOT NULL,
  KEY `tariffplan_id` (`tariffplan_id`),
  KEY `subscriber_id` (`subscriber_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `subscriber_tariffplan`
--

INSERT INTO `subscriber_tariffplan` (`subscriber_id`, `tariffplan_id`) VALUES
(11, 2),
(12, 3),
(13, 3),
(14, 2),
(15, 4);

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
  UNIQUE KEY `tariffplanname` (`tariffplan_name`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `tariffplan`
--

INSERT INTO `tariffplan` (`tariffplan_id`, `tariffplan_name`, `callfirstblock`, `callfirstblockprice`, `callsubseqblock`, `callsubseqblockprice`, `smsfirstblock`, `smsfirstblockprice`, `smssubseqblock`, `smssubseqblockprice`, `gprsfirstblock`, `gprsfirstblockprice`, `gprssubseqblock`, `gprssubseqblockprice`) VALUES
(2, 'MyDefaultPlan', 60, 0.3, 1, 0.005, 1, 0.2, 1, 0.2, 1000, 0.01, 1000, 0.01),
(3, 'MTel', 60, 0.25, 1, 0.01, 1, 0.28, 1, 0.18, 10000, 0.05, 1000, 0.01),
(4, 'Globul', 30, 0.15, 1, 0.01, 1, 0.12, 1, 0.17, 10000, 0.07, 1000, 0.01);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
