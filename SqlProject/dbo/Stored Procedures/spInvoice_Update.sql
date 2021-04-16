CREATE PROCEDURE [dbo].[spInvoice_Update]
	@Id INT ,
	@CreatedDate DATE ,
	@ConfirmationStatus BIT ,
	@TotalCost DECIMAL  ,
	@CreatedStaffId INT ,
	@AgentId INT ,
	@WarehouseId INT
AS

BEGIN
	UPDATE dbo.Invoice
    SET 
	CreatedDate=	@CreatedDate, 
	ConfirmationStatus=	@ConfirmationStatus,
	TotalCost=	@TotalCost,
	CreatedStaffId=	@CreatedStaffId,
	AgentId=	@AgentId,
	WarehouseId=	@WarehouseId 
    WHERE Invoice.Id= @Id; 

END

