-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema d03adb48
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema d03adb48
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `d03adb48` DEFAULT CHARACTER SET utf8mb4 ;
USE `d03adb48` ;

-- -----------------------------------------------------
-- Table `d03adb48`.`Person`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `d03adb48`.`Person` (
  `ID` INT(11) NOT NULL,
  `Email` INT(11) NOT NULL,
  PRIMARY KEY (`ID`),
  INDEX `Email` (`Email` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `d03adb48`.`Ticket`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `d03adb48`.`Ticket` (
  `ID` INT(11) NOT NULL,
  `Kurzbeschreibung` VARCHAR(50) NOT NULL,
  `Erstellt` DATE NULL DEFAULT NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `d03adb48`.`Beobachter`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `d03adb48`.`Beobachter` (
  `ID` INT(11) NOT NULL,
  `Ticket` INT(11) NOT NULL,
  `Person` INT(11) NOT NULL,
  PRIMARY KEY (`ID`),
  INDEX `Ticket` (`Ticket` ASC) VISIBLE,
  INDEX `Beobachter_Person` (`Person` ASC) VISIBLE,
  CONSTRAINT `Beobachter_Person`
    FOREIGN KEY (`Person`)
    REFERENCES `d03adb48`.`Person` (`ID`),
  CONSTRAINT `Beobachter_Ticket`
    FOREIGN KEY (`Ticket`)
    REFERENCES `d03adb48`.`Ticket` (`ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;

USE `d03adb48` ;

-- -----------------------------------------------------
-- Placeholder table for view `d03adb48`.`Ticket_Offen`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `d03adb48`.`Ticket_Offen` (`ID` INT);

-- -----------------------------------------------------
-- View `d03adb48`.`Ticket_Offen`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `d03adb48`.`Ticket_Offen`;
USE `d03adb48`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`d03adb48`@`%` SQL SECURITY DEFINER VIEW `d03adb48`.`Ticket_Offen` AS select `d03adb48`.`Ticket`.`ID` AS `ID` from `d03adb48`.`Ticket`;
USE `d03adb48`;

DELIMITER $$
USE `d03adb48`$$
CREATE
DEFINER=`d03adb48`@`%`
TRIGGER `d03adb48`.`Ticket_Neu`
BEFORE INSERT ON `d03adb48`.`Ticket`
FOR EACH ROW
SET NEW.Erstellt = NOW()$$


DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
