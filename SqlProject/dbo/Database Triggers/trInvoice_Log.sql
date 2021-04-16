CREATE TRIGGER [dbo].[trInvoice_Log]
on [dbo].[Invoice]
for insert, update, delete
as
declare @op varchar(100)
begin
  if exists(select 1 from inserted)
	 and not exists(select 1 from deleted)
	set @op = 'Insert'
  else if exists(select 1 from inserted)
	   and exists(select 1 from deleted)
	set @op = 'Update'
  else 
	set @op = 'Delete'

INSERT INTO Invoice_log
           ([Id]
           ,[CreatedDate]
           ,[ConfirmationStatus]
           ,[TotalCost]
           ,[CreatedStaffId]
           ,[AgentId]
           ,[WarehouseId])
     select
           [Id]
           ,[CreatedDate]
           ,[ConfirmationStatus]
           ,[TotalCost]
           ,[CreatedStaffId]
           ,[AgentId]
           ,[WarehouseId]
	 from(
		   (select * from inserted)
		   union all
		   (select * from deleted)
		 ) as t
end
