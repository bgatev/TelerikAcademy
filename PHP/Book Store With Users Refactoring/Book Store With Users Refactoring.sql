-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Oct 25, 2013 at 10:13 AM
-- Server version: 5.6.11
-- PHP Version: 5.5.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `books`
--
CREATE DATABASE IF NOT EXISTS `books` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `books`;

-- --------------------------------------------------------

--
-- Table structure for table `authors`
--

CREATE TABLE IF NOT EXISTS `authors` (
  `author_id` int(11) NOT NULL AUTO_INCREMENT,
  `author_name` varchar(250) NOT NULL,
  PRIMARY KEY (`author_id`),
  UNIQUE KEY `author_name` (`author_name`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=12 ;

--
-- Dumping data for table `authors`
--

INSERT INTO `authors` (`author_id`, `author_name`) VALUES
(1, 'Иван Вазов'),
(2, 'Пенчо Славейков'),
(3, 'Елин Пелин'),
(4, 'Джак Лондон'),
(5, 'Тери Пратчет'),
(6, 'Христо Ботев'),
(7, 'Дора Габе'),
(8, 'Петко Славейков'),
(9, 'Валери Петров'),
(10, 'Boiko'),
(11, 'Валери Божинов');

-- --------------------------------------------------------

--
-- Table structure for table `books`
--

CREATE TABLE IF NOT EXISTS `books` (
  `book_id` int(11) NOT NULL AUTO_INCREMENT,
  `book_title` varchar(250) NOT NULL,
  PRIMARY KEY (`book_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=25 ;

--
-- Dumping data for table `books`
--

INSERT INTO `books` (`book_id`, `book_title`) VALUES
(1, 'Под Игото'),
(2, 'Успокоения'),
(3, 'Момини Сълзи'),
(4, 'Чичовци'),
(5, 'Най-големите'),
(6, 'Вечния студент'),
(7, 'Вечния студент 2'),
(8, 'Вечния студент 3'),
(9, 'Вечния студент 4'),
(10, 'Вечния студент 5'),
(11, 'BTV'),
(12, 'Nova'),
(13, 'Прасковките'),
(17, 'Гатака'),
(18, 'новата книга'),
(19, 'новата книга 2'),
(20, 'Прасковките 2'),
(21, 'Чичовци 2'),
(22, 'Мараба Пешо'),
(23, 'Мараба Пешо и Иван'),
(24, 'Мараба Донке');

-- --------------------------------------------------------

--
-- Table structure for table `books_authors`
--

CREATE TABLE IF NOT EXISTS `books_authors` (
  `book_id` int(11) NOT NULL,
  `author_id` int(11) NOT NULL,
  KEY `book_id` (`book_id`),
  KEY `author_id` (`author_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `books_authors`
--

INSERT INTO `books_authors` (`book_id`, `author_id`) VALUES
(1, 1),
(2, 2),
(3, 2),
(4, 1),
(5, 1),
(5, 2),
(10, 2),
(10, 6),
(10, 7),
(10, 8),
(11, 3),
(11, 4),
(12, 3),
(12, 4),
(13, 1),
(13, 7),
(20, 5),
(20, 4),
(18, 1),
(21, 1),
(22, 7),
(22, 9),
(23, 4),
(23, 5),
(23, 7),
(24, 4),
(24, 5),
(24, 11);

-- --------------------------------------------------------

--
-- Table structure for table `comments`
--

CREATE TABLE IF NOT EXISTS `comments` (
  `comment_id` int(11) NOT NULL AUTO_INCREMENT,
  `comment_name` varchar(100) NOT NULL,
  `comment_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`comment_id`),
  UNIQUE KEY `comment_id` (`comment_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=13 ;

--
-- Dumping data for table `comments`
--

INSERT INTO `comments` (`comment_id`, `comment_name`, `comment_date`) VALUES
(1, 'Много яка книга', '2013-10-22 07:12:32'),
(2, 'Препоръчвам я', '2013-10-22 07:11:32'),
(3, 'Не струва', '2013-10-22 07:11:32'),
(4, 'Не съм чел по-лоша творба от тази', '2013-10-22 07:11:32'),
(5, 'Незнам дали да я препоръчам или не', '2013-10-22 07:32:01'),
(6, 'Лоша работа', '2013-10-22 07:37:00'),
(7, 'не я четете', '2013-10-22 12:33:29'),
(10, 'бива си я', '2013-10-22 13:47:42'),
(9, 'те това е баце ми', '2013-10-22 13:42:20'),
(11, 'доволен съм', '2013-10-24 13:21:36'),
(12, 'super e', '2013-10-24 14:02:18');

-- --------------------------------------------------------

--
-- Table structure for table `comments_books`
--

CREATE TABLE IF NOT EXISTS `comments_books` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `comment_id` int(11) NOT NULL,
  `book_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=18 ;

--
-- Dumping data for table `comments_books`
--

INSERT INTO `comments_books` (`id`, `comment_id`, `book_id`, `user_id`) VALUES
(1, 1, 2, 6),
(2, 1, 3, 10),
(3, 2, 5, 6),
(4, 2, 8, 5),
(5, 3, 17, 6),
(6, 3, 13, 9),
(7, 4, 6, 9),
(8, 4, 5, 7),
(9, 3, 2, 5),
(10, 5, 8, 10),
(11, 6, 8, 10),
(12, 6, 17, 8),
(13, 7, 5, 5),
(14, 9, 5, 10),
(15, 10, 11, 10),
(16, 11, 11, 11),
(17, 12, 6, 6);

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
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=12 ;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `username`, `password`) VALUES
(5, '12345', '12345'),
(6, 'qwerty', 'qwerty'),
(7, 'vankata', 'vankata'),
(8, 'petyr4o', 'petyr4o'),
(9, 'stoqn4o', 'stoqn4o'),
(10, 'golemec', 'golemec'),
(11, 'newuser', 'newuser');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
