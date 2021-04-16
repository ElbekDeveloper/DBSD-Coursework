CREATE TRIGGER [dbo].[trProduct_ModificationDisallow] ON dbo.Product
FOR INSERT, UPDATE, DELETE
AS
BEGIN
 if datename(weekday, getdate()) in ('Sunday', 'Saturday')
 begin 
    throw 50001, 'Modifications on Product are not allowed on weekends!', 1;		
 end

 if cast(getdate() as time) not between '10:00' and '22:00'
 begin 
   throw 50002, 'Not work hours!', 1
 end
END