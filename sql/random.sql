/*
CREATE PROCEDURE [HAY_TABLA].[sp_listado_1]
	@desde DATETIME,
	@hasta DATETIME
AS
BEGIN	
	SELECT 	TOP 5 
			CD.NOMBRE, COUNT(*)
	FROM 	gd_esquema.Maestra, [HAY_TABLA].CIUDAD CO, [HAY_TABLA].CIUDAD CD, [HAY_TABLA].RUTA R, [HAY_TABLA].PASAJE_ENCOMIENDA P_E, [HAY_TABLA].COMPRA C, [HAY_TABLA].VIAJE V
	WHERE 	
			P_E.ID_COMPRA = C.ID AND P_E.ID_BUTACA_PASAJE IS NOT NULL -- porque pide por "pasajes" y NO "encomiendas"
			AND C.ID_VIAJE = V.ID AND V.STATUS = 1 
			AND C.FECHA BETWEEN @desde AND @hasta
			AND V.ID_RUTA = R.ID AND R.ID_CDADDESTINO = CD.ID 
			-- AND R.ID_CDADORIGEN = CO.ID
	GROUP BY 
			CD.NOMBRE
	ORDER BY 
			2 ASC
END
GO

----- */

CREATE PROCEDURE [HAY_TABLA].[sp_get_listado_1]
	@desde DATETIME,
	@hasta DATETIME
AS
BEGIN	

select top 5 ci.NOMBRE as 'Ciudad',COUNT(p.ID) as 'Cantidad de Pasajes comprados' ,
 MIN(c.FECHA )as 'Desde la fecha' , MAX (c.FECHA) as 'Hasta la fecha' from  HAY_TABLA.PASAJE p 
inner join HAY_TABLA.COMPRA c on c.ID = p.ID_COMPRA 
inner join HAY_TABLA.VIAJE  v on v.ID = p.ID_VIAJE
inner join HAY_TABLA.RUTA r on r.ID= v.ID_RUTA 
inner join HAY_TABLA.CIUDAD ci on ci.ID=r.ID_CDADDESTINO
where YEAR( c.FECHA ) = YEAR (@desde) and MONTH (c.FECHA)  between MONTH (@desde) and MONTH (@hasta) 
and p.ID not in (select pa.ID from HAY_TABLA.DEVOLUCION d
inner join HAY_TABLA.ITEMSDEVOLUCION i on d.ID= i.ID_DEVOLUCION
inner join HAY_TABLA.COMPRA co on co.ID = i.ID_COMPRA
inner join HAY_TABLA.PASAJE pa on pa.ID = i.ID_PASAJE 
where YEAR( co.FECHA ) = YEAR (@desde) and MONTH (co.FECHA)  between MONTH (@desde) and MONTH (@hasta) )
group by ci.NOMBRE order by COUNT(p.ID)  desc

END

----------



/*
CREATE PROCEDURE [HAY_TABLA].[sp_listado_2]
	@desde DATETIME,
	@hasta DATETIME
AS
BEGIN	
	SELECT 	TOP 5 
			CD.NOMBRE, COUNT(*)
	FROM 	gd_esquema.Maestra, [HAY_TABLA].CIUDAD CO, [HAY_TABLA].CIUDAD CD, [HAY_TABLA].RUTA R, [HAY_TABLA].PASAJE_ENCOMIENDA P_E, [HAY_TABLA].COMPRA C, [HAY_TABLA].VIAJE V
	WHERE 	
			P_E.ID_COMPRA = C.ID AND P_E.ID_BUTACA_PASAJE IS NOT NULL -- porque pide por "pasajes" y NO "encomiendas"
			AND C.ID_VIAJE = V.ID AND V.STATUS = 1 
			AND C.FECHA BETWEEN @desde AND @hasta
			AND V.ID_RUTA = R.ID AND R.ID_CDADDESTINO = CD.ID 
			-- AND R.ID_CDADORIGEN = CO.ID
	GROUP BY 
			CD.NOMBRE


	SELECT 	TOP 5 
			A.MATRICULA
			GROUP BY 
			HAVING COUNT(*)

END
GO
---------------------

CREATE PROCEDURE [HAY_TABLA].[sp_listado_2]
	@desde DATETIME,
	@hasta DATETIME
AS
BEGIN	

select  top 5 ci.NOMBRE from 
 hay_tabla.BUTACA b
inner join HAY_TABLA.PASAJE p  on b.ID = p.ID_BUTACA
inner join HAY_TABLA.COMPRA  c on c.ID = p.ID_COMPRA
inner join HAY_TABLA.VIAJE v on v.ID = p.ID_VIAJE
inner join HAY_TABLA.AERONAVE  a on v.ID_AERONAVE = a.ID
inner join HAY_TABLA.RUTA r on r.ID = v.ID_RUTA
inner join HAY_TABLA.CIUDAD ci on ci.ID = r.ID_CDADDESTINO
where YEAR( c.FECHA ) = YEAR (@desde) and MONTH (c.FECHA)  between MONTH (@desde) and MONTH (@hasta) 
and p.ID not in (select pa.ID from HAY_TABLA.DEVOLUCION d
inner join HAY_TABLA.ITEMSDEVOLUCION i on d.ID= i.ID_DEVOLUCION
inner join HAY_TABLA.COMPRA co on co.ID = i.ID_COMPRA
inner join HAY_TABLA.PASAJE pa on pa.ID = i.ID_PASAJE 
where YEAR( co.FECHA ) = YEAR (@desde) and MONTH (co.FECHA)  between MONTH (@desde) and MONTH (@hasta)   )
group by ci.NOMBRE ,a.CANTBUTACASPASILLO ,a.CANTBUTACASVENTANILLA 
 order by  (a.CANTBUTACASPASILLO+ a.CANTBUTACASVENTANILLA ) - count(*) desc 


 END
GO */

CREATE PROCEDURE [HAY_TABLA].[sp_get_listado_3]
	@desde DATETIME,
	@hasta DATETIME
AS
BEGIN
	SELECT TOP 5 p.NOMBRE as 'Nombre' , p.APELLIDO as 'Apellido', p.MAIL as 'E.mail', (((CAST(pa.IMPORTE AS int) +CAST(e.IMPORTE AS int)) / 10)) as 'Millas'
		    
		 
	from HAY_TABLA.PERSONA p 

	join HAY_TABLA.PASAJE pa on p.ID = pa.ID_CLIENTE

							 join HAY_TABLA.COMPRA c on c.ID_COMPRADOR = p.ID
							 join HAY_TABLA.ENCOMIENDA e on e.ID_COMPRA =c.ID
							 join HAY_TABLA.VIAJE v on pa.ID_VIAJE = v.ID
							 join HAY_TABLA.RUTA r on v.ID_RUTA = r.ID
							 join HAY_TABLA.CIUDAD ciu1 on r.ID_CDADORIGEN = ciu1.ID
							 join HAY_TABLA.CIUDAD ciu2 on r.ID_CDADDESTINO = ciu2.ID
	where pa.ID not in (select i.ID_PASAJE from HAY_TABLA.DEVOLUCION d 

	inner join  HAY_TABLA.ITEMSDEVOLUCION i  on d.ID = i.ID_DEVOLUCION)

	and  YEAR (c.FECHA) =YEAR (@desde) and MONTH (c.FECHA) between MONTH(@desde) and MONTH(@hasta)
	order by 4 desc 

	END 

	GO

CREATE PROCEDURE [HAY_TABLA].[sp_get_listado_4]
	@desde DATETIME,
	@hasta DATETIME
