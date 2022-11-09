-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: default
-- ------------------------------------------------------
-- Server version	8.0.31

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `location`
--

DROP TABLE IF EXISTS `location`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `location` (
  `locationId` int NOT NULL AUTO_INCREMENT,
  `locationName` varchar(45) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`locationId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `location`
--

LOCK TABLES `location` WRITE;
/*!40000 ALTER TABLE `location` DISABLE KEYS */;
INSERT INTO `location` VALUES (1,'Filial SP','Rua dos Marinheiros, 44'),(2,'Filiall MG','Rua dos Timbiras, 1913'),(3,'Filial SC','Rua Treze, 1277');
/*!40000 ALTER TABLE `location` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `meeting`
--

DROP TABLE IF EXISTS `meeting`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `meeting` (
  `meetingId` int NOT NULL AUTO_INCREMENT,
  `locationId` int NOT NULL,
  `roomId` int NOT NULL,
  `startDate` datetime NOT NULL,
  `endDate` datetime NOT NULL,
  `responsibleName` varchar(45) NOT NULL,
  `coffeeQuantity` int DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  `title` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`meetingId`),
  KEY `locationId_idx` (`locationId`),
  KEY `roomId_idx` (`roomId`),
  CONSTRAINT `location` FOREIGN KEY (`locationId`) REFERENCES `location` (`locationId`),
  CONSTRAINT `roomId` FOREIGN KEY (`roomId`) REFERENCES `room` (`roomId`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `meeting`
--

LOCK TABLES `meeting` WRITE;
/*!40000 ALTER TABLE `meeting` DISABLE KEYS */;
INSERT INTO `meeting` VALUES (1,1,1,'2022-11-01 13:00:00','2022-11-01 14:00:00','Romário',0,'Corrida de camelos','Jogo da velha'),(2,1,1,'2022-11-01 14:30:00','2022-11-01 15:30:00','Murilo',0,'Salada de Fruta','Retro'),(3,2,4,'2022-11-05 12:30:00','2022-11-01 01:30:00','Matheus',2,'Balde','Planning'),(4,2,6,'2022-11-07 16:30:00','2022-11-01 17:00:00','Nicolas',3,'Panela Enferrujada','Sprint 14'),(6,3,7,'2022-11-30 01:00:00','2022-10-30 02:01:00','aaaa',0,'Salsicha','Integração'),(7,3,7,'2022-11-30 09:00:00','2022-10-30 10:01:00','Roger',0,'Caramelo','Hora do Chá'),(8,2,5,'2022-11-15 11:00:00','2022-11-15 12:01:00','Marilia',0,'Centopeia','One on One'),(9,1,2,'2022-11-17 11:00:00','2022-11-17 13:00:00','Alberto',0,'Bife à Milenesa','Almoço'),(10,3,7,'2022-11-30 09:00:00','2022-10-30 12:01:00','Kayque',0,'Marreta','Check de engenharia');
/*!40000 ALTER TABLE `meeting` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `room`
--

DROP TABLE IF EXISTS `room`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `room` (
  `roomId` int NOT NULL,
  `roomName` varchar(45) DEFAULT NULL,
  `locationId` int DEFAULT NULL,
  PRIMARY KEY (`roomId`),
  KEY `locationId_idx` (`locationId`),
  CONSTRAINT `locationId` FOREIGN KEY (`locationId`) REFERENCES `location` (`locationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `room`
--

LOCK TABLES `room` WRITE;
/*!40000 ALTER TABLE `room` DISABLE KEYS */;
INSERT INTO `room` VALUES (1,'Sala de Reuniões 1',1),(2,'Sala de Reuniões 2',1),(3,'Sala de Lazer 1',1),(4,'Sala de Reuniões 1',2),(5,'Sala de Jogos 1',2),(6,'Sala de Reuniões Executivas',2),(7,'Sala de Reuniões (Grande)',3),(8,'Sala de Reuniões (pequena)',3);
/*!40000 ALTER TABLE `room` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-11-04 15:19:37
