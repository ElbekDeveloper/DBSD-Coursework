CREATE PROCEDURE [dbo].[spWarehouse_GetAll]
AS
BEGIN 
	SELECT [Id] as WarehouseId, [Address] from dbo.Warehouse;
END