AS
BEGIN	
select top 5 ci.NOMBRE as 'Ciudad', count (*) as 'Cantidad de pasajes devueltos', count(r.ID) as 'Cantidad de Rutas' ,
MIN (c.FECHA)as 'Desde la fecha ' , MAX(c.Fecha) as 'Hasta la fecha'
from  HAY_TABLA.PASAJE p
inner join HAY_TABLA.COMPRA c on c.ID = p.ID_COMPRA 
inner join HAY_TABLA.VIAJE  v on v.ID = p.ID_VIAJE
inner join HAY_TABLA.RUTA r on r.ID= v.ID_RUTA 
inner join HAY_TABLA.CIUDAD ci on ci.ID=r.ID_CDADDESTINO
where YEAR( c.FECHA ) = YEAR (@desde) and MONTH (c.FECHA)  between MONTH (@desde) and MONTH (@hasta)
and p.ID in (select pa.ID from HAY_TABLA.DEVOLUCION d
inner join HAY_TABLA.ITEMSDEVOLUCION i on d.ID= i.ID_DEVOLUCION
inner join HAY_TABLA.COMPRA co on co.ID = i.ID_COMPRA
inner join HAY_TABLA.PASAJE pa on pa.ID = i.ID_PASAJE 
where YEAR( co.FECHA ) = YEAR (@desde) and MONTH (co.FECHA)  between MONTH (@desde) and MONTH (@hasta))

group by ci.NOMBRE  order by 2 desc
END 
GO


CREATE PROCEDURE [HAY_TABLA].[sp_get_listado_5]
	@desde DATETIME,
	@hasta DATETIME
AS
BEGIN	
	select top 5 a.MATRICULA as 'Matricula',a.FABRICANTE as 'Fabricante' , a.MODELO as 'modelo',a.FECHAALTA as 'Fecha de ingreso de la aeronave al sistema ',
	(select sum (datediff(DD,hi.FECHABAJA ,hi.FECHAREINICIO))
	 from HAY_TABLA.AERONAVE ae
      inner join HAY_TABLA.HISTORIALBAJA_AERONAVE hi on ae.ID = hi.ID_AERONAVE
      where ae.ID = a.ID 
) as 'Cantidad de dias fuera de servicio'
 
 
 
 from HAY_TABLA.AERONAVE a
inner join HAY_TABLA.HISTORIALBAJA_AERONAVE h on a.ID = h.ID_AERONAVE

where  h.ID_TIPOBAJA = 1 
and YEAR (h.FECHABAJA) = YEAR (@desde) and MONTH(h.FECHABAJA)  between MONTH (@desde) and MONTH (@hasta)
and YEAR (h.FECHAREINICIO) = YEAR (@hasta) and MONTH(h.FECHAREINICIO) between MONTH (@desde) and MONTH (@hasta)
 group by a.ID ,a.MATRICULA,a.FABRICANTE ,a.MODELO ,a.FECHAALTA 
 order by 5 desc 


END
GO

CREATE PROCEDURE [HAY_TABLA].[sp_get_rol_by_id]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		Id,
		Nombre,
		Status
	FROM 
		[HAY_TABLA].Rol
	WHERE
		Id = @id
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_insertar_rol]
	@nombre NVARCHAR(50),
	@estado bit
AS
BEGIN
	
	if (exists(select id from [HAY_TABLA].ROL where NOMBRE = @nombre))
		begin
			RAISERROR(N'Ya existe un Rol con ese nombre',16,1)
			return
		end		
		
	INSERT INTO [HAY_TABLA].ROL  (NOMBRE, STATUS)
    OUTPUT
		inserted.id
    VALUES
          (@nombre, @estado)
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_baja_rol]
	@id	int
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE 
		[HAY_TABLA].ROL
	SET 
		STATUS = 0
	WHERE
		id = @id
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_select_roles]
	@nombre nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		Id,
		Nombre,
		Status
	FROM	
		[HAY_TABLA].Rol
	WHERE		
		((@nombre is null) or Nombre like '%' + @nombre + '%')
		and id<>2
	ORDER BY
		Nombre 
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_get_usuario_by_id]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ID, USERNAME, PASSWORD, INTENTOSFALLIDOS
	FROM [HAY_TABLA].USUARIO
	WHERE USUARIO.Id = @id
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_get_usuario_by_login]
	@username NVARCHAR(255),
	@password NVARCHAR(256)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ID, USERNAME, PASSWORD, INTENTOSFALLIDOS
	FROM [HAY_TABLA].USUARIO
	WHERE USERNAME = @username AND PASSWORD = @password
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_get_usuario_intentos]
	@username NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT INTENTOSFALLIDOS
	FROM [HAY_TABLA].USUARIO
	WHERE USERNAME = @username
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_set_usuario_intentos]
	@username NVARCHAR(255),
	@intentos int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [HAY_TABLA].USUARIO 
	SET INTENTOSFALLIDOS = @intentos 
	WHERE USERNAME = @username
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_set_status_usuario]
	@username NVARCHAR(255),
	@status int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [HAY_TABLA].USUARIO 
	SET STATUS = @status 
	WHERE USERNAME = @username
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_modificacion_rol]
	@id	int,
	@nombre nvarchar(50),
	@estado bit
AS
BEGIN
	SET NOCOUNT ON;
	
		if (exists(select id from [HAY_TABLA].ROL where Nombre = @nombre and id<> @id))
		begin
			RAISERROR(N'Ya existe un Rol con ese nombre',16,1)
			return
		end		
	
	UPDATE 
		[HAY_TABLA].ROL
	SET 
		Nombre = @nombre,
		Status = @estado
	WHERE
		id = @id
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_select_funcionalidades_de_rol]
	@rol_id int,
	@nombre varchar(255) = null
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		 f.Id,
		 f.Nombre,
		 ISNULL((
			SELECT
				1
			FROM 
				FUNCIONALIDAD_ROL fr 
			WHERE
				fr.ID_FUNCIONALIDAD = f.id and 
				fr.ID_ROL = @rol_id), 0) AS 'Seleccionado'
	FROM
		[HAY_TABLA].FUNCIONALIDAD f
	WHERE
		(@nombre is null) or (@nombre = f.Nombre)
	ORDER BY
		Nombre
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_select_funcionalidades_de_rol_nuevo]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		 f.Id,
		 f.Nombre,
		 0 as 'Seleccionado'
	FROM
		[HAY_TABLA].FUNCIONALIDAD f
	ORDER BY
		Nombre
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_insertar_funcionalidad_a_rol]
	@idRol int,
	@idFuncionalidad int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [HAY_TABLA].[FUNCIONALIDAD_ROL]
           ([ID_ROL]
           ,[ID_FUNCIONALIDAD])
     VALUES
           (@IdRol
           ,@IdFuncionalidad)
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_borrar_funcionalidades_de_rol]
       @idRol int 
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM
		[HAY_TABLA].FUNCIONALIDAD_ROL
	WHERE
		ID_ROL = @idRol
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_select_roles_de_usuario]
	@id_usuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		ID_ROL
	FROM	
		[HAY_TABLA].ROLES_USUARIO
	WHERE
		ID_USUARIO = @id_usuario
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_get_ciudades]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		ID, NOMBRE, STATUS
	FROM 
		[HAY_TABLA].CIUDAD
	WHERE
		STATUS = 1
	ORDER BY
		NOMBRE
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_insertar_ciudad]
	@nombre nvarchar(100)
AS
BEGIN
	SET NOCOUNT ON;
	if (exists(select id from [HAY_TABLA].CIUDAD where NOMBRE like '%' + @nombre and STATUS = 1))
		begin
			RAISERROR(N' Ya existe una ciudad con ese nombre ', 16, 1)
			return
		end		
	else 
		begin
			if (exists(select id from [HAY_TABLA].CIUDAD where NOMBRE like '%' + @nombre and STATUS = 0))		
				begin
					UPDATE 
						[HAY_TABLA].CIUDAD
					SET 
						STATUS = 1
					WHERE
						NOMBRE LIKE '%' + @nombre 
						AND STATUS = 0
					RAISERROR(N' Habilito Ciudad ', 16, 1)
					return
				end
			else
				begin
					INSERT INTO [HAY_TABLA].CIUDAD 
								(NOMBRE, STATUS)
					OUTPUT
						inserted.id
					VALUES
						(@nombre, 1)
					RAISERROR(N' Agrego Nueva Ciudad ', 16, 1)
					return
				end
		end
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_eliminar_ciudad]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE 
		[HAY_TABLA].CIUDAD
	SET 
		STATUS = 0
	WHERE
		ID = @id
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_select_tipos_de_servicio]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		ID, NOMBRE
	FROM 
		[HAY_TABLA].SERVICIO
	ORDER BY NOMBRE DESC
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_select_ciudades]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		ID, NOMBRE
	FROM 
		[HAY_TABLA].CIUDAD
	WHERE 
		STATUS = 1
	ORDER BY 
		NOMBRE ASC
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_get_ruta_by_id]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		R.ID, R.PRECIOBASEKG, R.PRECIOBASEPASAJE,
		SR.ID_SERVICIO as "S_ID", S.NOMBRE as "S_NOMBRE",
		R.ID_CDADORIGEN as "CO_ID", CO.NOMBRE as "CO_NOMBRE",
		R.ID_CDADDESTINO as "CD_ID", CD.NOMBRE as "CD_NOMBRE",
		R.STATUS 
	FROM 
		[HAY_TABLA].RUTA R, [HAY_TABLA].SERVICIO S, [HAY_TABLA].CIUDAD CO, [HAY_TABLA].CIUDAD CD, [HAY_TABLA].SERVICIOS_RUTA SR
	WHERE
		R.ID = @id
		AND CO.ID = R.ID_CDADORIGEN
		AND CD.ID = R.ID_CDADDESTINO
		AND S.ID = SR.ID_SERVICIO
		AND R.ID = SR.ID_RUTA
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_select_rutas]
	@codRuta nvarchar(12) = null,
	@idCiudadOrigen numeric(18,0) = null,
	@idCiudadDestino numeric(18,0) = null,
	@idTipoDeServicio numeric(18,0) = null
