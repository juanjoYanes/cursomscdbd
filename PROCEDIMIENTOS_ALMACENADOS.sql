-- CREAMOS UN PROCEDIMIENTO ALMACENADO
ALTER PROCEDURE [dbo].[GET_COCHE_POR_MARCA]
AS
BEGIN
	SELECT Coches.*, 
	Marcas.denominacion as denominacionMarca, 
	TiposCombustible.denominacion as denominacionTipoCombustible
	FROM Marcas
		INNER JOIN Coches on Marcas.id = Coches.idMarca
		INNER JOIN TiposCombustible on TiposCombustible.id = Coches.idTipoCombustible 
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

