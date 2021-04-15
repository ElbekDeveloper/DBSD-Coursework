
delete from dbo.Manufacturer;

--	INSERT SAMPLE VALUES
--  insert into manufacturer table
insert into dbo.Manufacturer (Name, Address) values ('Carilion Materials Management', '9 Aberg Pass');
insert into dbo.Manufacturer (Name, Address) values ('Fikes Northwest, Corp.', '874 Cody Circle');
insert into dbo.Manufacturer (Name, Address) values ('IASO Inc', '40480 Randy Circle');
insert into dbo.Manufacturer (Name, Address) values ('Uriel Pharmacy Inc.', '32555 Fulton Alley');
insert into dbo.Manufacturer (Name, Address) values ('A-S Medication Solutions LLC', '5 Corry Center');
insert into dbo.Manufacturer (Name, Address) values ('Dispensing Solutions, Inc.', '5 Luster Pass');
insert into dbo.Manufacturer (Name, Address) values ('Cresson', '9 Springview Plaza');
insert into dbo.Manufacturer (Name, Address) values ('DIRECT RX', '86302 Alpine Way');
insert into dbo.Manufacturer (Name, Address) values ('Wal-Mart Stores,Inc', '6236 Bunting Park');
insert into dbo.Manufacturer (Name, Address) values ( 'Topco Associates LLC', '976 Heath Crossing');


delete from dbo.MeasurementUnit;
-- insert into measurement unit table
insert into dbo.MeasurementUnit  (Name) values ( 'package');
insert into dbo.MeasurementUnit  (Name) values ( 'capsule');
insert into dbo.MeasurementUnit  (Name) values ( 'ampule');
insert into dbo.MeasurementUnit  (Name) values ( 'ml');
