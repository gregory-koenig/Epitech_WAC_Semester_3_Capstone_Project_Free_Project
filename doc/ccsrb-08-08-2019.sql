# ************************************************************
# Sequel Pro SQL dump
# Version 4541
#
# http://www.sequelpro.com/
# https://github.com/sequelpro/sequelpro
#
# Hôte: localhost (MySQL 5.7.21)
# Base de données: Ccsrb
# Temps de génération: 2019-08-08 14:34:30 +0000
# ************************************************************


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


# Affichage de la table __EFMigrationsHistory
# ------------------------------------------------------------

DROP TABLE IF EXISTS `__EFMigrationsHistory`;

CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES
	('20190731122345_CcsrbInit','2.2.6-servicing-10079');

/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;


# Affichage de la table Answers
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Answers`;

CREATE TABLE `Answers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `Answers` WRITE;
/*!40000 ALTER TABLE `Answers` DISABLE KEYS */;

INSERT INTO `Answers` (`Id`, `Name`)
VALUES
	(1,'answer');

/*!40000 ALTER TABLE `Answers` ENABLE KEYS */;
UNLOCK TABLES;


# Affichage de la table ArticleImages
# ------------------------------------------------------------

DROP TABLE IF EXISTS `ArticleImages`;

CREATE TABLE `ArticleImages` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ArticleId` int(11) NOT NULL,
  `ImageId` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `ArticleImages` WRITE;
/*!40000 ALTER TABLE `ArticleImages` DISABLE KEYS */;

INSERT INTO `ArticleImages` (`Id`, `ArticleId`, `ImageId`)
VALUES
	(1,1,1);

/*!40000 ALTER TABLE `ArticleImages` ENABLE KEYS */;
UNLOCK TABLES;


# Affichage de la table Articles
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Articles`;

CREATE TABLE `Articles` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` longtext,
  `Body` longtext,
  `Date` datetime(6) NOT NULL,
  `Active` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `Articles` WRITE;
/*!40000 ALTER TABLE `Articles` DISABLE KEYS */;

INSERT INTO `Articles` (`Id`, `Title`, `Body`, `Date`, `Active`)
VALUES
	(1,'CCSRB','abdc','2019-01-08 00:00:00.000000','true');

/*!40000 ALTER TABLE `Articles` ENABLE KEYS */;
UNLOCK TABLES;


# Affichage de la table ArticleTags
# ------------------------------------------------------------

DROP TABLE IF EXISTS `ArticleTags`;

CREATE TABLE `ArticleTags` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ArticleId` int(11) NOT NULL,
  `TagId` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `ArticleTags` WRITE;
/*!40000 ALTER TABLE `ArticleTags` DISABLE KEYS */;

INSERT INTO `ArticleTags` (`Id`, `ArticleId`, `TagId`)
VALUES
	(1,1,1);

/*!40000 ALTER TABLE `ArticleTags` ENABLE KEYS */;
UNLOCK TABLES;


# Affichage de la table Images
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Images`;

CREATE TABLE `Images` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Picture` longblob,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `Images` WRITE;
/*!40000 ALTER TABLE `Images` DISABLE KEYS */;

INSERT INTO `Images` (`Id`, `Picture`)
VALUES
	(1,'');

/*!40000 ALTER TABLE `Images` ENABLE KEYS */;
UNLOCK TABLES;


# Affichage de la table PollAnswers
# ------------------------------------------------------------

DROP TABLE IF EXISTS `PollAnswers`;

CREATE TABLE `PollAnswers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PollId` int(11) NOT NULL,
  `AnswerId` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `PollAnswers` WRITE;
/*!40000 ALTER TABLE `PollAnswers` DISABLE KEYS */;

INSERT INTO `PollAnswers` (`Id`, `PollId`, `AnswerId`)
VALUES
	(1,1,1);

/*!40000 ALTER TABLE `PollAnswers` ENABLE KEYS */;
UNLOCK TABLES;


# Affichage de la table Polls
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Polls`;

CREATE TABLE `Polls` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` longtext,
  `Date` datetime(6) NOT NULL,
  `Active` bit(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `Polls` WRITE;
/*!40000 ALTER TABLE `Polls` DISABLE KEYS */;

INSERT INTO `Polls` (`Id`, `Title`, `Date`, `Active`)
VALUES
	(1,NULL,'0001-01-01 00:00:00.000000',b'0');

/*!40000 ALTER TABLE `Polls` ENABLE KEYS */;
UNLOCK TABLES;


# Affichage de la table Tags
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Tags`;

CREATE TABLE `Tags` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `Tags` WRITE;
/*!40000 ALTER TABLE `Tags` DISABLE KEYS */;

INSERT INTO `Tags` (`Id`, `Name`)
VALUES
	(1,'CcsrbTag');

/*!40000 ALTER TABLE `Tags` ENABLE KEYS */;
UNLOCK TABLES;


# Affichage de la table UserPollAnswers
# ------------------------------------------------------------

DROP TABLE IF EXISTS `UserPollAnswers`;

CREATE TABLE `UserPollAnswers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL,
  `PollId` int(11) NOT NULL,
  `AnswerId` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `UserPollAnswers` WRITE;
/*!40000 ALTER TABLE `UserPollAnswers` DISABLE KEYS */;

INSERT INTO `UserPollAnswers` (`Id`, `UserId`, `PollId`, `AnswerId`)
VALUES
	(1,1,1,1);

/*!40000 ALTER TABLE `UserPollAnswers` ENABLE KEYS */;
UNLOCK TABLES;


# Affichage de la table Users
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Users`;

CREATE TABLE `Users` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` longtext,
  `LastName` longtext,
  `Username` longtext,
  `Password` longtext,
  `Mail` longtext,
  `Phone` longtext,
  `Cost` longtext,
  `Role` longtext,
  `Token` longtext,
  `PasswordHash` longblob,
  `PasswordSalt` longblob,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `Users` WRITE;
/*!40000 ALTER TABLE `Users` DISABLE KEYS */;

INSERT INTO `Users` (`Id`, `FirstName`, `LastName`, `Username`, `Password`, `Mail`, `Phone`, `Cost`, `Role`, `Token`, `PasswordHash`, `PasswordSalt`)
VALUES
	(1,NULL,NULL,'admin','admin',NULL,NULL,NULL,'Admin',NULL,X'7B41ACB33C8FFE5DECF9F071180B4B05970E74A0C9D3F6EA831DD2AA7A4288D3FD7F64576F2B028B33C21479A7543D3300C4DDDA213C555385C0BC39411658A3',X'460D226905A9E55BB3E2ABE3F84CBD9BF8EDC16164DE58F02C95276CC85446E6E3F33B0D033AC1B3E11A4AD56A22639AE954F03EEBAF785E169FC3715D325F513877B2AF5A58009470ABD161FF2805C31DBFE8058886DB32F2284F8496106A2D75141BD3F1E4BE2EBA82487674D45531560A336D4B01BBE37E231BE80EC2B36F');

/*!40000 ALTER TABLE `Users` ENABLE KEYS */;
UNLOCK TABLES;



/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
