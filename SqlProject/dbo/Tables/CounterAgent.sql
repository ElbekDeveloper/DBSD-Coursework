CREATE TABLE [dbo].[CounterAgent] (
    [Id]          INT           NOT NULL IDENTITY,
    [FirstName]   VARCHAR (255) NOT NULL,
    [LastName]    VARCHAR (255) NULL,
    [Address]     VARCHAR (255) NULL,
    [Email]       VARCHAR (255) NULL,
    [IsCustomer]  BIT           NOT NULL,
    [PhoneNumber] VARCHAR (55)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

