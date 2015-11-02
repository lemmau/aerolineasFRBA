/* --		
	Se tiene un total de 23 tablas
	
	Sacar esto cuando lo entreguemos porque solo esta para testing. 
	SI falla -> correr varias veces asi "vuelan" las restricciones de FK

DROP TABLE [HAY_TABLA].#TEMP

DROP TABLE [HAY_TABLA].VIAJE
DROP TABLE [HAY_TABLA].TIPOBAJA
DROP TABLE [HAY_TABLA].HISTORIALBAJA_AERONAVE
DROP TABLE [HAY_TABLA].AERONAVE
DROP TABLE [HAY_TABLA].USUARIO
DROP TABLE [HAY_TABLA].CANJE
DROP TABLE [HAY_TABLA].PERSONA
DROP TABLE [HAY_TABLA].CIUDAD
DROP TABLE [HAY_TABLA].RUTA
DROP TABLE [HAY_TABLA].SERVICIO
DROP TABLE [HAY_TABLA].BUTACA
DROP TABLE [HAY_TABLA].DEVOLUCION
DROP TABLE [HAY_TABLA].ITEMSDEVOLUCION
DROP TABLE [HAY_TABLA].PASAJE_ENCOMIENDA
DROP TABLE [HAY_TABLA].FORMADEPAGO
DROP TABLE [HAY_TABLA].COMPRA
DROP TABLE [HAY_TABLA].TIPOTARJETA
DROP TABLE [HAY_TABLA].TARJETA
DROP TABLE [HAY_TABLA].PRODUCTO
DROP TABLE [HAY_TABLA].ROL
DROP TABLE [HAY_TABLA].ROLES_USUARIO
DROP TABLE [HAY_TABLA].FUNCIONALIDAD_ROL
DROP TABLE [HAY_TABLA].FUNCIONALIDAD

DROP PROCEDURE [HAY_TABLA].[sp_get_rol_by_id]
DROP PROCEDURE [HAY_TABLA].[sp_insertar_rol]
DROP PROCEDURE [HAY_TABLA].[sp_baja_rol]
DROP PROCEDURE [HAY_TABLA].[sp_modificacion_rol]
DROP PROCEDURE [HAY_TABLA].[sp_select_roles]
DROP PROCEDURE [HAY_TABLA].[sp_select_funcionalidades_de_rol]
DROP PROCEDURE [HAY_TABLA].[sp_select_funcionalidades_de_rol_nuevo]
DROP PROCEDURE [HAY_TABLA].[sp_insertar_funcionalidad_a_rol]
DROP PROCEDURE [HAY_TABLA].[sp_borrar_funcionalidades_de_rol]
DROP PROCEDURE [HAY_TABLA].[sp_select_roles_de_usuario]

DROP PROCEDURE [HAY_TABLA].[sp_get_usuario_by_id]
DROP PROCEDURE [HAY_TABLA].[sp_get_usuario_by_login]
DROP PROCEDURE [HAY_TABLA].[sp_get_usuario_intentos]
DROP PROCEDURE [HAY_TABLA].[sp_set_usuario_intentos]

DROP PROCEDURE [HAY_TABLA].[sp_get_ciudades]
DROP PROCEDURE [HAY_TABLA].[sp_insertar_ciudad]
DROP PROCEDURE [HAY_TABLA].[sp_eliminar_ciudad]


DROP SCHEMA [HAY_TABLA]
*/

USE [GD2C2015]
GO

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name='HAY_TABLA')
BEGIN
    -- The schema must be run in its own batch!
	EXEC ('CREATE SCHEMA [HAY_TABLA]')
END
GO

print 'Inicio de Instrucciones DDL.'

CREATE TABLE [HAY_TABLA].ROL
(
ID			INT IDENTITY(1,1) NOT NULL,
NOMBRE		NVARCHAR(50) UNIQUE NOT NULL,
STATUS		BIT NOT NULL DEFAULT 1,	-- todos activos por default

PRIMARY KEY (ID)
);
GO

CREATE TABLE [HAY_TABLA].FUNCIONALIDAD (
ID 			INT IDENTITY(1,1) NOT NULL,
NOMBRE		NVARCHAR(50) NOT NULL,

PRIMARY KEY (ID)
);
GO

CREATE TABLE [HAY_TABLA].FUNCIONALIDAD_ROL (
ID_FUNCIONALIDAD	INT NOT NULL,
ID_ROL				INT NOT NULL,

PRIMARY KEY (ID_FUNCIONALIDAD, ID_ROL),
FOREIGN KEY (ID_FUNCIONALIDAD) REFERENCES [HAY_TABLA].FUNCIONALIDAD,
FOREIGN KEY (ID_ROL) REFERENCES [HAY_TABLA].ROL,
);
GO

