-- MariaDB dump 10.19  Distrib 10.4.28-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: kindergarten
-- ------------------------------------------------------
-- Server version	10.4.28-MariaDB

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
-- Current Database: `kindergarten`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `kindergarten` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;

USE `kindergarten`;

--
-- Table structure for table `children`
--

DROP TABLE IF EXISTS `children`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `children` (
  `ID_c` int(11) NOT NULL,
  `Surname` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `SName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Born` date NOT NULL,
  `Adress` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `G_Name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`ID_c`),
  KEY `children_ibfk_1` (`G_Name`),
  CONSTRAINT `children_ibfk_1` FOREIGN KEY (`G_Name`) REFERENCES `groups` (`Name`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `children`
--

LOCK TABLES `children` WRITE;
/*!40000 ALTER TABLE `children` DISABLE KEYS */;
INSERT INTO `children` VALUES (5,'Войцехов','Олексій','Олександрович','2018-02-15','Петровского','Веселк'),(6,'Волошко','Маруся','Іванівна','2017-08-13','Київська 27','Веселк'),(7,'Волошина','Маруся','Іванівна','2017-08-13','Київська 24','Веселк'),(8,'Тест','Тест','Тестович','2021-03-12','Тестовая','Пролісок'),(9,'Романюк','Антон','Павлович','2021-04-12','вул. Набережна 7','Волошко');
/*!40000 ALTER TABLE `children` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `groups`
--

DROP TABLE IF EXISTS `groups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `groups` (
  `Name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `MaxClindren` int(11) NOT NULL,
  `MinYear` int(11) NOT NULL,
  `MaxYear` int(11) NOT NULL,
  `Schedule` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ID_k` int(11) NOT NULL,
  PRIMARY KEY (`Name`),
  KEY `groups_ibfk_1` (`ID_k`),
  CONSTRAINT `groups_ibfk_1` FOREIGN KEY (`ID_k`) REFERENCES `kindergartener` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `groups`
--

LOCK TABLES `groups` WRITE;
/*!40000 ALTER TABLE `groups` DISABLE KEYS */;
INSERT INTO `groups` VALUES ('Барвінок',2,1,3,'Вечірня',5),('Березка',25,1,3,'Вечірня',7),('Веселк',25,3,6,'Денна',1),('Веселка',1,3,5,'Вечірня',1),('Волошко',3,1,3,'Вечірня',8),('Мавпа',12,1,2,'Вечірня',9),('Попугай',2,1,6,'Денна',5),('Пролісок',1,1,3,'Вечірня',7),('Сонечко',21,1,3,'Денна',2);
/*!40000 ALTER TABLE `groups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kindergartener`
--

DROP TABLE IF EXISTS `kindergartener`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `kindergartener` (
  `ID` int(11) NOT NULL,
  `Surname` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `SName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Born` date NOT NULL,
  `Adress` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Number` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Work` date NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kindergartener`
--

LOCK TABLES `kindergartener` WRITE;
/*!40000 ALTER TABLE `kindergartener` DISABLE KEYS */;
INSERT INTO `kindergartener` VALUES (1,'Іванюк','Іванна','Іванівна','2000-10-12','Петрова 2','0967801450','2023-04-09'),(2,'Петрова','Анна','Ивановна','1970-10-05','Беля 33/5','0991337174','2015-04-09'),(5,'Сидоренко','Светлана','Сергеевна','1981-08-24','Шолохова 2/130','0501235698','2000-04-09'),(7,'Сватова','Ірина','Василівна','1990-05-13','Пушкіна 8/9','0961785209','2015-04-18'),(8,'Іванова','Олеся','Іванівна','1999-03-14','вул.Пастера 4.','0981702423','2023-05-17'),(9,'Тест','Тест','Тест1','2000-06-12','Тест','0961758487','2023-05-24');
/*!40000 ALTER TABLE `kindergartener` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `parent`
--

DROP TABLE IF EXISTS `parent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `parent` (
  `ID` int(11) NOT NULL,
  `Surname` varchar(50) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `SName` varchar(50) NOT NULL,
  `Adress` varchar(50) NOT NULL,
  `Number` varchar(10) NOT NULL,
  `Email` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `parent`
--

LOCK TABLES `parent` WRITE;
/*!40000 ALTER TABLE `parent` DISABLE KEYS */;
INSERT INTO `parent` VALUES (0,'Сорок','Надія','Олександрівна','Беляєва 4/23','096175024',''),(1,'Войцехов','Максим','Олександрович','Беляєва 4/23','0991788584','voytcehov1@gmail.com'),(2,'Войцехов','Микола','Олександрович','Беляєва 4/23','096175024',''),(4,'Павлюк','Ганна','Петрівна','Беляєва 4/23','096175024',''),(5,'Кульміна','Дарина','Віталіївна','пр. Європи 28/85','0961240117','kylmina@gmail.com'),(6,'gffdgfgfd','fdgdfgdf','dfgdgdf','dfgdfg','0991337174','');
/*!40000 ALTER TABLE `parent` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pclind`
--

DROP TABLE IF EXISTS `pclind`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pclind` (
  `ID_PC` int(11) NOT NULL,
  `ID_P` int(11) NOT NULL,
  `ID_C` int(11) NOT NULL,
  PRIMARY KEY (`ID_PC`),
  KEY `ID_P` (`ID_P`),
  KEY `ID_C` (`ID_C`),
  CONSTRAINT `pclind_ibfk_1` FOREIGN KEY (`ID_P`) REFERENCES `parent` (`ID`),
  CONSTRAINT `pclind_ibfk_2` FOREIGN KEY (`ID_C`) REFERENCES `children` (`ID_c`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pclind`
--

LOCK TABLES `pclind` WRITE;
/*!40000 ALTER TABLE `pclind` DISABLE KEYS */;
INSERT INTO `pclind` VALUES (3,2,5),(4,1,7),(5,6,8),(6,6,9);
/*!40000 ALTER TABLE `pclind` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pqueue`
--

DROP TABLE IF EXISTS `pqueue`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pqueue` (
  `ID_PQ` int(11) NOT NULL,
  `ID_P` int(11) NOT NULL,
  `ID_Q` int(11) NOT NULL,
  PRIMARY KEY (`ID_PQ`),
  KEY `ID_P` (`ID_P`),
  KEY `ID_Q` (`ID_Q`),
  CONSTRAINT `pqueue_ibfk_1` FOREIGN KEY (`ID_P`) REFERENCES `parent` (`ID`),
  CONSTRAINT `pqueue_ibfk_2` FOREIGN KEY (`ID_Q`) REFERENCES `queue` (`ID_Q`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pqueue`
--

LOCK TABLES `pqueue` WRITE;
/*!40000 ALTER TABLE `pqueue` DISABLE KEYS */;
INSERT INTO `pqueue` VALUES (1,0,1);
/*!40000 ALTER TABLE `pqueue` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `queue`
--

DROP TABLE IF EXISTS `queue`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `queue` (
  `ID_Q` int(11) NOT NULL,
  `Surname` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `SName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Born` date NOT NULL,
  `Adress` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`ID_Q`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `queue`
--

LOCK TABLES `queue` WRITE;
/*!40000 ALTER TABLE `queue` DISABLE KEYS */;
INSERT INTO `queue` VALUES (1,'Сидоров','Сидр','Сидорович','2021-05-08','вул. Шідддта 6969');
/*!40000 ALTER TABLE `queue` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'kindergarten'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-03 20:21:18