AS
BEGIN
	SELECT
		R.ID, R.CODIGO as "R_CODIGO", CO.NOMBRE as "CO_NOMBRE", CD.NOMBRE as "CD_NOMBRE",
		R.PRECIOBASEKG, R.PRECIOBASEPASAJE, S.NOMBRE as "S_NOMBRE",
		(	case 
			when R.STATUS = 0 
			then 'NO'
			else 'SI' 
			end ) as 'STATUS'
	FROM [HAY_TABLA].RUTA R
		INNER JOIN [HAY_TABLA].CIUDAD CO ON R.ID_CDADORIGEN=CO.ID
		INNER JOIN [HAY_TABLA].CIUDAD CD ON R.ID_CDADDESTINO=CD.ID
		INNER JOIN [HAY_TABLA].SERVICIOS_RUTA SR ON R.ID=SR.ID_RUTA
		INNER JOIN [HAY_TABLA].SERVICIO S ON S.ID=SR.ID_SERVICIO
	WHERE
		((@codRuta is null) or (R.CODIGO LIKE '%' + @codRuta + '%')) AND
		((@idCiudadOrigen is null)  or (R.ID_CDADORIGEN = @idCiudadOrigen)) AND
		((@idCiudadDestino is null) or (R.ID_CDADDESTINO = @idCiudadDestino)) AND
		((@idTipoDeServicio is null) or (SR.ID_SERVICIO = @idTipoDeServicio))
	ORDER BY
		R.CODIGO, CO.NOMBRE
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_select_ruta]
	@id int
AS
BEGIN
	SELECT
		R.ID, CO.NOMBRE as "CO_NOMBRE", CD.NOMBRE as "CD_NOMBRE", R.PRECIOBASEPASAJE, R.PRECIOBASEKG, S.ID as "S_ID", S.NOMBRE as "S_NOMBRE"
	FROM
		[HAY_TABLA].RUTA R, [HAY_TABLA].SERVICIO S, [HAY_TABLA].CIUDAD CO, [HAY_TABLA].CIUDAD CD, [HAY_TABLA].SERVICIOS_RUTA SR
	WHERE
		R.ID  = @id
		AND R.ID_CDADORIGEN=CO.ID AND R.ID_CDADDESTINO=CD.ID AND S.ID=SR.ID_SERVICIO AND R.ID=SR.ID_RUTA
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_baja_ruta]
	@id	int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
		[HAY_TABLA].RUTA
	SET 
		STATUS = 0
	WHERE
		id = @id
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_insertar_ruta]
	@idCiudadOrigen int,
	@idCiudadDestino int,
	@idTipoServicio int,
	@precioBasePasaje numeric(18,0),
	@precioBaseKG numeric(18,0)
AS
BEGIN
	DECLARE @codRuta int, @ultimoID int

	if (exists(	SELECT 1 from [HAY_TABLA].RUTA R, [HAY_TABLA].SERVICIOS_RUTA SR
				where R.ID_CDADORIGEN=@idCiudadOrigen AND R.ID_CDADDESTINO=@idCiudadDestino 
				AND R.ID=SR.ID_RUTA AND SR.ID_SERVICIO=@idTipoServicio)
		)
		begin
			RAISERROR(N'Ya existe dicha Ruta',16,1)
			return
		end		

	SELECT @codRuta = MAX(CODIGO)+1 FROM [HAY_TABLA].RUTA

	INSERT INTO [HAY_TABLA].RUTA
				(	ID_CDADORIGEN, ID_CDADDESTINO, 
					PRECIOBASEPASAJE, PRECIOBASEKG, CODIGO )
    OUTPUT
		inserted.id
    VALUES
          	(	@idCiudadOrigen, @idCiudadDestino, 
          		@precioBasePasaje, @precioBaseKG, @codRuta )

    SELECT @ultimoID = MAX(ID) FROM [HAY_TABLA].RUTA

    INSERT INTO [HAY_TABLA].SERVICIOS_RUTA
    			(ID_RUTA, ID_SERVICIO)
    	VALUES	(@ultimoID, @idTipoServicio)
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_modificacion_ruta]
	@id	int,
	@idCiudadOrigen int,
	@idCiudadDestino int,
	@idTipoServicio int,
	@precioBasePasaje numeric(18,0),
	@precioBaseKG numeric(18,0),
	@status bit
AS
BEGIN
	SET NOCOUNT ON;
	
		if (exists(select 1 from [HAY_TABLA].RUTA R, [HAY_TABLA].SERVICIOS_RUTA SR
					where R.ID_CDADORIGEN=@idCiudadOrigen AND R.ID_CDADDESTINO=@idCiudadDestino 
					AND R.ID=SR.ID_RUTA AND SR.ID_SERVICIO=@idTipoServicio AND R.ID <> @id)
			)
		begin
			RAISERROR(N'Ya existe una Ruta con esos datos',16,1)
			return
		end		
	-- actualizo ruta
	UPDATE 
		[HAY_TABLA].RUTA
	SET 
		ID_CDADORIGEN = @idCiudadOrigen,
		ID_CDADDESTINO = @idCiudadDestino,
		PRECIOBASEPASAJE = @precioBasePasaje,
		PRECIOBASEKG = @precioBaseKG,
		STATUS = @status
	WHERE
		id = @id
	-- actualizo el servicio de la ruta
	UPDATE [HAY_TABLA].SERVICIOS_RUTA
	SET 
		ID_SERVICIO = @idTipoServicio
	WHERE 
		ID_RUTA = @id	
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_alta_viaje]
    @f_salida datetime,
	@f_llegada_est  datetime ,
	@id_aeronave int,
	@id_ruta int,
	@hayErr int OUT,
    @errores varchar(200) OUT
AS
BEGIN
	INSERT INTO [HAY_TABLA].VIAJE
	(ID_AERONAVE, ID_RUTA, FECHASALIDA, FECHALLEGADA, FECHALLEGADAESTIMADA)
	VALUES 
	(@id_aeronave, @id_ruta, @f_salida, null, @f_llegada_est)

 END
 GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_get_aeronaves_generar_viaje]
	@fecha datetime ,
	@id_tipo_ser int
AS 
BEGIN
	
SELECT A.ID , A.MODELO ,A.MATRICULA ,A.FABRICANTE , S.NOMBRE
FROM HAY_TABLA.AERONAVE A JOIN HAY_TABLA.SERVICIO S ON  A.ID_SERVICIO =S.ID 
WHERE 
A.ID_SERVICIO = @id_tipo_ser AND
A.ID NOT IN  
(SELECT V.ID_AERONAVE FROM   HAY_TABLA.VIAJE  V , HAY_TABLA.AERONAVE  A  WHERE V.ID_AERONAVE =A.ID 
AND @fecha BETWEEN V.FECHASALIDA  AND DATEADD(HH,24,V.FECHASALIDA)
UNION 
SELECT H.ID_AERONAVE FROM HAY_TABLA.HISTORIALBAJA_AERONAVE H , HAY_TABLA.AERONAVE A WHERE  H.ID_AERONAVE = A.ID 
AND @fecha BETWEEN H.FECHABAJA AND H.FECHAREINICIO 
);

