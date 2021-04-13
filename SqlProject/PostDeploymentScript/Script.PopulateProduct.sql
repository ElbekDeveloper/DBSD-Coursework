--	INSERT SAMPLE VALUES
delete from Manufacturer;
--  insert into manufacturer table
insert into Manufacturer (Id, Name, Address) values (1, 'Carilion Materials Management', '9 Aberg Pass');
insert into Manufacturer (Id, Name, Address) values (2, 'Fikes Northwest, Corp.', '874 Cody Circle');
insert into Manufacturer (Id, Name, Address) values (3, 'IASO Inc', '40480 Randy Circle');
insert into Manufacturer (Id, Name, Address) values (4, 'Uriel Pharmacy Inc.', '32555 Fulton Alley');
insert into Manufacturer (Id, Name, Address) values (5, 'A-S Medication Solutions LLC', '5 Corry Center');
insert into Manufacturer (Id, Name, Address) values (6, 'Dispensing Solutions, Inc.', '5 Luster Pass');
insert into Manufacturer (Id, Name, Address) values (7, 'Cresson', '9 Springview Plaza');
insert into Manufacturer (Id, Name, Address) values (8, 'DIRECT RX', '86302 Alpine Way');
insert into Manufacturer (Id, Name, Address) values (9, 'Wal-Mart Stores,Inc', '6236 Bunting Park');
insert into Manufacturer (Id, Name, Address) values (10, 'Topco Associates LLC', '976 Heath Crossing');

go
delete from MeasurementUnit;
-- insert into measurement unit table
insert into MeasurementUnit (Id, Name) values (1, 'package');
insert into MeasurementUnit (Id, Name) values (2, 'capsule');
insert into MeasurementUnit (Id, Name) values (3, 'ampule');
insert into MeasurementUnit (Id, Name) values (4, 'ml');



go
delete from Product;
--insert into product table 
insert into Product (Id, Name, Description, Price, ManufacturedDate, ExpirationDate, ManufacturerId, MeasurementUnitId, QuantityAtWarehouse) values (1, 'Buspirone HCl', 'Aenean lectus. Pellentesque eget nunc. Donec quis orci eget orci vehicula condimentum.', 11.97, '3/12/2020', '3/25/2023', 6, 4, 1947);
insert into Product (Id, Name, Description, Price, ManufacturedDate, ExpirationDate, ManufacturerId, MeasurementUnitId, QuantityAtWarehouse) values (2, 'Chlorpromazine Hydrochloride', 'Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla. Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus.', 41.69, '12/15/2020', '1/28/2025', 7, 1, 1622);
insert into Product (Id, Name, Description, Price, ManufacturedDate, ExpirationDate, ManufacturerId, MeasurementUnitId, QuantityAtWarehouse) values (3, 'Instant Hand Sanitizer', 'Fusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem.', 24.27, '5/28/2020', '11/12/2022', 2, 3, 1773);
insert into Product (Id, Name, Description, Price, ManufacturedDate, ExpirationDate, ManufacturerId, MeasurementUnitId, QuantityAtWarehouse) values (4, 'LBEL', 'Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh.', 15.18, '5/19/2020', '4/30/2025', 8, 1, 1545);
insert into Product (Id, Name, Description, Price, ManufacturedDate, ExpirationDate, ManufacturerId, MeasurementUnitId, QuantityAtWarehouse) values (5, 'Terragen HG Treatment', 'Etiam vel augue. Vestibulum rutrum rutrum neque. Aenean auctor gravida sem.', 99.65, '12/6/2019', '10/26/2022', 8, 3, 985);
insert into Product (Id, Name, Description, Price, ManufacturedDate, ExpirationDate, ManufacturerId, MeasurementUnitId, QuantityAtWarehouse) values (6, 'Assured Instant Hand Sanitizer', 'Curabitur in libero ut massa volutpat convallis. Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo. Maecenas pulvinar lobortis est.', 81.64, '6/5/2019', '4/29/2025', 1, 2, 1639);
insert into Product (Id, Name, Description, Price, ManufacturedDate, ExpirationDate, ManufacturerId, MeasurementUnitId, QuantityAtWarehouse) values (7, 'Chloroquine Phosphate', 'Phasellus in felis. Donec semper sapien a libero. Nam dui.', 75.24, '3/15/2020', '7/7/2023', 5, 1, 294);
insert into Product (Id, Name, Description, Price, ManufacturedDate, ExpirationDate, ManufacturerId, MeasurementUnitId, QuantityAtWarehouse) values (8, 'NARS ALL DAY LUMINOUS FOUNDATION', 'Cras mi pede, malesuada in, imperdiet et, commodo vulputate, justo. In blandit ultrices enim. Lorem ipsum dolor sit amet, consectetuer adipiscing elit.', 89.41, '8/24/2019', '11/22/2023', 10, 4, 103);
insert into Product (Id, Name, Description, Price, ManufacturedDate, ExpirationDate, ManufacturerId, MeasurementUnitId, QuantityAtWarehouse) values (9, 'Nifedipine', 'Morbi porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem.', 8.45, '1/7/2020', '10/20/2023', 5, 1, 1383);
go
