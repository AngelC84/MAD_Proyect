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
IF EXISTS(SELECT 1 FROM sysconstraints WHERE OBJECT_NAME(constid) = 'fk_MedidorCon' AND OBJECT_NAME(id) = 'Contrato')
BEGIN
	ALTER TABLE Contrato DROP CONSTRAINT fk_MedidorCon;
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
IF EXISTS(SELECT 1 FROM sysconstraints WHERE OBJECT_NAME(constid) = 'fk_ServRec' AND OBJECT_NAME(id) = 'Recibo')
BEGIN
	ALTER TABLE Recibo DROP CONSTRAINT fk_ServRec;
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


IF EXISTS(SELECT 1 FROM sysconstraints WHERE OBJECT_NAME(constid) = 'fk_UsuarioCliente' AND OBJECT_NAME(id) = 'Clientes')
BEGIN
	ALTER TABLE Clientes DROP CONSTRAINT fk_UsuarioCliente;
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
Nombre_Usuario			VARCHAR(50)  PRIMARY KEY  not null,
Contraseña				VARCHAR (15) not null,
Activo bit not null default (1)
);




CREATE TABLE Usuarios(
Nombre_Usuario	VARCHAR (50) PRIMARY KEY not null,
Contraseña		VARCHAR (15) not null

);


Create table Empleado(
CURP VARCHAR (18) PRIMARY KEY not null,
Fecha_Nacimiento date not null,
Nombre VARCHAR (50) not null,
RFC VARCHAR (12) not null UNIQUE,
Fecha_de_Alta_Modificacion date not null,
Nombre_Usuario VARCHAR(50) not null,
Contraseña VARCHAR(50) not null,
CONSTRAINT fk_Usuario FOREIGN KEY (Nombre_Usuario) REFERENCES Usuarios (Nombre_Usuario),
genero varchar (25),
Activo bit not null default (1)

);


CREATE TABLE Clientes(
CURP VARCHAR (18) PRIMARY KEY not null,
Fecha_Nacimiento date null,
Nombre VARCHAR (50) null,
Fecha_de_Alta_Modificacion date null,
Genero varchar (20) not null,
email varchar (30) UNIQUE not null,
Nombre_Usuario varchar(50) not null,
CONSTRAINT fk_UsuarioCliente FOREIGN KEY (Nombre_Usuario) REFERENCES Usuarios (Nombre_Usuario),
Contraseña varchar (25),
Activo bit not null default (1)
);





CREATE TABLE Consumo(
Numero_Medidor int PRIMARY KEY IDENTITY (1000,1) ,
Watts int not null,
Periodo date not null,
Cliente VARCHAR(18) not null,
CONSTRAINT fk_ClienteCons FOREIGN KEY (Cliente) REFERENCES Clientes (CURP),

);




CREATE TABLE Tarifa(
Id_Tarifa VARCHAR (20) PRIMARY KEY,
Precio_Watt_Bajo int not null,
Precio_Watt_Medio int not null,
Precio_Watt_Excedente int not null,
Fecha date not null,
Tipo_de_uso bit default (1),
Watt_Bajo int default (5000),         /* Por ejemplo consumo de hasta 5000 Watts es consumo bajo, de 5000 a 10000 es consumo medio y de 10001 hacia arriba se considera consumo excedente     */
Watt_Medio int default (10000),
Watt_Excedente int,
 
);


CREATE TABLE Servicio(
Numero_de_Servicio	int  PRIMARY KEY ,
Tipo_de_Servicio		VARCHAR (15) not null,
Numero_Medidor int not null,
CONSTRAINT fk_MedidorServ FOREIGN KEY (Numero_Medidor) REFERENCES Consumo (Numero_Medidor),
Tarifa VARCHAR(20) not null,
CONSTRAINT fk_TarifaServ FOREIGN KEY (Tarifa) REFERENCES Tarifa (Id_Tarifa),
Cliente VARCHAR(18) not null,
CONSTRAINT fk_ClienteServ FOREIGN KEY (Cliente) REFERENCES Clientes (CURP),
);


CREATE TABLE Contrato(
Domicilio VARCHAR (50) PRIMARY KEY not null ,
Servicio int not null,
CONSTRAINT fk_ServicioCon FOREIGN KEY (Servicio) REFERENCES Servicio (Numero_de_Servicio),
Fecha date not null,
Cliente VARCHAR (18) not null,
CONSTRAINT fk_ClienteCon FOREIGN KEY (Cliente) REFERENCES Clientes (CURP),
Activo bit default (1),
Numero_Medidor int not null,
CONSTRAINT fk_MedidorCon FOREIGN KEY (Numero_Medidor) REFERENCES Consumo (Numero_Medidor),



);
CREATE TABLE Recibo(
Id_Recibo int identity (1,1) Primary Key,

Iva tinyint not null,
Fecha date not null,
Watts int not null,
Numero_Medidor int not null,
CONSTRAINT fk_MedidorRec FOREIGN KEY (Numero_Medidor) REFERENCES Consumo (Numero_Medidor),
Numero_de_Servicio		int not null,
CONSTRAINT fk_ServRec FOREIGN KEY (Numero_de_Servicio) REFERENCES Servicio (Numero_de_Servicio),
Cliente VARCHAR(18),
CONSTRAINT fk_ClienteRec FOREIGN KEY (Cliente) REFERENCES Clientes (CURP),
Tarifa VARCHAR(20),
CONSTRAINT fk_TarifaRec FOREIGN KEY (Tarifa) REFERENCES Tarifa (Id_Tarifa),
Subtotal int not null,
Total int not null
);

