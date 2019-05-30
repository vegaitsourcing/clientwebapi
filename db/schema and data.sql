-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: clientdb
-- ------------------------------------------------------
-- Server version	5.7.22-log

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

CREATE DATABASE `clientdb` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `clientdb` ;

--
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `client` (
  `ClientId` char(36) NOT NULL,
  `ClientName` varchar(60) NOT NULL,
  `Email` varchar(60) NOT NULL,
  `FirstName` varchar(60) NOT NULL,
  `LastName` varchar(60) NOT NULL,
  `PhoneNo` varchar(60) NOT NULL,
  `MobileNo` varchar(60) NOT NULL,
  `StreetAddr` varchar(100) NOT NULL,
  `City` varchar(60) NOT NULL,
  `State` varchar(60) NOT NULL,
  `Country` varchar(60) NOT NULL,
  `Industry` varchar(60) NOT NULL,
  `Description` varchar(200) NOT NULL,
  PRIMARY KEY (`ClientId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` VALUES ('33d8d56a-2a5e-33f1-97db-cb587ac01ca3','consequuntur','mwunsch@example.com','Cary','Kozey','(929)474-8796x3273','870-593-3300x409','0640 Yost Centers Apt. 968','Langburgh','Georgia','512','Reactive didactic interface','Delectus quaerat dolore magnam voluptas placeat voluptatibus corrupti. Iste iste animi in deleniti consectetur fuga omnis sint. Temporibus fugit rerum quia at ea quasi ratione.'),('4a1ad511-6852-34e1-b6a4-c7aaacd3d210','quo','bradtke.carey@example.com','Jana','Sipes','382.659.2744','435-359-2170x74897','5742 McDermott Crossroad Apt. 535','Kaydenton','Kansas','80763443','Triple-buffered foreground synergy','Sapiente eum sapiente cum qui odio. Quis dolores ad qui tenetur atque.'),('74c0ac5e-f14f-3722-9dee-8972e5a903a9','molestiae','morar.brittany@example.net','Marquise','Tromp','1-609-065-5203x5812','(456)360-5032','341 Trantow Highway','New Ellsworth','Nebraska','45','Multi-layered coherent help-desk','Nihil amet officia enim vel nisi quisquam. Facilis dolores blanditiis debitis veniam quaerat. Qui ipsam porro laborum consequatur. Tempora voluptatem minus sequi nemo magnam.'),('7d57951e-bb5a-36ef-ab32-eb6c88c03445','labore','ukessler@example.net','Benny','Donnelly','1-057-951-2779x1737','210.892.2943x90068','198 Muller Shoals Apt. 426','East Liaville','NewMexico','602','Cloned optimal structure','Nisi id et sint omnis dolore dolor. Asperiores laudantium ut necessitatibus corrupti deserunt non fugit. Aut ipsum et quod quibusdam. Ut aut sit dignissimos suscipit aperiam at quia inventore.'),('9ca91f15-fbe3-3f34-a61d-94cc950797e8','sit','wilfredo.o\'connell@example.net','Irma','Orn','741-756-9292x3408','(295)768-2353','46852 Yasmin Drive Suite 665','New Anika','RhodeIsland','180','Public-key bi-directional model','Dolorem quia aut est exercitationem fugiat. Fuga earum cupiditate sed sunt. Quo debitis quo autem commodi perspiciatis.'),('c54fc1ef-5ca2-3614-85fe-a3d452008155','consectetur','sporer.rey@example.org','Rex','Oberbrunner','416.117.1478','074-136-7996x532','02726 Hahn Centers','East Toneyshire','NorthCarolina','327','Down-sized upward-trending intranet','Atque et atque tenetur et aut delectus. Et adipisci consequatur qui non aliquam magni. Ab ad libero aut nobis minima natus ad. Expedita soluta in autem illum blanditiis occaecati.'),('ddb95a3a-9e40-3155-9b29-2f08ff259fae','dolor','twill@example.net','Tiara','Torphy','046-537-1171','(680)916-5268x887','233 Jerde Expressway Apt. 000','Tryciaton','California','22404','Object-based intermediate definition','Deleniti dolorem porro provident ut non dolor facere. Quia accusamus aspernatur beatae illum. Aspernatur reprehenderit amet et rerum ullam. Quo voluptas enim voluptatem.');
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `UserId` char(36) NOT NULL,
  `Username` varchar(30) NOT NULL,
  `HashedPassword` varchar(100) NOT NULL,
  `Salt` varchar(100) NOT NULL,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES ('18ac3da7-31a2-4182-aa17-bb5363f95817','test','uVXqKm5PGw2rxJo9LNo/T7PwKMbnGNQJ28RcO64+J2Y=','57969A668CF6321621ABA94462BC2'),('e1619ca7-e79d-4e02-81b9-2770d4da9263','admin','tKZwEKzmT5GBCck9WWulYxPouUeNqud+pweOCc2r0JY=','61ACCEE867A4AB7A8F8A8DBAFE5D1');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-05-30 14:06:11
