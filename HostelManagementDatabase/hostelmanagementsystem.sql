-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 22, 2021 at 06:16 AM
-- Server version: 10.4.17-MariaDB
-- PHP Version: 8.0.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hostelmanagementsystem`
--

-- --------------------------------------------------------

--
-- Table structure for table `customerrequest`
--

CREATE TABLE `customerrequest` (
  `ID` int(11) NOT NULL,
  `RequestTitle` varchar(50) NOT NULL,
  `Status` text NOT NULL,
  `Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `customerrequest`
--

INSERT INTO `customerrequest` (`ID`, `RequestTitle`, `Status`, `Date`) VALUES
(10340, 'Payment Unsuccesful', 'Pending', '2021-01-12'),
(10341, 'Inquiry on Room J-5-12', 'Pending', '2021-01-11'),
(10342, 'Payment Unsuccesful', 'Pending', '2021-01-10'),
(10343, 'How to Pay with Cheque?', 'Pending', '2021-01-09'),
(10344, 'Electricity & Water Rates', 'Pending', '2021-01-08'),
(10345, 'Amenities Available with Hostel', 'Pending', '2021-01-07'),
(10346, 'Payment Unsuccessful', 'Active', '2021-01-06'),
(10347, 'How to Pay with Cheque?', 'Active', '2021-01-05'),
(10348, 'Electricity & Water Rates', 'Active', '2021-01-04'),
(10349, 'Amenities Available with Hostel', 'Active', '2021-01-03'),
(10350, 'Payment Unsuccessful', 'Resolved', '2021-01-02'),
(10351, 'Inquiry on Room J-2-6', 'Resolved', '2021-01-01'),
(10352, 'Payment Unsuccessful', 'Resolved', '2020-12-31');

-- --------------------------------------------------------

--
-- Table structure for table `room`
--

CREATE TABLE `room` (
  `ID` int(11) NOT NULL,
  `Size` varchar(50) NOT NULL,
  `Description` text NOT NULL,
  `Vacancy` tinyint(1) NOT NULL,
  `Price` int(11) NOT NULL,
  `Image` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `room`
--

INSERT INTO `room` (`ID`, `Size`, `Description`, `Vacancy`, `Price`, `Image`) VALUES
(1, 'Medium', 'Fit for anyone that wants to have enough space to rule them all!', 0, 69, 'http://localhost/HostelManagementSystem/RoomImages/1.jpg'),
(2, 'Big', 'A big room to party but not during the pandemic!', 0, 420, 'http://localhost/HostelManagementSystem/RoomImages/2.jpg'),
(3, 'Small', 'Small, fit for a Japanese!', 0, 21, 'http://localhost/HostelManagementSystem/RoomImages/3.jpg'),
(4, 'Small', 'What is this? A room for ants?', 0, 13, 'http://localhost/HostelManagementSystem/RoomImages/4.jpg'),
(5, 'Big', 'Looks like a massive mansion!', 1, 512, 'http://localhost/HostelManagementSystem/RoomImages/5.jpg'),
(6, 'Medium', 'Fit to handle 4 people!', 0, 128, 'http://localhost/HostelManagementSystem/RoomImages/6.jpg'),
(7, 'Medium', 'This is the perfect size for you and me.', 0, 666, 'http://localhost/HostelManagementSystem/RoomImages/7.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `ID` int(11) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(256) NOT NULL,
  `isStaff` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`ID`, `Username`, `Password`, `isStaff`) VALUES
(1, 'test', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 0),
(13, 'cats', '28ef3c76c9d38b82469d448b6fadb20e35e5964af4514770761ac718613ff917', 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `customerrequest`
--
ALTER TABLE `customerrequest`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `room`
--
ALTER TABLE `room`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `customerrequest`
--
ALTER TABLE `customerrequest`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10353;

--
-- AUTO_INCREMENT for table `room`
--
ALTER TABLE `room`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
