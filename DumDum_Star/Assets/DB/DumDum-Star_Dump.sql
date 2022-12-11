CREATE DATABASE  IF NOT EXISTS `dumdum_star` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `dumdum_star`;
-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: dumdum_star
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
-- Table structure for table `address`
--

DROP TABLE IF EXISTS `address`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `address` (
  `id` int NOT NULL AUTO_INCREMENT,
  `city` varchar(48) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `region` varchar(48) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `street` varchar(48) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `address`
--

LOCK TABLES `address` WRITE;
/*!40000 ALTER TABLE `address` DISABLE KEYS */;
INSERT INTO `address` VALUES (1,'Night-City','Watson','H8 MB'),(2,'Night-City','Watson','H9 MB'),(3,'Night-City','Northside','All Foods Mall'),(4,'Night City','North-Oak','HillTop');
/*!40000 ALTER TABLE `address` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `admin`
--

DROP TABLE IF EXISTS `admin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `admin` (
  `id` int NOT NULL AUTO_INCREMENT,
  `choom_id` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admin`
--

LOCK TABLES `admin` WRITE;
/*!40000 ALTER TABLE `admin` DISABLE KEYS */;
INSERT INTO `admin` VALUES (1,1);
/*!40000 ALTER TABLE `admin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `choom`
--

DROP TABLE IF EXISTS `choom`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `choom` (
  `id` int NOT NULL AUTO_INCREMENT,
  `login` varchar(32) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `password` varchar(48) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `mail_address` varchar(64) NOT NULL,
  `name` varchar(16) DEFAULT 'Choom',
  PRIMARY KEY (`id`),
  UNIQUE KEY `login` (`login`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `choom`
--

LOCK TABLES `choom` WRITE;
/*!40000 ALTER TABLE `choom` DISABLE KEYS */;
INSERT INTO `choom` VALUES (1,'Chrome','Chromazon','MoreChrome@nc.com','Dum-Dum'),(2,'SoloOfFortune','Master@Solo','solo-to-solo@nc.com','David'),(3,'SLHand','rock-live','fan-mail@nc.com','Johnny'),(4,'BH-Solo','solo-ruler-master-race','bh-mail@nc.com','Morgan');
/*!40000 ALTER TABLE `choom` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `client` (
  `id` int NOT NULL AUTO_INCREMENT,
  `choom_id` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` VALUES (1,2),(2,3),(3,4);
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `corporation`
--

DROP TABLE IF EXISTS `corporation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `corporation` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(64) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `monetary_value` decimal(18,2) DEFAULT NULL,
  `members` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `corporation_chk_1` CHECK ((`members` > 0))
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `corporation`
--

LOCK TABLES `corporation` WRITE;
/*!40000 ALTER TABLE `corporation` DISABLE KEYS */;
INSERT INTO `corporation` VALUES (1,'Arasaka',890000000000.00,595000),(2,'Militech',1200000000000.00,647000),(3,'Zetatech',NULL,12000),(4,'Techtronika Ltd.',NULL,NULL),(5,'Malorian Firearms, Inc',NULL,25000),(6,'Biotechnica',NULL,36256),(7,'Night Corporation',464000000000.00,38648);
/*!40000 ALTER TABLE `corporation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cyber_ware`
--

DROP TABLE IF EXISTS `cyber_ware`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cyber_ware` (
  `id` int NOT NULL AUTO_INCREMENT,
  `type_id` int DEFAULT NULL,
  `target_id` int DEFAULT NULL,
  `manufacturer_id` int DEFAULT NULL,
  `quantity` int NOT NULL,
  `custom` tinyint(1) NOT NULL DEFAULT '1',
  `name` varchar(64) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `price` decimal(9,2) NOT NULL,
  `load_level` float DEFAULT '0.05',
  PRIMARY KEY (`id`),
  KEY `type_limit_idx` (`type_id`),
  KEY `target_limit_idx` (`target_id`),
  KEY `manufacturer_limit_idx` (`manufacturer_id`),
  CONSTRAINT `manufacturer_limit` FOREIGN KEY (`manufacturer_id`) REFERENCES `corporation` (`id`),
  CONSTRAINT `target_limit` FOREIGN KEY (`target_id`) REFERENCES `cyber_ware_target` (`id`),
  CONSTRAINT `type_limit` FOREIGN KEY (`type_id`) REFERENCES `cyber_ware_type` (`id`),
  CONSTRAINT `cyber_ware_chk_1` CHECK ((`quantity` >= 0)),
  CONSTRAINT `cyber_ware_chk_2` CHECK ((`price` > 0))
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cyber_ware`
--

LOCK TABLES `cyber_ware` WRITE;
/*!40000 ALTER TABLE `cyber_ware` DISABLE KEYS */;
INSERT INTO `cyber_ware` VALUES (1,4,7,2,13,0,'Sandevistan Falcon MK5',43749.99,0.37),(2,4,7,1,4,0,'Hashishin Berserk MK1',894766.87,0.63),(3,2,2,4,1,0,'Eagle-Eye NK2',13479.99,0.15),(4,1,4,3,5,0,'Pain Editor \'StreetKid\' MK3',27899.99,0.15);
/*!40000 ALTER TABLE `cyber_ware` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cyber_ware_message`
--

DROP TABLE IF EXISTS `cyber_ware_message`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cyber_ware_message` (
  `id` int NOT NULL AUTO_INCREMENT,
  `author_id` int NOT NULL,
  `cyber_ware_id` int NOT NULL,
  `rank` float NOT NULL,
  `message` varchar(128) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `cyber_limit` (`cyber_ware_id`),
  KEY `author_limit_idx` (`author_id`),
  CONSTRAINT `author_limit` FOREIGN KEY (`author_id`) REFERENCES `choom` (`id`),
  CONSTRAINT `cyber_limit` FOREIGN KEY (`cyber_ware_id`) REFERENCES `cyber_ware` (`id`),
  CONSTRAINT `cyber_ware_message_chk_1` CHECK (((`rank` > 0) and (`rank` <= 5)))
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cyber_ware_message`
--

LOCK TABLES `cyber_ware_message` WRITE;
/*!40000 ALTER TABLE `cyber_ware_message` DISABLE KEYS */;
INSERT INTO `cyber_ware_message` VALUES (1,2,1,5,'This is the best implant, that have been released. EVER!');
/*!40000 ALTER TABLE `cyber_ware_message` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cyber_ware_target`
--

DROP TABLE IF EXISTS `cyber_ware_target`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cyber_ware_target` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(64) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cyber_ware_target`
--

LOCK TABLES `cyber_ware_target` WRITE;
/*!40000 ALTER TABLE `cyber_ware_target` DISABLE KEYS */;
INSERT INTO `cyber_ware_target` VALUES (1,'Frontal Cortex'),(2,'Ocular System'),(3,'Circulatory System'),(4,'Immune System'),(5,'Nervous System'),(6,'Integumentary System'),(7,'Operating System'),(8,'Skeleton'),(9,'Hands'),(10,'Arms'),(11,'Legs');
/*!40000 ALTER TABLE `cyber_ware_target` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cyber_ware_type`
--

DROP TABLE IF EXISTS `cyber_ware_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cyber_ware_type` (
  `id` int NOT NULL AUTO_INCREMENT,
  `type` varchar(48) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cyber_ware_type`
--

LOCK TABLES `cyber_ware_type` WRITE;
/*!40000 ALTER TABLE `cyber_ware_type` DISABLE KEYS */;
INSERT INTO `cyber_ware_type` VALUES (1,'Automatic'),(2,'Semi-Automatic'),(3,'Trigger'),(4,'Active');
/*!40000 ALTER TABLE `cyber_ware_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order`
--

DROP TABLE IF EXISTS `order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order` (
  `id` int NOT NULL AUTO_INCREMENT,
  `choom_id` int NOT NULL,
  `address_id` int NOT NULL,
  `chippin_time` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `choom_limit_idx` (`choom_id`),
  KEY `address_limit_idx` (`address_id`),
  CONSTRAINT `address_limit` FOREIGN KEY (`address_id`) REFERENCES `address` (`id`),
  CONSTRAINT `choom_limit` FOREIGN KEY (`choom_id`) REFERENCES `choom` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'dumdum_star'
--

--
-- Dumping routines for database 'dumdum_star'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-12-11 18:48:19
