CREATE TABLE[dbo].[InvoiceProduct] (
[ProductId] INT NOT NULL,
[InvoiceId] INT NOT NULL,
[SoldPrice] DECIMAL (18) NULL,
[SoldQuantity] DECIMAL (18) NULL,
    CONSTRAINT[PK_ProductInvoiceKey] PRIMARY KEY CLUSTERED ([ProductId] ASC,[InvoiceId] ASC),
    CONSTRAINT[FK_InvoiceId] FOREIGN KEY ([InvoiceId]) REFERENCES[dbo].[Invoice] ([Id]),
    CONSTRAINT[FK_ProductId] FOREIGN KEY ([ProductId]) REFERENCES[dbo].[Product] ([Id])
);
