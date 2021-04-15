CREATE PROCEDURE [dbo].[spMeasurementUnit_GetAll]
AS
BEGIN 
	SELECT [Id] AS MeasurementUnitId, [Name] FROM dbo.MeasurementUnit;
END	