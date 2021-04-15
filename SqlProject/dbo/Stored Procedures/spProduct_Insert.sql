CREATE PROCEDURE [dbo].[spProduct_Insert]
        @Name nvarchar(255),
        @Description nvarchar(max),
        @Price decimal,
        @ManufacturedDate date,
        @ExpirationDate date,
        @ManufacturerId int,
        @MeasurementUnitId int,
        @QuantityAtWarehouse int
AS
begin
     INSERT INTO dbo.Product 
     (
         Name 
         ,Description 
         ,Price 
         ,ManufacturedDate
         ,ExpirationDate
         ,ManufacturerId
         ,MeasurementUnitId,
         QuantityAtWarehouse
     )
     VALUES
          (@Name,
        @Description,
        @Price,
        @ManufacturedDate,
        @ExpirationDate,
        @ManufacturerId,
        @MeasurementUnitId,
		@QuantityAtWarehouse);
 end

