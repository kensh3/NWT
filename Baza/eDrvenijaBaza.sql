SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

DROP SCHEMA IF EXISTS `edrvenijabaza` ;
CREATE SCHEMA IF NOT EXISTS `edrvenijabaza` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `edrvenijabaza` ;

-- -----------------------------------------------------
-- Table `edrvenijabaza`.`TipoviKorisnika`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `edrvenijabaza`.`TipoviKorisnika` ;

CREATE TABLE IF NOT EXISTS `edrvenijabaza`.`TipoviKorisnika` (
  `idTipaKorisnika` INT NOT NULL,
  `nazivTipaKorisnika` VARCHAR(45) NULL,
  PRIMARY KEY (`idTipaKorisnika`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `edrvenijabaza`.`Korisnici`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `edrvenijabaza`.`Korisnici` ;

CREATE TABLE IF NOT EXISTS `edrvenijabaza`.`Korisnici` (
  `idKorisnika` INT NOT NULL AUTO_INCREMENT,
  `imeKorisnika` VARCHAR(45) NULL,
  `prezimeKorisnika` VARCHAR(45) NULL,
  `eMailKorisnika` VARCHAR(45) NULL,
  `brojTelefonaKorisnika` VARCHAR(45) NULL,
  `avatarKorisnika` VARBINARY(100) NULL,
  `korisnickoImeKorisnika` VARCHAR(45) NULL,
  `lozinkaKorisnika` VARCHAR(45) NULL,
  `idTipaKorisnika` INT NOT NULL,
  PRIMARY KEY (`idKorisnika`),
  UNIQUE INDEX `eMailKorisnika_UNIQUE` (`eMailKorisnika` ASC),
  UNIQUE INDEX `korisnickoImeKorisnika_UNIQUE` (`korisnickoImeKorisnika` ASC),
  INDEX `fk_Korisnici_TipoviKorisnika1_idx` (`idTipaKorisnika` ASC),
  CONSTRAINT `fk_Korisnici_TipoviKorisnika1`
    FOREIGN KEY (`idTipaKorisnika`)
    REFERENCES `edrvenijabaza`.`TipoviKorisnika` (`idTipaKorisnika`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `edrvenijabaza`.`Upiti`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `edrvenijabaza`.`Upiti` ;

CREATE TABLE IF NOT EXISTS `edrvenijabaza`.`Upiti` (
  `idUpita` INT NOT NULL AUTO_INCREMENT,
  `naslovUpita` VARCHAR(45) NULL,
  `tekstUpita` VARCHAR(1000) NULL,
  `idKorisnika` INT NOT NULL,
  PRIMARY KEY (`idUpita`),
  INDEX `fk_Upiti_Korisnici_idx` (`idKorisnika` ASC),
  CONSTRAINT `fk_Upiti_Korisnici`
    FOREIGN KEY (`idKorisnika`)
    REFERENCES `edrvenijabaza`.`Korisnici` (`idKorisnika`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `edrvenijabaza`.`Poruke`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `edrvenijabaza`.`Poruke` ;

CREATE TABLE IF NOT EXISTS `edrvenijabaza`.`Poruke` (
  `idPoruke` INT NOT NULL AUTO_INCREMENT,
  `naslovPoruke` VARCHAR(45) NULL,
  `tekstPoruke` VARCHAR(1000) NULL,
  `idKorisnikaPosiljaoca` INT NOT NULL,
  `idKorisnikaPrimaoca` INT NOT NULL,
  PRIMARY KEY (`idPoruke`),
  INDEX `fk_Poruke_Korisnici1_idx` (`idKorisnikaPosiljaoca` ASC),
  INDEX `fk_Poruke_Korisnici2_idx` (`idKorisnikaPrimaoca` ASC),
  CONSTRAINT `fk_Poruke_Korisnici1`
    FOREIGN KEY (`idKorisnikaPosiljaoca`)
    REFERENCES `edrvenijabaza`.`Korisnici` (`idKorisnika`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Poruke_Korisnici2`
    FOREIGN KEY (`idKorisnikaPrimaoca`)
    REFERENCES `edrvenijabaza`.`Korisnici` (`idKorisnika`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `edrvenijabaza`.`Logovi`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `edrvenijabaza`.`Logovi` ;

CREATE TABLE IF NOT EXISTS `edrvenijabaza`.`Logovi` (
  `idLoga` INT NOT NULL AUTO_INCREMENT,
  `akcijaLoga` VARCHAR(45) NULL,
  `vrijemeLoga` DATETIME NULL,
  `idKorisnika` INT NOT NULL,
  PRIMARY KEY (`idLoga`),
  INDEX `fk_Logovi_Korisnici1_idx` (`idKorisnika` ASC),
  CONSTRAINT `fk_Logovi_Korisnici1`
    FOREIGN KEY (`idKorisnika`)
    REFERENCES `edrvenijabaza`.`Korisnici` (`idKorisnika`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `edrvenijabaza`.`Ocjene`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `edrvenijabaza`.`Ocjene` ;

CREATE TABLE IF NOT EXISTS `edrvenijabaza`.`Ocjene` (
  `idOcjene` INT NOT NULL AUTO_INCREMENT,
  `ocjena` DOUBLE NULL,
  `idKorisnika` INT NOT NULL,
  PRIMARY KEY (`idOcjene`),
  INDEX `fk_Ocjene_Korisnici1_idx` (`idKorisnika` ASC),
  CONSTRAINT `fk_Ocjene_Korisnici1`
    FOREIGN KEY (`idKorisnika`)
    REFERENCES `edrvenijabaza`.`Korisnici` (`idKorisnika`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `edrvenijabaza`.`Statusi`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `edrvenijabaza`.`Statusi` ;

CREATE TABLE IF NOT EXISTS `edrvenijabaza`.`Statusi` (
  `idStatusa` INT NOT NULL AUTO_INCREMENT,
  `brojProdaja` INT NULL,
  `brojKupovina` INT NULL,
  `korisnikAktivanOd` DATETIME NULL,
  `idKorisnika` INT NOT NULL,
  PRIMARY KEY (`idStatusa`),
  INDEX `fk_Statusi_Korisnici1_idx` (`idKorisnika` ASC),
  CONSTRAINT `fk_Statusi_Korisnici1`
    FOREIGN KEY (`idKorisnika`)
    REFERENCES `edrvenijabaza`.`Korisnici` (`idKorisnika`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `edrvenijabaza`.`TipoviOglasa`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `edrvenijabaza`.`TipoviOglasa` ;

CREATE TABLE IF NOT EXISTS `edrvenijabaza`.`TipoviOglasa` (
  `idTipaOglasa` INT NOT NULL AUTO_INCREMENT,
  `nazivTipaOglasa` VARCHAR(45) NULL,
  PRIMARY KEY (`idTipaOglasa`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `edrvenijabaza`.`Kategorije`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `edrvenijabaza`.`Kategorije` ;

CREATE TABLE IF NOT EXISTS `edrvenijabaza`.`Kategorije` (
  `idKategorije` INT NOT NULL AUTO_INCREMENT,
  `nazivKategorije` VARCHAR(45) NULL,
  PRIMARY KEY (`idKategorije`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `edrvenijabaza`.`Oglasi`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `edrvenijabaza`.`Oglasi` ;

CREATE TABLE IF NOT EXISTS `edrvenijabaza`.`Oglasi` (
  `idOglasa` INT NOT NULL AUTO_INCREMENT,
  `nazivOglasa` VARCHAR(45) NULL,
  `datumObjaveOglasa` DATETIME NULL,
  `opisOglasa` VARCHAR(1000) NULL,
  `brojPregledaOglasa` INT NULL,
  `idTipaOglasa` INT NOT NULL,
  `idKategorije` INT NOT NULL,
  `idKorisnika` INT NOT NULL,
  PRIMARY KEY (`idOglasa`),
  INDEX `fk_Oglasi_TipoviOglasa1_idx` (`idTipaOglasa` ASC),
  INDEX `fk_Oglasi_Kategorije1_idx` (`idKategorije` ASC),
  INDEX `fk_Oglasi_Korisnici1_idx` (`idKorisnika` ASC),
  CONSTRAINT `fk_Oglasi_TipoviOglasa1`
    FOREIGN KEY (`idTipaOglasa`)
    REFERENCES `edrvenijabaza`.`TipoviOglasa` (`idTipaOglasa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Oglasi_Kategorije1`
    FOREIGN KEY (`idKategorije`)
    REFERENCES `edrvenijabaza`.`Kategorije` (`idKategorije`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Oglasi_Korisnici1`
    FOREIGN KEY (`idKorisnika`)
    REFERENCES `edrvenijabaza`.`Korisnici` (`idKorisnika`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `edrvenijabaza`.`Komentari`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `edrvenijabaza`.`Komentari` ;

CREATE TABLE IF NOT EXISTS `edrvenijabaza`.`Komentari` (
  `idKomentara` INT NOT NULL AUTO_INCREMENT,
  `tekstKomentara` VARCHAR(45) NULL,
  `idKorisnika` INT NOT NULL,
  `idOglasa` INT NOT NULL,
  PRIMARY KEY (`idKomentara`),
  INDEX `fk_Komentari_Korisnici1_idx` (`idKorisnika` ASC),
  INDEX `fk_Komentari_Oglasi1_idx` (`idOglasa` ASC),
  CONSTRAINT `fk_Komentari_Korisnici1`
    FOREIGN KEY (`idKorisnika`)
    REFERENCES `edrvenijabaza`.`Korisnici` (`idKorisnika`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Komentari_Oglasi1`
    FOREIGN KEY (`idOglasa`)
    REFERENCES `edrvenijabaza`.`Oglasi` (`idOglasa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `edrvenijabaza`.`Dokumenti`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `edrvenijabaza`.`Dokumenti` ;

CREATE TABLE IF NOT EXISTS `edrvenijabaza`.`Dokumenti` (
  `idDokumenta` INT NOT NULL,
  `nazivDokumenta` VARCHAR(45) NULL,
  `opisDokumenta` VARCHAR(1000) NULL,
  `datumObjaveDokumenta` DATETIME NULL,
  `brojPreuzimanjaDokumenta` INT NULL,
  `dokument` VARBINARY(1000) NULL,
  `idOglasa` INT NOT NULL,
  PRIMARY KEY (`idDokumenta`),
  INDEX `fk_Dokumenti_Oglasi1_idx` (`idOglasa` ASC),
  CONSTRAINT `fk_Dokumenti_Oglasi1`
    FOREIGN KEY (`idOglasa`)
    REFERENCES `edrvenijabaza`.`Oglasi` (`idOglasa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `edrvenijabaza`.`KorisniciKategorije`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `edrvenijabaza`.`KorisniciKategorije` ;

CREATE TABLE IF NOT EXISTS `edrvenijabaza`.`KorisniciKategorije` (
  `idKorisnikaKategorije` INT NOT NULL,
  `idKorisnika` INT NOT NULL,
  `idKategorije` INT NOT NULL,
  PRIMARY KEY (`idKorisnikaKategorije`),
  INDEX `fk_KorisniciKategorije_Korisnici1_idx` (`idKorisnika` ASC),
  INDEX `fk_KorisniciKategorije_Kategorije1_idx` (`idKategorije` ASC),
  CONSTRAINT `fk_KorisniciKategorije_Korisnici1`
    FOREIGN KEY (`idKorisnika`)
    REFERENCES `edrvenijabaza`.`Korisnici` (`idKorisnika`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_KorisniciKategorije_Kategorije1`
    FOREIGN KEY (`idKategorije`)
    REFERENCES `edrvenijabaza`.`Kategorije` (`idKategorije`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `edrvenijabaza`.`Transakcije`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `edrvenijabaza`.`Transakcije` ;

CREATE TABLE IF NOT EXISTS `edrvenijabaza`.`Transakcije` (
  `idTransakcije` INT NOT NULL AUTO_INCREMENT,
  `datumTransakcije` DATETIME NULL,
  `idKorisnika` INT NOT NULL,
  `idOglasa` INT NOT NULL,
  PRIMARY KEY (`idTransakcije`),
  INDEX `fk_Transakcije_Korisnici1_idx` (`idKorisnika` ASC),
  INDEX `fk_Transakcije_Oglasi1_idx` (`idOglasa` ASC),
  CONSTRAINT `fk_Transakcije_Korisnici1`
    FOREIGN KEY (`idKorisnika`)
    REFERENCES `edrvenijabaza`.`Korisnici` (`idKorisnika`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Transakcije_Oglasi1`
    FOREIGN KEY (`idOglasa`)
    REFERENCES `edrvenijabaza`.`Oglasi` (`idOglasa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
