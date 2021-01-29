-- MySQL Workbench Synchronization
-- Generated: 2021-01-28 21:30
-- Model: New Model
-- Version: 1.0
-- Project: Name of the project
-- Author: Daniel Santos

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

CREATE SCHEMA IF NOT EXISTS `catalogarpatrimonio` DEFAULT CHARACTER SET utf8 ;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`pessoa` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `dataNascimento` DATE NULL DEFAULT NULL,
  `CPF` VARCHAR(20) NULL DEFAULT NULL,
  `email` VARCHAR(40) NOT NULL,
  `telefone` VARCHAR(20) NULL DEFAULT NULL,
  `senha` VARCHAR(100) NOT NULL,
  `estado` VARCHAR(45) NULL DEFAULT NULL,
  `cidade` VARCHAR(45) NULL DEFAULT NULL,
  `idEmpresa` INT(11) NULL DEFAULT NULL,
  `tipo` ENUM('Administrador', 'Gestor', 'Almoxarife', 'Tecnico', 'Solicitante') NULL DEFAULT 'Solicitante',
  PRIMARY KEY (`id`),
  UNIQUE INDEX `CPF_UNIQUE` (`CPF` ASC),
  UNIQUE INDEX `email_UNIQUE` (`email` ASC),
  INDEX `fk_tb_pessoa_empresa_idx` (`idEmpresa` ASC),
  CONSTRAINT `fk_tb_pessoa_empresa`
    FOREIGN KEY (`idEmpresa`)
    REFERENCES `catalogarpatrimonio`.`empresa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`empresa` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`almoxarifado` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `idEmpresa` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_tb_almoxarifado_empresa_idx` (`idEmpresa` ASC),
  CONSTRAINT `fk_tb_almoxarifado_empresa`
    FOREIGN KEY (`idEmpresa`)
    REFERENCES `catalogarpatrimonio`.`empresa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`servico` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `dataSolicitacao` DATE NOT NULL,
  `descricao` VARCHAR(1000) NULL DEFAULT NULL,
  `idSolicitante` INT(11) NOT NULL,
  `idTipoServico` INT(11) NOT NULL,
  `observacao` VARCHAR(300) NULL DEFAULT NULL,
  `dataAutorizacao` DATE NULL DEFAULT NULL,
  `dataConclusao` DATE NULL DEFAULT NULL,
  `idStatusServico` INT(11) NOT NULL,
  `idAlmoxarife` INT(11) NOT NULL,
  `idTecnico` INT(11) NOT NULL,
  `idLocal` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_tb_ordemServico_solicitante_idx` (`idSolicitante` ASC),
  INDEX `fk_tb_ordemServico_tipoServico_idx` (`idTipoServico` ASC),
  INDEX `fk_servico_statusServico1_idx` (`idStatusServico` ASC),
  INDEX `fk_servico_pessoa1_idx` (`idAlmoxarife` ASC),
  INDEX `fk_servico_pessoa2_idx` (`idTecnico` ASC),
  INDEX `fk_Servico_Local1_idx` (`idLocal` ASC),
  CONSTRAINT `fk_tb_ordemServico_solicitante`
    FOREIGN KEY (`idSolicitante`)
    REFERENCES `catalogarpatrimonio`.`pessoa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tb_ordemServico_tipoServico`
    FOREIGN KEY (`idTipoServico`)
    REFERENCES `catalogarpatrimonio`.`tiposervico` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_servico_statusServico1`
    FOREIGN KEY (`idStatusServico`)
    REFERENCES `catalogarpatrimonio`.`statusservico` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_servico_pessoa1`
    FOREIGN KEY (`idAlmoxarife`)
    REFERENCES `catalogarpatrimonio`.`pessoa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_servico_pessoa2`
    FOREIGN KEY (`idTecnico`)
    REFERENCES `catalogarpatrimonio`.`pessoa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Servico_Local1`
    FOREIGN KEY (`idLocal`)
    REFERENCES `catalogarpatrimonio`.`local` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`patrimonio` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `valor` DECIMAL NULL DEFAULT NULL,
  `qrCode` VARCHAR(1000) NULL DEFAULT NULL,
  `numero` INT(11) NULL DEFAULT NULL,
  `idTipoPatrimonio` INT(11) NOT NULL,
  `idLocal` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_patrimonio_tipoPatrimonio1_idx` (`idTipoPatrimonio` ASC),
  INDEX `fk_Patrimonio_Local1_idx` (`idLocal` ASC),
  CONSTRAINT `fk_patrimonio_tipoPatrimonio1`
    FOREIGN KEY (`idTipoPatrimonio`)
    REFERENCES `catalogarpatrimonio`.`tipopatrimonio` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Patrimonio_Local1`
    FOREIGN KEY (`idLocal`)
    REFERENCES `catalogarpatrimonio`.`local` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`tiposervico` (
  `id` INT(11) NOT NULL,
  `nome` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`predio` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NULL DEFAULT NULL,
  `latitude` DOUBLE NULL DEFAULT NULL,
  `longitude` DOUBLE NULL DEFAULT NULL,
  `estado` VARCHAR(45) NOT NULL,
  `cidade` VARCHAR(45) NOT NULL,
  `idEmpresa` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_local_empresa1_idx` (`idEmpresa` ASC),
  CONSTRAINT `fk_local_empresa1`
    FOREIGN KEY (`idEmpresa`)
    REFERENCES `catalogarpatrimonio`.`empresa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`tipopatrimonio` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`material` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `idTipoMaterial` INT(11) NOT NULL,
  `statusSolicitação` TINYINT(4) NULL DEFAULT NULL,
  `deveVincularMaterial` TINYINT(4) NULL DEFAULT NULL,
  `valor` DECIMAL NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_material_tipoMaterial1_idx` (`idTipoMaterial` ASC),
  CONSTRAINT `fk_material_tipoMaterial1`
    FOREIGN KEY (`idTipoMaterial`)
    REFERENCES `catalogarpatrimonio`.`tipomaterial` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`fornecedor` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `categoria` VARCHAR(45) NOT NULL,
  `telefone` VARCHAR(20) NULL DEFAULT NULL,
  `estado` VARCHAR(45) NULL DEFAULT NULL,
  `cidade` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`entrada` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `notaFiscal` DOUBLE NOT NULL,
  `dataEntrada` DATE NOT NULL,
  `idFornecedor` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_entradaMaterial_fornecedor1_idx` (`idFornecedor` ASC),
  CONSTRAINT `fk_entradaMaterial_fornecedor1`
    FOREIGN KEY (`idFornecedor`)
    REFERENCES `catalogarpatrimonio`.`fornecedor` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`tipomaterial` (
  `id` INT(11) NOT NULL,
  `nome` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`estoquematerial` (
  `idMaterial` INT(11) NOT NULL,
  `idAlmoxarifado` INT(11) NOT NULL,
  `quantidade` INT(11) NOT NULL,
  PRIMARY KEY (`idMaterial`, `idAlmoxarifado`),
  INDEX `fk_material_has_almoxarifado_almoxarifado1_idx` (`idAlmoxarifado` ASC),
  INDEX `fk_material_has_almoxarifado_material1_idx` (`idMaterial` ASC),
  CONSTRAINT `fk_material_has_almoxarifado_material1`
    FOREIGN KEY (`idMaterial`)
    REFERENCES `catalogarpatrimonio`.`material` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_material_has_almoxarifado_almoxarifado1`
    FOREIGN KEY (`idAlmoxarifado`)
    REFERENCES `catalogarpatrimonio`.`almoxarifado` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`transferencia` (
  `id` INT(11) NOT NULL,
  `idAlmoxarifadoOrigem` INT(11) NOT NULL,
  `idAlmoxarifadoDestino` INT(11) NOT NULL,
  `data` DATE NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_transferirMaterial_almoxarifado1_idx` (`idAlmoxarifadoOrigem` ASC),
  INDEX `fk_transferirMaterial_almoxarifado2_idx` (`idAlmoxarifadoDestino` ASC),
  CONSTRAINT `fk_transferirMaterial_almoxarifado1`
    FOREIGN KEY (`idAlmoxarifadoOrigem`)
    REFERENCES `catalogarpatrimonio`.`almoxarifado` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_transferirMaterial_almoxarifado2`
    FOREIGN KEY (`idAlmoxarifadoDestino`)
    REFERENCES `catalogarpatrimonio`.`almoxarifado` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`entradamaterial` (
  `idMaterial` INT(11) NOT NULL,
  `idEntrada` INT(11) NOT NULL,
  `quantidade` INT(11) NULL DEFAULT NULL,
  `valor` FLOAT(11) NULL DEFAULT NULL,
  `quantidadeUtilizada` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`idMaterial`, `idEntrada`),
  INDEX `fk_material_has_entrada_entrada1_idx` (`idEntrada` ASC),
  INDEX `fk_material_has_entrada_material1_idx` (`idMaterial` ASC),
  CONSTRAINT `fk_material_has_entrada_material1`
    FOREIGN KEY (`idMaterial`)
    REFERENCES `catalogarpatrimonio`.`material` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_material_has_entrada_entrada1`
    FOREIGN KEY (`idEntrada`)
    REFERENCES `catalogarpatrimonio`.`entrada` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`servicomaterial` (
  `idMaterial` INT(11) NOT NULL,
  `idServico` INT(11) NOT NULL,
  `quantidade` INT(11) NOT NULL,
  `idPatrimonio` INT(11) NOT NULL,
  PRIMARY KEY (`idMaterial`, `idServico`),
  INDEX `fk_material_has_Servico_Servico1_idx` (`idServico` ASC),
  INDEX `fk_material_has_Servico_material1_idx` (`idMaterial` ASC),
  INDEX `fk_servicoMaterial_patrimonio1_idx` (`idPatrimonio` ASC),
  CONSTRAINT `fk_material_has_Servico_material1`
    FOREIGN KEY (`idMaterial`)
    REFERENCES `catalogarpatrimonio`.`material` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_material_has_Servico_Servico1`
    FOREIGN KEY (`idServico`)
    REFERENCES `catalogarpatrimonio`.`servico` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_servicoMaterial_patrimonio1`
    FOREIGN KEY (`idPatrimonio`)
    REFERENCES `catalogarpatrimonio`.`patrimonio` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`statusservico` (
  `id` INT(11) NOT NULL,
  `descricao` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`dialogoservico` (
  `id` INT(11) NOT NULL,
  `dataHora` DATETIME NULL DEFAULT NULL,
  `mensagem` VARCHAR(1000) NULL DEFAULT NULL,
  `idServico` INT(11) NOT NULL,
  `idPessoa` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_dialogoServico_servico1_idx` (`idServico` ASC),
  INDEX `fk_dialogoServico_pessoa1_idx` (`idPessoa` ASC),
  CONSTRAINT `fk_dialogoServico_servico1`
    FOREIGN KEY (`idServico`)
    REFERENCES `catalogarpatrimonio`.`servico` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_dialogoServico_pessoa1`
    FOREIGN KEY (`idPessoa`)
    REFERENCES `catalogarpatrimonio`.`pessoa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`transferenciamaterial` (
  `idMaterial` INT(11) NOT NULL,
  `idTransferencia` INT(11) NOT NULL,
  `quantidade` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`idMaterial`, `idTransferencia`),
  INDEX `fk_Material_has_Transferencia_Transferencia1_idx` (`idTransferencia` ASC),
  INDEX `fk_Material_has_Transferencia_Material1_idx` (`idMaterial` ASC),
  CONSTRAINT `fk_Material_has_Transferencia_Material1`
    FOREIGN KEY (`idMaterial`)
    REFERENCES `catalogarpatrimonio`.`material` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Material_has_Transferencia_Transferencia1`
    FOREIGN KEY (`idTransferencia`)
    REFERENCES `catalogarpatrimonio`.`transferencia` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`local` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NULL DEFAULT NULL,
  `idPredio` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Local_Predio1_idx` (`idPredio` ASC),
  CONSTRAINT `fk_Local_Predio1`
    FOREIGN KEY (`idPredio`)
    REFERENCES `catalogarpatrimonio`.`predio` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`disponibilidade` (
  `id` INT(11) NOT NULL,
  `dia` DATE NULL DEFAULT NULL,
  `hora` DATETIME NULL DEFAULT NULL,
  `idLocal` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Disponibilidade_Local1_idx` (`idLocal` ASC),
  CONSTRAINT `fk_Disponibilidade_Local1`
    FOREIGN KEY (`idLocal`)
    REFERENCES `catalogarpatrimonio`.`predio` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
