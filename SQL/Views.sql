
	create view ReporteTarifas as 

	SELECT year(Tarifa.Fecha)anio, month(Tarifa.Fecha)mes,Tarifa.Precio_Watt_Bajo, Tarifa.Precio_Watt_Medio, Tarifa.Precio_Watt_Excedente
	FROM Tarifa 
	
	WHERE Tarifa.Id_Tarifa in (select Id_Tarifa from Tarifa)
    group by year(Tarifa.Fecha), month(Tarifa.Fecha), Tarifa.Precio_Watt_Bajo, Tarifa.Precio_Watt_Medio, Tarifa.Precio_Watt_Excedente	

go


create view ReporteConsumoV as 

	SELECT year(Tarifa.Fecha)anio, month(Tarifa.Fecha)mes, Servicio.Numero_Medidor, Tarifa.Precio_Watt_Bajo, Tarifa.Precio_Watt_Medio, Tarifa.Precio_Watt_Excedente
	
	FROM Tarifa 
	join Servicio
	ON Servicio.Tarifa = Tarifa.Id_Tarifa 
	WHERE Tarifa.Id_Tarifa in (select Id_Tarifa from Tarifa)
    group by year(Tarifa.Fecha), month(Tarifa.Fecha), Servicio.Numero_Medidor,Tarifa.Precio_Watt_Bajo, Tarifa.Precio_Watt_Medio, Tarifa.Precio_Watt_Excedente	

go
