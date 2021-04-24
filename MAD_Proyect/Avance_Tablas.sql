USE Tryout1
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



IF EXISTS(SELECT 1 FROM sysconstraints WHERE OBJECT_NAME(constid) = 'fk_ServicioCon' AND OBJECT_NAME(id) = 'Contrato')
BEGIN
	ALTER TABLE Contrato DROP CONSTRAINT fk_ServicioCon;
END

IF EXISTS(SELECT 1 FROM sysconstraints WHERE OBJECT_NAME(constid) = 'fk_ClienteCon' AND OBJECT_NAME(id) = 'Contrato')
BEGIN
	ALTER TABLE Contrato DROP CONSTRAINT fk_ClienteCon;
END
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
IF EXISTS(SELECT 1 FROM sysconstraints WHERE OBJECT_NAME(constid) = 'fk_MedidorRec' AND OBJECT_NAME(id) = 'Recibo')
BEGIN
	ALTER TABLE Recibo DROP CONSTRAINT fk_MedidorRec;
END

IF EXISTS(SELECT 1 FROM sysconstraints WHERE OBJECT_NAME(constid) = 'fk_ClienteRec' AND OBJECT_NAME(id) = 'Recibo')
BEGIN
	ALTER TABLE Recibo DROP CONSTRAINT fk_ClienteRec;
END

IF EXISTS(SELECT 1 FROM sysconstraints WHERE OBJECT_NAME(constid) = 'fk_TarifaRec' AND OBJECT_NAME(id) = 'Recibo')
BEGIN
	ALTER TABLE Recibo DROP CONSTRAINT fk_TarifaRec;
END
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
IF EXISTS(SELECT 1 FROM sysconstraints WHERE OBJECT_NAME(constid) = 'fk_TarifaServ' AND OBJECT_NAME(id) = 'Servicio')
BEGIN
	ALTER TABLE Servicio DROP CONSTRAINT fk_TarifaServ;
END
IF EXISTS(SELECT 1 FROM sysconstraints WHERE OBJECT_NAME(constid) = 'fk_MedidorServ' AND OBJECT_NAME(id) = 'Servicio')
BEGIN
	ALTER TABLE Servicio DROP CONSTRAINT fk_MedidorServ;
END
IF EXISTS(SELECT 1 FROM sysconstraints WHERE OBJECT_NAME(constid) = 'fk_ClienteServ' AND OBJECT_NAME(id) = 'Servicio')
BEGIN
	ALTER TABLE Servicio DROP CONSTRAINT fk_ClienteServ;
END
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
IF EXISTS(SELECT 1 FROM sysconstraints WHERE OBJECT_NAME(constid) = 'fk_ClienteCons' AND OBJECT_NAME(id) = 'Consumo')
BEGIN
	ALTER TABLE Consumo DROP CONSTRAINT fk_ClienteCons;
END
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT 1 FROM sysconstraints WHERE OBJECT_NAME(constid) = 'fk_Usuario' AND OBJECT_NAME(id) = 'Empleado')
BEGIN
	ALTER TABLE Empleado DROP CONSTRAINT fk_Usuario;
END
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
IF EXISTS(SELECT 1 FROM sysobjects WHERE name = 'Administrador')
BEGIN
	DROP TABLE Administrador;
END

IF EXISTS(SELECT 1 FROM sysobjects WHERE name = 'Usuarios')
BEGIN
	DROP TABLE Usuarios;
END

IF EXISTS(SELECT 1 FROM sysobjects WHERE name = 'Empleado')
BEGIN
	DROP TABLE Empleado;
END

IF EXISTS(SELECT 1 FROM sysobjects WHERE name = 'Clientes')
BEGIN
	DROP TABLE Clientes;
END


IF EXISTS(SELECT 1 FROM sysobjects WHERE name = 'Tarifa')
BEGIN
	DROP TABLE Tarifa;
END

IF EXISTS(SELECT 1 FROM sysobjects WHERE name = 'Consumo')
BEGIN
	DROP TABLE Consumo;
END

