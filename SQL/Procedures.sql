
 /*Empleados-----------------------------*/

Create proc EmpleadoReg
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




Create procedure EmpleadoUpd
@CURP VARCHAR (18),
@Fecha_Nacimiento date,
@Nombre VARCHAR (50),
@RFC VARCHAR (12),
@Fecha_de_Alta_Modificacion date,
@Contraseña VARCHAR(50)
--@Nombre_Usuario varchar(50)
--@Nombre_UsuarioOLD varchar(50)

As
BEGIN

--update usuario set Nombre_Usuario= @Nombre_usuario where Nombre_usuario=@Nombre_usuarioOLD
--update usuario set Contraseña = @Contraseña where Nombre_Usuario = @Nombre_Usuario

--Update Usuarios  
--set 
--  where Nombre_Usuario = @Nombre_Usuario

UPDATE Empleado
set 
CURP = @CURP,
Fecha_Nacimiento = @Fecha_Nacimiento,
Nombre = @Nombre,
RFC = @RFC,
Fecha_de_Alta_Modificacion =@Fecha_de_Alta_Modificacion,
Contraseña = @Contraseña
--Nombre_Usuario = @Nombre_Usuario

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



Create procedure EmpleadoActivo

@Nombre VARCHAR (50)
As
BEGIN

Update Empleado set Activo = 1

WHERE Nombre=@Nombre

END
GO


 /*Clientes-----------------------------*/

 
Create procedure ClientesReg
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
insert into Clientes(CURP, Fecha_Nacimiento, Nombre,Fecha_de_Alta_Modificacion, Genero, email, Nombre_Usuario,Contraseña ) values
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

--Update Usuarios  
--set 
--Contraseña = @Contraseña 

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


Create procedure EliminarCliente
@CURP VARCHAR (18)
As
BEGIN

Update Clientes set Activo = 0

WHERE CURP=@CURP

END
GO


/*-------------------------------------------------------*/
/* -----------   REPORTES -----------*/


create procedure GetDatoTarifas
@ano int

AS
Begin
Select
ano'Año', 
mes 'Mes',
Precio_Watt_Bajo 'Basica',
Precio_Watt_Medio 'Intermedio',
Precio_Watt_Excedente 'Excedente'

FROM ReporteTarifas where ano = @ano
END
go 


Create procedure GetDatoConsumo
@ano int

AS
Begin
Select
ano'Año', 
mes 'Mes',
Numero_Medidor 'Medidor',
Watt_Bajo 'Bajo',
Watt_Medio 'Medio',
Watt_Excedente 'Excedente'

FROM ReporteConsumoV where ano = @ano
END
go 


Create Procedure ConsumoHistorico
@ano int = null,
@Numero_Medidor int = null,
@Numero_de_Servicio int = null

as 
begin
Select

Fecha'Periodo Facturacion',
Watts 'Consumo de kW', 
Subtotal'Importe', 
Total'Pago',
Pendiente_Pago'Pendiente de Pago'

From ConsumoHistoricoV
where (YEAR(Fecha) = @ano or @ano is null)  and (ConsumoHistoricoV.Numero_Medidor = @Numero_Medidor  or @Numero_Medidor is null) and (ConsumoHistoricoV.Servicio = @Numero_de_Servicio or @Numero_de_Servicio is null)

end 
go


/*---------------------LOGIN ------------------------*/

Create procedure LoginEmp
 @Nombre_Usuario varchar (50),
 @Contraseña varchar(15)
as 
begin

IF((select 1  from Usuarios where Nombre_Usuario = @Nombre_Usuario) = 1)

BEGIN
   IF((select Contraseña from Usuarios where Nombre_Usuario = @Nombre_Usuario) = @Contraseña)
   BEGIN
   SELECT 1
   END
   ELSE 
   BEGIN 
   SELECT 3
   END
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

create procedure ActivarLogin
@Nombre_Usuario	varchar(50),
@activo bit
as
begin
Update Usuarios set Activo = @activo where Nombre_Usuario = @Nombre_Usuario


end 
go

create procedure SortUsuario
as 
begin
select Nombre_Usuario from Usuarios where Activo=1
end
go

create procedure SortCliente
@nombre_usuario varchar (50)
as begin
select
CURP,
Fecha_Nacimiento,
Nombre,
Fecha_de_Alta_Modificacion,
Genero,
email
from Clientes where Nombre_Usuario= @nombre_usuario
end 
go




create procedure DesactivarLogin
@Nombre_Usuario	varchar(50)
as
begin
Update Empleado set Activo = 0 where Nombre_Usuario = @Nombre_Usuario
Update Clientes set Activo = 0 where Nombre_Usuario = @Nombre_Usuario

