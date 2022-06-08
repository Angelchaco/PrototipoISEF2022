use hotelsancarlos;

-- -----------------------------------------------------
-- Tabla `hotelsancarlos`.`marca`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `hotelsancarlos`.`marca` (
  `idMarca` VARCHAR(15) NOT NULL,
  `nombre` VARCHAR(100) NOT NULL,
  `descripcion` VARCHAR(500) NOT NULL,
  PRIMARY KEY (`idMarca`)
  ) ENGINE = InnoDB DEFAULT CHARACTER SET = latin1;

INSERT INTO `hotelsancarlos`.`marca` (`idMarca`, `nombre`, `descripcion`) VALUES ('1', 'Marca 1', 'Marca 1');
INSERT INTO `hotelsancarlos`.`marca` (`idMarca`, `nombre`, `descripcion`) VALUES ('2', 'Marca 2', 'Marca 2');
INSERT INTO `hotelsancarlos`.`marca` (`idMarca`, `nombre`, `descripcion`) VALUES ('3', 'Marca 3', 'Marca 3');

-- -----------------------------------------------------
-- Tabla `hotelsancarlos`.`linea`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `hotelsancarlos`.`linea` (
  `idLinea` VARCHAR(15) NOT NULL,
  `nombre` VARCHAR(100) NOT NULL,
  `descripcion` VARCHAR(500) NOT NULL,
  `idMarca` VARCHAR(15) NOT NULL,
  PRIMARY KEY (`idLinea`),
  FOREIGN KEY (`idMarca`) REFERENCES `hotelsancarlos`.`marca` (`idMarca`)
)ENGINE = InnoDB DEFAULT CHARACTER SET = latin1;

INSERT INTO `hotelsancarlos`.`linea` (`idLinea`, `nombre`, `descripcion`, `idMarca`) VALUES ('1', 'Linea 1', 'Linea 1', '1');
INSERT INTO `hotelsancarlos`.`linea` (`idLinea`, `nombre`, `descripcion`, `idMarca`) VALUES ('2', 'Linea 2', 'Linea 2', '1');
INSERT INTO `hotelsancarlos`.`linea` (`idLinea`, `nombre`, `descripcion`, `idMarca`) VALUES ('3', 'Linea 3', 'Linea 3', '2');

alter table linea add estado varchar(1) not null;

update linea set estado='1' where idLinea = '1';
update linea set estado='1' where idLinea = '2';
update linea set estado='1' where idLinea = '3';

-- -----------------------------------------------------
-- Tabla `hotelsancarlos`.`bodegas` *
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `hotelsancarlos`.`bodegas` (
  `pkid` VARCHAR(15) NOT NULL,
  `nombre` VARCHAR(50) NOT NULL,
  `direccion` VARCHAR(65) NOT NULL,
  `estado` VARCHAR(1) NOT NULL,
  PRIMARY KEY (`pkid`)
) ENGINE = InnoDB DEFAULT CHARACTER SET = latin1;

insert into bodegas values ('1','Bodega 1','Area Bodegas','1');
insert into bodegas values ('2','Bodega 2','Area Bodegas','1');
insert into bodegas values ('3','Bodega 3','Area Bodegas','1');


-- -----------------------------------------------------
-- Tabla `hotelsancarlos`.`proveedores` *
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `hotelsancarlos`.`proveedores` (
  `idProveedor` VARCHAR(15) NOT NULL,
  `nombre` VARCHAR(100) NOT NULL,
  `direccion` VARCHAR(500) NOT NULL,
  `telefono` INT NOT NULL,
  `email` VARCHAR(200) NOT NULL,
  `idEmpresa` VARCHAR(15) NOT NULL,
  `estado` VARCHAR(1) NOT NULL,
  PRIMARY KEY (`idProveedor`),
  FOREIGN KEY (`idEmpresa`) REFERENCES `hotelsancarlos`.`empresa` (`idEmpresa`)
) ENGINE = InnoDB DEFAULT CHARACTER SET = latin1;

insert into proveedores values ('1','Proveedor 1','Zona 6','52147895','Prov1@gmail.com','1','1');
insert into proveedores values ('2','Proveedor 2','Zona 7','52985495','Prov2@gmail.com','1','1');
insert into proveedores values ('3','Proveedor 3','Zona 1','84247895','Prov3@gmail.com','2','1');

