using System;
using System.Collections.Generic;

namespace App.Data
{
    public partial class Person
    {
  

        public int Id { get; set; }
        public string Emailadresse { get; set; } = null!;
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }

   
    }
}
/*
CREATE TABLE IF NOT EXISTS `d03adb48`.`Personen` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Emailadresse` LONGTEXT NOT NULL,
  `Vorname` LONGTEXT NULL DEFAULT NULL,
  `Nachname` LONGTEXT NULL DEFAULT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4;
*/