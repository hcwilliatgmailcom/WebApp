using System;
using System.Collections.Generic;

namespace App.Data
{
    public partial class Email
    {
  

        public int Id { get; set; }
        public string Titel { get; set; } = null!;
        public string? Beschreibung { get; set; }
        public DateTime? Gesendet { get; set; }
 
    }
}

/*
CREATE TABLE IF NOT EXISTS `d03adb48`.`Emails` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Titel` LONGTEXT NOT NULL,
  `Beschreibung` LONGTEXT NULL DEFAULT NULL,
  `Gesendet` DATETIME(6) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4;
*/