END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_get_rutas_generar_viaje]
	@servicio varchar(255)
AS
BEGIN
	
	DECLARE @id_tipo_servicio INT

	SET  @id_tipo_servicio = (SELECT ID FROM HAY_TABLA.SERVICIO WHERE NOMBRE = @servicio)

	SELECT 	R.ID , R.CODIGO , C1.NOMBRE , C2.NOMBRE ,S.NOMBRE 
	FROM 	HAY_TABLA.RUTA R 
			JOIN HAY_TABLA.SERVICIOS_RUTA SR ON R.ID = SR.ID_RUTA
			JOIN HAY_TABLA.SERVICIO S ON SR.ID_SERVICIO = S.ID
			JOIN HAY_TABLA.CIUDAD C1 ON C1.ID = R.ID_CDADORIGEN 
			JOIN HAY_TABLA.CIUDAD C2 ON C2.ID = R.ID_CDADDESTINO	 
	WHERE 	SR.ID_SERVICIO = @id_tipo_servicio ;
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_get_tipo_servicio]
AS BEGIN
	SELECT * FROM HAY_TABLA.SERVICIO ORDER BY 2;
END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_aeronave_x_matricula]
  @matricula varchar (255),
  @hayErr int OUT,
  @errores varchar(200) OUT
  
AS BEGIN
   SET @hayErr = 0
   DECLARE @exite int 
   SET @exite =  (select count (*) from HAY_TABLA.AERONAVE A  where upper(MATRICULA) = upper (@matricula) )
   IF @exite != 0
	BEGIN
	 select A.ID, A.MODELO ,A.FABRICANTE , S.NOMBRE  from HAY_TABLA.AERONAVE A join HAY_TABLA.SERVICIO S
	 on A.ID_SERVICIO = S.ID where upper(MATRICULA) = upper (@matricula); 
	 RETURN
	END
	ELSE 
	BEGIN
	SET @hayErr = 1
	SET @errores = ' No se ha encontrado una Aeronave para la matricula ingresada'
	END

END
GO
------
CREATE PROCEDURE [HAY_TABLA].[sp_alta_registro_llegada]
    	@matricula VARCHAR(255),
		@f_llegada datetime,
    	@id_ciudad_origen int,
    	@id_ciudad_destino int,
		@f_actual datetime ,
		@hayErr int OUT,
    	@errores varchar(200) OUT
AS
	SET @hayErr = 0
	SET @errores = 'Se ha registrado la llegada de la Aeronave'	
BEGIN

	DECLARE @id_viaje int 
	select @id_viaje = (select V.ID 
						from HAY_TABLA.VIAJE V join HAY_TABLA.AERONAVE A on V.ID_AERONAVE = A.ID
						join HAY_TABLA.RUTA R1 on R1.ID = V.ID_RUTA
					
						where V.FECHALLEGADA is null and  V.STATUS = 1
						and R1.ID_CDADORIGEN = @id_ciudad_origen and upper(A.MATRICULA) = upper(@matricula))
						
	
	IF @id_viaje is null BEGIN 
		set @hayErr = 1
		set @errores = 'No existe ning�n Viaje  para la ciudad de origen seleccionada'
		RETURN
	END
    	
	DECLARE @ciudadLlegada int  
	select @ciudadLlegada = (select count (*) from HAY_TABLA.VIAJE V join HAY_TABLA.RUTA R1 on R1.ID = V.ID_RUTA
	 where V.ID = @id_viaje and R1.ID_CDADDESTINO = @id_ciudad_destino and V.STATUS = 1  ) 


	 	IF @ciudadLlegada = 0 BEGIN 
		set @hayErr = 2
		set @errores = 'Se registrara el viaje con una ciudad de destino diferente al promagramado'
		
	END

	DECLARE @id_aeronave int
	select @id_aeronave = (select V.ID_AERONAVE from HAY_TABLA.VIAJE V where V.ID = @id_viaje)		

	UPDATE [HAY_TABLA].VIAJE
	SET FECHALLEGADA = @f_llegada 
	WHERE ID = @id_viaje
END
GO

/*-------------   SP  PARA AERONAVES   -------------*/

CREATE PROCEDURE [HAY_TABLA].[sp_baja_fuera_de_servicio]
	@id int,
	@fechaActual datetime,
	@fechaReincorporacion datetime
AS
BEGIN
	if (exists(select A.ID from HAY_TABLA.AERONAVE A, HAY_TABLA.HISTORIALBAJA_AERONAVE HB      
				where A.ID = @id AND A.ID = HB.ID_AERONAVE AND HB.ID_TIPOBAJA = 2))
		begin
			RAISERROR(N' Esta aeronave ya cumplio su Vida Util ', 16, 1)
			return
		end		
	else
		begin
			if (exists(select A.ID from HAY_TABLA.AERONAVE A, HAY_TABLA.HISTORIALBAJA_AERONAVE HB      
					   where A.ID = @id AND A.ID = HB.ID_AERONAVE AND HB.ID_TIPOBAJA = 1 AND HB.FECHAREINICIO > @fechaActual))
				begin
					RAISERROR(N' Esta aeronave ya se encontraba fuera de servicio ', 16, 1)
					return
				end		
			else
				begin
					if (@fechaActual > @fechaReincorporacion)
						begin
							RAISERROR(N' La fecha de reincorporacion debe ser mayor a la fecha actual ', 16, 1)
							return
						end
				end 
		end

		INSERT INTO [HAY_TABLA].HISTORIALBAJA_AERONAVE
			(ID_AERONAVE, ID_TIPOBAJA, FECHABAJA, FECHAREINICIO)
		OUTPUT
			inserted.id
		VALUES
			(@id, 1, @fechaActual, @fechaReincorporacion)
			
END
GO
----------------
CREATE PROCEDURE [HAY_TABLA].[sp_baja_vida_util]
	@id int,
	@fechaActual datetime
AS
BEGIN
	if (exists(select A.ID from HAY_TABLA.AERONAVE A, HAY_TABLA.HISTORIALBAJA_AERONAVE HB      
				where A.ID = @id AND A.ID = HB.ID_AERONAVE AND HB.ID_TIPOBAJA = 2))
		begin
			RAISERROR(N' La aeronave ya estaba dada de baja por Fin de Vida Util ', 16, 1)
			return
		end		
		INSERT INTO [HAY_TABLA].HISTORIALBAJA_AERONAVE
			(ID_AERONAVE, ID_TIPOBAJA, FECHABAJA, FECHAREINICIO)
		OUTPUT
			inserted.id
		VALUES
			(@id, 2, @fechaActual, null)
END
GO
----------------
CREATE PROCEDURE [HAY_TABLA].[sp_get_aeronave_by_id]
	@id int
AS
BEGIN
	select
		A.ID, A.MATRICULA, A.MODELO, A.FABRICANTE, A.CANTBUTACASPASILLO, A.CANTBUTACASVENTANILLA, A.ESPACIOKGENCOMIENDAS, S.ID as 'S_ID', S.NOMBRE as 'S_NOMBRE'
	from 
		HAY_TABLA.AERONAVE A, HAY_TABLA.SERVICIO S
	where
		A.ID = @id
END
GO
----------------
CREATE PROCEDURE [HAY_TABLA].[sp_get_fabricantes]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		DISTINCT FABRICANTE
	FROM 
		[HAY_TABLA].AERONAVE
	ORDER BY
		FABRICANTE
END
GO
----------------
CREATE PROCEDURE [HAY_TABLA].[sp_insertar_aeronave]
	@fechaAlta datetime,
	@fabricante nvarchar(255),
	@modelo nvarchar(255),
	@matricula nvarchar(255),
	@espacioKg int,
	@cantButacasPasillo int,
	@cantButacasVentanilla int,
	@idTipoServicio int