CREATE TABLE [HAY_TABLA].USUARIO (
ID 					INT IDENTITY(1,1) NOT NULL,
USERNAME			NVARCHAR(255) UNIQUE NOT NULL,
PASSWORD			NVARCHAR(255),	-- mediante encriptacion SHA256
INTENTOSFALLIDOS	INT NOT NULL DEFAULT 0,	-- al llegar a 3 se pone STATUS en 0

PRIMARY KEY (ID)
);
GO

CREATE TABLE [HAY_TABLA].ROLES_USUARIO
(
ID_ROL 		INT NOT NULL,
ID_USUARIO 	INT NOT NULL,

PRIMARY KEY (ID_ROL, ID_USUARIO),
FOREIGN KEY (ID_ROL) REFERENCES [HAY_TABLA].ROL,
FOREIGN KEY (ID_USUARIO) REFERENCES [HAY_TABLA].USUARIO
)

CREATE TABLE [HAY_TABLA].PERSONA -- aca se va a agrupar los CLIENTES + COMPRADORES
(
ID 					INT IDENTITY(1,1) NOT NULL,
ID_ROL				INT NOT NULL DEFAULT 2, -- ROL 2 (GUEST)
DNI 				INT NOT NULL, -- UNIQUE 
NOMBRE				NVARCHAR(255),
APELLIDO			NVARCHAR(255),
DIRECCION			NVARCHAR(255),
TELEFONO			NVARCHAR(255),
MAIL 				NVARCHAR(255),
FECHANACIMIENTO		DATETIME,

PRIMARY KEY (ID),
FOREIGN KEY (ID_ROL) REFERENCES [HAY_TABLA].ROL
);
GO

CREATE TABLE [HAY_TABLA].PRODUCTO (
ID 					INT IDENTITY(1,1) NOT NULL,
DESCRIPCION			NVARCHAR(255) NOT NULL,
CANTSTOCK			INT NOT NULL,
MILLASNECESARIAS	INT NOT NULL,

PRIMARY KEY (ID),
);
GO

CREATE TABLE [HAY_TABLA].CANJE (
ID 					INT IDENTITY(1,1) NOT NULL,
ID_PRODUCTO			INT NOT NULL,
ID_PERSONA			INT NOT NULL,
DNI					INT NOT NULL,
CANTIDAD			INT NOT NULL,
FECHA				DATETIME NOT NULL,

PRIMARY KEY (ID),
FOREIGN KEY (ID_PRODUCTO) REFERENCES [HAY_TABLA].PRODUCTO,
FOREIGN KEY (ID_PERSONA) REFERENCES [HAY_TABLA].PERSONA
);
GO

CREATE TABLE [HAY_TABLA].CIUDAD (
ID 			INT	IDENTITY(1,1) NOT NULL,
NOMBRE		NVARCHAR(100) NOT NULL,
STATUS		BIT NOT NULL DEFAULT 1,	-- 0 cuando es BAJA

PRIMARY KEY (ID)
);
GO

CREATE TABLE [HAY_TABLA].SERVICIO (
ID 						INT	IDENTITY(1,1) NOT NULL,
NOMBRE					NVARCHAR(255) NOT NULL,
PORCENTAJEADICIONAL		INT NOT NULL,

PRIMARY KEY (ID)
);
GO

CREATE TABLE [HAY_TABLA].RUTA (
ID 					INT IDENTITY(1,1) NOT NULL,
CODIGO 				INT NOT NULL, -- UNIQUE 
ID_CDADORIGEN		INT NOT NULL,
ID_CDADDESTINO		INT NOT NULL,
ID_SERVICIO			INT NOT NULL,
PRECIOBASEPASAJE 	INT NOT NULL,
PRECIOBASEKG 		INT NOT NULL,
STATUS				BIT NOT NULL DEFAULT 1,	-- 0 cuando es BAJA

PRIMARY KEY (ID),
FOREIGN KEY (ID_CDADORIGEN) REFERENCES [HAY_TABLA].CIUDAD,
FOREIGN KEY (ID_CDADDESTINO) REFERENCES [HAY_TABLA].CIUDAD,
FOREIGN KEY (ID_SERVICIO) REFERENCES [HAY_TABLA].SERVICIO
);
GO

CREATE TABLE [HAY_TABLA].AERONAVE (
ID 						INT IDENTITY(1,1) NOT NULL,
FECHAALTA				DATETIME NOT NULL,
ID_SERVICIO				INT NOT NULL,
MODELO					NVARCHAR(255) NOT NULL,
MATRICULA				NVARCHAR(255) NOT NULL, -- UNIQUE
FABRICANTE				NVARCHAR(255) NOT NULL,
CANTBUTACAS				INT NOT NULL,
ESPACIOKGENCOMIENDAS	INT NOT NULL,

PRIMARY KEY (ID),
FOREIGN KEY (ID_SERVICIO) REFERENCES [HAY_TABLA].SERVICIO
);
GO

