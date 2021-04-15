CREATE PROCEDURE [dbo].[spInvoice_GetAll]
AS
begin 
	select 
	[i].[Id] as InvoiceId, [i].[CreatedDate], [i].[ConfirmationStatus], [i].[TotalCost], 
	[w].[Id] as WarehouseId , [w].[Address], 
	[ca].[Id] as CounterAgentId, [ca].[FirstName], [ca].[LastName], [ca].[Address], [ca].[Email], [ca].[IsCustomer], [ca].[PhoneNumber],
	[sm].[Id] as StaffMemberId, [sm].[FirstName], [sm].[LastName], [sm].[Address], [sm].[Email], [sm].[RegisterDate], [sm].[PhoneNumber],
	[p].[Id] as ProductId, [p].[Name], [p].[Description], [p].[Price], [p].[ManufacturedDate], [p].[ExpirationDate], [m].[Name] as Manufacturer, [mu].[Name] as MeasurementUnit, [p].[QuantityAtWarehouse], 
	[inprod].[SoldPrice], [inprod].[SoldQuantity]
	from dbo.Invoice i
	join dbo.CounterAgent ca 
	on i.AgentId = ca.Id
	join dbo.Warehouse w
	on i.WarehouseId=w.Id
	join dbo.StaffMember sm
	on i.CreatedStaffId=sm.Id
	join dbo.InvoiceProduct inprod
	on i.Id=inprod.InvoiceId
	join dbo.Product p
	on inprod.ProductId=p.Id
	join dbo.Manufacturer m
	on p.ManufacturerId=m.Id
	join dbo.MeasurementUnit mu
	on p.MeasurementUnitId=mu.Id;

end 