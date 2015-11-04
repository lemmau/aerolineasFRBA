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

CREATE PROCEDURE [HAY_TABLA].[sp_listado_3]
	@desde DATETIME,
	@hasta DATETIME
AS
BEGIN	
	SELECT 	TOP 5 

END
GO

CREATE PROCEDURE [HAY_TABLA].[sp_listado_4]
	@desde DATETIME,
	@hasta DATETIME
AS
BEGIN	
	SELECT 	TOP 5 

END
GO

CREATE PROCEDURE [HAY_TABLA].[sp_listado_5]
	@desde DATETIME,
	@hasta DATETIME
AS
BEGIN	
	SELECT 	TOP 5 

END
GO
*/
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
	ORDER BY
		Nombre 
END
GO

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

-----------------------
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

--- =============================================
--- Description:	Devuelve un listado de funcionalidades de un rol nuevo
--- =============================================
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
/*
CREATE PROCEDURE [HAY_TABLA].[sp_select_rutas_con_ciudadOrigen]
	@cdadOrigen nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 10
		R.ID, R.CODIGO, CO.NOMBRE as "CO_NOMBRE", CD.NOMBRE as "CD_NOMBRE", R.PRECIOBASEKG, R.PRECIOBASEPASAJE, R.STATUS
	FROM	
		[HAY_TABLA].RUTA R, [HAY_TABLA].CIUDAD CO, [HAY_TABLA].CIUDAD CD
	WHERE		
		((@cdadOrigen is null) or CO.NOMBRE like '%' + @cdadOrigen + '%' AND CO.ID = R.ID_CDADORIGEN AND CD.ID = R.ID_CDADDESTINO)
	ORDER BY
		CO.NOMBRE 
END
GO
*/

CREATE PROCEDURE [HAY_TABLA].[sp_get_ruta_by_id]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		ID, PRECIOBASEKG, PRECIOBASEPASAJE, ID_SERVICIO, ID_CDADORIGEN, ID_CDADDESTINO
	FROM 
		[HAY_TABLA].RUTA
	WHERE
		Id = @id
END
GO

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
	FROM
		[HAY_TABLA].RUTA R, [HAY_TABLA].SERVICIO S, [HAY_TABLA].CIUDAD CO, [HAY_TABLA].CIUDAD CD
	WHERE
		((@codRuta is null)) or (R.CODIGO LIKE '%' + @codRuta + '%') AND
		((@idCiudadOrigen is null)  or (R.ID_CDADORIGEN = @idCiudadOrigen AND R.ID_CDADORIGEN=CO.ID)) AND
		((@idCiudadDestino is null) or (R.ID_CDADDESTINO = @idCiudadDestino  AND R.ID_CDADDESTINO=CD.ID)) AND
		((@idTipoDeServicio is null) or (R.ID_SERVICIO = @idTipoDeServicio 		AND S.ID=R.ID_SERVICIO ))
	ORDER BY
		R.CODIGO, CO.NOMBRE
END
GO

CREATE PROCEDURE [HAY_TABLA].[sp_select_ruta]
	@id int
AS
BEGIN
	SELECT
		R.ID, CO.NOMBRE as "CO_NOMBRE", CD.NOMBRE as "CD_NOMBRE", R.PRECIOBASEPASAJE, R.PRECIOBASEKG, S.ID as "S_ID", S.NOMBRE as "S_NOMBRE"
	FROM
		[HAY_TABLA].RUTA R, [HAY_TABLA].SERVICIO S, [HAY_TABLA].CIUDAD CO, [HAY_TABLA].CIUDAD CD
	WHERE
		R.ID  = @id
		AND R.ID_CDADORIGEN=CO.ID AND R.ID_CDADDESTINO=CD.ID AND S.ID=R.ID_SERVICIO
END
GO

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

CREATE PROCEDURE [HAY_TABLA].[sp_insertar_ruta]
	@idCiudadOrigen int,
	@idCiudadDestino int,
	@idTipoDeServicio int,
	@precioBasePasaje numeric(18,0),
	@precioBaseKG numeric(18,0),
	@status bit
AS
BEGIN
	DECLARE @codRuta int
	SELECT @codRuta = MAX(CODIGO)+1 FROM [HAY_TABLA].RUTA

	if (exists(select id from [HAY_TABLA].RUTA where ID_CDADORIGEN=@idCiudadOrigen AND ID_CDADDESTINO=@idCiudadDestino AND ID_SERVICIO=@idTipoDeServicio))
		begin
			RAISERROR(N'Ya existe dicha Ruta',16,1)
			return
		end		
		
	INSERT INTO [HAY_TABLA].RUTA
				(ID_CDADORIGEN,ID_CDADDESTINO,ID_SERVICIO,PRECIOBASEPASAJE,PRECIOBASEKG,CODIGO)
    OUTPUT
		inserted.id
    VALUES
          (	@idCiudadOrigen, @idCiudadDestino, @idTipoDeServicio, 
          	@precioBasePasaje, @precioBaseKG, @codRuta)
END
GO

CREATE PROCEDURE [HAY_TABLA].[sp_modificacion_ruta]
	@id	int,
	@idCiudadOrigen int,
	@idCiudadDestino int,
	@idTipoDeServicio int,
	@precioBasePasaje numeric(18,0),
	@precioBaseKG numeric(18,0),
	@status bit
AS
BEGIN
	SET NOCOUNT ON;
	
		if (exists(select id from [HAY_TABLA].RUTA where ID_CDADORIGEN=@idCiudadOrigen AND ID_CDADDESTINO=@idCiudadDestino AND ID_SERVICIO=@idTipoDeServicio AND ID <> @id))
		begin
			RAISERROR(N'Ya existe una Ruta con esos datos',16,1)
			return
		end		
	
	UPDATE 
		[HAY_TABLA].RUTA
	SET 
	ID_CDADORIGEN = @idCiudadOrigen,
	ID_CDADDESTINO = @idCiudadDestino,
	ID_SERVICIO = @idTipoDeServicio,
	PRECIOBASEPASAJE = @precioBasePasaje,
	PRECIOBASEKG = @precioBaseKG,
	STATUS = @status
	WHERE
		id = @id
END
GO