CREATE TABLE [HAY_TABLA].TIPOBAJA (
ID 						INT IDENTITY(1,1) NOT NULL,
DESCRIPCION	 			NVARCHAR(255) NOT NULL,
PRIMARY KEY (ID)
);
GO

CREATE TABLE [HAY_TABLA].HISTORIALBAJA_AERONAVE (
ID 						INT IDENTITY(1,1) NOT NULL,
ID_AERONAVE				INT NOT NULL,
ID_TIPOBAJA 			INT NOT NULL,
FECHABAJA 				DATETIME NOT NULL,
FECHAREINICIO 			DATETIME, -- puede ser NULL

PRIMARY KEY (ID),
FOREIGN KEY (ID_AERONAVE) REFERENCES [HAY_TABLA].AERONAVE,
FOREIGN KEY (ID_TIPOBAJA) REFERENCES [HAY_TABLA].TIPOBAJA
);
GO

CREATE TABLE [HAY_TABLA].BUTACA (
ID 						INT	IDENTITY(1,1) NOT NULL,
NUMERO 					INT NOT NULL,
ID_AERONAVE				INT NOT NULL,
TIPO 					NVARCHAR(255) NOT NULL,	-- pasillo / ventanilla / 0 (cuando se trata de una encomienda)
PISO					BIT NOT NULL, -- TODAS estan en el piso '1' !!
STATUS					BIT NOT NULL DEFAULT 1,	-- libre (0) / ocupada (1)

PRIMARY KEY (ID),
FOREIGN KEY (ID_AERONAVE) REFERENCES [HAY_TABLA].AERONAVE
);
GO

CREATE TABLE [HAY_TABLA].VIAJE (
ID 						INT IDENTITY(1,1) NOT NULL,
ID_AERONAVE				INT NOT NULL,
ID_RUTA 				INT NOT NULL,
FECHASALIDA 			DATETIME NOT NULL,
FECHALLEGADA 			DATETIME NOT NULL,
FECHALLEGADAESTIMADA 	DATETIME NOT NULL,
STATUS 					BIT NOT NULL DEFAULT 0, -- no realizado / realizado

PRIMARY KEY (ID),
FOREIGN KEY (ID_AERONAVE) REFERENCES [HAY_TABLA].AERONAVE,
FOREIGN KEY (ID_RUTA) REFERENCES [HAY_TABLA].RUTA
);
GO

CREATE TABLE [HAY_TABLA].TIPOTARJETA
(
ID					INT IDENTITY(1,1) NOT NULL,
NOMBRE 				NVARCHAR(50) NOT NULL,
CANTCUOTAS 			INT NOT NULL,

PRIMARY KEY (ID)
);
GO

CREATE TABLE [HAY_TABLA].TARJETA
(
ID					INT IDENTITY(1,1) NOT NULL,
ID_TIPOTARJETA 		INT NOT NULL,
ID_COMPRADOR 		INT NOT NULL,
NUMERO				INT NOT NULL,
CLAVE				INT NOT NULL,
FECHAVTO			DATETIME NOT NULL,

PRIMARY KEY (ID),
FOREIGN KEY(ID_TIPOTARJETA) REFERENCES [HAY_TABLA].TIPOTARJETA,
FOREIGN KEY(ID_COMPRADOR) REFERENCES [HAY_TABLA].PERSONA
);
GO


CREATE TABLE [HAY_TABLA].FORMADEPAGO (
ID 					INT IDENTITY(1,1) NOT NULL,
DESCRIPCION			NVARCHAR(255) NOT NULL,

PRIMARY KEY (ID),
);
GO

CREATE TABLE [HAY_TABLA].COMPRA (
ID 						INT IDENTITY(1,1) NOT NULL,
ID_TARJETA				INT,
ID_VIAJE				INT NOT NULL,
ID_FORMADEPAGO			INT, -- NOT NULL
FECHA 					DATETIME NOT NULL,
IMPORTETOTAL			INT NOT NULL,

PRIMARY KEY (ID),
FOREIGN KEY (ID_FORMADEPAGO) REFERENCES [HAY_TABLA].FORMADEPAGO,
FOREIGN KEY (ID_TARJETA) REFERENCES [HAY_TABLA].TARJETA,
FOREIGN KEY (ID_VIAJE) REFERENCES [HAY_TABLA].VIAJE
);
GO

