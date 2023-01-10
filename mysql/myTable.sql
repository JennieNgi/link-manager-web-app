-- phpMyAdmin SQL Dump
-- version 4.9.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Nov 02, 2020 at 11:25 PM
-- Server version: 5.7.30
-- PHP Version: 7.4.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sean_dotnetcoreSamples`
--

-- --------------------------------------------------------

--
-- Table structure for table `tblCategory`
--
CREATE TABLE IF NOT EXISTS `tblCategory` (
  `categoryID` int(10) NOT NULL AUTO_INCREMENT,
  `categoryName` varchar(100) NOT NULL,
  PRIMARY KEY (`categoryID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1;

INSERT INTO `tblCategory` (`categoryID`, `categoryName`) VALUES
(1, 'Technology'),
(2, 'School'),
(3, 'Play'),
(4, 'Data');


--
-- Table structure for table `tblLinks`
--
CREATE TABLE IF NOT EXISTS `tblLinks` (
  `linkID` int(10) NOT NULL AUTO_INCREMENT,
  `categoryRefID` int(10) NOT NULL,
  `linkName` varchar(100) NOT NULL,
  `href` text NOT NULL,
  `pinned` TINYINT(1) NOT NULL,
  PRIMARY KEY (`linkID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1;

ALTER TABLE `tblLinks`
  ADD CONSTRAINT `tblLinks_ibfk_1` FOREIGN KEY (`categoryRefID`) REFERENCES `tblCategory` (`categoryID`) ON DELETE CASCADE ON UPDATE CASCADE;



--
-- Table structure for table `tblLogin`
--
CREATE TABLE `tblLogin` (
  `username` varchar(45) NOT NULL,
  `password` varchar(200) NOT NULL,
  `salt` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


INSERT INTO `tblLogin` (`username`, `password`, `salt`) VALUES
-- the password is "test"
('user', 'uLzOc9hqo47A75r1r9TE3ZctD3qmWEA4oQip4zfpgMg=', 'KUgMBBIZbPDsMiGUOc1UvQ=='),
('user2', 'onV5AZwgU51QdLPaMP9QF0xernDIHoVgrhReNTvhmTo=', 'gxuuJ4cZHTmcQB148FCI2g==');


ALTER TABLE `tblLogin`
  ADD PRIMARY KEY (`username`);