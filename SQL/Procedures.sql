
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
insert into Usuarios(Nombre_Usuario, Contraseña, Permiso) values(@Nombre_Usuario, @Contraseña, 2);
insert into Empleado(CURP, Fecha_Nacimiento, Nombre, RFC,Fecha_de_Alta_Modificacion,Nombre_Usuario,Contraseña) values
(@CURP, @Fecha_Nacimiento, @Nombre, @RFC, GETDATE(), @Nombre_Usuario,@Contraseña)
end
go





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

Update Clientes set Activo = 0 where Nombre_Usuario = 'Sadrach'


Create procedure EmpleadoActivo

@Nombre VARCHAR (50)
As
BEGIN

Update Empleado set Activo = 1

WHERE Nombre=@Nombre

END
GO


 /*Clientes-----------------------------*/

 
Alter proc ClientesReg
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
insert into Usuarios(Nombre_Usuario, Contraseña, Permiso) values(@Nombre_Usuario, @Contraseña, 1);
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

/*---------------------LOGIN ------------------------*/

CREATE procedure LoginEmp
 @Nombre_Usuario varchar (50),
 @Contraseña varchar(15)
as 
begin

IF((select Contraseña from Usuarios where Nombre_Usuario = @Nombre_Usuario) = @Contraseña)
BEGIN
   SELECT 1 
END
ELSE
BEGIN
    SELECT 2
END
END
GO

CREATE procedure LoginPermiso
@Nombre_Usuario varchar (50)
as 
begin

select Permiso from Usuarios where Nombre_Usuario = @Nombre_Usuario
end

GO


CREATE procedure ClienteLogin
@Nombre_Usuario	varchar(50)
as
begin 
select 
CURP  
from Clientes  
where Nombre_Usuario = @Nombre_Usuario 
end
GO




CREATE procedure GetEmpleadoGral
@Nombre_Usuario	varchar(50)
AS
BEGIN
Select Usuar.Nombre_Usuario  from Usuarios Usuar
join Empleado Empl
on Empl.Nombre_Usuario = Usuar.Nombre_Usuario
where Empl.Nombre_Usuario =@Nombre_Usuario  
END
GO

/*-------------------------------*/




/*------------------------------------TARIFAS----------------------------------*/


Create procedure TarifaReg
@PrecioBajo float,
@PrecioMedio float,
@PrecioExcedente float,
@PeriodoFac date,
@Uso bit,
@ConsumoBajo int,
@ConsumoMedio int,
@ConsumoExcedente int


as
begin
insert into Tarifa(Precio_Watt_Bajo, Precio_Watt_Medio, Precio_Watt_Excedente,Fecha, Tipo_de_uso,Watt_Bajo,Watt_Medio,Watt_Excedente) values
(@PrecioBajo, @PrecioMedio, @PrecioExcedente, @PeriodoFac, @Uso, @ConsumoBajo,@ConsumoMedio,@ConsumoExcedente)
end
go


/*-----------------------------------------Contrato------------------------------------------*/

CREATE procedure regContrato
@Domicilio varchar (50),
@Servicio bit,
@curp varchar (18),
@fecha date

As
Begin
insert into Contrato(Domicilio,Servicio,Fecha,Cliente,Activo) values (@Domicilio,@Servicio,@curp,@fecha,1)
End
go


Create procedure regConsumo
@NumeroMedidor int,
@Watts int,
@Periodo date

As
Begin
Insert into Consumo(Numero_Medidor,Watts,Periodo) values (@NumeroMedidor,@Watts,@Periodo)
End
go