AS
BEGIN

	if (@cantButacasPasillo = 0 OR @cantButacasVentanilla = 0) 
		begin
			RAISERROR(N' La aeronave debe contar con al menos una butaca ', 16, 1)
			return	
		end

	if (@espacioKg = 0) 
		begin
			RAISERROR(N' La aeronave debe contar con espacio para encomiendas ', 16, 1)
			return	
		end
	
	if (exists(select ID from [HAY_TABLA].AERONAVE where MATRICULA like '%' + @matricula))
		begin
			RAISERROR(N' Ya existe una aeronave con esa matr�cula ', 16, 1)
			return
		end		

	declare @t table (id int)

	INSERT INTO [HAY_TABLA].AERONAVE
		(FECHAALTA, ID_SERVICIO, MODELO, MATRICULA, FABRICANTE, CANTBUTACASPASILLO, CANTBUTACASVENTANILLA, ESPACIOKGENCOMIENDAS)
	OUTPUT 
		inserted.id INTO @t -- esta villereada es "gracias" a SQL SERVER para devolver un unico valor y que deje correr el trigger !!
	VALUES
		(@fechaAlta, @idTipoServicio, @modelo, @matricula, @fabricante, @cantButacasPasillo, @cantButacasVentanilla, @espacioKg)

	SELECT * FROM @t -- IDEM -> http://blogs.msdn.com/b/sqlprogrammability/archive/2008/07/11/update-with-output-clause-triggers-and-sqlmoreresults.aspx
END
GO
------
CREATE TRIGGER [HAY_TABLA].tr_generar_butacas
   ON  [HAY_TABLA].AERONAVE 
   AFTER INSERT
AS 
BEGIN
	DECLARE @I INT, @CANT_PAS INT, @CANT_VEN INT, @ID_AERONAVE INT
	SET @I = 1
	SELECT 	@CANT_PAS = i.CANTBUTACASPASILLO,
			@CANT_VEN = i.CANTBUTACASVENTANILLA,
			@ID_AERONAVE = i.ID 
	FROM inserted i

    WHILE @I <= @CANT_PAS
    BEGIN
        INSERT INTO [HAY_TABLA].BUTACA
        (ID_AERONAVE, NUMERO, PISO, TIPO)
        VALUES
        (@ID_AERONAVE, @I, 1, 'Pasillo')

        SET @I = @I + 1
    END

	WHILE @I <= (@CANT_PAS + @CANT_VEN)
    BEGIN
        INSERT INTO [HAY_TABLA].BUTACA
        (ID_AERONAVE, NUMERO, PISO, TIPO)
        VALUES
        (@ID_AERONAVE, @I, 1, 'Ventanilla')

        SET @I = @I + 1
    END

END
GO
----------------
CREATE PROCEDURE [HAY_TABLA].[sp_modificar_aeronave]
	@id int,
	@fechaAlta datetime,
	@fabricante nvarchar(255),
	@modelo nvarchar(255),
	@matricula nvarchar(255),
	@espacioKg int,
	@cantButacasPasillo int,
	@cantButacasVentanilla int,
	@idTipoServicio int
AS
BEGIN

	if (@cantButacasPasillo = 0 OR @cantButacasVentanilla = 0) 
		begin
			RAISERROR(N' La aeronave debe contar con al menos una butaca ', 16, 1)
			return	
		end

	if (@espacioKg = 0) 
		begin
			RAISERROR(N' La aeronave debe contar con espacio para encomiendas ', 16, 1)
			return	
		end

	UPDATE 
		[HAY_TABLA].AERONAVE
	SET 
		FECHAALTA = @fechaAlta,
		FABRICANTE = @fabricante,
		MODELO = @modelo,
		MATRICULA = @matricula,
		ESPACIOKGENCOMIENDAS = @espacioKg,
		CANTBUTACASPASILLO = @cantButacasPasillo,
		CANTBUTACASVENTANILLA = @cantButacasVentanilla,
		ID_SERVICIO = @idTipoServicio
	WHERE
		ID = @id
END
GO
----------------
CREATE PROCEDURE [HAY_TABLA].[sp_select_aeronaves]
	@matricula nvarchar(255) = null,
	@idTipoDeServicio numeric(18,0) = null,
	@fabricante nvarchar(255) = null
AS BEGIN
	SELECT 
		A.ID, A.MATRICULA, A.MODELO, A.FABRICANTE, A.FECHAALTA, A.CANTBUTACASPASILLO, 
		A.CANTBUTACASVENTANILLA, A.ESPACIOKGENCOMIENDAS, S.ID as 'S_ID', S.NOMBRE as 'S_NOMBRE',
		(SELECT CASE 
			WHEN(MAX(HB.ID_TIPOBAJA) IS NULL) THEN 0
			ELSE MAX(HB.ID_TIPOBAJA)
		END FROM [HAY_TABLA].HISTORIALBAJA_AERONAVE HB WHERE A.ID=HB.ID_AERONAVE) as 'HB_ID',
		(SELECT CASE 
			WHEN (MAX(HB.FECHAREINICIO) IS NULL) THEN '-'
			WHEN (MAX(HB.ID_TIPOBAJA)=2) THEN '-'
			ELSE CONVERT(nvarchar(10), MAX(HB.FECHAREINICIO), 110)
		END FROM [HAY_TABLA].HISTORIALBAJA_AERONAVE HB WHERE A.ID=HB.ID_AERONAVE) as 'HB_FECHAREINICIO'
	FROM 
		[HAY_TABLA].AERONAVE A 
			INNER JOIN [HAY_TABLA].SERVICIO S ON A.ID_SERVICIO = S.ID
--			LEFT JOIN [HAY_TABLA].HISTORIALBAJA_AERONAVE HB ON HB.ID_AERONAVE = A.ID
--			INNER JOIN (SELECT ID_AERONAVE FROM [HAY_TABLA].HISTORIALBAJA_AERONAVE
--						GROUP BY ID_AERONAVE HAVING COUNT(*)>1) as TEMP ON TEMP.ID_AERONAVE = A.ID
	WHERE
		-- TODOS LOS CAMPOS VACIOS
--		(@matricula is null AND @idTipoDeServicio is null AND @fabricante is null AND A.ID_SERVICIO = S.ID) or
		-- SOLO UN CAMPO DE BUSQUEDA
		(A.MATRICULA = @matricula AND @idTipoDeServicio is null AND @fabricante is null AND A.ID_SERVICIO = S.ID) or 
		(A.ID_SERVICIO = @idTipoDeServicio AND @matricula is null AND @fabricante is null AND A.ID_SERVICIO = S.ID) or
		(A.FABRICANTE = @fabricante AND @idTipoDeServicio is null AND @matricula is null AND A.ID_SERVICIO = S.ID) or
		-- SOLO DOS CAMPOS DE BUSQUEDA
		(A.MATRICULA = @matricula AND A.ID_SERVICIO = @idTipoDeServicio AND @fabricante is null AND A.ID_SERVICIO = S.ID) or
		(A.MATRICULA = @matricula AND @idTipoDeServicio is null AND A.FABRICANTE = @fabricante AND A.ID_SERVICIO = S.ID) or
		(@matricula is null AND A.ID_SERVICIO = @idTipoDeServicio AND A.FABRICANTE = @fabricante AND A.ID_SERVICIO = S.ID) or
		-- LOS 3 CAMPOS
		(A.MATRICULA = @matricula AND A.ID_SERVICIO = @idTipoDeServicio AND A.FABRICANTE = @fabricante AND A.ID_SERVICIO = S.ID)
END
GO
/*-------------   SP  PARA MILLAS   -------------*/
CREATE PROCEDURE [HAY_TABLA].[sp_listado_millas]
	@id int,
	@fechaActual datetime
