CREATE DATABASE  IF NOT EXISTS `my-finance`
USE `my-finance`;

DROP TABLE IF EXISTS `planoconta`;
CREATE TABLE `planoconta` (
  `id` int NOT NULL AUTO_INCREMENT,
  `descricao` varchar(255) DEFAULT NULL,
  `tipo` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
)

DROP TABLE IF EXISTS `transacao`;
CREATE TABLE `transacao` (
  `id` int NOT NULL AUTO_INCREMENT,
  `historico` varchar(255) DEFAULT NULL,
  `tipo` varchar(50) DEFAULT NULL,
  `valor` decimal(10,2) DEFAULT NULL,
  `data` date DEFAULT NULL,
  `PlanoConta_Id` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `planoconta_transacao_FK_idx` (`PlanoConta_Id`),
  CONSTRAINT `Transacao_planoConta_FK` FOREIGN KEY (`PlanoConta_Id`) REFERENCES `planoconta` (`id`)
)