end 
go

Create procedure GetEmpleadInActivLogin
@Nombre_Usuario	varchar(50)

AS
Begin
Select Activo 

FROM Empleado 
where Nombre_Usuario = @Nombre_Usuario
END
go




Create procedure GetClienteInActivLogin
@Nombre_Usuario	varchar(50)

AS
Begin
Select Activo 

FROM Clientes  
where Nombre_Usuario = @Nombre_Usuario
END
go





/*-----------RECIBO --------------------*/

create procedure getdataRecibo
@curp  varchar (18)
AS
Begin
Select 

Cliente,
Id_Recibo,
Iva,
Fecha,
Watts,
Numero_Medidor,
Servicio,
Cliente,
Tarifa ,
Subtotal,
Total,
Pendiente_Pago,
Pagado 

FROM Recibo where Cliente = @curp and Pagado = 0
end
go


create procedure ObtenerCliente
@curp varchar (18)

AS
Begin
Select 
CURP,
Fecha_Nacimiento,
Nombre ,
Fecha_de_Alta_Modificacion,
Genero,
email,
Nombre_Usuario,
Contraseña ,
Activo

FROM Clientes where CURP = @curp 
end
go



Create procedure ReciboPDF
@ano int = null,
@mes int = null,
@Numero_Medidor int = null,
@Numero_de_Servicio int = null

AS
Begin
Select
Cliente , 
Domicilio, 
Numero_Medidor, 
Servicio, 
Fecha ,
Total, 
Subtotal,
Iva, 
Pendiente_Pago  

FROM RecibopdfV where (YEAR(Fecha) = @ano or @ano is null)  and (MONTH(Fecha) = @mes or @mes is null) and (RecibopdfV.Numero_Medidor = @Numero_Medidor  or @Numero_Medidor is null) and (RecibopdfV.Servicio = @Numero_de_Servicio or @Numero_de_Servicio is null)
--where ano = @ano and mes= @mes and Numero_Medidor =  @Numero_Medidor and Numero_de_Servicio = @Numero_de_Servicio

END
go







select * from RecibopdfV


/*------------------------------------TARIFAS----------------------------------*/


Create procedure TarifaReg
@PrecioBajo float,
@PrecioMedio float,
@PrecioExcedente float,
@mes int,
@ano int,
@Uso bit,
@ConsumoBajo int,
@ConsumoMedio int,
@ConsumoExcedente int
as

begin
insert into Tarifa(Precio_Watt_Bajo, Precio_Watt_Medio, Precio_Watt_Excedente,mes,ano, Tipo_de_uso,Watt_Bajo,Watt_Medio,Watt_Excedente) values
(@PrecioBajo, @PrecioMedio, @PrecioExcedente, @mes,@ano, @Uso, @ConsumoBajo,@ConsumoMedio,@ConsumoExcedente)
end
go


/*-----------------------------------------Contrato------------------------------------------*/

create  procedure regContrato
@Domicilio varchar (50),
@Servicio bit,
@fecha date,
@curp varchar (18)


As


Begin
insert into Contrato(Domicilio,Servicio,Fecha,Cliente,Activo) values (@Domicilio,@Servicio,@fecha,@curp,1)
End
go


create procedure getContratos
AS
Begin
Select 
Domicilio,
Servicio,
Fecha,
Cliente,
Numero_Medidor

FROM Contrato
where Activo = 1 
END
go

create procedure getContratosMedidor
@Medidor int
AS
Begin
Select 
Domicilio,
Servicio,
Fecha,
Cliente,
Numero_Medidor

FROM Contrato
where Activo = 1 and Numero_Medidor=@Medidor
END
go

create procedure getContratosCliente
@curp varchar(18)
AS
Begin
Select 
Domicilio,
Servicio,
Fecha,
Cliente,
Numero_Medidor

FROM Contrato
where Activo = 1 and Cliente=@curp
END
go

create procedure getTarifaSort
@mes int,
@ano int
AS
Begin
Select 
Id_Tarifa,
ano,
mes,
Precio_Watt_Bajo,
Precio_Watt_Medio,
Precio_Watt_Excedente,
Tipo_de_uso,
Watt_Bajo,
Watt_Medio,
Watt_Excedente
	FROM Tarifa where mes=@mes  and ano=@ano and Tipo_de_uso=0
END
go

create procedure getTarifaSortID
@ID int

AS
Begin
Select 
Id_Tarifa,
ano,
mes,
Precio_Watt_Bajo,
Precio_Watt_Medio,
Precio_Watt_Excedente,
Tipo_de_uso,
Watt_Bajo,
Watt_Medio,
Watt_Excedente
	FROM Tarifa where Id_Tarifa=@ID  
