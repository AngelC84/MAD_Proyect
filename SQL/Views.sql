
	create view ReporteTarifas as 

	SELECT Tarifa.ano, Tarifa.mes,Tarifa.Precio_Watt_Bajo, Tarifa.Precio_Watt_Medio, Tarifa.Precio_Watt_Excedente
	FROM Tarifa 
	
	WHERE Tarifa.Id_Tarifa in (select Id_Tarifa from Tarifa)
    group by Tarifa.ano, Tarifa.mes, Tarifa.Precio_Watt_Bajo, Tarifa.Precio_Watt_Medio, Tarifa.Precio_Watt_Excedente	

go

--CHECAR ESTAS VISTAS ---------------
Alter view ReporteConsumoV as 

	SELECT Tarifa.ano, Tarifa.mes, Consumo.Numero_Medidor, Tarifa.Watt_Bajo, Tarifa.Watt_Medio, Tarifa.Watt_Excedente
	
	FROM Tarifa 
	join Consumo  
	ON Consumo.ano = Tarifa.ano
    group by Tarifa.ano, Tarifa.mes, Consumo.Numero_Medidor,Tarifa.Watt_Bajo, Tarifa.Watt_Medio, Tarifa.Watt_Excedente

go

select * from ConsumoHistoricoV

Alter view ConsumoHistoricoV as 

	SELECT Recibo.Fecha, Recibo.Watts, Recibo.Subtotal, Recibo.Total, Recibo.Pendiente_Pago, Recibo.Numero_Medidor, Contrato.Servicio
	
	FROM Recibo   
	join Contrato
	on Contrato.Numero_Medidor = Recibo.Numero_Medidor  
    group by Recibo.Fecha, Recibo.Watts, Recibo.Subtotal, Recibo.Total, Recibo.Pendiente_Pago, Recibo.Numero_Medidor, Contrato.Servicio
	
	
go
------------------------------------------------------------