AS
BEGIN
	
	SELECT 	((-1) * pr.MILLASNECESARIAS * c.CANTIDAD) as 'Millas', 
			c.FECHA as 'Fecha', 
			'Canje de producto: ' + pr.DESCRIPCION + ' (Cant: ' + cast(c.CANTIDAD as varchar) + ')' as 'Detalle'
	from HAY_TABLA.PERSONA pe join HAY_TABLA.CANJE c on pe.ID = c.ID_CLIENTE
							  join HAY_TABLA.PRODUCTO pr on c.ID_PRODUCTO = pr.ID
	where pe.ID = @id
	and c.FECHA > DATEADD (MONTH, -12, @fechaActual)

	UNION ALL

	SELECT (CAST(pa.IMPORTE AS int) / 10) as 'Millas',
		   v.FECHALLEGADA as 'Fecha',
		   'Pasaje desde ' + c1.NOMBRE + ' hasta ' + c2.NOMBRE as 'Detalle'
	from HAY_TABLA.PERSONA p join HAY_TABLA.PASAJE pa on p.ID = pa.ID_CLIENTE
							 join HAY_TABLA.VIAJE v on pa.ID_VIAJE = v.ID
							 join HAY_TABLA.RUTA r on v.ID_RUTA = r.ID
							 join HAY_TABLA.CIUDAD c1 on r.ID_CDADORIGEN = c1.ID
							 join HAY_TABLA.CIUDAD c2 on r.ID_CDADDESTINO = c2.ID
	where p.ID = @id
	and not exists (select 1 from HAY_TABLA.ITEMSDEVOLUCION itemd 
					join HAY_TABLA.PASAJE pa2 on itemd.ID_PASAJE = pa2.ID
					where pa2.ID = pa.ID)
	and v.FECHALLEGADA > DATEADD (MONTH, -12, @fechaActual)

	UNION ALL

	SELECT (CAST(e.IMPORTE AS int) / 10) as 'Millas',
		   v.FECHALLEGADA as 'Fecha',
		   'Encomienda de ' + cast(e.PESO as varchar) + 'Kg desde' + c1.NOMBRE + ' hasta' + c2.NOMBRE as 'Detalle'
	from HAY_TABLA.PERSONA p join HAY_TABLA.COMPRA c on p.ID = c.ID_COMPRADOR
							 join HAY_TABLA.ENCOMIENDA e on c.ID = e.ID_COMPRA
							 join HAY_TABLA.VIAJE v on e.ID_VIAJE = v.ID
							 join HAY_TABLA.RUTA r on v.ID_RUTA = r.ID
							 join HAY_TABLA.CIUDAD c1 on r.ID_CDADORIGEN = c1.ID
							 join HAY_TABLA.CIUDAD c2 on r.ID_CDADDESTINO = c2.ID
	where p.ID = @id
	and not exists (select 1 from HAY_TABLA.ITEMSDEVOLUCION itemd 
					join HAY_TABLA.ENCOMIENDA e2 on itemd.ID_ENCOMIENDA = e2.ID
					where e2.ID = e.ID)
	and v.FECHALLEGADA > DATEADD (MONTH, -12, @fechaActual)

	order by c.FECHA desc

END
GO
----------------
CREATE PROCEDURE [HAY_TABLA].[sp_get_datos_clie]
	@DNI int
AS 
BEGIN
	SET NOCOUNT ON;

	if (exists(select ID from HAY_TABLA.PERSONA
				where @DNI = DNI))
		begin
			SELECT ID as 'id', (APELLIDO + ', ' + NOMBRE) as 'nombre'
			from HAY_TABLA.PERSONA
			where @DNI = DNI
		end		
	else
		begin
			RAISERROR(N' El DNI ingresado no pertenece a ning�n cliente existente ', 16, 1)
			return
		end

END
GO
----------------
CREATE PROCEDURE [HAY_TABLA].[sp_get_millas_acumuladas]
	@id int,
	@fechaActual DateTime
AS
	DECLARE @ACUMULADAS int, @MILLAS_VIGENTES int, @CANJES_DEL_ULTIMO_ANIO int
BEGIN

	
	SET @MILLAS_VIGENTES = (
							SELECT sum (millas.acumuladas)
							from
							(
								SELECT sum(CAST(pa.IMPORTE AS int) / 10) as 'acumuladas'
								from HAY_TABLA.PERSONA p join HAY_TABLA.PASAJE pa on p.ID = pa.ID_CLIENTE
														 join HAY_TABLA.VIAJE v on pa.ID_VIAJE = v.ID
														 join HAY_TABLA.RUTA r on v.ID_RUTA = r.ID
														 join HAY_TABLA.CIUDAD c1 on r.ID_CDADORIGEN = c1.ID
														 join HAY_TABLA.CIUDAD c2 on r.ID_CDADDESTINO = c2.ID
								where p.ID = @id
								and not exists (select 1 from HAY_TABLA.ITEMSDEVOLUCION itemd 
												join HAY_TABLA.PASAJE pa2 on itemd.ID_PASAJE = pa2.ID
												where pa2.ID = pa.ID)
								and v.FECHALLEGADA > DATEADD (MONTH, -12, @fechaActual)

								UNION ALL

								SELECT sum(CAST(e.IMPORTE AS int) / 10) as 'acumuladas'
								from HAY_TABLA.PERSONA p join HAY_TABLA.COMPRA c on p.ID = c.ID_COMPRADOR
														 join HAY_TABLA.ENCOMIENDA e on c.ID = e.ID_COMPRA
														 join HAY_TABLA.VIAJE v on e.ID_VIAJE = v.ID
														 join HAY_TABLA.RUTA r on v.ID_RUTA = r.ID
														 join HAY_TABLA.CIUDAD c1 on r.ID_CDADORIGEN = c1.ID
														 join HAY_TABLA.CIUDAD c2 on r.ID_CDADDESTINO = c2.ID
								where p.ID = @id
								and not exists (select 1 from HAY_TABLA.ITEMSDEVOLUCION itemd 
												join HAY_TABLA.ENCOMIENDA e2 on itemd.ID_ENCOMIENDA = e2.ID
												where e2.ID = e.ID)
								and v.FECHALLEGADA > DATEADD (MONTH, -12, @fechaActual)
							) millas
						   )

	SET @CANJES_DEL_ULTIMO_ANIO = (
								   SELECT sum(pr.MILLASNECESARIAS * c.CANTIDAD)
								   from HAY_TABLA.PERSONA pe join HAY_TABLA.CANJE c on pe.ID = c.ID_CLIENTE
														     join HAY_TABLA.PRODUCTO pr on c.ID_PRODUCTO = pr.ID
								   where pe.ID = @id
								   and c.FECHA > DATEADD (MONTH, -12, @fechaActual)
								  )

	if (@CANJES_DEL_ULTIMO_ANIO is null)
		begin
			if (@MILLAS_VIGENTES is null)
				begin
					SET @MILLAS_VIGENTES = 0
				end
			select @MILLAS_VIGENTES
		end
	else
		begin
			if (@MILLAS_VIGENTES is null)
				begin
					SET @MILLAS_VIGENTES = 0
				end
			SET @ACUMULADAS = (@MILLAS_VIGENTES - @CANJES_DEL_ULTIMO_ANIO)
			select @ACUMULADAS
		end

END
GO
/*-------------   SP  PARA DEVOLUCIONES   -------------*/

CREATE PROCEDURE [HAY_TABLA].[sp_select_items]
	@idCompra int,
	@idPasaje int,
	@idEncomienda int,
	@fechaActual datetime