END
go

--------------------------------------------------------------------------------AQUI ESTA 
 create procedure getTarifaSortInd
@mes int,
@ano int
AS
Begin
Select 
Id_Tarifa,
ano,
mes,
Precio_Watt_Bajo,
Precio_Watt_Medio,
Precio_Watt_Excedente,
Tipo_de_uso,
Watt_Bajo,
Watt_Medio,
Watt_Excedente
	FROM Tarifa where mes=@mes  and ano=@ano and Tipo_de_uso=1
END
go

 create procedure getConsumoSort
AS
Begin
Select 
Id_Consumo,
ano,
mes,
Numero_Medidor,
Watts
	FROM Consumo where Used=0
	end
go


alter procedure getConsumoByDate
@Numero_Medidor int,
@ano int,
@mes int


AS
Begin
Select 
Id_Consumo,
ano,
mes,
Numero_Medidor,
Watts
	FROM Consumo where Used=0 and ano=@ano and mes=@mes and Numero_Medidor = @Numero_Medidor
	end
go



/*------------------------------------------Consumo-------------------------------------------*/

Create procedure regConsumo
@NumeroMedidor int,
@Watts int,
@mes int,
@ano int

As


Begin
Insert into Consumo(Numero_Medidor,Watts,mes,ano ) values (@NumeroMedidor,@Watts,@mes,@ano)
End
go
/*---------------------------------------------------------------------------------------------------------------*/

Create procedure regConsumoMasivo
@tblConsumo ConsumoMasivo readonly
as 
begin
set nocount on;
insert into Consumo(ano,mes,Numero_Medidor,Watts) select ano, mes, NumMedidor,Watts from @tblConsumo
end

go

create procedure regTarifaMasivo
@tblTarifa TarifaMasiva readonly
as 
begin
set nocount on;
insert into Tarifa(Precio_Watt_Bajo,Precio_Watt_Medio,Precio_Watt_Excedente,mes,ano,Tipo_de_uso,Watt_Bajo,Watt_Medio,Watt_Excedente) select Precio_Medio, Precio_Bajo, Precio_Excedente ,ano,mes,Tipo_de_uso, Watt_Bajo,Watt_Medio, Watt_Excedente from @tblTarifa
end


go


create procedure regRecibo
@watts int,
@medidor int,
@servicio bit,
@curp varchar (18),
@tarifa int,
@subtotal float,
@total float,
@pendiente_pago float,
@Consumo int

as
begin
insert into Recibo(Fecha,Watts,Servicio,Subtotal,Total,Pendiente_Pago,Pagado,Tarifa,Numero_Medidor,Cliente,Id_Consumo ) values (getdate(),@watts,@servicio,@subtotal,@total,@pendiente_pago,0,@tarifa,@medidor,@curp,@Consumo) 
Update Consumo set Used =1 where Id_Consumo = @Consumo

end
 go

 create procedure altConsumo
 @id int
 as
 begin
 Update Consumo set Used =1 where Id_Consumo = @id

end
 go

 create procedure getRecibodataCURPactivo
@curp varchar(18)
AS
Begin
Select 
Id_Recibo,
Fecha,
Watts,
Tarifa,
Subtotal,
Total,
Pendiente_Pago
Fecha,
Cliente,
Numero_Medidor,
Pagado

FROM Recibo
where  Cliente=@curp and Pagado=0
END
go
 create procedure getRecibodataCURPinactivo
@curp varchar(18)
AS
Begin
Select 
Id_Recibo,
Fecha,
Watts,
Tarifa,
Subtotal,
Total,
Pendiente_Pago
Fecha,
Cliente,
Numero_Medidor,
Pagado

FROM Recibo
where  Cliente=@curp and Pagado=1
END
go

create procedure updateReciboPago
@pendientepago int,
@pagado bit,
@Id int
as 
begin
Update Recibo set Pendiente_Pago = @pendientepago where Id_Recibo = @Id
Update Recibo set Pagado = @pagado where Id_Recibo = @Id
end
go
   
Select * from Empleado   

 Select * from Recibo
Select * from Consumo 
                                  


Select * from Tarifa      
     
Select * from Contrato  
Select * from Usuarios
Select * from ReporteConsumoV  

update Clientes set Activo = 1 



update Empleado set Activo = 0 where Nombre = 'Beatriz Pinzon'

insert into Usuarios(Nombre_Usuario, Contraseña, Permiso) values('Alejandro Venegas','AdmiGenial',3)

insert into Administrador (Nombre_Usuario, Contraseña, Permiso) values('UsuarioAdmin','AdmiGenial',3)


