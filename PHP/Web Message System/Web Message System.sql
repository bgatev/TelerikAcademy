-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Oct 09, 2013 at 12:30 PM
-- Server version: 5.6.11
-- PHP Version: 5.5.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `homework5`
--
CREATE DATABASE IF NOT EXISTS `homework5` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `homework5`;

-- --------------------------------------------------------

--
-- Table structure for table `groups`
--

CREATE TABLE IF NOT EXISTS `groups` (
  `group_id` tinyint(4) NOT NULL AUTO_INCREMENT,
  `groupname` varchar(20) NOT NULL,
  PRIMARY KEY (`group_id`),
  UNIQUE KEY `group_id` (`group_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `groups`
--

INSERT INTO `groups` (`group_id`, `groupname`) VALUES
(1, 'Важни'),
(2, 'Системни'),
(3, 'Общи');

-- --------------------------------------------------------

--
-- Table structure for table `messages`
--

CREATE TABLE IF NOT EXISTS `messages` (
  `msg_id` int(11) NOT NULL AUTO_INCREMENT,
  `msg_date` datetime NOT NULL,
  `msg_title` varchar(50) NOT NULL,
  `msg_text` varchar(250) NOT NULL,
  PRIMARY KEY (`msg_id`),
  UNIQUE KEY `msg_id` (`msg_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=36 ;

--
-- Dumping data for table `messages`
--

INSERT INTO `messages` (`msg_id`, `msg_date`, `msg_title`, `msg_text`) VALUES
(1, '2009-10-20 00:00:00', 'my first message', 'this is my first message'),
(2, '2009-10-20 00:00:00', 'qw', 'ert'),
(20, '2009-10-20 14:00:00', 'eha', 'ihuuuuuuu'),
(18, '2009-10-20 14:00:00', 've4e trqbva da raboti', 'pisna mi'),
(19, '2009-10-20 14:00:00', 'rabotim li', 'dali ve4e raboti vsi4ko'),
(21, '2009-11-20 13:00:00', 'q', 'w'),
(22, '2009-10-21 13:00:00', 'na0nakraq', 'pisna li ti'),
(23, '2009-10-20 13:00:00', 'work', 'weve wrok'),
(24, '2009-10-20 13:00:00', 'novo', 'moeto novo syosbstenie'),
(25, '2009-10-20 14:00:00', 'ivan', 'petkan e dobre'),
(26, '2009-10-08 23:01:33', 'php', 'kurs'),
(27, '2013-12-20 00:00:00', 'ihaa', 'a'),
(28, '0000-00-00 00:00:00', 'd', 'd'),
(29, '2009-10-20 10:00:00', 'd', 'd'),
(30, '0000-00-00 00:00:00', 'opo', 'oki'),
(31, '2009-10-20 14:00:00', 'a', 'a'),
(32, '2009-10-20 14:00:00', 'a', 'a'),
(33, '2024-10-19 00:00:00', 'd', 'd'),
(34, '2023-10-19 00:00:00', 'er', 'er'),
(35, '2013-10-10 00:00:00', 'real', 'first real msg');

-- --------------------------------------------------------

--
-- Table structure for table `msgsgroups`
--

CREATE TABLE IF NOT EXISTS `msgsgroups` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `msg_id` int(11) NOT NULL,
  `group_id` tinyint(4) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`),
  UNIQUE KEY `msg_id` (`msg_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=21 ;

--
-- Dumping data for table `msgsgroups`
--

INSERT INTO `msgsgroups` (`id`, `msg_id`, `group_id`) VALUES
(1, 0, 0),
(2, 17, 1),
(3, 18, 2),
(4, 19, 3),
(5, 20, 2),
(6, 21, 3),
(7, 22, 1),
(8, 23, 2),
(9, 24, 3),
(10, 25, 2),
(11, 26, 2),
(12, 27, 1),
(13, 28, 1),
(14, 29, 1),
(15, 30, 1),
(16, 31, 1),
(17, 32, 1),
(18, 33, 1),
(19, 34, 2),
(20, 35, 2);

-- --------------------------------------------------------

--
-- Table structure for table `userroles`
--

CREATE TABLE IF NOT EXISTS `userroles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `role` varchar(10) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `user_id` (`user_id`),
  UNIQUE KEY `id` (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `userroles`
--

INSERT INTO `userroles` (`id`, `user_id`, `role`) VALUES
(1, 1, 'admin'),
(2, 2, 'user');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password` varchar(20) NOT NULL DEFAULT 'qwerty',
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `username` (`username`),
  UNIQUE KEY `user_id` (`user_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `username`, `password`) VALUES
(1, '12345', 'qwerty'),
(2, 'qwerty', 'qwerty'),
(3, 'pesho', 'golemec'),
(4, 'ivan4o', 'baiivan');

-- --------------------------------------------------------

--
-- Table structure for table `usersmsgs`
--

CREATE TABLE IF NOT EXISTS `usersmsgs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `msg_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=20 ;

--
-- Dumping data for table `usersmsgs`
--

INSERT INTO `usersmsgs` (`id`, `user_id`, `msg_id`) VALUES
(1, 0, 17),
(2, 0, 18),
(3, 0, 19),
(4, 0, 20),
(5, 3, 21),
(6, 3, 22),
(7, 3, 23),
(8, 3, 24),
(9, 1, 25),
(10, 1, 26),
(11, 1, 27),
(12, 1, 28),
(13, 1, 29),
(14, 1, 30),
(15, 1, 31),
(16, 1, 32),
(17, 1, 33),
(18, 1, 34),
(19, 1, 35);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
