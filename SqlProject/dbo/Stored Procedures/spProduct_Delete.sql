CREATE PROCEDURE [dbo].[spProduct_Delete]
	@ProductId int
AS
BEGIN  
	DELETE FROM dbo.Product 
	WHERE	 Product.Id = @ProductId;
END 