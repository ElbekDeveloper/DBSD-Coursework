CREATE PROCEDURE [dbo].[spInvoiceProduct_Update]
	@ProductId INT, 
	@InvoiceId INT, 
	@SoldPrice DECIMAL, 
	@SoldQuantity DECIMAL
AS
BEGIN
	UPDATE dbo.InvoiceProduct 
	SET 
		SoldPrice=@SoldPrice,
		SoldQuantity=@SoldQuantity
	WHERE ProductId=@ProductId 
		and InvoiceId=@InvoiceId
END