CREATE TABLE [HAY_TABLA].PASAJE_ENCOMIENDA (
ID 						INT IDENTITY(1,1) NOT NULL,
ID_CLIENTE				INT NOT NULL,
ID_VIAJE				INT NOT NULL,
ID_COMPRA				INT NOT NULL,
IMPORTE 				INT NOT NULL, 
FECHA 					DATETIME NOT NULL,
ID_BUTACA_PASAJE		INT,
PESO_ENCOMIENDA			INT,
	
PRIMARY KEY (ID),
FOREIGN KEY (ID_CLIENTE) REFERENCES [HAY_TABLA].PERSONA,
FOREIGN KEY (ID_VIAJE) REFERENCES [HAY_TABLA].VIAJE,
FOREIGN KEY (ID_COMPRA) REFERENCES [HAY_TABLA].COMPRA,
FOREIGN KEY (ID_BUTACA_PASAJE) REFERENCES [HAY_TABLA].BUTACA,

--CHECK (	(PESO_ENCOMIENDA IS NOT NULL) OR (ID_BUTACA_PASAJE IS NOT NULL)
--			AND NOT (PESO_ENCOMIENDA IS NOT NULL) AND (ID_BUTACA_PASAJE IS NOT NULL)
--		)
);
GO

CREATE TABLE [HAY_TABLA].DEVOLUCION (
ID 					INT IDENTITY(1,1) NOT NULL,
FECHA 				DATETIME NOT NULL,
MOTIVO	 			NVARCHAR(255) NOT NULL,

PRIMARY KEY (ID)
);
GO

CREATE TABLE [HAY_TABLA].ITEMSDEVOLUCION (
ID 						INT IDENTITY(1,1) NOT NULL,
ID_DEVOLUCION 			INT NOT NULL,
ID_PASAJE_ENCOMIENDA	INT NOT NULL,
ID_COMPRA				INT NOT NULL,	-- VER si es necesario (ya que PASAJE_ENCOMIENDA tiene referencia a la compra)

PRIMARY KEY (ID),
FOREIGN KEY (ID_DEVOLUCION)	REFERENCES [HAY_TABLA].DEVOLUCION,
FOREIGN KEY (ID_PASAJE_ENCOMIENDA) REFERENCES [HAY_TABLA].PASAJE_ENCOMIENDA,
FOREIGN KEY (ID_COMPRA)	REFERENCES [HAY_TABLA].COMPRA
);
GO

print 'Fin de Instrucciones DDL.'
/*************************************************** INSERTS ******************************************************/
-- INSERCIONES en:
--				ROLES / FUNCIONALIDADES / FUNCIONALIDADES X ROL / USUARIOS / PRODUCTOS / FORMAS DE PAGO / ROLES DE USUARIO
---------------------------------------------------------------------------------------------------------------------

SET IDENTITY_INSERT [HAY_TABLA].ROL ON
	INSERT INTO [HAY_TABLA].ROL (ID, NOMBRE) VALUES(1,'Administrativo')
	INSERT INTO [HAY_TABLA].ROL (ID, NOMBRE) VALUES(2,'Cliente (Guest)')
SET IDENTITY_INSERT [HAY_TABLA].ROL OFF
print 'Roles creados!'

-- Son 12 las FUNCIONALIDADES a desarrollar
-- La funcionalidad "Registro de Usuario" SE PIDIO NO HACER (segun la cátedra !!!)
-- "LOGIN no se considera una funcionalidad que pueda ser asignada a un rol" (segun enunciado), por lo tanto la quito
SET IDENTITY_INSERT [HAY_TABLA].FUNCIONALIDAD ON
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD (ID, NOMBRE) VALUES(1,'ABM DE ROL');
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD (ID, NOMBRE) VALUES(2,'ABM DE CIUDAD');	-- solo para búsqueda y A/B (logica)
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD (ID, NOMBRE) VALUES(3,'ABM DE RUTA AEREA');
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD (ID, NOMBRE) VALUES(4,'ABM DE AERONAVE');
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD (ID, NOMBRE) VALUES(5,'GENERACION DE VIAJE');
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD (ID, NOMBRE) VALUES(6,'REGISTRO DE LLEGADA A DESTINO');
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD (ID, NOMBRE) VALUES(7,'COMPRA DE PASAJE/ENCOMIENDA');
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD (ID, NOMBRE) VALUES(8,'DEVOLUCION/CANCELACION DE PASAJE/ENCOMIENDA');
	-- VER si estos pueden ser 2 en 1:
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD (ID, NOMBRE) VALUES(9,'CONSULTA DE MILLAS');
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD (ID, NOMBRE) VALUES(10,'CANJE DE MILLAS');

	INSERT INTO [HAY_TABLA].FUNCIONALIDAD (ID, NOMBRE) VALUES(11,'LISTADO ESTADISTICO');
SET IDENTITY_INSERT [HAY_TABLA].FUNCIONALIDAD OFF
print 'Funcionalidades creadas!'

