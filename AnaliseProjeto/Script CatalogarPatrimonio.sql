-- MySQL Workbench Synchronization
-- Generated: 2020-12-28 20:23
-- Model: New Model
-- Version: 1.0
-- Project: Name of the project
-- Author: Daniel Santos

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`Pessoa` (
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
    REFERENCES `catalogarpatrimonio`.`Empresa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`Empresa` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`Almoxarifado` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `idEmpresa` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_tb_almoxarifado_empresa_idx` (`idEmpresa` ASC),
  CONSTRAINT `fk_tb_almoxarifado_empresa`
    FOREIGN KEY (`idEmpresa`)
    REFERENCES `catalogarpatrimonio`.`Empresa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`Servico` (
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
    REFERENCES `catalogarpatrimonio`.`Pessoa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tb_ordemServico_tipoServico`
    FOREIGN KEY (`idTipoServico`)
    REFERENCES `catalogarpatrimonio`.`TipoServico` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_servico_statusServico1`
    FOREIGN KEY (`idStatusServico`)
    REFERENCES `catalogarpatrimonio`.`StatusServico` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_servico_pessoa1`
    FOREIGN KEY (`idAlmoxarife`)
    REFERENCES `catalogarpatrimonio`.`Pessoa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_servico_pessoa2`
    FOREIGN KEY (`idTecnico`)
    REFERENCES `catalogarpatrimonio`.`Pessoa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Servico_Local1`
    FOREIGN KEY (`idLocal`)
    REFERENCES `catalogarpatrimonio`.`Local` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`Patrimonio` (
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
    REFERENCES `catalogarpatrimonio`.`TipoPatrimonio` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Patrimonio_Local1`
    FOREIGN KEY (`idLocal`)
    REFERENCES `catalogarpatrimonio`.`Local` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`TipoServico` (
  `id` INT(11) NOT NULL,
  `nome` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`Predio` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `latitude` DOUBLE NULL DEFAULT NULL,
  `longitude` DOUBLE NULL DEFAULT NULL,
  `estado` VARCHAR(45) NOT NULL,
  `cidade` VARCHAR(45) NOT NULL,
  `idEmpresa` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_local_empresa1_idx` (`idEmpresa` ASC),
  CONSTRAINT `fk_local_empresa1`
    FOREIGN KEY (`idEmpresa`)
    REFERENCES `catalogarpatrimonio`.`Empresa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`TipoPatrimonio` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`Material` (
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
    REFERENCES `catalogarpatrimonio`.`TipoMaterial` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`Fornecedor` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `categoria` VARCHAR(45) NOT NULL,
  `telefone` VARCHAR(20) NULL DEFAULT NULL,
  `estado` VARCHAR(45) NULL DEFAULT NULL,
  `cidade` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`Entrada` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `notaFiscal` DOUBLE NOT NULL,
  `dataEntrada` DATE NOT NULL,
  `idFornecedor` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_entradaMaterial_fornecedor1_idx` (`idFornecedor` ASC),
  CONSTRAINT `fk_entradaMaterial_fornecedor1`
    FOREIGN KEY (`idFornecedor`)
    REFERENCES `catalogarpatrimonio`.`Fornecedor` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`TipoMaterial` (
  `id` INT(11) NOT NULL,
  `nome` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`materialEntrada` (
  `idMaterial` INT(11) NOT NULL,
  `idEntrada` INT(11) NOT NULL,
  PRIMARY KEY (`idMaterial`, `idEntrada`),
  INDEX `fk_material_has_entradaMaterial_entradaMaterial1_idx` (`idEntrada` ASC),
  INDEX `fk_material_has_entradaMaterial_material1_idx` (`idMaterial` ASC),
  CONSTRAINT `fk_material_has_entradaMaterial_material1`
    FOREIGN KEY (`idMaterial`)
    REFERENCES `catalogarpatrimonio`.`Material` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_material_has_entradaMaterial_entradaMaterial1`
    FOREIGN KEY (`idEntrada`)
    REFERENCES `catalogarpatrimonio`.`Entrada` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`EstoqueMaterial` (
  `idMaterial` INT(11) NOT NULL,
  `idAlmoxarifado` INT(11) NOT NULL,
  `quantidade` INT(11) NOT NULL,
  PRIMARY KEY (`idMaterial`, `idAlmoxarifado`),
  INDEX `fk_material_has_almoxarifado_almoxarifado1_idx` (`idAlmoxarifado` ASC),
  INDEX `fk_material_has_almoxarifado_material1_idx` (`idMaterial` ASC),
  CONSTRAINT `fk_material_has_almoxarifado_material1`
    FOREIGN KEY (`idMaterial`)
    REFERENCES `catalogarpatrimonio`.`Material` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_material_has_almoxarifado_almoxarifado1`
    FOREIGN KEY (`idAlmoxarifado`)
    REFERENCES `catalogarpatrimonio`.`Almoxarifado` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`Transferencia` (
  `id` INT(11) NOT NULL,
  `idAlmoxarifadoOrigem` INT(11) NOT NULL,
  `idAlmoxarifadoDestino` INT(11) NOT NULL,
  `data` DATE NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_transferirMaterial_almoxarifado1_idx` (`idAlmoxarifadoOrigem` ASC),
  INDEX `fk_transferirMaterial_almoxarifado2_idx` (`idAlmoxarifadoDestino` ASC),
  CONSTRAINT `fk_transferirMaterial_almoxarifado1`
    FOREIGN KEY (`idAlmoxarifadoOrigem`)
    REFERENCES `catalogarpatrimonio`.`Almoxarifado` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_transferirMaterial_almoxarifado2`
    FOREIGN KEY (`idAlmoxarifadoDestino`)
    REFERENCES `catalogarpatrimonio`.`Almoxarifado` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`EntradaMaterial` (
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
    REFERENCES `catalogarpatrimonio`.`Material` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_material_has_entrada_entrada1`
    FOREIGN KEY (`idEntrada`)
    REFERENCES `catalogarpatrimonio`.`Entrada` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`ServicoMaterial` (
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
    REFERENCES `catalogarpatrimonio`.`Material` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_material_has_Servico_Servico1`
    FOREIGN KEY (`idServico`)
    REFERENCES `catalogarpatrimonio`.`Servico` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_servicoMaterial_patrimonio1`
    FOREIGN KEY (`idPatrimonio`)
    REFERENCES `catalogarpatrimonio`.`Patrimonio` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`StatusServico` (
  `id` INT(11) NOT NULL,
  `descricao` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`DialogoServico` (
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
    REFERENCES `catalogarpatrimonio`.`Servico` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_dialogoServico_pessoa1`
    FOREIGN KEY (`idPessoa`)
    REFERENCES `catalogarpatrimonio`.`Pessoa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`TransferenciaMaterial` (
  `idMaterial` INT(11) NOT NULL,
  `idTransferencia` INT(11) NOT NULL,
  `quantidade` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`idMaterial`, `idTransferencia`),
  INDEX `fk_Material_has_Transferencia_Transferencia1_idx` (`idTransferencia` ASC),
  INDEX `fk_Material_has_Transferencia_Material1_idx` (`idMaterial` ASC),
  CONSTRAINT `fk_Material_has_Transferencia_Material1`
    FOREIGN KEY (`idMaterial`)
    REFERENCES `catalogarpatrimonio`.`Material` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Material_has_Transferencia_Transferencia1`
    FOREIGN KEY (`idTransferencia`)
    REFERENCES `catalogarpatrimonio`.`Transferencia` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`Local` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NULL DEFAULT NULL,
  `idPredio` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Local_Predio1_idx` (`idPredio` ASC),
  CONSTRAINT `fk_Local_Predio1`
    FOREIGN KEY (`idPredio`)
    REFERENCES `catalogarpatrimonio`.`Predio` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `catalogarpatrimonio`.`Disponibilidade` (
  `id` INT(11) NOT NULL,
  `dia` DATE NULL DEFAULT NULL,
  `hora` DATETIME NULL DEFAULT NULL,
  `idLocal` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Disponibilidade_Local1_idx` (`idLocal` ASC),
  CONSTRAINT `fk_Disponibilidade_Local1`
    FOREIGN KEY (`idLocal`)
    REFERENCES `catalogarpatrimonio`.`Predio` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
