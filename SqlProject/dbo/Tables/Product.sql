CREATE TABLE [dbo].[Product] (
    [Id]                  INT           NOT NULL IDENTITY,
    [Name]                VARCHAR (255) NOT NULL,
    [Description]         VARCHAR (MAX) NULL,
    [Price]               DECIMAL (18)  NOT NULL,
    [ManufacturedDate]    DATE          NULL,
    [ExpirationDate]      DATE          NULL,
    [ManufacturerId]      INT           NULL,
    [MeasurementUnitId]   INT           NULL,
    [QuantityAtWarehouse] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ManufacturerdId_Manufacturer] FOREIGN KEY ([ManufacturerId]) REFERENCES [dbo].[Manufacturer] ([Id]),
    CONSTRAINT [FK_MeasurementUnitId_MeasurementUnit] FOREIGN KEY ([MeasurementUnitId]) REFERENCES [dbo].[MeasurementUnit] ([Id])
);

