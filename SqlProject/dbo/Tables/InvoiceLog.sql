CREATE TABLE [dbo].[InvoiceLog] (
    [Id]                 INT          IDENTITY (1, 1) NOT NULL,
    [CreatedDate]        DATE         NULL,
    [ConfirmationStatus] BIT          NULL,
    [TotalCost]          DECIMAL (18) NULL,
    [CreatedStaffId]     INT          NULL,
    [AgentId]            INT          NULL,
    [WarehouseId]        INT          NULL
);

