CREATE PROCEDURE [dbo].[spProduct_Update]
        @ProductId int,
        @Name nvarchar(255),
        @Description nvarchar(max),
        @Price decimal,
        @ManufacturedDate date,
        @ExpirationDate date,
        @ManufacturerId int,
        @MeasurementUnitId int,
        @QuantityAtWarehouse int
AS
BEGIN 
    UPDATE dbo.Product
    SET 
          Name =@Name
         ,Description =@Description
         ,Price =@Price
         ,ManufacturedDate=@ManufacturedDate
         ,ExpirationDate=@ExpirationDate
         ,ManufacturerId=@ManufacturerId
         ,MeasurementUnitId=@MeasurementUnitId
         ,QuantityAtWarehouse=@QuantityAtWarehouse
    WHERE Product.Id = @ProductId; 
END
