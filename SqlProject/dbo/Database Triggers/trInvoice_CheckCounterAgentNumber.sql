CREATE TRIGGER [dbo].[trInvoice_CheckCounterAgentNumber] ON dbo.Invoice
FOR INSERT, UPDATE
AS
declare @icnt int = 0
BEGIN
  select @icnt = count(*)
  from invoice ie join inserted i
       on i.id = ie.AgentId
  
  if @icnt > 1
    begin
 	throw 50001, 'One CounterAgent can have maximum one invoice', 1;
    end
    end