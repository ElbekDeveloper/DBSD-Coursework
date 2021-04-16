CREATE TRIGGER dbo.trProduct_CheckExpiration
ON dbo.Product
FOR INSERT, UPDATE
AS
BEGIN
if exists(
    SELECT i.expirationDate
    FROM inserted i
    where i.expirationDate <= getdate())
	throw 50001, 'Expired product can not be added', 1;
END
