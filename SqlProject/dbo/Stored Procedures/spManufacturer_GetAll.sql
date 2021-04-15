CREATE PROCEDURE [dbo].[spManufacturer_GetAll]
AS
BEGIN 
	SELECT [Id] AS ManufacturerId, [Name], [Address] FROM dbo.Manufacturer;
END
