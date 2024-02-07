create database MiTienda
go
use MiTienda
go

--INSERTS---------------------------------------------------------------
INSERT INTO Categoria values
('Remeras'),
('Pantalon'),
('Accesorios')

INSERT INTO Marca values
('Adidas'),
('Levis'),
('Penguin'),
('UnderArmor')

INSERT INTO Articulo values
('Medias','1211-1111',500,0.5,750,500					,0.21,1,3),
('Remera manga cortas','1211-1222',15000,0.5,null,null	,0.21,1,1),
('Pantalon jean','1211-4566',22000,0.5,null,null		,0.21,2,2),
('Remera manga cortas','1211-1333',12000,0.5,null,null	,0.21,3,1),
('Remera deportiva','1211-3322',8000,0.5,null,null		,0.21,4,1)
GO
INSERT INTO Color values
('Rojo'),
('Azul'),
('Blanco'),
('Negro')

INSERT INTO TipoTalle values
('Americano'),
('Europeo'),
('Brasilero')

INSERT INTO Talle values
('42',2),
('43',2),
('11.5',1),
('M',3)

INSERT INTO CondicionTributaria values
('RI','Responsable Inscripto'),
('M','Monotributista'),
('E','Exento'),
('NR','No Responsable'),
('CF','Consumidor Final')

INSERT INTO Tienda values
('20401112227',1)

INSERT INTO Sucursal values
(1,'San Miguel de Tucuman',1),
(3,'Tafi Viejo',1),
(2,'Yerba Buena',1)

GO
INSERT INTO Stock values
(1,1,2),
(2,2,1),
(3,3,3)
GO

INSERT INTO Inventario values
(50,3,2),
(10,1,1),
(15,2,2),
(25,3,3)
GO
INSERT INTO TipoPago values
('Efectivo'),
('Tarjeta Credito'),
('Tarjeta Debito')

INSERT INTO TipoComprobante values
('Factura A'),
('Factura B'),
('Nota Debito'),
('Nota Credito')
GO
INSERT INTO Pago values
('20240101',15000.5,2),
('20240115',55000,1)





INSERT INTO Cliente values
(45000222,'20-45000222-5','Tomas','Wolf',2),
(40555111,'20-40555111-7','Florencio','Chavez',1)
GO
INSERT INTO Vendedor values
(1111,'Rodriguez',' Nicolas','nrodriguez','admin123',2),
(1112,'Vigiani','Nicolas','nvigiani','admin123',1),
(1113,'Sischi','Facundo','fsischi','admin123',1),
(1114,'Llebeili','Agustin','allebeili','admin123',3)

INSERT INTO PuntoDeVenta values
(1,2),
(2,2),
(1,1),
(2,1)



---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--CONSULTAS----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
select cantidad,ar.CodigoBarras,cat.Descripcion,mar.Nombre nombreMarca,t.Descripcion,c.Nombre color,sl.Nombre from inventario i
inner join Stock s on s.IdStock = i.idStock
inner join sucursal sl on sl.IdSucursal = i.idsucursal
inner join Articulo ar on ar.IdArticulo = s.IdArticulo
inner join talle t on t.IdTalle = s.IdTalle
inner join color c on c.IdColor = s.IdColor
inner join Categoria cat on cat.IdCategoria = ar.IdCategoria
inner join Marca mar on mar.IdMarca = ar.IdMarca


select * from Articulo
select * from Marca
select * from Categoria

select * from Talle
select * from TipoTalle
select * from Color
select * from Articulo
select * from Sucursal
select * from Stock


--DELETES
--ALTER TABLE articulo
--DROP CONSTRAINT NombreDeRestriccion;
--delete from Articulo 
--delete from Categoria
--delete from Cliente
--delete from Color
--delete from CondicionTributaria
--delete from Inventario
--delete from LineaDeVenta
--delete from Marca
--delete from Pago
--delete from PuntoDeVenta
--delete from Stock
--delete from Sucursal
--delete from Talle
--delete from Tienda
--delete from TipoComprobante
--delete from TipoPago
--delete from TipoTalle
--delete from Vendedor
--delete from Venta
---------------------------------------------------------------------------------------------------------------------------------------------------------------------