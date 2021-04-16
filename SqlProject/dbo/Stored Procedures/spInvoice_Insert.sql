CREATE PROCEDURE [dbo].[spInvoice_Insert]
	@Id INT output ,
	@CreatedDate DATE ,
	@ConfirmationStatus BIT ,
	@TotalCost DECIMAL  ,
	@CreatedStaffId INT ,
	@AgentId INT ,
	@WarehouseId INT
AS
BEGIN 
insert into dbo.Invoice 
          values
		  (
			@CreatedDate,
			@ConfirmationStatus,
			@TotalCost,
			@CreatedStaffId,
			@AgentId,
			@WarehouseId
		  );
          select @Id = @@IDENTITY;
END