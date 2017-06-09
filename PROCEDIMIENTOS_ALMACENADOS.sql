-- CREAMOS UN PROCEDIMIENTO ALMACENADO
ALTER PROCEDURE [dbo].[GET_COCHE_POR_MARCA]
AS
BEGIN
<<<<<<< HEAD
	SELECT Coches.*, Marcas.denominacion as denominacionMarca, TiposCombustible.id as denominacionTipoCombustible
	FROM Marcas
		INNER JOIN Coches on Marcas.id = Coches.idMarca
		INNER JOIN TiposCombustible TC on TC.id = Coches.idTipoCombustible 
=======
	SELECT Coches.*, 
	Marcas.denominacion as denominacionMarca, 
	TiposCombustible.denominacion as denominacionTipoCombustible
	FROM Marcas
		INNER JOIN Coches on Marcas.id = Coches.idMarca
		INNER JOIN TiposCombustible on TiposCombustible.id = Coches.idTipoCombustible 
>>>>>>> development
	--PRINT 'MI PRIMER PROCEDIMIENTO ALMACENADO'
END

ALTER PROCEDURE [dbo].[GET_COCHE_POR_MARCA_ID]
@id int
AS
BEGIN
	SELECT Coches.*, Marcas.denominacion as denominacionMarca, TiposCombustible.denominacion as denominacionTipoCombustible
	FROM Marcas
		INNER JOIN Coches on Marcas.id = Coches.idMarca
		INNER JOIN TiposCombustible on TiposCombustible.id = Coches.idTipoCombustible
	WHERE Coches.id = @id 
	
END

-- PROCEDIMIENTO PARA EL EJERCICIO DEL VIERNES 02/06
CREATE PROCEDURE GET_COCHE_POR_MARCA_MATRICULA_PLAZAS
AS
BEGIN
	SELECT 
		 M.denominacion as Marca
		,C.matricula
		,C.nPlazas
	FROM Marcas M
		INNER JOIN Coches C ON M.id = C.idMarca
	GROUP BY 
		 M.denominacion
		,C.matricula
		,C.nPlazas
	ORDER BY nPlazas
END

ALTER PROCEDURE GET_COCHE_POR_MARCA_MATRICULA_PLAZAS_2
	  @marca nvarchar(50) = NULL
	, @nPlazas smallint = NULL
AS
BEGIN
	SELECT 
		 M.denominacion as Marca
		,C.matricula
		,C.nPlazas
	FROM Marcas M
		INNER JOIN Coches C ON M.id = C.idMarca
	WHERE 
		(M.denominacion LIKE '%' + @marca + '%' OR @marca is null)
	and	(C.nPlazas >= @nPlazas OR @nPlazas is null)
	ORDER BY nPlazas
END

-- PROCEDIMIENTO PARA OBTENER LA LISTA DE MARCAS
CREATE PROCEDURE GET_MARCAS
AS
BEGIN
	SELECT id, denominacion FROM Marcas 
END

CREATE PROCEDURE GET_MARCAS_POR_ID
	@id BigInt
AS
BEGIN
	SELECT id, denominacion FROM Marcas 
	WHERE Marcas.id = @id
END

-- PROCEDIMIENTOS PARA LA TABLA TIPOS COMBUSTIBLES
CREATE PROCEDURE GET_TIPOS_COMBUSTIBLE
AS
BEGIN
	SELECT id, denominacion FROM TiposCombustible
END

CREATE PROCEDURE GET_TIPOS_COMBUSTIBLE_ID
	@id Bigint
AS
BEGIN
	SELECT id, denominacion FROM TiposCombustible
	WHERE id = @id
END

-- PROCEDIMIENTO ACTUALIZACION MARCA
CREATE PROCEDURE ACTUALIZA_MARCA
	@id BigInt,
	@denominacion nvarchar(50)
AS
BEGIN
	UPDATE Marcas
    SET denominacion = @denominacion
    WHERE id = @id
END

-- PROCEDIMIENTO PARA BORRAR MARCA
CREATE PROCEDURE BORRA_MARCA
@id BigInt
AS
BEGIN
	DELETE FROM Marcas
	WHERE id = @id 
END