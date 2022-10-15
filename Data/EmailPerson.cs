using System;
using System.Collections.Generic;

namespace App.Data
{
    public partial class EmailPerson
    {
  

        public int Id { get; set; }
        public int? Person { get; set; } 
        public int? Email { get; set; }
       
 
    }
}

/*
CREATE TABLE IF NOT EXISTS `d03adb48`.`EmailPersonen` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Person` INT(11) NULL DEFAULT NULL,
  `Email` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4;
*/

/* 
CREATE TABLE IF NOT EXISTS `d03adb48`.`EmailPerson` (
  `PersonId` INT(11) NOT NULL,
  `EmailId` INT(11) NOT NULL,
  PRIMARY KEY (`EmailId`, `PersonId`),
  INDEX `IX_EmailPerson_PersonId` (`PersonId` ASC) VISIBLE,
  CONSTRAINT `FK_EmailPerson_Emails_EmailId`
    FOREIGN KEY (`EmailId`)
    REFERENCES `d03adb48`.`Emails` (`Id`)
    ON DELETE CASCADE,
  CONSTRAINT `FK_EmailPerson_Personen_PersonId`
    FOREIGN KEY (`PersonId`)
    REFERENCES `d03adb48`.`Personen` (`Id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;
*/