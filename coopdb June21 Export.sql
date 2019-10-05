-- phpMyAdmin SQL Dump
-- version 4.0.4
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Jun 21, 2017 at 04:56 AM
-- Server version: 5.6.12-log
-- PHP Version: 5.4.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `coopdb`
--
CREATE DATABASE IF NOT EXISTS `coopdb` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `coopdb`;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_audit_trail`
--

CREATE TABLE IF NOT EXISTS `tbl_audit_trail` (
  `aud_id` int(11) NOT NULL AUTO_INCREMENT,
  `aud_module` varchar(35) NOT NULL,
  `aud_action` varchar(35) NOT NULL,
  `aud_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `emp_id` int(11) NOT NULL,
  PRIMARY KEY (`aud_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=36 ;

--
-- Dumping data for table `tbl_audit_trail`
--

INSERT INTO `tbl_audit_trail` (`aud_id`, `aud_module`, `aud_action`, `aud_date`, `emp_id`) VALUES
(3, 'Loans', 'Withdraw Money', '2016-11-09 16:51:28', 1),
(4, 'Loans', 'Deposit Money', '2016-11-09 16:53:36', 1),
(5, 'Loans', 'Withdraw Money', '2016-11-10 12:02:23', 1),
(6, 'Point of Sale', 'Open Saved Sale', '2016-11-10 12:48:02', 1),
(7, 'Point of Sale', 'Open Saved Sale', '2016-11-10 13:11:01', 1),
(8, 'Point of Sale', 'Open Register', '2016-11-10 13:45:46', 5),
(9, 'Inventory', 'Enter Items', '2016-11-10 15:51:34', 1),
(10, 'Inventory', 'Enter Items', '2016-11-10 15:56:31', 1),
(11, 'Inventory', 'Enter Items', '2016-11-10 15:59:27', 1),
(12, 'Inventory', 'Enter Items', '2016-11-10 16:01:58', 1),
(13, 'Inventory', 'Enter Items', '2016-11-10 16:07:47', 1),
(14, 'Inventory', 'Enter Items', '2016-11-10 16:09:13', 1),
(15, 'Inventory', 'Enter Items', '2016-11-10 16:09:56', 1),
(16, 'Inventory', 'Enter Items', '2016-11-10 16:10:59', 1),
(17, 'Inventory', 'Enter Items', '2016-11-10 16:12:59', 1),
(18, 'Inventory', 'Enter Items', '2016-11-10 16:14:24', 1),
(19, 'Inventory', 'Enter Items', '2016-11-10 16:15:29', 1),
(20, 'Inventory', 'Enter Items', '2016-11-10 16:17:15', 1),
(21, 'Inventory', 'Enter Items', '2016-11-10 16:17:39', 1),
(22, 'Inventory', 'Enter Items', '2016-11-10 16:18:05', 1),
(23, 'Inventory', 'Enter Items', '2016-11-10 16:19:04', 1),
(24, 'Inventory', 'Enter Items', '2016-11-10 16:21:36', 1),
(25, 'Inventory', 'Enter Items', '2016-11-10 16:49:07', 1),
(26, 'Inventory', 'Enter Items', '2016-11-10 17:31:48', 1),
(27, 'Loans', 'Deposit Money', '2016-11-11 19:38:03', 1),
(28, 'Loans', 'Loan Payment', '2016-11-11 19:45:30', 1),
(29, 'Loans', 'Loan Payment', '2016-11-11 19:58:41', 1),
(30, 'Loans', 'Loan Payment', '2016-11-11 19:59:31', 1),
(31, 'Loans', 'Loan Payment', '2016-11-11 19:59:38', 1),
(32, 'Loans', 'Loan Payment', '2016-11-11 20:00:33', 1),
(33, 'Point of Sale', 'Open Saved Sale', '2016-11-19 11:23:29', 1),
(34, 'Point of Sale', 'Open Saved Sale', '2016-11-19 11:24:43', 1),
(35, 'Point of Sale', 'Open Saved Sale', '2016-11-19 11:27:38', 1);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_currsavings`
--

CREATE TABLE IF NOT EXISTS `tbl_currsavings` (
  `savings_id` int(11) NOT NULL AUTO_INCREMENT,
  `mem_id` int(11) NOT NULL,
  `current_Savings` decimal(10,0) NOT NULL,
  `current_ShareCapital` decimal(10,0) NOT NULL,
  PRIMARY KEY (`savings_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `tbl_currsavings`
--

INSERT INTO `tbl_currsavings` (`savings_id`, `mem_id`, `current_Savings`, `current_ShareCapital`) VALUES
(2, 1, '120', '0'),
(3, 2, '100', '4'),
(4, 3, '120', '0'),
(5, 4, '500', '6'),
(7, 5, '0', '0');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_deposit`
--

CREATE TABLE IF NOT EXISTS `tbl_deposit` (
  `dep_id` int(11) NOT NULL AUTO_INCREMENT,
  `customer_id` int(11) NOT NULL,
  `process_by` int(11) NOT NULL,
  `process_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `deposit` decimal(10,0) NOT NULL,
  `or_num` int(11) NOT NULL,
  PRIMARY KEY (`dep_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=16 ;

--
-- Dumping data for table `tbl_deposit`
--

INSERT INTO `tbl_deposit` (`dep_id`, `customer_id`, `process_by`, `process_date`, `deposit`, `or_num`) VALUES
(10, 1, 1, '2016-11-07 15:34:51', '18', 15),
(11, 3, 1, '2016-11-07 15:52:57', '120', 17),
(12, 1, 1, '2016-11-09 16:46:13', '100', 19),
(13, 2, 1, '2016-11-09 16:48:39', '55', 20),
(14, 2, 1, '2016-11-09 16:53:36', '55', 21),
(15, 4, 1, '2016-11-11 19:38:03', '500', 27);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_feefiling`
--

CREATE TABLE IF NOT EXISTS `tbl_feefiling` (
  `fillfee_id` int(11) NOT NULL AUTO_INCREMENT,
  `fillfee_amt` decimal(10,0) NOT NULL,
  `loanlog_id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `emp_id` int(11) NOT NULL,
  `date_filed` datetime NOT NULL,
  PRIMARY KEY (`fillfee_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `tbl_feefiling`
--

INSERT INTO `tbl_feefiling` (`fillfee_id`, `fillfee_amt`, `loanlog_id`, `customer_id`, `emp_id`, `date_filed`) VALUES
(1, '2', 2, 1, 1, '2016-11-05 00:00:00'),
(2, '2', 3, 2, 1, '2016-11-05 00:00:00'),
(3, '2', 4, 3, 1, '2016-11-05 00:00:00'),
(4, '1', 4, 3, 1, '2016-11-07 00:00:00'),
(5, '2', 2, 2, 1, '2016-11-10 00:00:00'),
(6, '3', 3, 4, 1, '2016-11-11 00:00:00'),
(7, '2', 4, 4, 1, '2016-11-11 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_feeprocessing`
--

CREATE TABLE IF NOT EXISTS `tbl_feeprocessing` (
  `procfee_id` int(11) NOT NULL AUTO_INCREMENT,
  `procfee_amt` decimal(10,0) NOT NULL,
  `loanlog_id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `emp_id` int(11) NOT NULL,
  `date_filed` datetime NOT NULL,
  PRIMARY KEY (`procfee_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `tbl_feeprocessing`
--

INSERT INTO `tbl_feeprocessing` (`procfee_id`, `procfee_amt`, `loanlog_id`, `customer_id`, `emp_id`, `date_filed`) VALUES
(1, '2', 2, 1, 1, '2016-11-05 00:00:00'),
(2, '2', 3, 2, 1, '2016-11-05 00:00:00'),
(3, '2', 4, 3, 1, '2016-11-05 00:00:00'),
(4, '1', 4, 3, 1, '2016-11-07 00:00:00'),
(5, '2', 2, 2, 1, '2016-11-10 00:00:00'),
(6, '3', 3, 4, 1, '2016-11-11 00:00:00'),
(7, '2', 4, 4, 1, '2016-11-11 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_feesharecapital`
--

CREATE TABLE IF NOT EXISTS `tbl_feesharecapital` (
  `shcapfee_id` int(11) NOT NULL AUTO_INCREMENT,
  `shcap_amt` decimal(10,0) NOT NULL,
  `loanlog_id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `emp_id` int(11) NOT NULL,
  `date_filed` datetime NOT NULL,
  PRIMARY KEY (`shcapfee_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `tbl_feesharecapital`
--

INSERT INTO `tbl_feesharecapital` (`shcapfee_id`, `shcap_amt`, `loanlog_id`, `customer_id`, `emp_id`, `date_filed`) VALUES
(5, '2', 2, 2, 1, '2016-11-10 00:00:00'),
(6, '4', 3, 4, 1, '2016-11-11 00:00:00'),
(7, '2', 4, 4, 1, '2016-11-11 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_inputtedor`
--

CREATE TABLE IF NOT EXISTS `tbl_inputtedor` (
  `input_orID` int(11) NOT NULL AUTO_INCREMENT,
  `or_number_ref` varchar(250) NOT NULL,
  `issue_date` datetime NOT NULL,
  `inputted_by` int(11) NOT NULL,
  `status` int(11) NOT NULL COMMENT 'if consumed or not',
  `consumed_date` datetime NOT NULL,
  PRIMARY KEY (`input_orID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=13 ;

--
-- Dumping data for table `tbl_inputtedor`
--

INSERT INTO `tbl_inputtedor` (`input_orID`, `or_number_ref`, `issue_date`, `inputted_by`, `status`, `consumed_date`) VALUES
(1, '12', '2016-11-12 00:00:00', 1, 1, '2016-11-12 13:00:25'),
(4, 'WWW', '2016-11-12 00:00:00', 1, 1, '2016-11-12 13:23:41'),
(5, '23', '2016-11-12 00:00:00', 1, 1, '0000-00-00 00:00:00'),
(6, '45', '2016-11-12 00:00:00', 1, 1, '0000-00-00 00:00:00'),
(7, '34', '2016-11-12 00:00:00', 1, 1, '0000-00-00 00:00:00'),
(8, '1', '2016-11-12 00:00:00', 1, 1, '2016-11-12 17:49:56'),
(9, '56', '2016-11-12 00:00:00', 1, 0, '0000-00-00 00:00:00'),
(10, '67', '2016-11-12 00:00:00', 1, 0, '0000-00-00 00:00:00'),
(11, '89', '2016-11-19 00:00:00', 1, 0, '0000-00-00 00:00:00'),
(12, '87', '2016-11-19 00:00:00', 1, 0, '0000-00-00 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_invoicenumber`
--

CREATE TABLE IF NOT EXISTS `tbl_invoicenumber` (
  `invnum_id` int(11) NOT NULL AUTO_INCREMENT,
  `det` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `nothing` varchar(5) NOT NULL,
  PRIMARY KEY (`invnum_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=16 ;

--
-- Dumping data for table `tbl_invoicenumber`
--

INSERT INTO `tbl_invoicenumber` (`invnum_id`, `det`, `nothing`) VALUES
(1, '2016-11-06 20:53:46', ''),
(8, '2016-11-06 23:50:37', ''),
(9, '2016-11-07 00:03:03', ''),
(10, '2016-11-07 09:23:11', ''),
(11, '2016-11-07 09:59:36', ''),
(12, '2016-11-07 10:05:48', ''),
(13, '2016-11-07 11:13:04', ''),
(14, '2016-11-07 11:14:07', ''),
(15, '2016-11-07 11:15:22', '');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_items`
--

CREATE TABLE IF NOT EXISTS `tbl_items` (
  `item_id` int(11) NOT NULL AUTO_INCREMENT,
  `item_desc` varchar(200) NOT NULL,
  `net_weight` varchar(50) NOT NULL,
  `quantity` int(11) NOT NULL,
  `unit_cost` decimal(10,0) NOT NULL,
  `selling_price` decimal(10,0) NOT NULL,
  `expiration_date` date NOT NULL,
  `item_code` varchar(50) NOT NULL,
  `category` varchar(150) NOT NULL,
  `unit_measurement` varchar(30) NOT NULL,
  `photo` varchar(250) NOT NULL,
  PRIMARY KEY (`item_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=21 ;

--
-- Dumping data for table `tbl_items`
--

INSERT INTO `tbl_items` (`item_id`, `item_desc`, `net_weight`, `quantity`, `unit_cost`, `selling_price`, `expiration_date`, `item_code`, `category`, `unit_measurement`, `photo`) VALUES
(1, 'asd', 'asd', 71, '21', '21', '2016-11-06', 'asdasd', 'Dairy Products', 'asd', ''),
(2, 'z', 'z', 98, '2', '2', '2016-11-06', 'asd', 'Canned Goods', 'z', ''),
(7, 'aa', 'aa', 0, '11', '11', '2016-11-10', '12', 'Toiletries', 'aa', ''),
(18, 'www', 'www', 0, '34', '34', '2016-11-10', 'wdwwd', 'Toiletries', 'www', ''),
(19, 'hh', 'hh', 0, '3', '3', '2016-11-10', '3', 'Dairy Products', 'hh', ''),
(20, 'fw', 'wd', 0, '2', '22', '2016-11-10', '22', 'Canned Goods', 'wd', '');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_loanlog`
--

CREATE TABLE IF NOT EXISTS `tbl_loanlog` (
  `loanlog_id` int(11) NOT NULL AUTO_INCREMENT,
  `mem_id` int(11) NOT NULL,
  `principal_amount` decimal(10,0) NOT NULL,
  `total_amount` decimal(10,0) NOT NULL,
  `term_loan` text NOT NULL,
  `term_duration` int(11) NOT NULL,
  `rate_interest` decimal(10,0) NOT NULL,
  `notes` varchar(200) NOT NULL,
  `process_date` datetime NOT NULL,
  `start_date` datetime NOT NULL,
  `end_date` datetime NOT NULL,
  `emp_id` int(11) NOT NULL,
  `ispaid` int(11) NOT NULL,
  `or_num` int(11) NOT NULL,
  PRIMARY KEY (`loanlog_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `tbl_loanlog`
--

INSERT INTO `tbl_loanlog` (`loanlog_id`, `mem_id`, `principal_amount`, `total_amount`, `term_loan`, `term_duration`, `rate_interest`, `notes`, `process_date`, `start_date`, `end_date`, `emp_id`, `ispaid`, `or_num`) VALUES
(1, 2, '100', '101', '1', 1, '1', '', '2016-11-05 00:00:00', '2016-11-05 00:00:00', '2017-03-05 00:00:00', 1, 1, 16),
(2, 2, '100', '101', '0', 1, '1', '\r\n Loaned 100 @ 11/5/2016 12:00:00 AM', '2016-11-10 00:00:00', '2016-11-10 00:00:00', '2016-12-10 00:00:00', 1, 1, 23),
(3, 4, '200', '202', '0', 3, '1', '', '2016-11-11 00:00:00', '2016-11-11 00:00:00', '2017-02-11 00:00:00', 1, 1, 28),
(4, 4, '100', '103', '1', 2, '3', '\r\n Loaned 200 @ 11/11/2016', '2016-11-11 00:00:00', '2016-11-11 00:00:00', '2016-11-11 00:00:00', 1, 1, 36);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_loanpayment`
--

CREATE TABLE IF NOT EXISTS `tbl_loanpayment` (
  `loan_payment` int(11) NOT NULL AUTO_INCREMENT,
  `mem_id` int(11) NOT NULL,
  `principal_amount` decimal(10,0) NOT NULL,
  `amount_paid` decimal(10,0) NOT NULL,
  `date_paid` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `emp_id` int(11) NOT NULL,
  `loanlog_id` int(11) NOT NULL,
  `or_num` int(11) NOT NULL,
  PRIMARY KEY (`loan_payment`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=17 ;

--
-- Dumping data for table `tbl_loanpayment`
--

INSERT INTO `tbl_loanpayment` (`loan_payment`, `mem_id`, `principal_amount`, `amount_paid`, `date_paid`, `emp_id`, `loanlog_id`, `or_num`) VALUES
(1, 3, '100', '11', '2016-11-05 00:00:00', 1, 1, 1),
(2, 3, '100', '10', '2016-11-05 00:00:00', 1, 1, 2),
(3, 3, '100', '15', '2016-11-05 14:35:06', 1, 1, 3),
(4, 3, '100', '5', '2016-11-05 15:22:24', 1, 1, 4),
(5, 2, '100', '101', '2016-11-10 11:48:30', 1, 1, 22),
(6, 2, '100', '101', '2016-11-10 11:51:07', 1, 2, 24),
(7, 4, '200', '100', '2016-11-11 19:45:30', 1, 3, 29),
(13, 4, '200', '102', '2016-11-11 19:58:41', 1, 3, 35),
(14, 4, '100', '3', '2016-11-11 19:59:31', 1, 4, 37),
(15, 4, '100', '50', '2016-11-11 19:59:38', 1, 4, 38),
(16, 4, '100', '50', '2016-11-11 20:00:33', 1, 4, 39);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_members`
--

CREATE TABLE IF NOT EXISTS `tbl_members` (
  `mem_id` int(11) NOT NULL AUTO_INCREMENT,
  `mem_lname` varchar(100) NOT NULL,
  `mem_fname` varchar(100) NOT NULL,
  `mem_mname` varchar(100) NOT NULL,
  `mem_address` varchar(200) NOT NULL,
  `mem_provaddress` varchar(200) NOT NULL,
  `mem_addresstype` varchar(25) NOT NULL,
  `mem_cellcontact` varchar(100) NOT NULL,
  `mem_tellcontact` varchar(100) NOT NULL,
  `mem_bday` date NOT NULL,
  `mem_bplace` varchar(200) NOT NULL,
  `mem_age` int(11) NOT NULL,
  `mem_gender` varchar(7) NOT NULL,
  `mem_civilstatus` varchar(15) NOT NULL,
  `mem_religion` varchar(50) NOT NULL,
  `mem_id_one` varchar(100) NOT NULL,
  `mem_id_onedet` varchar(100) NOT NULL,
  `mem_id_two` varchar(100) NOT NULL,
  `mem_id_twodet` varchar(100) NOT NULL,
  `mem_active` int(11) NOT NULL,
  PRIMARY KEY (`mem_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `tbl_members`
--

INSERT INTO `tbl_members` (`mem_id`, `mem_lname`, `mem_fname`, `mem_mname`, `mem_address`, `mem_provaddress`, `mem_addresstype`, `mem_cellcontact`, `mem_tellcontact`, `mem_bday`, `mem_bplace`, `mem_age`, `mem_gender`, `mem_civilstatus`, `mem_religion`, `mem_id_one`, `mem_id_onedet`, `mem_id_two`, `mem_id_twodet`, `mem_active`) VALUES
(1, 'Gazette', 'Ruki', 'G', 'dasad', 'dasdas', 'Owned', 'asdasdasd', 'dasdasd', '2008-12-05', 'asdasd', 21, 'Male', 'Single', 'Islam', 'asd', 'sad', 'asd', 'asdasd', 1),
(2, 'Gray', 'Nana', 'R', 'asd', 'asd', 'Owned', 'asd', 'asd', '2007-02-05', 'asd', 21, 'Male', 'Single', 'Roman Catholic', 'asd', 'asd', 'asd', 'asdasd', 1),
(3, 'FUCK', 'YOU', 'asd', 'asd', 'asd', 'Owned', 'asd', 'asd', '2009-02-05', 'asd', 21, 'Female', 'Single', 'Islam', 'sad', 'asd', 'asd', 'asd', 0),
(4, 'Stella', 'Gray', 'G', 'Tokyo Bau', 'Tokyo', 'Owned', 'asdasd', 'f', '2016-02-01', 'asd', 21, 'Male', 'Single', 'Roman Catholic', 'sad', 'sad', 'asd', 'asd', 1),
(5, 'Namine', 'Ritsu', 'ss', 'saan', 'saabn', 'Owned', '222', '22', '2013-02-01', 'sad', 21, 'Female', 'Single', 'Iglesia ni Cristo', 'asd', 'a', 'sad', 'a', 1);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_membersbenef`
--

CREATE TABLE IF NOT EXISTS `tbl_membersbenef` (
  `membene_id` int(11) NOT NULL AUTO_INCREMENT,
  `benef_name` varchar(250) NOT NULL,
  `benef_age` int(11) NOT NULL,
  `benef_relationship` varchar(100) NOT NULL,
  `mem_id` int(11) NOT NULL,
  PRIMARY KEY (`membene_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=11 ;

--
-- Dumping data for table `tbl_membersbenef`
--

INSERT INTO `tbl_membersbenef` (`membene_id`, `benef_name`, `benef_age`, `benef_relationship`, `mem_id`) VALUES
(1, 'azzzz', 21, 'e', 1),
(2, 'www', 45, 'father', 1),
(3, 'eee', 12, 'sister', 1),
(4, 'haha', 21, 'asd', 2),
(6, 'wwww', 21, 'sdadsadzzzzz', 4),
(7, 'wwww', 21, 'sdadsadzzzzz', 4),
(8, 'haha', 21, 'asd', 2),
(9, 'Nana', 12, 'asdsa', 4),
(10, 'Rokune Yokune', 21, 'aaa', 5);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_membersdetails`
--

CREATE TABLE IF NOT EXISTS `tbl_membersdetails` (
  `mem_detid` int(11) NOT NULL AUTO_INCREMENT,
  `mem_edAttainment` varchar(50) NOT NULL,
  `mem_occupation` varchar(100) NOT NULL,
  `mem_workplace` varchar(250) NOT NULL,
  `mem_salary` varchar(150) NOT NULL,
  `mem_spouseoccupation` varchar(100) NOT NULL,
  `mem_spouseworkplace` varchar(250) NOT NULL,
  `mem_spousesalary` varchar(150) NOT NULL,
  `mem_photo` varchar(150) NOT NULL,
  `mem_id` int(11) NOT NULL,
  PRIMARY KEY (`mem_detid`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `tbl_membersdetails`
--

INSERT INTO `tbl_membersdetails` (`mem_detid`, `mem_edAttainment`, `mem_occupation`, `mem_workplace`, `mem_salary`, `mem_spouseoccupation`, `mem_spouseworkplace`, `mem_spousesalary`, `mem_photo`, `mem_id`) VALUES
(1, 'Highschool', 'sd', 'sd', '', 'sd', 'sd', '', '', 1),
(2, 'College', 'asd', 'asd', 'asd', '', '', '', '', 2),
(4, 'College', 'asd', '21', 'asdasd', '', '', '', '', 4),
(5, 'College', 'asd', '21', 'asdasd', '', '', '', '', 4),
(6, 'Highschool', 'sad', 'asd', 'asd', '', '', '', '', 5);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_moneycounter`
--

CREATE TABLE IF NOT EXISTS `tbl_moneycounter` (
  `money_id` int(11) NOT NULL AUTO_INCREMENT,
  `emp_id` int(11) NOT NULL,
  `date_saved` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `thousand` int(11) NOT NULL,
  `fivehundred` int(11) NOT NULL,
  `twohundred` int(11) NOT NULL,
  `onehundred` int(11) NOT NULL,
  `fifty` int(11) NOT NULL,
  `twenty` int(11) NOT NULL,
  `ten` int(11) NOT NULL,
  `five` int(11) NOT NULL,
  `one` int(11) NOT NULL,
  `tot_startday` decimal(10,0) NOT NULL,
  `ed_onetho` int(11) NOT NULL,
  `ed_fivehundred` int(11) NOT NULL,
  `ed_twohundred` int(11) NOT NULL,
  `ed_onehundred` int(11) NOT NULL,
  `ed_fifty` int(11) NOT NULL,
  `ed_twenty` int(11) NOT NULL,
  `ed_ten` int(11) NOT NULL,
  `ed_five` int(11) NOT NULL,
  `ed_one` int(11) NOT NULL,
  `tot_endday` decimal(10,0) NOT NULL,
  `tot_diff` decimal(10,0) NOT NULL,
  PRIMARY KEY (`money_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `tbl_moneycounter`
--

INSERT INTO `tbl_moneycounter` (`money_id`, `emp_id`, `date_saved`, `thousand`, `fivehundred`, `twohundred`, `onehundred`, `fifty`, `twenty`, `ten`, `five`, `one`, `tot_startday`, `ed_onetho`, `ed_fivehundred`, `ed_twohundred`, `ed_onehundred`, `ed_fifty`, `ed_twenty`, `ed_ten`, `ed_five`, `ed_one`, `tot_endday`, `tot_diff`) VALUES
(1, 1, '0000-00-00 00:00:00', 1, 1, 1, 1, 1, 1, 1, 1, 1, '1886', 2, 2, 2, 2, 2, 2, 2, 2, 2, '3772', '1886');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_ornumber`
--

CREATE TABLE IF NOT EXISTS `tbl_ornumber` (
  `ornum_id` int(11) NOT NULL AUTO_INCREMENT,
  `det` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `nothing` varchar(10) NOT NULL,
  PRIMARY KEY (`ornum_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=43 ;

--
-- Dumping data for table `tbl_ornumber`
--

INSERT INTO `tbl_ornumber` (`ornum_id`, `det`, `nothing`) VALUES
(3, '2016-11-06 16:45:58', ''),
(4, '2016-11-06 16:46:36', ''),
(5, '2016-11-06 16:48:42', ''),
(6, '2016-11-06 16:50:16', ''),
(7, '2016-11-06 16:58:58', ''),
(8, '2016-11-06 17:10:46', ''),
(9, '2016-11-07 13:09:06', ''),
(10, '2016-11-07 13:15:00', ''),
(15, '2016-11-07 15:34:51', ''),
(16, '2016-11-07 15:46:38', ''),
(17, '2016-11-07 15:52:57', ''),
(18, '2016-11-08 19:08:24', ''),
(19, '2016-11-09 16:46:13', ''),
(20, '2016-11-09 16:48:39', ''),
(21, '2016-11-09 16:53:36', ''),
(22, '2016-11-10 11:48:30', ''),
(23, '2016-11-10 11:50:58', ''),
(24, '2016-11-10 11:51:07', ''),
(25, '2016-11-10 12:02:23', ''),
(26, '2016-11-10 13:45:46', ''),
(27, '2016-11-11 19:38:03', ''),
(28, '2016-11-11 19:38:29', ''),
(29, '2016-11-11 19:45:30', ''),
(35, '2016-11-11 19:58:41', ''),
(36, '2016-11-11 19:59:18', ''),
(37, '2016-11-11 19:59:31', ''),
(38, '2016-11-11 19:59:38', ''),
(39, '2016-11-11 20:00:33', ''),
(40, '2016-11-12 17:05:01', ''),
(41, '2016-11-12 17:07:10', ''),
(42, '2016-11-12 17:18:21', '');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_savedtransactionlog`
--

CREATE TABLE IF NOT EXISTS `tbl_savedtransactionlog` (
  `strans_id` int(11) NOT NULL AUTO_INCREMENT,
  `customer_id` int(11) NOT NULL,
  `purchase_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`strans_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_savedtransactions`
--

CREATE TABLE IF NOT EXISTS `tbl_savedtransactions` (
  `trans_id` int(11) NOT NULL AUTO_INCREMENT,
  `customer_id` int(11) NOT NULL,
  `translog_id` int(11) NOT NULL,
  `item_name` varchar(200) NOT NULL,
  `item_price` decimal(10,0) NOT NULL,
  `item_qty_bought` int(11) NOT NULL,
  `total_amt` decimal(10,0) NOT NULL,
  `bought_period` varchar(10) NOT NULL,
  `bought_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `item_code` varchar(200) NOT NULL,
  PRIMARY KEY (`trans_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_stockrcitems`
--

CREATE TABLE IF NOT EXISTS `tbl_stockrcitems` (
  `stockrcid` int(11) NOT NULL AUTO_INCREMENT,
  `stock_itemcode` varchar(250) NOT NULL,
  `stock_itemid` int(11) NOT NULL,
  `stock_itemname` varchar(250) NOT NULL,
  `stock_rq_qty` int(11) NOT NULL,
  `stock_rc_qty` int(11) NOT NULL,
  `stock_expdate` datetime NOT NULL,
  `stock_receivedid` int(11) NOT NULL,
  PRIMARY KEY (`stockrcid`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `tbl_stockrcitems`
--

INSERT INTO `tbl_stockrcitems` (`stockrcid`, `stock_itemcode`, `stock_itemid`, `stock_itemname`, `stock_rq_qty`, `stock_rc_qty`, `stock_expdate`, `stock_receivedid`) VALUES
(4, 'asdasd', 20, 'asd', 20, 10, '2016-11-07 00:00:00', 7);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_stockreceive`
--

CREATE TABLE IF NOT EXISTS `tbl_stockreceive` (
  `stock_receiveid` int(11) NOT NULL AUTO_INCREMENT,
  `stock_requestperson` varchar(250) NOT NULL,
  `stock_reqdate` datetime NOT NULL,
  `stock_supplier` varchar(250) NOT NULL,
  `stock_desc` varchar(250) NOT NULL,
  `stock_deldate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `stock_recby` int(11) NOT NULL,
  `stock_finished` int(11) NOT NULL,
  `stock_requestid` int(11) NOT NULL,
  `invoice_number` int(11) NOT NULL,
  PRIMARY KEY (`stock_receiveid`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `tbl_stockreceive`
--

INSERT INTO `tbl_stockreceive` (`stock_receiveid`, `stock_requestperson`, `stock_reqdate`, `stock_supplier`, `stock_desc`, `stock_deldate`, `stock_recby`, `stock_finished`, `stock_requestid`, `invoice_number`) VALUES
(1, 'KL Lawingco', '2016-11-06 00:00:00', 'CTI', '', '2016-11-07 09:23:06', 1, 1, 15, 10),
(5, 'KL Lawingco', '2016-11-06 00:00:00', 'CTI', '', '2016-11-07 11:12:59', 1, 1, 15, 13),
(6, 'KL Lawingco', '2016-11-06 00:00:00', 'CTI', '', '2016-11-07 11:14:05', 1, 1, 15, 14),
(7, 'KL Lawingco', '2016-11-06 00:00:00', 'CTI', '', '2016-11-07 11:15:14', 1, 1, 15, 15);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_stockrequest`
--

CREATE TABLE IF NOT EXISTS `tbl_stockrequest` (
  `stock_requestid` int(11) NOT NULL AUTO_INCREMENT,
  `stock_requestperson` varchar(150) NOT NULL,
  `stock_reqdate` datetime NOT NULL,
  `stock_supplier` varchar(250) NOT NULL,
  `stock_desc` varchar(250) NOT NULL,
  `stock_finished` int(11) NOT NULL,
  `invoice_number` int(11) NOT NULL,
  PRIMARY KEY (`stock_requestid`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=21 ;

--
-- Dumping data for table `tbl_stockrequest`
--

INSERT INTO `tbl_stockrequest` (`stock_requestid`, `stock_requestperson`, `stock_reqdate`, `stock_supplier`, `stock_desc`, `stock_finished`, `invoice_number`) VALUES
(12, 's', '0000-00-00 00:00:00', '', '', 0, 0),
(13, '', '0000-00-00 00:00:00', '', '', 0, 0),
(15, 'KL Lawingco', '2016-11-06 00:00:00', 'CTI', '', 1, 1),
(16, '', '0000-00-00 00:00:00', '', '', 0, 0),
(17, '', '0000-00-00 00:00:00', '', '', 0, 0),
(18, '', '0000-00-00 00:00:00', '', '', 0, 0),
(19, '', '0000-00-00 00:00:00', '', '', 0, 0),
(20, '', '0000-00-00 00:00:00', '', '', 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_stockreturn`
--

CREATE TABLE IF NOT EXISTS `tbl_stockreturn` (
  `stock_returnid` int(11) NOT NULL AUTO_INCREMENT,
  `stock_receivedperson` varchar(250) NOT NULL,
  `stock_recdate` datetime NOT NULL,
  `stock_supplier` varchar(250) NOT NULL,
  `stock_desc` varchar(300) NOT NULL,
  `stock_retdate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `stock_retby` int(11) NOT NULL,
  `stock_finished` int(11) NOT NULL,
  `stock_receiveid` int(11) NOT NULL,
  `invoice_number` int(11) NOT NULL,
  PRIMARY KEY (`stock_returnid`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `tbl_stockreturn`
--

INSERT INTO `tbl_stockreturn` (`stock_returnid`, `stock_receivedperson`, `stock_recdate`, `stock_supplier`, `stock_desc`, `stock_retdate`, `stock_retby`, `stock_finished`, `stock_receiveid`, `invoice_number`) VALUES
(3, 'KL Lawingco', '2016-11-07 00:00:00', 'CTI', '', '2016-11-07 10:05:47', 1, 1, 3, 12);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_stockrqitems`
--

CREATE TABLE IF NOT EXISTS `tbl_stockrqitems` (
  `stockrq_id` int(11) NOT NULL AUTO_INCREMENT,
  `stock_itemcode` varchar(50) NOT NULL,
  `stock_itemid` int(11) NOT NULL,
  `stock_itemname` varchar(250) NOT NULL,
  `stock_qty` int(11) NOT NULL,
  `stock_requestid` int(11) NOT NULL,
  PRIMARY KEY (`stockrq_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `tbl_stockrqitems`
--

INSERT INTO `tbl_stockrqitems` (`stockrq_id`, `stock_itemcode`, `stock_itemid`, `stock_itemname`, `stock_qty`, `stock_requestid`) VALUES
(1, 'asdasd', 20, 'asd', 20, 15);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_stockrtitems`
--

CREATE TABLE IF NOT EXISTS `tbl_stockrtitems` (
  `stockrtid` int(11) NOT NULL AUTO_INCREMENT,
  `stock_itemcode` varchar(80) NOT NULL,
  `stock_itemid` int(11) NOT NULL,
  `stock_itemname` varchar(250) NOT NULL,
  `stock_rc_qty` int(11) NOT NULL,
  `stock_rt_qty` int(11) NOT NULL,
  `stock_retdate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `stock_returnid` int(11) NOT NULL,
  PRIMARY KEY (`stockrtid`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `tbl_stockrtitems`
--

INSERT INTO `tbl_stockrtitems` (`stockrtid`, `stock_itemcode`, `stock_itemid`, `stock_itemname`, `stock_rc_qty`, `stock_rt_qty`, `stock_retdate`, `stock_returnid`) VALUES
(2, 'asd', 1, '20', 20, 1, '2016-11-07 10:05:48', 3);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_supplier`
--

CREATE TABLE IF NOT EXISTS `tbl_supplier` (
  `supp_id` int(11) NOT NULL AUTO_INCREMENT,
  `supp_name` varchar(250) NOT NULL,
  `supp_address` varchar(250) NOT NULL,
  `supp_contact` varchar(250) NOT NULL,
  PRIMARY KEY (`supp_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `tbl_supplier`
--

INSERT INTO `tbl_supplier` (`supp_id`, `supp_name`, `supp_address`, `supp_contact`) VALUES
(1, 'CTI', 'Manhattan', 'Aya Brea');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_tempor`
--

CREATE TABLE IF NOT EXISTS `tbl_tempor` (
  `tem_id` int(11) NOT NULL AUTO_INCREMENT,
  `or_number_ref` varchar(250) NOT NULL,
  `insert_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`tem_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `tbl_tempor`
--

INSERT INTO `tbl_tempor` (`tem_id`, `or_number_ref`, `insert_date`) VALUES
(4, '56', '2017-06-21 12:53:05');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_transactionlog`
--

CREATE TABLE IF NOT EXISTS `tbl_transactionlog` (
  `translog_id` int(11) NOT NULL AUTO_INCREMENT,
  `customer_id` int(11) NOT NULL,
  `purchase_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `total_purchased` decimal(10,0) NOT NULL,
  `emp_id` int(11) NOT NULL,
  `or_number` varchar(250) NOT NULL,
  `void` int(11) NOT NULL,
  `total_qty` int(11) NOT NULL,
  PRIMARY KEY (`translog_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=30 ;

--
-- Dumping data for table `tbl_transactionlog`
--

INSERT INTO `tbl_transactionlog` (`translog_id`, `customer_id`, `purchase_date`, `total_purchased`, `emp_id`, `or_number`, `void`, `total_qty`) VALUES
(8, 0, '2016-11-06 16:48:39', '44', 1, '5', 0, 0),
(9, 0, '2016-11-06 16:50:13', '42', 1, '6', 0, 0),
(12, 0, '2016-11-06 16:58:54', '147', 1, '7', 0, 0),
(16, 0, '2016-11-06 17:10:25', '21', 1, '8', 1, 0),
(17, 0, '2016-11-07 13:09:03', '42', 1, '9', 0, 0),
(18, 2, '2016-11-07 13:14:54', '21', 1, '10', 0, 0),
(19, 1, '2016-11-08 19:08:19', '42', 1, '18', 0, 2),
(20, 4, '2016-11-10 13:45:42', '21', 5, '26', 1, 1),
(21, 0, '2016-11-12 13:38:19', '0', 0, '0', 0, 0),
(23, 0, '2016-11-12 17:07:10', '42', 1, 'WWW', 0, 2),
(24, 0, '2016-11-12 17:18:21', '21', 1, '23', 0, 1),
(25, 0, '2016-11-12 17:36:14', '42', 1, '12', 0, 2),
(26, 0, '2016-11-12 17:42:24', '21', 1, '45', 0, 1),
(27, 0, '2016-11-12 17:45:58', '42', 1, '34', 0, 2),
(28, 0, '2016-11-12 17:48:46', '0', 0, '', 0, 0),
(29, 0, '2016-11-12 17:49:55', '21', 1, '1', 0, 1);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_transactions`
--

CREATE TABLE IF NOT EXISTS `tbl_transactions` (
  `trans_id` int(11) NOT NULL AUTO_INCREMENT,
  `customer_id` int(11) NOT NULL,
  `translog_id` int(11) NOT NULL,
  `item_name` varchar(200) NOT NULL,
  `item_price` decimal(10,0) NOT NULL,
  `item_qty_bought` int(11) NOT NULL,
  `total_amt` decimal(10,0) NOT NULL,
  `bought_period` varchar(10) NOT NULL,
  `bought_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`trans_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=35 ;

--
-- Dumping data for table `tbl_transactions`
--

INSERT INTO `tbl_transactions` (`trans_id`, `customer_id`, `translog_id`, `item_name`, `item_price`, `item_qty_bought`, `total_amt`, `bought_period`, `bought_date`) VALUES
(5, 0, 8, 'asd', '21', 1, '21', '11-16', '2016-11-06 16:48:42'),
(6, 0, 8, 'asd', '21', 1, '21', '11-16', '2016-11-06 16:48:42'),
(7, 0, 8, 'z', '2', 1, '2', '11-16', '2016-11-06 16:48:42'),
(8, 0, 9, 'asd', '21', 2, '42', '11-16', '2016-11-06 16:50:16'),
(9, 0, 12, 'asd', '21', 1, '21', '11-16', '2016-11-06 16:58:58'),
(10, 0, 12, 'asd', '21', 1, '21', '11-16', '2016-11-06 16:58:58'),
(11, 0, 12, 'asd', '21', 1, '21', '11-16', '2016-11-06 16:58:58'),
(12, 0, 12, 'asd', '21', 1, '21', '11-16', '2016-11-06 16:58:58'),
(13, 0, 12, 'asd', '21', 1, '21', '11-16', '2016-11-06 16:58:58'),
(14, 0, 12, 'asd', '21', 1, '21', '11-16', '2016-11-06 16:58:58'),
(15, 0, 12, 'asd', '21', 1, '21', '11-16', '2016-11-06 16:58:58'),
(16, 0, 16, 'asd', '21', 1, '21', '11-16', '2016-11-06 17:10:46'),
(17, 0, 17, 'asd', '21', 1, '21', '11-16', '2016-11-07 13:09:06'),
(18, 0, 17, 'asd', '21', 1, '21', '11-16', '2016-11-07 13:09:06'),
(19, 2, 18, 'asd', '21', 1, '21', '11-16', '2016-11-07 13:15:00'),
(20, 1, 19, 'asd', '21', 1, '21', '11-16', '2016-11-08 19:08:24'),
(21, 1, 19, 'asd', '21', 1, '21', '11-16', '2016-11-08 19:08:24'),
(22, 4, 20, 'asd', '21', 1, '21', '11-16', '2016-11-10 13:45:46'),
(23, 0, 22, 'z', '2', 1, '2', '11-16', '2016-11-12 17:05:01'),
(24, 0, 23, 'asd', '21', 1, '21', '11-16', '2016-11-12 17:07:10'),
(25, 0, 23, 'asd', '21', 1, '21', '11-16', '2016-11-12 17:07:10'),
(26, 0, 24, 'asd', '21', 1, '21', '11-16', '2016-11-12 17:18:21'),
(27, 0, 25, 'asd', '21', 1, '21', '11-16', '2016-11-12 17:36:14'),
(28, 0, 25, 'asd', '21', 1, '21', '11-16', '2016-11-12 17:36:14'),
(29, 0, 26, 'asd', '21', 1, '21', '11-16', '2016-11-12 17:42:24'),
(30, 0, 27, 'asd', '21', 1, '21', '11-16', '2016-11-12 17:45:58'),
(31, 0, 27, 'asd', '21', 1, '21', '11-16', '2016-11-12 17:45:58'),
(34, 0, 29, 'asd', '21', 1, '21', '11-16', '2016-11-12 17:49:56');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_user`
--

CREATE TABLE IF NOT EXISTS `tbl_user` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(100) NOT NULL,
  `userpass` varchar(100) NOT NULL,
  `user_fullname` varchar(200) NOT NULL,
  `admin_priv` int(11) NOT NULL,
  `date_created` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `active` int(11) NOT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `tbl_user`
--

INSERT INTO `tbl_user` (`user_id`, `username`, `userpass`, `user_fullname`, `admin_priv`, `date_created`, `active`) VALUES
(1, 'kl', 'pass', 'KL Lawingco', 1, '2016-11-05 14:28:58', 1),
(5, 'gumi', 'pass', 'Gumi Megpoid', 1, '2016-11-10 00:00:00', 1),
(6, 'kap', 'pass', 'lap', 0, '2016-11-12 00:00:00', 1);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_useraccessrights`
--

CREATE TABLE IF NOT EXISTS `tbl_useraccessrights` (
  `u_id` int(11) NOT NULL AUTO_INCREMENT,
  `emp_id` int(11) NOT NULL,
  `mem_module` int(11) NOT NULL,
  `mem_newmem` int(11) NOT NULL,
  `mem_record` int(11) NOT NULL,
  `pos_module` int(11) NOT NULL,
  `pos_register` int(11) NOT NULL,
  `pos_savedsales` int(11) NOT NULL,
  `pos_refunds` int(11) NOT NULL,
  `pos_endday` int(11) NOT NULL,
  `pos_endweek` int(11) NOT NULL,
  `pos_transhis` int(11) NOT NULL,
  `inv_module` int(11) NOT NULL,
  `inv_enteritems` int(11) NOT NULL,
  `stocks_submod` int(11) NOT NULL,
  `stocks_req` int(11) NOT NULL,
  `stocks_rec` int(11) NOT NULL,
  `stocks_ret` int(11) NOT NULL,
  `inv_itemlist` int(11) NOT NULL,
  `inv_report` int(11) NOT NULL,
  `col_module` int(11) NOT NULL,
  `col_loans` int(11) NOT NULL,
  `col_deposit` int(11) NOT NULL,
  `col_loanmoney` int(11) NOT NULL,
  `col_loanpay` int(11) NOT NULL,
  `col_moneycounter` int(11) NOT NULL,
  `rep_module` int(11) NOT NULL,
  `rep_mem` int(11) NOT NULL,
  `rep_inventory` int(11) NOT NULL,
  `rep_sales` int(11) NOT NULL,
  `rep_purchases` int(11) NOT NULL,
  `rep_loans` int(11) NOT NULL,
  `rep_trans` int(11) NOT NULL,
  `rep_pay` int(11) NOT NULL,
  `rep_listrep` int(11) NOT NULL,
  `payroll_module` int(11) NOT NULL,
  `misc_module` int(11) NOT NULL,
  `misc_uaccess` int(11) NOT NULL,
  `misc_audit` int(11) NOT NULL,
  `misc_loancal` int(11) NOT NULL,
  PRIMARY KEY (`u_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `tbl_useraccessrights`
--

INSERT INTO `tbl_useraccessrights` (`u_id`, `emp_id`, `mem_module`, `mem_newmem`, `mem_record`, `pos_module`, `pos_register`, `pos_savedsales`, `pos_refunds`, `pos_endday`, `pos_endweek`, `pos_transhis`, `inv_module`, `inv_enteritems`, `stocks_submod`, `stocks_req`, `stocks_rec`, `stocks_ret`, `inv_itemlist`, `inv_report`, `col_module`, `col_loans`, `col_deposit`, `col_loanmoney`, `col_loanpay`, `col_moneycounter`, `rep_module`, `rep_mem`, `rep_inventory`, `rep_sales`, `rep_purchases`, `rep_loans`, `rep_trans`, `rep_pay`, `rep_listrep`, `payroll_module`, `misc_module`, `misc_uaccess`, `misc_audit`, `misc_loancal`) VALUES
(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
(2, 5, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(3, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_voidreceipt`
--

CREATE TABLE IF NOT EXISTS `tbl_voidreceipt` (
  `void_id` int(11) NOT NULL AUTO_INCREMENT,
  `receipttovoid_or` int(11) NOT NULL,
  `void_reason` varchar(250) NOT NULL,
  `void_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `emp_id` int(11) NOT NULL,
  PRIMARY KEY (`void_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `tbl_voidreceipt`
--

INSERT INTO `tbl_voidreceipt` (`void_id`, `receipttovoid_or`, `void_reason`, `void_date`, `emp_id`) VALUES
(2, 8, 'Expired', '2016-11-06 18:24:55', 1),
(3, 26, 'nagbago isip', '2016-11-10 13:47:01', 1);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_withdraw`
--

CREATE TABLE IF NOT EXISTS `tbl_withdraw` (
  `with_id` int(11) NOT NULL AUTO_INCREMENT,
  `customer_id` int(11) NOT NULL,
  `process_by` int(11) NOT NULL,
  `process_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `withdraw` decimal(10,0) NOT NULL,
  `or_num` int(11) NOT NULL,
  PRIMARY KEY (`with_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=15 ;

--
-- Dumping data for table `tbl_withdraw`
--

INSERT INTO `tbl_withdraw` (`with_id`, `customer_id`, `process_by`, `process_date`, `withdraw`, `or_num`) VALUES
(2, 2, 1, '2016-11-05 13:43:01', '25', 0),
(3, 2, 1, '2016-11-05 13:45:06', '25', 0),
(8, 6, 1, '2016-11-05 16:21:10', '10', 0),
(11, 6, 1, '2016-11-05 16:27:04', '15', 0),
(12, 1, 1, '2016-11-09 16:06:39', '8', 0),
(13, 2, 1, '2016-11-09 16:51:28', '5', 0),
(14, 2, 1, '2016-11-10 12:02:23', '5', 25);

DELIMITER $$
--
-- Events
--
CREATE DEFINER=`root`@`localhost` EVENT `delete_tempEvent` ON SCHEDULE EVERY 30 MINUTE STARTS '2016-11-12 17:00:00' ON COMPLETION PRESERVE ENABLE DO DELETE FROM tbl_tempor WHERE TIMESTAMPDIFF(MINUTE,insert_date, NOW()) > 30$$

DELIMITER ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
