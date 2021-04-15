CREATE PROCEDURE [dbo].[spCounterAgent_GetAll]
AS
BEGIN 
	SELECT [Id] as CounterAgentId, [FirstName], [LastName], [Address], [Email], [IsCustomer], [PhoneNumber] from dbo.CounterAgent;
END