IF EXISTS(SELECT 1 FROM sysobjects WHERE name = 'Servicio')
BEGIN
	DROP TABLE Servicio;
END

IF EXISTS(SELECT 1 FROM sysobjects WHERE name = 'Recibo')
BEGIN
	DROP TABLE Recibo;
END

IF EXISTS(SELECT 1 FROM sysobjects WHERE name = 'Contrato')
BEGIN
	DROP TABLE Contrato;
END



-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



CREATE TABLE Administrador(
Nombre_Usuario			VARCHAR(50)  PRIMARY KEY,
Contraseña				VARCHAR (15)
);




CREATE TABLE Usuarios(
Nombre_Usuario	VARCHAR (50) PRIMARY KEY,
Contraseña		VARCHAR (15)
);


CREATE TABLE Empleado(
CURP VARCHAR (18) PRIMARY KEY,
Fecha_Nacimiento date,
Nombre VARCHAR (50),
RFC VARCHAR (12),
Fecha_de_Alta_Modificacion date,
Nombre_Usuario VARCHAR(50),
CONSTRAINT fk_Usuario FOREIGN KEY (Nombre_Usuario) REFERENCES Usuarios (Nombre_Usuario),
);



CREATE TABLE Clientes(
CURP VARCHAR (18) PRIMARY KEY,
Fecha_Nacimiento date,
Nombre VARCHAR (50),
Fecha_de_Alta_Modificacion date,
Genero VARCHAR (50),
Domicilio VARCHAR (60),

);


CREATE TABLE Tarifa(
Id_Tarifa VARCHAR (20) PRIMARY KEY,
Precio_Watt_Bajo int,
Precio_Watt_Medio int,
Precio_Watt_Excedente int,
Fecha date,
Tipo_de_uso bit,
Genero VARCHAR (50),
Domicilio VARCHAR (60),
);


CREATE TABLE Consumo(
Numero_Medidor int PRIMARY KEY IDENTITY (153458,1),
Domicilio VARCHAR (70),
Watts int,
Periodo date,
Cliente VARCHAR(18),
CONSTRAINT fk_ClienteCons FOREIGN KEY (Cliente) REFERENCES Clientes (CURP),

);

CREATE TABLE Servicio(
Numero_de_Servicio	int PRIMARY KEY,
Tipo_de_Servicio		VARCHAR (15),
Numero_Medidor int,
CONSTRAINT fk_MedidorServ FOREIGN KEY (Numero_Medidor) REFERENCES Consumo (Numero_Medidor),
Tarifa VARCHAR(20),
CONSTRAINT fk_TarifaServ FOREIGN KEY (Tarifa) REFERENCES Tarifa (Id_Tarifa),
Cliente VARCHAR(18),
CONSTRAINT fk_ClienteServ FOREIGN KEY (Cliente) REFERENCES Clientes (CURP),
);

CREATE TABLE Recibo(
Id_Recibo int identity (11564645,1) Primary Key,
Tipo_de_Servicio		VARCHAR (15),
Iva tinyint,
Fecha date,
Watts int,
Numero_Medidor int,
CONSTRAINT fk_MedidorRec FOREIGN KEY (Numero_Medidor) REFERENCES Consumo (Numero_Medidor),
Cliente VARCHAR(18),
CONSTRAINT fk_ClienteRec FOREIGN KEY (Cliente) REFERENCES Clientes (CURP),
Tarifa VARCHAR(20),
CONSTRAINT fk_TarifaRec FOREIGN KEY (Tarifa) REFERENCES Tarifa (Id_Tarifa),
Subtotal int,
Total int
);

CREATE TABLE Contrato(
Id_Contrato int IDENTITY (1465565786,1)PRIMARY KEY ,
Domicilio VARCHAR (50),
Servicio int,
CONSTRAINT fk_ServicioCon FOREIGN KEY (Servicio) REFERENCES Servicio (Numero_de_Servicio),
Fecha date,
Cliente VARCHAR (18),
CONSTRAINT fk_ClienteCon FOREIGN KEY (Cliente) REFERENCES Clientes (CURP),
Activo bit


);