-- -----------------------------------------------------
-- Tabla `hotelsancarlos`.`productos` *
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `hotelsancarlos`.`productos` (
  `pkid` VARCHAR(15) NOT NULL,
  `nombre` VARCHAR(50) NOT NULL,
  `Fkidlinea` VARCHAR(15) NOT NULL,
  `Fkidproveedor` VARCHAR(15) NOT NULL,
  `stockMaximo` INT NOT NULL,
  `stockMinimo` INT NOT NULL,
  `costo` FLOAT NOT NULL,
  `precio` FLOAT NOT NULL,
  `fechaExpiracion` DATE NOT NULL,
  `estado` VARCHAR(1) NOT NULL,
  PRIMARY KEY (`pkid`),
  FOREIGN KEY (`Fkidlinea`) REFERENCES `hotelsancarlos`.`linea` (`idLinea`),
  FOREIGN KEY (`Fkidproveedor`) REFERENCES `hotelsancarlos`.`proveedores` (`idProveedor`)
) ENGINE = InnoDB DEFAULT CHARACTER SET = latin1;

insert into productos values ('1','Producto 1','1','1','500','50','25','30','2022/12/15','1');
insert into productos values ('2','Producto 2','2','1','400','100','20','25','2022/09/20','1');
insert into productos values ('3','Producto 3','2','2','500','80','30','35','2022/10/10','1');

-- -----------------------------------------------------
-- Tabla `hotelsancarlos`.`clientes` *
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `hotelsancarlos`.`clientes` (
  `Pkid` VARCHAR(15) NOT NULL,
  `nombre` VARCHAR(30) NOT NULL,
  `apellido` VARCHAR(30) NOT NULL,
  `nit` VARCHAR(15) NOT NULL,
  `telefono` VARCHAR(15) NOT NULL,
  `direccion` VARCHAR(50) NOT NULL,
  `correo` VARCHAR(50) NOT NULL,
  `estatus` VARCHAR(1) NULL DEFAULT NULL,
  PRIMARY KEY (`Pkid`)
)ENGINE = InnoDB DEFAULT CHARACTER SET = latin1;

insert into clientes values ('1','Cliente 1','Apellido 1','1546125-8','58214764','Zona 1','Cliente1@gmail.com','1');
insert into clientes values ('2','Cliente 2','Apellido 2','2151822-2','05504764','Zona 1','Cliente2@gmail.com','1');
insert into clientes values ('3','Cliente 3','Apellido 3','9526658-9','52140040','Zona 2','Cliente3@gmail.com','1');

-- -----------------------------------------------------
-- Tabla `hotelsancarlos`.`movimientomotivo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `hotelsancarlos`.`movimientomotivo` (
  `Pkid` VARCHAR(15) NOT NULL,
  `Movimiento` VARCHAR(15) NULL DEFAULT NULL,
  `Estado` VARCHAR(1) NOT NULL,
  PRIMARY KEY (`Pkid`)
)ENGINE = InnoDB DEFAULT CHARACTER SET = latin1;

insert into movimientomotivo values ('1','Movimiento Prod','1');
insert into movimientomotivo values ('2','Traslado Prod Bod','1');

-- -----------------------------------------------------
-- Tabla `hotelsancarlos`.`tipomovimientoinventario` *
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `hotelsancarlos`.`tipomovimientoinventario` (
  `Pkid` VARCHAR(15) NOT NULL,
  `Fkidmotivo` VARCHAR(15) NOT NULL,
  `FechaMovimiento` DATE NOT NULL,
  `estado` VARCHAR(11) NOT NULL,
  PRIMARY KEY (`Pkid`),
  FOREIGN KEY (`Fkidmotivo`) REFERENCES `hotelsancarlos`.`movimientomotivo` (`Pkid`)
)ENGINE = InnoDB DEFAULT CHARACTER SET = latin1;

insert into tipomovimientoinventario values ('1','1','2022/05/15','1');

-- -----------------------------------------------------
-- Tabla `hotelsancarlos`.`movinvetario_encabezado`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `hotelsancarlos`.`movinvetario_encabezado` (
  `Pkid` VARCHAR(15) NOT NULL,
  `FkidConcepto` VARCHAR(15) NOT NULL,
  `FkidTipoMovInv` VARCHAR(15) NOT NULL,
  `estado` VARCHAR(1) NOT NULL,
  PRIMARY KEY (`Pkid`),
  FOREIGN KEY (`FkidConcepto`) REFERENCES `hotelsancarlos`.`concepto` (`pkIdConcepto`),
  FOREIGN KEY (`FkidTipoMovInv`) REFERENCES `hotelsancarlos`.`tipomovimientoinventario` (`Pkid`)
)ENGINE = InnoDB DEFAULT CHARACTER SET = latin1;

-- -----------------------------------------------------
-- Tabla `hotelsancarlos`.`movinvetario_detalle`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `hotelsancarlos`.`movinvetario_detalle` (
  `Pkid` VARCHAR(15) NOT NULL,
  `FkidProducto` VARCHAR(15) NOT NULL,
  `Cantidad` INT NOT NULL,
  PRIMARY KEY (`Pkid`),
  FOREIGN KEY (`FkidProducto`) REFERENCES `hotelsancarlos`.`productos` (`pkid`)
)ENGINE = InnoDB DEFAULT CHARACTER SET = latin1;
