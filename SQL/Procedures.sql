
 /*Empleados-----------------------------*/

Alter proc EmpleadoReg
@CURP VARCHAR (18),
@Fecha_Nacimiento date,
@Nombre VARCHAR (50),
@RFC VARCHAR (12),
@Fecha_de_Alta_Modificacion date,
@Nombre_Usuario VARCHAR(50),
@Contraseņa VARCHAR(50)

as
begin
insert into Usuarios(Nombre_Usuario, Contraseņa) values(@Nombre_Usuario, @Contraseņa);
insert into Empleado(CURP, Fecha_Nacimiento, Nombre, RFC,Fecha_de_Alta_Modificacion,Nombre_Usuario,Contraseņa) values
(@CURP, @Fecha_Nacimiento, @Nombre, @RFC, GETDATE(), @Nombre_Usuario,@Contraseņa)
end
go


Select * from Empleado


Alter procedure EmpleadoUpd
@CURP VARCHAR (18),
@Fecha_Nacimiento date,
@Nombre VARCHAR (50),
@RFC VARCHAR (12),
@Fecha_de_Alta_Modificacion date,
@Contraseņa VARCHAR(50)
As
BEGIN

UPDATE Empleado
set 
CURP = @CURP,
Fecha_Nacimiento = @Fecha_Nacimiento,
Nombre = @Nombre,
RFC = @RFC,
Fecha_de_Alta_Modificacion =@Fecha_de_Alta_Modificacion,
Contraseņa = @Contraseņa


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
Contraseņa

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

Update Empleado set Activo = 0 where Nombre_Usuario = 'Angel'

Create procedure EmpleadoActivo

@Nombre VARCHAR (50)
As
BEGIN

Update Empleado set Activo = 1

WHERE Nombre=@Nombre

END
GO


 /*Clientes-----------------------------*/
