
	create view ReporteTarifas as 

	SELECT Tarifa.ano, Tarifa.mes,Tarifa.Precio_Watt_Bajo, Tarifa.Precio_Watt_Medio, Tarifa.Precio_Watt_Excedente
	FROM Tarifa 
	
	WHERE Tarifa.Id_Tarifa in (select Id_Tarifa from Tarifa)
    group by Tarifa.ano, Tarifa.mes, Tarifa.Precio_Watt_Bajo, Tarifa.Precio_Watt_Medio, Tarifa.Precio_Watt_Excedente	

go

--CHECAR ESTAS VISTAS ---------------
Create view ReporteConsumoV as 

	SELECT Tarifa.ano, Tarifa.mes, Consumo.Numero_Medidor, Tarifa.Watt_Bajo, Tarifa.Watt_Medio, Tarifa.Watt_Excedente
	
	FROM Tarifa 
	join Consumo  
	ON Consumo.ano  = Tarifa.ano 
	WHERE Tarifa.ano in (select Id_Tarifa from Tarifa)
    group by Tarifa.ano, Tarifa.mes, Consumo.Numero_Medidor,Tarifa.Watt_Bajo, Tarifa.Watt_Medio, Tarifa.Watt_Excedente
	

go

Create view ConsumoHistoricoV as 

	SELECT Consumo.Periodo, Consumo.Watts, Recibo.Importe, Recibo.Total, Recibo.Pendiente_Pago 
	
	FROM Consumo  
	join Recibo 
	ON Consumo.Numero_Medidor = Recibo.Numero_Medidor 
	WHERE Consumo.Numero_Medidor in (select Numero_Medidor from Consumo)
    group by Consumo.Periodo, Consumo.Watts, Recibo.Importe, Recibo.Total, Recibo.Pendiente_Pago 
	
go
------------------------------------------------------------