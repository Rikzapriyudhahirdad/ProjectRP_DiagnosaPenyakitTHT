-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 12, 2017 at 04:20 AM
-- Server version: 10.1.21-MariaDB
-- PHP Version: 5.6.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `diagnosatht`
--

-- --------------------------------------------------------

--
-- Table structure for table `basis_pengetahuan`
--

CREATE TABLE `basis_pengetahuan` (
  `kode_gejalapenyakit` varchar(6) NOT NULL,
  `kode_penyakit` varchar(4) NOT NULL,
  `kode_gejala` varchar(4) NOT NULL,
  `jumlah` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `basis_pengetahuan`
--

INSERT INTO `basis_pengetahuan` (`kode_gejalapenyakit`, `kode_penyakit`, `kode_gejala`, `jumlah`) VALUES
('GP001', 'P1', 'G3', 3),
('GP002', 'P1', 'G16', 4),
('GP003', 'P1', 'G22', 4),
('GP004', 'P2', 'G2', 7),
('GP005', 'P2', 'G4', 7),
('GP006', 'P2', 'G6', 8),
('GP007', 'P2', 'G15', 7),
('GP008', 'P3', 'G7', 8),
('GP009', 'P3', 'G10', 7),
('GP010', 'P3', 'G12', 8),
('GP011', 'P3', 'G13', 8),
('GP012', 'P4', 'G1', 17),
('GP013', 'P4', 'G11', 16),
('GP014', 'P4', 'G14', 17),
('GP015', 'P4', 'G20', 16),
('GP016', 'P4', 'G21', 15),
('GP017', 'P5', 'G1', 15),
('GP018', 'P5', 'G8', 16),
('GP019', 'P5', 'G12', 16),
('GP020', 'P5', 'G17', 16),
('GP021', 'P5', 'G20', 16),
('GP022', 'P6', 'G4', 15),
('GP023', 'P6', 'G5', 16),
('GP024', 'P6', 'G9', 15),
('GP025', 'P6', 'G18', 15),
('GP026', 'P6', 'G19', 14),
('GP027', 'P7', 'G3', 4),
('GP028', 'P7', 'G16', 2),
('GP029', 'P7', 'G22', 8),
('GP030', 'P7', 'G23', 8);

-- --------------------------------------------------------

--
-- Table structure for table `gejala`
--

CREATE TABLE `gejala` (
  `kode_gejala` varchar(4) NOT NULL,
  `nama_gejala` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `gejala`
--

INSERT INTO `gejala` (`kode_gejala`, `nama_gejala`) VALUES
('G1', 'Badan Panas'),
('G10', 'Nyeri Kepala'),
('G11', 'Nyeri Leher'),
('G12', 'Nyeri Waktu Menelan'),
('G13', 'Tenggorokan Panas'),
('G14', 'Leher Bengkak'),
('G15', 'Penciuman Terganggu'),
('G16', 'Pendengaran Menurun'),
('G17', 'Pusing'),
('G18', 'Pilek Menahun'),
('G19', 'Sakit Kepala'),
('G2', 'Bersin'),
('G20', 'Sesak Nafas'),
('G21', 'Sulit Buka Mulut'),
('G22', 'Telinga Terasa Penuh Cairan'),
('G23', 'Nyeri Telinga'),
('G3', 'Telinga Berdengung'),
('G4', 'Hidung Buntu'),
('G5', 'Ingus Darah'),
('G6', 'Iritasi Hidung'),
('G7', 'Tenggorokan Kering'),
('G8', 'Leher Kaku'),
('G9', 'Mata Juling');

-- --------------------------------------------------------

--
-- Table structure for table `penderita`
--

CREATE TABLE `penderita` (
  `kode_penderita` varchar(6) NOT NULL,
  `nama` text NOT NULL,
  `tgl_lahir` date NOT NULL,
  `jenis_kelamin` text NOT NULL,
  `usia` int(30) NOT NULL,
  `alamat` varchar(200) NOT NULL,
  `pekerjaan` varchar(100) NOT NULL,
  `kode_penyakit` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `penderita`
--

INSERT INTO `penderita` (`kode_penderita`, `nama`, `tgl_lahir`, `jenis_kelamin`, `usia`, `alamat`, `pekerjaan`, `kode_penyakit`) VALUES
('PS001', 'Jono', '1998-04-12', 'Laki-laki', 20, 'Malang', 'Mahasiswa', 'P4'),
('PS002', 'Darso', '1990-01-12', 'Perempuan', 40, 'Tulungagung', 'Buruh', 'P4'),
('PS003', 'Dodit', '1997-03-11', 'Laki-laki', 30, 'Malang', 'Guru', 'P4'),
('PS004', 'Caca', '1989-12-09', 'Perempuan', 30, 'Malang', 'wiraswasta', 'P2'),
('PS005', 'Loli', '1999-05-08', 'Perempuan', 19, 'Kediri', 'Mahasiswa', 'P4'),
('PS006', 'Doni', '2017-12-08', 'Laki-laki', 10, 'Malang', 'siswa', 'P4');

--
-- Triggers `penderita`
--
DELIMITER $$
CREATE TRIGGER `triger_penderita` BEFORE INSERT ON `penderita` FOR EACH ROW BEGIN
SET @hitung = CONVERT((RIGHT((SELECT kode_penderita FROM `penderita` ORDER by kode_penderita DESC LIMIT 1), 3)), UNSIGNED) + 1;
if (@hitung > 1) THEN
if (@hitung < 10) THEN 
SET new.kode_penderita = concat('PS00',@hitung);
ELSEIF (@hitung < 100) THEN
SET new.kode_penderita = concat('PS0',@hitung);
ELSE
SET new.kode_penderita = concat('PS',@hitung);
END IF;
END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `penyakit`
--

CREATE TABLE `penyakit` (
  `kode_penyakit` varchar(4) NOT NULL,
  `nama_penyakit` varchar(50) NOT NULL,
  `jumlah` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `penyakit`
--

INSERT INTO `penyakit` (`kode_penyakit`, `nama_penyakit`, `jumlah`) VALUES
('P1', 'Otitis Media Serosa', 7),
('P2', 'Polip Hidung', 13),
('P3', 'Faringitis Akut', 14),
('P4', 'Infeksi Leher Dalam', 30),
('P5', 'Abses Retrofaring', 30),
('P6', 'Karsinoma Nasofaring', 28),
('P7', 'Serumen Obsturan', 10);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `basis_pengetahuan`
--
ALTER TABLE `basis_pengetahuan`
  ADD PRIMARY KEY (`kode_gejalapenyakit`),
  ADD KEY `kode_penyakit` (`kode_penyakit`),
  ADD KEY `kode_gejala` (`kode_gejala`);

--
-- Indexes for table `gejala`
--
ALTER TABLE `gejala`
  ADD PRIMARY KEY (`kode_gejala`);

--
-- Indexes for table `penderita`
--
ALTER TABLE `penderita`
  ADD PRIMARY KEY (`kode_penderita`),
  ADD KEY `kode_penyakit` (`kode_penyakit`);

--
-- Indexes for table `penyakit`
--
ALTER TABLE `penyakit`
  ADD PRIMARY KEY (`kode_penyakit`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `basis_pengetahuan`
--
ALTER TABLE `basis_pengetahuan`
  ADD CONSTRAINT `basis_pengetahuan_ibfk_1` FOREIGN KEY (`kode_penyakit`) REFERENCES `penyakit` (`kode_penyakit`),
  ADD CONSTRAINT `basis_pengetahuan_ibfk_2` FOREIGN KEY (`kode_gejala`) REFERENCES `gejala` (`kode_gejala`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
