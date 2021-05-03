
 /*Empleados-----------------------------*/

Alter proc EmpleadoReg
@CURP VARCHAR (18),
@Fecha_Nacimiento date,
@Nombre VARCHAR (50),
@RFC VARCHAR (12),
@Fecha_de_Alta_Modificacion date,
@Nombre_Usuario VARCHAR(50),
@Contraseña VARCHAR(50)

as
begin
insert into Usuarios(Nombre_Usuario, Contraseña) values(@Nombre_Usuario, @Contraseña);
insert into Empleado(CURP, Fecha_Nacimiento, Nombre, RFC,Fecha_de_Alta_Modificacion,Nombre_Usuario,Contraseña) values
(@CURP, @Fecha_Nacimiento, @Nombre, @RFC, GETDATE(), @Nombre_Usuario,@Contraseña)
end
go


Select * from Empleado


Alter procedure EmpleadoUpd
@CURP VARCHAR (18),
@Fecha_Nacimiento date,
@Nombre VARCHAR (50),
@RFC VARCHAR (12),
@Fecha_de_Alta_Modificacion date,
@Contraseña VARCHAR(50)
As
BEGIN

UPDATE Empleado
set 
CURP = @CURP,
Fecha_Nacimiento = @Fecha_Nacimiento,
Nombre = @Nombre,
RFC = @RFC,
Fecha_de_Alta_Modificacion =@Fecha_de_Alta_Modificacion,
Contraseña = @Contraseña


WHERE CURP=@CURP 
END
GO


Create procedure getdataEmplead
AS
Begin
Select 
CURP,
Fecha_Nacimiento,
Nombre,
RFC,
Fecha_de_Alta_Modificacion,
Nombre_Usuario,
Contraseña

FROM Empleado 
where Activo = 1 
END
go


Create procedure GetEmpleadInActiv
AS
Begin
Select 
Nombre

FROM Empleado 
where Activo = 0 
END
go

Update Clientes set Activo = 1 where Nombre_Usuario = 'Sadrach'


Create procedure EmpleadoActivo

@Nombre VARCHAR (50)
As
BEGIN

Update Empleado set Activo = 1

WHERE Nombre=@Nombre

END
GO


 /*Clientes-----------------------------*/

 
Create proc ClientesReg
@CURP VARCHAR (18),
@Fecha_Nacimiento date,
@Nombre VARCHAR (50),
@Fecha_de_Alta_Modificacion date,
@Genero varchar (20),
@email varchar (30),
@Nombre_Usuario VARCHAR(50),
@Contraseña VARCHAR(50)

as
begin
insert into Usuarios(Nombre_Usuario, Contraseña) values(@Nombre_Usuario, @Contraseña);
insert into Clientes(CURP, Fecha_Nacimiento, Nombre,Fecha_de_Alta_Modificacion, Genero, email, Nombre_Usuario,Contraseña) values
(@CURP, @Fecha_Nacimiento, @Nombre, GETDATE(), @Genero, @email,@Nombre_Usuario,@Contraseña)
end
go


Create procedure getdataClientes
AS
Begin
Select 
CURP,
Fecha_Nacimiento,
Nombre,
Fecha_de_Alta_Modificacion,
Genero,
email,
Nombre_Usuario,
Contraseña

FROM Clientes 
where Activo = 1 
END
go

select* from Clientes


Create procedure ClienteUpd
@CURP VARCHAR (18),
@Fecha_Nacimiento date,
@Nombre VARCHAR (50),
@Fecha_de_Alta_Modificacion date,
@Genero varchar (20),
@email varchar (30),
@Contraseña VARCHAR(50)

As
BEGIN

UPDATE Clientes
set 
CURP = @CURP,
Fecha_Nacimiento = @Fecha_Nacimiento,
Nombre = @Nombre,
Fecha_de_Alta_Modificacion =@Fecha_de_Alta_Modificacion,
Genero = @Genero,
email = @email,
Contraseña = @Contraseña

WHERE CURP=@CURP 
END
GO


Create procedure GetClienteInActiv
AS
Begin
Select 
Nombre

FROM Clientes 
where Activo = 0 
END
go



Create procedure ClienteActivo

@Nombre VARCHAR (50)
As
BEGIN

Update Clientes set Activo = 1

WHERE Nombre=@Nombre

END
GO


Alter procedure EliminarCliente
@CURP VARCHAR (18)
As
BEGIN

Update Clientes set Activo = 0

WHERE CURP=@CURP

END
GO

select* from Clientes


/*-------------------------------------------------------*/
/* -----------   REPORTES -----------*/


Alter procedure GetDatoTarifas
@anio int

AS
Begin
Select
anio'Año', 
mes 'Mes',
Precio_Watt_Bajo 'Basica',
Precio_Watt_Medio 'Intermedio',
Precio_Watt_Excedente 'Excedente'

FROM ReporteTarifas
END
go 


Alter procedure GetDatoConsumo
@anio int

AS
Begin
Select
anio'Año', 
mes 'Mes',
Numero_Medidor 'Medidor',
Watt_Bajo 'Bajo',
Watt_Medio 'Medio',
Watt_Excedente 'Excedente'

FROM ReporteConsumoV
END
go 

Create Procedure ConsumoHistorico
@anio int,
@Numero_Medidor int,
@Numero_de_Servicio int
as 
begin
Select

Periodo 'Periodo Facturacion',
Watts 'Consumo de kW', 
Importe 'Importe', 
Total 'Pago', 
Pendiente_Pago  'Pendiente de Pago'

From ConsumoHistoricoV
end 
go























