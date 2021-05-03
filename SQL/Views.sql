
	create view ReporteTarifas as 

	SELECT year(Tarifa.Fecha)anio, month(Tarifa.Fecha)mes,Tarifa.Precio_Watt_Bajo, Tarifa.Precio_Watt_Medio, Tarifa.Precio_Watt_Excedente
	FROM Tarifa 
	
	WHERE Tarifa.Id_Tarifa in (select Id_Tarifa from Tarifa)
    group by year(Tarifa.Fecha), month(Tarifa.Fecha), Tarifa.Precio_Watt_Bajo, Tarifa.Precio_Watt_Medio, Tarifa.Precio_Watt_Excedente	

go


ALter view ReporteConsumoV as 

	SELECT year(Tarifa.Fecha)anio, month(Tarifa.Fecha)mes, Servicio.Numero_Medidor, Tarifa.Watt_Bajo, Tarifa.Watt_Medio, Tarifa.Watt_Excedente
	
	FROM Tarifa 
	join Servicio
	ON Servicio.Tarifa = Tarifa.Id_Tarifa 
	WHERE Tarifa.Id_Tarifa in (select Id_Tarifa from Tarifa)
    group by year(Tarifa.Fecha), month(Tarifa.Fecha), Servicio.Numero_Medidor,Tarifa.Watt_Bajo, Tarifa.Watt_Medio, Tarifa.Watt_Excedente
	

go



Create view ConsumoHistoricoV as 

	SELECT Consumo.Periodo, Consumo.Watts, Recibo.Importe, Recibo.Total, Recibo.Pendiente_Pago 
	
	FROM Consumo  
	join Recibo 
	ON Consumo.Numero_Medidor = Recibo.Numero_Medidor 
	WHERE Consumo.Numero_Medidor in (select Numero_Medidor from Consumo)
    group by Consumo.Periodo, Consumo.Watts, Recibo.Importe, Recibo.Total, Recibo.Pendiente_Pago 
	
go
