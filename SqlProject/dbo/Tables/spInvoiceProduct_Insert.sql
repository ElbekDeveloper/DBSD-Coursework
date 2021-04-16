CREATE PROCEDURE [dbo].[spInvoiceProduct_Insert]
	@ProductId INT, 
	@InvoiceId INT, 
	@SoldPrice DECIMAL, 
	@SoldQuantity DECIMAL
AS
BEGIN 
	insert into dbo.InvoiceProduct 
          values (
			@ProductId,
			@InvoiceId,
			@SoldPrice,
			@SoldQuantity 
		  );
END