AS
BEGIN
--Caso 1--------------------------------------------------------------------------------------------------------------------------------------------------------
	-- Si ingres� s�lo el id de compra
	if ((@idCompra <> -1) and (@idPasaje = -1) and (@idEncomienda = -1))
		begin
			-- Busco pasajes existentes para esta compra
			SELECT pa.ID_COMPRA as 'idCompra', 
				   'Pasaje' as 'tipo',
				   pa.ID as 'idPasajeEncomienda',
				   c.FECHA as 'fechaCompra',
				   (p.APELLIDO + ', ' + p.NOMBRE) as 'nombreCompleto'
			FROM HAY_TABLA.PASAJE pa join HAY_TABLA.COMPRA c on pa.ID_COMPRA = c.ID
												join HAY_TABLA.PERSONA p on pa.ID_CLIENTE = p.ID
												join HAY_TABLA.VIAJE v on pa.ID_VIAJE = v.ID
			WHERE @idCompra = pa.ID_COMPRA and 
				  --Chequeo que la fecha actual sea previa a la de salida del viaje
				  @fechaActual < v.FECHASALIDA and
				  --Chequeo que el pasaje a cancelar, no este ya cancelado
				  not exists (SELECT *
							  FROM HAY_TABLA.PASAJE pa2 join HAY_TABLA.ITEMSDEVOLUCION itemd on pa2.ID = itemd.ID_PASAJE
							  WHERE pa2.ID = pa.ID)
			UNION ALL
			-- Busco encomiendas existentes para esta compra
			SELECT e.ID_COMPRA as 'idCompra', 
				   'Encomienda' as 'tipo',
				   e.ID as 'idPasajeEncomienda',
				   c.FECHA as 'fechaCompra',
				   (p.APELLIDO + ', ' + p.NOMBRE) as 'nombreCompleto'
			FROM HAY_TABLA.ENCOMIENDA e join HAY_TABLA.COMPRA c on e.ID_COMPRA = c.ID
												join HAY_TABLA.PERSONA p on c.ID_COMPRADOR = p.ID
												join HAY_TABLA.VIAJE v on e.ID_VIAJE = v.ID
			WHERE @idCompra = e.ID_COMPRA and 
				  --Chequeo que la fecha actual sea previa a la de salida del viaje
				  @fechaActual < v.FECHASALIDA and
				  --Chequeo que la encomienda a cancelar, no este ya cancelada
				  not exists (SELECT *
							  FROM HAY_TABLA.ENCOMIENDA e2 join HAY_TABLA.ITEMSDEVOLUCION itemd on e2.ID = itemd.ID_ENCOMIENDA
							  WHERE e2.ID = e.ID)
		end
--Caso 2--------------------------------------------------------------------------------------------------------------------------------------------------------
	else
		begin
			-- Si ingres� s�lo el id de compra y de pasaje
			if ((@idCompra <> -1) and (@idPasaje <> -1) and (@idEncomienda = -1))
				begin
					-- Busco pasajes existentes para esta compra
					SELECT pa.ID_COMPRA as 'idCompra', 
						   'Pasaje' as 'tipo',
						   pa.ID as 'idPasajeEncomienda',
					       c.FECHA as 'fechaCompra',
				           (p.APELLIDO + ', ' + p.NOMBRE) as 'nombreCompleto'
					FROM HAY_TABLA.PASAJE pa join HAY_TABLA.COMPRA c on pa.ID_COMPRA = c.ID
										     join HAY_TABLA.PERSONA p on pa.ID_CLIENTE = p.ID
											 join HAY_TABLA.VIAJE v on pa.ID_VIAJE = v.ID
					WHERE @idCompra = pa.ID_COMPRA and 
					--Chequeo que la fecha actual sea previa a la de salida del viaje
					@fechaActual < v.FECHASALIDA and
					@idPasaje = pa.ID and
					--Chequeo que el pasaje a cancelar, no este ya cancelado
					not exists (SELECT *
							    FROM HAY_TABLA.PASAJE pa2 join HAY_TABLA.ITEMSDEVOLUCION itemd on pa2.ID = itemd.ID_PASAJE
							    WHERE pa2.ID = pa.ID)
				end
--Caso 3--------------------------------------------------------------------------------------------------------------------------------------------------------
			else
				begin
					-- Si ingres� s�lo el id de compra y de encomienda
					if ((@idCompra <> -1) and (@idPasaje = -1) and (@idEncomienda <> -1))
						begin
							SELECT e.ID_COMPRA as 'idCompra', 
								   'Encomienda' as 'tipo',
								   e.ID as 'idPasajeEncomienda',
								   c.FECHA as 'fechaCompra',
								   (p.APELLIDO + ', ' + p.NOMBRE) as 'nombreCompleto'
							FROM HAY_TABLA.ENCOMIENDA e join HAY_TABLA.COMPRA c on e.ID_COMPRA = c.ID
													    join HAY_TABLA.PERSONA p on c.ID_COMPRADOR = p.ID
														join HAY_TABLA.VIAJE v on e.ID_VIAJE = v.ID
							WHERE @idCompra = e.ID_COMPRA and 
							--Chequeo que la fecha actual sea previa a la de salida del viaje
							@fechaActual < v.FECHASALIDA and
							@idEncomienda = e.ID and
							--Chequeo que la encomienda a cancelar, no este ya cancelada
							not exists (SELECT *
									    FROM HAY_TABLA.ENCOMIENDA e2 join HAY_TABLA.ITEMSDEVOLUCION itemd on e2.ID = itemd.ID_ENCOMIENDA
										WHERE e2.ID = e.ID)
						end
--Caso 4--------------------------------------------------------------------------------------------------------------------------------------------------------
					else
						begin
							-- Si ingres� s�lo el id de encomienda
							if ((@idCompra = -1) and (@idPasaje = -1) and (@idEncomienda <> -1))
								begin
									SELECT e.ID_COMPRA as 'idCompra', 
										   'Encomienda' as 'tipo',
										   e.ID as 'idPasajeEncomienda',
										   c.FECHA as 'fechaCompra',
										   (p.APELLIDO + ', ' + p.NOMBRE) as 'nombreCompleto'
									FROM HAY_TABLA.ENCOMIENDA e join HAY_TABLA.COMPRA c on e.ID_COMPRA = c.ID
																join HAY_TABLA.PERSONA p on c.ID_COMPRADOR = p.ID
																join HAY_TABLA.VIAJE v on e.ID_VIAJE = v.ID
									WHERE @idEncomienda = e.ID and 
									--Chequeo que la fecha actual sea previa a la de salida del viaje
									@fechaActual < v.FECHASALIDA and
									--Chequeo que la encomienda a cancelar, no este ya cancelada
									not exists (SELECT *
												FROM HAY_TABLA.ENCOMIENDA e2 join HAY_TABLA.ITEMSDEVOLUCION itemd on e2.ID = itemd.ID_ENCOMIENDA
												WHERE e2.ID = e.ID)
								end
--Caso 5--------------------------------------------------------------------------------------------------------------------------------------------------------
							else
								-- Si ingres� s�lo el id de pasaje
								if ((@idCompra = -1) and (@idPasaje <> -1) and (@idEncomienda = -1))
									begin
										SELECT pa.ID_COMPRA as 'idCompra', 
											   'Pasaje' as 'tipo',
											   pa.ID as 'idPasajeEncomienda',
											   c.FECHA as 'fechaCompra',
											   (p.APELLIDO + ', ' + p.NOMBRE) as 'nombreCompleto'
										FROM HAY_TABLA.PASAJE pa join HAY_TABLA.COMPRA c on pa.ID_COMPRA = c.ID
																 join HAY_TABLA.PERSONA p on pa.ID_CLIENTE = p.ID
																 join HAY_TABLA.VIAJE v on pa.ID_VIAJE = v.ID
										WHERE @idPasaje = pa.ID and 
										--Chequeo que la fecha actual sea previa a la de salida del viaje
										@fechaActual < v.FECHASALIDA and
										--Chequeo que el pasaje a cancelar, no este ya cancelado
										not exists (SELECT *
													FROM HAY_TABLA.PASAJE pa2 join HAY_TABLA.ITEMSDEVOLUCION itemd on pa2.ID = itemd.ID_PASAJE
													WHERE pa2.ID = pa.ID)
									end
----------------------------------------------------------------------------------------------------------------------------------------------------------------
						end
				end
		end

END
GO
----------------
CREATE PROCEDURE [HAY_TABLA].[sp_actualizacion_importes_devolucion]
	@idCompra int,
	@idPasaje int,
	@idEncomienda int
	
AS
	DECLARE @IMPORTE_A_DESCONTAR NUMERIC(18,2), @IMPORTE_TOTAL_COMPRA NUMERIC(18,2)
