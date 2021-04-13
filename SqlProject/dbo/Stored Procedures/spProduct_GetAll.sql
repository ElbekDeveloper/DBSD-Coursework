CREATE PROCEDURE [dbo].[spProduct_GetAll]
AS
	
BEGIN 
	SELECT [P].[Id] as ProductId, [P].[Name], [P].[Description], 
				[P].[Price], [P].[ManufacturedDate], 
				[P].[ExpirationDate],
				[P].[QuantityAtWarehouse],
				[M].[Id] as ManufacturerId, [M].[Name], [M].[Address], 
				[MU].[Id] as MeasurementUnitId, [MU].[Name] 
	FROM [dbo].[Product] P
	JOIN dbo.Manufacturer M 
	ON P.ManufacturerId=M.Id
	JOIN dbo.MeasurementUnit MU
	ON P.MeasurementUnitId=MU.Id;
END
