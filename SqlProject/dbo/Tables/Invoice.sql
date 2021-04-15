CREATE TABLE[dbo].[Invoice] (
[Id] INT NOT NULL IDENTITY,
[CreatedDate] DATE NULL,
[ConfirmationStatus] BIT NULL,
[TotalCost] DECIMAL (18) NULL,
[CreatedStaffId] INT NULL,
[AgentId] INT NULL,
[WarehouseId] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT[FK_AgentId] FOREIGN KEY ([AgentId]) REFERENCES[dbo].[CounterAgent] ([Id]),
    CONSTRAINT[FK_CreatedStaffMemberId] FOREIGN KEY ([CreatedStaffId]) REFERENCES[dbo].[StaffMember] ([Id]),
    CONSTRAINT[FK_WarehouseId] FOREIGN KEY ([WarehouseId]) REFERENCES[dbo].[Warehouse] ([Id])
);
