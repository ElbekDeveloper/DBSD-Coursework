CREATE PROCEDURE [dbo].[spInvoice_Delete]
	@InvoiceId int
AS
begin 
	delete from dbo.InvoiceProduct
	where InvoiceId=@InvoiceId;

	delete from dbo.Invoice
	where Id=@InvoiceId;
end