BEGIN
	
	SET @IMPORTE_TOTAL_COMPRA = (select c.IMPORTETOTAL
								 from HAY_TABLA.COMPRA c
								 where @idCompra = c.ID)

    if (@idPasaje is null)
		begin
			SET @IMPORTE_A_DESCONTAR = (select e.IMPORTE
										from HAY_TABLA.ENCOMIENDA e 
										where @idEncomienda = e.ID)
			
			-- Cuando cancelo un Item, seteo el importe del mismo en negativo en su tabla respectiva
			UPDATE 
				[HAY_TABLA].ENCOMIENDA
			SET 
				IMPORTE = (-1 * @IMPORTE_A_DESCONTAR)
			where @idEncomienda = ID
			-- Actualizo el importe total de la compra restando el monto del item cancelado
			UPDATE 
				[HAY_TABLA].COMPRA
			SET 
				IMPORTETOTAL = (@IMPORTE_TOTAL_COMPRA - @IMPORTE_A_DESCONTAR)
			where @idCompra = ID

 		end
	else
		begin
			if (@idEncomienda is null)
				begin
					SET @IMPORTE_A_DESCONTAR = (select p.IMPORTE
												from HAY_TABLA.PASAJE p
												where @idPasaje = p.ID)

					-- Cuando cancelo un Item, seteo el importe del mismo en negativo en su tabla respectiva
					UPDATE 
						[HAY_TABLA].PASAJE
					SET 
						IMPORTE = (-1 * IMPORTE)
					where @idPasaje = ID
					-- Actualizo el importe total de la compra restando el monto del item cancelado
					UPDATE 
						[HAY_TABLA].COMPRA
					SET 
						IMPORTETOTAL = (@IMPORTE_TOTAL_COMPRA - @IMPORTE_A_DESCONTAR)
					where @idCompra = ID

 				end
		end

END
GO
----------------
CREATE PROCEDURE [HAY_TABLA].[sp_cancelar_pasaje_encomienda]
	@idCompra int,
	@tipoItem nvarchar(20),
	@idPasajeEncomienda int,
	@fechaActual datetime,
	@motivoDevolucion nvarchar(255)
AS
	DECLARE @idDevolucion int
BEGIN
	--No chequea si el Item que quiero cancelar ya existe, ya que eso lo controla el sp_select_items, y de existir NO lo muestra en el DGV de Devoluciones

	if --Si no existe una devolucion para esa compra
	   ((not exists(SELECT * 
		 			FROM HAY_TABLA.ITEMSDEVOLUCION itemd 
					WHERE @idCompra = itemd.ID_COMPRA)) or
	   --Ya existe una devolucion para esa compra, PERO fue echa en alguna operacion previa, ahora es una devolucion parcial de OTRO item de la misma compra
	   (exists(SELECT * 
		 	   FROM HAY_TABLA.ITEMSDEVOLUCION itemd join HAY_TABLA.DEVOLUCION d on itemd.ID_DEVOLUCION = d.ID 
			   WHERE @idCompra = itemd.ID_COMPRA and @fechaActual > d.FECHA)))
	   begin
			INSERT INTO [HAY_TABLA].[DEVOLUCION]
				(FECHA, MOTIVO)
			/*OUTPUT
				inserted.ID*/
			VALUES
				(@fechaActual, @motivoDevolucion)	

			--Busco el ID de devolucion recien insertado para completar la devolucion parcial de la misma operacion
			SET @idDevolucion = (SELECT top 1 (d.ID) 
								 FROM HAY_TABLA.DEVOLUCION d 
								 order by d.ID desc)

			--Inserto nuevo registro en ItemDevolucion para otro Item de la misma Compra
			if (@tipoItem = 'Pasaje')
				begin
					INSERT INTO [HAY_TABLA].[ITEMSDEVOLUCION]
						(ID_DEVOLUCION, ID_COMPRA, ID_PASAJE, ID_ENCOMIENDA)
					OUTPUT
						inserted.ID
					VALUES
						(@idDevolucion, @idCompra, @idPasajeEncomienda, null)
					--Este sp actualiza importeTotal de la compra, y paso a negativo el importe del item
					exec HAY_TABLA.sp_actualizacion_importes_devolucion @idCompra, @idPasajeEncomienda, null
				end
			else
				begin
					if (@tipoItem = 'Encomienda')
						begin
							INSERT INTO [HAY_TABLA].[ITEMSDEVOLUCION]
								(ID_DEVOLUCION, ID_COMPRA, ID_PASAJE, ID_ENCOMIENDA)
							OUTPUT
								inserted.ID
							VALUES
								(@idDevolucion, @idCompra, null, @idPasajeEncomienda)
							--Este sp actualiza importeTotal de la compra, y paso a negativo el importe del item
							exec HAY_TABLA.sp_actualizacion_importes_devolucion @idCompra, null, @idPasajeEncomienda
						end
				end
	   end
	else
		--Existe una devolucion para esa compra y es la misma fecha y horario, por lo tanto es OTRO item mas que me llega de esta devolucion parcial
		begin
			--Busco el ID de devolucion recien insertado para completar la devolucion parcial de la misma operacion
			SET @idDevolucion = (SELECT top 1 (d.ID) 
								 FROM HAY_TABLA.DEVOLUCION d 
								 order by d.ID desc)

			--Inserto nuevo registro en ItemDevolucion para otro Item de la misma Compra
			if (@tipoItem = 'Pasaje')
				begin
					INSERT INTO [HAY_TABLA].[ITEMSDEVOLUCION]
						(ID_DEVOLUCION, ID_COMPRA, ID_PASAJE, ID_ENCOMIENDA)
					OUTPUT
						inserted.ID
					VALUES
						(@idDevolucion, @idCompra, @idPasajeEncomienda, null)
					--Este sp actualiza importeTotal de la compra, y paso a negativo el importe del item
					exec HAY_TABLA.sp_actualizacion_importes_devolucion @idCompra, @idPasajeEncomienda, null
				end
			else
				begin
					if (@tipoItem = 'Encomienda')
						begin
							INSERT INTO [HAY_TABLA].[ITEMSDEVOLUCION]
								(ID_DEVOLUCION, ID_COMPRA, ID_PASAJE, ID_ENCOMIENDA)
							OUTPUT
								inserted.ID
							VALUES
								(@idDevolucion, @idCompra, null, @idPasajeEncomienda)
							--Este sp actualiza importeTotal de la compra, y paso a negativo el importe del item
							exec HAY_TABLA.sp_actualizacion_importes_devolucion @idCompra, null, @idPasajeEncomienda
						end
				end
		end

END
GO
/*-------------   SP  PARA CANJES   -------------*/
CREATE PROCEDURE [HAY_TABLA].[sp_get_canjes_posibles]
	@acumuladas int
AS
BEGIN
	
	if (not exists (SELECT 1
					from HAY_TABLA.PRODUCTO pr
					where @acumuladas >= pr.MILLASNECESARIAS))
		begin
			RAISERROR(N' Las millas son insuficientes para cualquier producto ', 16, 1)
			return
		end
	else
		begin
			SELECT pr.ID as 'id', pr.DESCRIPCION as 'producto', pr.MILLASNECESARIAS as 'millasNecesarias'
			from HAY_TABLA.PRODUCTO pr
			where @acumuladas >= pr.MILLASNECESARIAS and pr.CANTSTOCK > 0
		end
END

GO
----------------
CREATE PROCEDURE [HAY_TABLA].[sp_confirmar_canje]
	@idProducto int,
	@cantidad int,
	@dni int,
	@acumuladas int,
	@fechaActual datetime
AS
	DECLARE @idCliente int
BEGIN
	if (@acumuladas < (@cantidad * (SELECT pr.MILLASNECESARIAS
									from HAY_TABLA.PRODUCTO pr
									where @idProducto = pr.ID)))
		begin
			RAISERROR(N'Las millas acumuladas no son suficientes para la cantidad solicitada',16,1)
			return
		end
	else
		begin
			if (@cantidad > (SELECT pr.CANTSTOCK
							 from HAY_TABLA.PRODUCTO pr
							 where @idProducto = pr.ID))
				begin
					RAISERROR(N'El stock del producto no es suficiente para la cantidad solicitada',16,1)
					return
				end
			else
				begin

					SET @idCliente = (SELECT p.ID
									  from HAY_TABLA.PERSONA p
									  where @dni = p.DNI)

					INSERT INTO [HAY_TABLA].CANJE
						(ID_PRODUCTO, ID_CLIENTE, DNI, CANTIDAD, FECHA)
					VALUES
						(@idProducto, @idCliente, @dni, @cantidad, @fechaActual)

					UPDATE 
						[HAY_TABLA].PRODUCTO
					SET 
						CANTSTOCK = (CANTSTOCK - @cantidad)
					where @idProducto = ID

					--RAISERROR(N'Canje exitoso',16,1)
					--return
				end
		end

END
GO
----------------