----------------------------------------------------
-- FUNCIONALIDADES disponibles para c/u de los ROLES
----------------------------------------------------
	--Administrativos
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD_ROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,1)
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD_ROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,2)
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD_ROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,3)
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD_ROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,4)
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD_ROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,5)
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD_ROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,6)
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD_ROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,7)
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD_ROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,8)
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD_ROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,9)
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD_ROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,10)
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD_ROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,11)
	--Clientes
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD_ROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (2,7)
	INSERT INTO [HAY_TABLA].FUNCIONALIDAD_ROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (2,9)
	print 'Cruce de Funcionalidades por Rol insertados exitosamente!'

------------------------------------------------------
--- users ADMIN
------------------------------------------------------
INSERT INTO [HAY_TABLA].USUARIO
(USERNAME, PASSWORD, INTENTOSFALLIDOS) VALUES
(N'admin', N'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 0)	-- password : 'w23e'
GO

INSERT INTO [HAY_TABLA].USUARIO
(USERNAME, PASSWORD, INTENTOSFALLIDOS) VALUES
(N'admin02', N'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 0)	-- password : 'w23e'
GO

INSERT INTO [HAY_TABLA].USUARIO
(USERNAME, PASSWORD, INTENTOSFALLIDOS) VALUES
(N'admin03', N'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 0)	-- password : 'w23e'
GO
print 'Usuarios administrativos creados!'

------------------------------------------------------
--- PORCENTAJES segun Tipo de Servicio
------------------------------------------------------
INSERT INTO [HAY_TABLA].SERVICIO(NOMBRE, PORCENTAJEADICIONAL) values ('Primera Clase', 2)
INSERT INTO [HAY_TABLA].SERVICIO(NOMBRE, PORCENTAJEADICIONAL) values ('Ejecutivo', 1.5)
INSERT INTO [HAY_TABLA].SERVICIO(NOMBRE, PORCENTAJEADICIONAL) values ('Turista', 1.2)
GO
print 'Porcentajes Adicionales creados!'

------------------------------------------------------
--- ROLES de USUARIO
------------------------------------------------------
-- asocio al user 'admin' unicamente el rol 'Administrativo'
INSERT INTO [HAY_TABLA].ROLES_USUARIO
(ID_ROL, ID_USUARIO) VALUES (1, 1)
GO

-- asocio al usuario 'admin02' los unicos 2 roles que hay de momento
INSERT INTO [HAY_TABLA].ROLES_USUARIO
(ID_ROL, ID_USUARIO) VALUES (1, 2)
GO

INSERT INTO [HAY_TABLA].ROLES_USUARIO
(ID_ROL, ID_USUARIO) VALUES (2, 2)
GO
print 'Roles de Usuario creados!'

------------------------------------------------------
--- FORMAS de PAGO
------------------------------------------------------
INSERT INTO [HAY_TABLA].FORMADEPAGO
(DESCRIPCION) VALUES ('Efectivo')
GO

INSERT INTO [HAY_TABLA].FORMADEPAGO
(DESCRIPCION) VALUES ('Tarjeta')
GO
print 'Formas de Pago creadas!'

------------------------------------------------------
--- TIPOS de BAJA
------------------------------------------------------
INSERT INTO [HAY_TABLA].TIPOBAJA
(DESCRIPCION) VALUES ('Fuera de Servicio')
GO

INSERT INTO [HAY_TABLA].TIPOBAJA
(DESCRIPCION) VALUES ('Baja definitiva')
GO
print 'Tipos de Baja creadas!'

------------------------------------------------------
--- TIPOS de TARJETAS -random-
------------------------------------------------------
INSERT INTO [HAY_TABLA].TIPOTARJETA
(NOMBRE, CANTCUOTAS) VALUES ('Diners Club', 3)
GO

INSERT INTO [HAY_TABLA].TIPOTARJETA
(NOMBRE, CANTCUOTAS) VALUES ('Visa', 12)
GO

INSERT INTO [HAY_TABLA].TIPOTARJETA
(NOMBRE, CANTCUOTAS) VALUES ('Master Card', 12)
GO

INSERT INTO [HAY_TABLA].TIPOTARJETA
(NOMBRE, CANTCUOTAS) VALUES ('American Airlines', 12)
GO

INSERT INTO [HAY_TABLA].TIPOTARJETA
(NOMBRE, CANTCUOTAS) VALUES ('Argencard', 36)	-- esta es de terror !!
GO
print 'Tarjetas -random- creadas!'

------------------------------------------------------
--- PRODUCTOS para canjes de millas
------------------------------------------------------
INSERT INTO [HAY_TABLA].PRODUCTO
(DESCRIPCION, CANTSTOCK, MILLASNECESARIAS)
VALUES
('E-Reader', 1205, 15000)
GO

INSERT INTO [HAY_TABLA].PRODUCTO
(DESCRIPCION, CANTSTOCK, MILLASNECESARIAS)
VALUES
('Afeitadora Philips', 250, 17000)
GO

INSERT INTO [HAY_TABLA].PRODUCTO
(DESCRIPCION, CANTSTOCK, MILLASNECESARIAS)
VALUES
('Samsung s6', 150, 25000)
GO

INSERT INTO [HAY_TABLA].PRODUCTO
(DESCRIPCION, CANTSTOCK, MILLASNECESARIAS)
VALUES
('Cam GO PRO HERO 4', 225, 39000)
GO

INSERT INTO [HAY_TABLA].PRODUCTO
(DESCRIPCION, CANTSTOCK, MILLASNECESARIAS)
VALUES
('Lenovo yoga 2 pro', 310, 45000)
GO

INSERT INTO [HAY_TABLA].PRODUCTO
(DESCRIPCION, CANTSTOCK, MILLASNECESARIAS)
VALUES
('HP ALL-in-one', 70, 55000)
GO

INSERT INTO [HAY_TABLA].PRODUCTO
(DESCRIPCION, CANTSTOCK, MILLASNECESARIAS)
VALUES
('Play Station 4', 99 , 56200)
GO

INSERT INTO [HAY_TABLA].PRODUCTO
(DESCRIPCION, CANTSTOCK, MILLASNECESARIAS)
VALUES
('SMART TV Samsung 40"', 59, 153200)
GO

INSERT INTO [HAY_TABLA].PRODUCTO
(DESCRIPCION, CANTSTOCK, MILLASNECESARIAS)
VALUES
('Cuatriciclo Yamaha 700', 25, 199000)
GO
print 'Productos para canjes creados!'
GO

print 'Fin de INSERCIONES manuales.'
GO
/***********************************************STORED PROCEDURES*********************************************/
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
	if (exists(select id from [HAY_TABLA].CIUDAD where NOMBRE = @nombre and STATUS = 1))
		begin
			RAISERROR(N'Ya existe una ciudad con ese nombre',16,1)
			return
		end		
	else 
		begin
			if (exists(select id from [HAY_TABLA].CIUDAD where NOMBRE = @nombre and STATUS = 0))		
				begin
					UPDATE 
						[HAY_TABLA].CIUDAD
					SET 
						STATUS = 1
					WHERE
						NOMBRE = @nombre and STATUS = 0
					RAISERROR(N'Habilito Ciudad',16,1)
					return
				end
			else
				begin
					INSERT INTO [HAY_TABLA].CIUDAD  (NOMBRE, STATUS)
					OUTPUT
						inserted.id
					VALUES
						(@nombre, 1)
					RAISERROR(N'Agrego Nueva Ciudad',16,1)
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


/*************************************************** MIGRACION ******************************************************/
--- MIGRACION - CIUDADES (Un total de 35 registros en tabla MASTER)
		INSERT INTO [HAY_TABLA].CIUDAD
					(NOMBRE)
		SELECT DISTINCT Ruta_Ciudad_Destino
  		FROM gd_esquema.Maestra
  	print 'Ciudades migradas!'

--- MIGRACION - PERSONAS (Un total de 2594 registros en tabla MASTER)
	INSERT INTO [HAY_TABLA].PERSONA
				(DNI, NOMBRE, APELLIDO, DIRECCION, TELEFONO, MAIL, FECHANACIMIENTO)	
	SELECT 
			Cli_Dni, Cli_Nombre, Cli_Apellido, Cli_Dir, Cli_Telefono, Cli_Mail, Cli_Fecha_Nac
	FROM
		gd_esquema.Maestra
	group by
		Cli_Dni, Cli_Nombre, Cli_Apellido, Cli_Dir, Cli_Telefono, Cli_Mail, Cli_Fecha_Nac
	print 'Personas migrados!'

--- MIGRACION - AERONAVES (Un total de  30 registros en tabla MASTER)
--- nota: NUMERO DE AERONAVE = ID (DE LA TABLA)
	INSERT INTO [HAY_TABLA].AERONAVE
				(ID_SERVICIO, MODELO, MATRICULA, FABRICANTE, CANTBUTACAS, ESPACIOKGENCOMIENDAS, FECHAALTA)
   	SELECT 	SERVICIO.ID as "ID_SERVICIO", Aeronave_Modelo, Aeronave_Matricula, Aeronave_Fabricante, 
  			MAX(Butaca_Nro)+1 as "Cant Butacas", Aeronave_KG_Disponibles, MIN(FechaSalida) as "Fecha Alta"
  	FROM 
  		gd_esquema.Maestra, 
  		[HAY_TABLA].SERVICIO
  	WHERE 
  		Tipo_Servicio = SERVICIO.NOMBRE
  	GROUP BY 
  		SERVICIO.ID, Aeronave_Modelo, Aeronave_Matricula, Aeronave_Fabricante, Aeronave_KG_Disponibles, Tipo_Servicio
  	print 'Aeronaves migradas!'

--- MIGRACION - BUTACAS (Un total de 1337 registros en tabla MASTER)
--- nota: todas las que se vayan a insertar se suponen ocupadas (STATUS = 1), los "huecos" se consideran libres
	INSERT INTO [HAY_TABLA].BUTACA
				(NUMERO, ID_AERONAVE, TIPO, PISO)
  	SELECT 	Butaca_Nro+1 as "Numero", 
  			A.ID "ID Aeronave", 
  			Butaca_Tipo, Butaca_Piso
  	FROM 
  		gd_esquema.Maestra, [HAY_TABLA].AERONAVE A
  	WHERE 
  		A.MATRICULA = Aeronave_Matricula
  		AND Butaca_Tipo <> '0'
  	GROUP BY 
  		Butaca_Nro, Butaca_Tipo, Butaca_Piso, A.ID
  	print 'Butacas migradas!'

--- MIGRACION - RUTAS (Un total de 68 registros en tabla MASTER)
--- notas: 
---- 		* originalmente NO hay rutas dadas de bajas, por lo que STATUS = 1 para TODOS los registros
----		* convencion adoptada: Si un MISMO recorrido ofrece DISTINTOS servicios entonces se trata de 2 rutas DISTINTAS
	INSERT INTO [HAY_TABLA].RUTA
				(CODIGO, ID_SERVICIO, ID_CDADORIGEN, ID_CDADDESTINO, PRECIOBASEPASAJE, PRECIOBASEKG)
	SELECT	Ruta_Codigo, SERVICIO.ID as "ID Servicio",	C1.ID as "ID Cdad Origen", C2.ID as "ID Cdad Destino",
			SUM(Ruta_Precio_BaseKG),SUM(Ruta_Precio_BasePasaje)
	FROM 
		(SELECT DISTINCT Ruta_Codigo, Ruta_Ciudad_Origen, Ruta_Ciudad_Destino,
						 Ruta_Precio_BaseKG, Ruta_Precio_BasePasaje, Tipo_Servicio
				FROM gd_esquema.Maestra
		) TEMPORAL,
		[HAY_TABLA].CIUDAD C1,
		[HAY_TABLA].CIUDAD C2,
		[HAY_TABLA].SERVICIO
	WHERE
		Ruta_Ciudad_Origen = C1.NOMBRE 
		AND Ruta_Ciudad_Destino = C2.NOMBRE
		AND Tipo_Servicio = SERVICIO.NOMBRE
	GROUP BY 
		Ruta_Codigo, Tipo_Servicio, Ruta_Ciudad_Destino, Ruta_Ciudad_Origen, SERVICIO.ID, C1.ID, C2.ID
	order by 1,3
  	print 'Rutas migradas!'

--- MIGRACION - VIAJES (Un total de 8510 registros en tabla MASTER)
		INSERT INTO [HAY_TABLA].VIAJE
					(ID_AERONAVE, ID_RUTA, FECHASALIDA, FECHALLEGADA, FECHALLEGADAESTIMADA)
		SELECT	
				(SELECT ID FROM [HAY_TABLA].AERONAVE WHERE Aeronave_Matricula = AERONAVE.MATRICULA) AS "ID_AERONAVE",
				(SELECT TOP 1 ID FROM [HAY_TABLA].RUTA WHERE Ruta_Codigo = RUTA.CODIGO),
				FechaSalida, FechaLLegada, Fecha_LLegada_Estimada
  		FROM gd_esquema.Maestra
  		GROUP BY 	FechaSalida, FechaLLegada, Fecha_LLegada_Estimada, Tipo_Servicio, 
  					Ruta_Codigo, Ruta_Ciudad_Origen, Ruta_Ciudad_Destino, Aeronave_Matricula
  	print 'Viajes migrados!'

-- Tabla temporal para los INSERT de COMPRA Y PASAJES/ENCOMIENDAS
CREATE TABLE #TEMP (
ID 					INT IDENTITY(1,1),
Butaca_Nro 			INT,
Pasaje_Precio 		NUMERIC(18,2),
Paquete_KG 			INT,
Paquete_Precio 		NUMERIC(18,2),
FECHA_COMPRA 		DATETIME,
ID_CLIENTE 			INT,
ID_VIAJE 			INT,
);
GO

INSERT INTO [HAY_TABLA].#TEMP
			(Butaca_Nro, Pasaje_Precio, Paquete_KG, Paquete_Precio, FECHA_COMPRA, ID_CLIENTE, ID_VIAJE)
		SELECT
			Butaca_Nro, Pasaje_Precio, Paquete_KG, Paquete_Precio,
			case Butaca_Piso
				when 0 then Paquete_FechaCompra
				when 1 	then Pasaje_FechaCompra
			end	as "FECHA COMPRA",
			(	select ID from HAY_TABLA.PERSONA P 
				where P.DNI = m.Cli_Dni
				and P.nombre = m.Cli_Nombre
				and P.apellido = P.apellido
			) AS "ID CLIENTE" ,
			(
				select TOP 1 v.ID 
				from  HAY_TABLA.Viaje v, HAY_TABLA.Ruta r, HAY_TABLA.Ciudad co, HAY_TABLA.Ciudad cd
				where v.id_ruta = r.id
				and r.codigo = m.Ruta_Codigo
				and r.ID_CDADORIGEN = co.id
				and r.ID_CDADDESTINO = cd.id
				and co.nombre = m.Ruta_Ciudad_Origen
				and cd.nombre = m.Ruta_Ciudad_Destino
				and v.id_aeronave = (	select a.id
										from HAY_TABLA.Aeronave a
										where a.matricula = m.Aeronave_Matricula
										)
				and v.FECHASALIDA = m.FechaSalida
				and v.FECHALLEGADAESTIMADA = m.Fecha_LLegada_Estimada
				AND V.FECHALLEGADA = m.FechaLLegada
			) as "ID VIAJE"
		from gd_esquema.Maestra m

/*
--- MIGRACION - COMPRA (Un total de 401 304 registros en tabla MASTER)
INSERT INTO [HAY_TABLA].COMPRA 
			(ID_VIAJE, FECHA, IMPORTETOTAL)
	SELECT 	ID_VIAJE, FECHA_COMPRA, 
			CASE Pasaje_Precio
				WHEN 0.00 	THEN Paquete_Precio
				ELSE		Pasaje_Precio
			END as "ImporteTotal"
	FROM  #TEMP
GO

--- MIGRACION - PASAJE_ENCOMIENDA (Un total de 401 304 registros en tabla MASTER)
	INSERT INTO [HAY_TABLA].PASAJE_ENCOMIENDA
--				(ID_CLIENTE, ID_VIAJE, ID_COMPRA, IMPORTE, FECHA, , ID_BUTACA_PASAJE, PESO_ENCOMIENDA)
				(ID, ID_CLIENTE, PESO_ENCOMIENDA, ID_BUTACA_PASAJE, IMPORTE)
	select ID, ID_CLIENTE, Paquete_KG, 
			case 
				when Paquete_KG > 0 then NULL
				else Butaca_Nro
				end,
		case Pasaje_Precio
			when 0.00 then 	Paquete_Precio
			else 			Pasaje_Precio
			end as "Importe"
		from #TEMP
GO


/*
INSERT INTO [HAY_TABLA].#TEMP
			(ID_CLIENTE, ID_VIAJE, Butaca_Nro, Pasaje_Precio, Paquete_KG, Paquete_Precio, FECHA_COMPRA)
		SELECT
			P.ID AS "ID CLIENTE", V.ID as "ID VIAJE",
			Butaca_Nro, Pasaje_Precio, Paquete_KG, Paquete_Precio,
			case Butaca_Piso
				when 0 then Paquete_FechaCompra
				when 1 	then Pasaje_FechaCompra
			end	as "FECHA COMPRA"
	FROM
		gd_esquema.Maestra, HAY_TABLA.PERSONA P,
		HAY_TABLA.VIAJE V, HAY_TABLA.RUTA R, HAY_TABLA.CIUDAD co, HAY_TABLA.CIUDAD cd, 
		HAY_TABLA.AERONAVE A, HAY_TABLA.BUTACA B
	WHERE 
		P.DNI = Cli_Dni AND P.NOMBRE = Cli_Nombre and P.APELLIDO = Cli_Apellido AND P.DIRECCION = Cli_Dir AND P.FECHANACIMIENTO = Cli_Fecha_Nac
		AND A.MATRICULA = Aeronave_Matricula AND V.ID_AERONAVE = A.ID
		AND R.CODIGO = Ruta_Codigo AND V.ID_RUTA = R.ID
		AND co.NOMBRE = Ruta_Ciudad_Origen AND cd.NOMBRE = Ruta_Ciudad_Destino
		AND R.ID_CDADORIGEN = co.ID AND R.ID_CDADDESTINO = cd.ID
		AND V.FECHASALIDA = maestra.FechaSalida and V.FECHALLEGADAESTIMADA = Fecha_LLegada_Estimada	AND V.FECHALLEGADA = maestra.FechaLLegada
		AND B.NUMERO = Butaca_Nro AND B.ID_AERONAVE = A.ID
*/*/