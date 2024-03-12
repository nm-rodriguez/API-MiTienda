--create database MiTienda
--go
use MiTienda
go


--INSERTS---------------------------------------------------------------
INSERT INTO Categoria values
('Remeras'),
('Pantalon'),
('Accesorios'),
('Camisas'),
('Ropa Interior')

INSERT INTO Marca values
('Adidas'),
('Levis'),
('Penguin'),
('Nike'),
('UnderArmor')

INSERT INTO TipoTalle values
('Americano'),
('Europeo'),
('Brasilero')

INSERT INTO Talle values
('42',2),
('43',2),
('11.5',1),
('M',3)

INSERT INTO Color values
('Rojo'),
('Azul'),
('Blanco'),
('Negro')

INSERT INTO CondicionTributaria values
('RI','Responsable Inscripto'),
('M','Monotributista'),
('E','Exento'),
('NR','No Responsable'),
('CF','Consumidor Final')

INSERT INTO TipoPago values
('Efectivo'),
('Tarjeta Credito'),
('Tarjeta Debito')

INSERT INTO TipoComprobante values
('Factura A'),
('Factura B'),
('Nota Debito'),
('Nota Credito')


INSERT INTO Articulo values
('Medias'			  ,'1211-1111',500  ,0.5,null ,null,0.21,1,1,3),
('Remera manga cortas','1211-1222',15000,0.5,null,null	,0.21,1,1,1),
('Pantalon jean','1211-4566',22000,0.5,null,null		,0.21,1,2,2),
('Remera manga corta','1211-1333',12000,0.5,null,null	,0.21,1,3,1),
('Remera deportiva','1211-3322',8000,0.5,null,null		,0.21,1,4,1)


INSERT INTO Tienda values
('20401112227',1)

INSERT INTO Sucursal values
(1,'San Miguel de Tucuman',1),
(3,'Tafi Viejo',1),
(2,'Yerba Buena',1)

INSERT INTO Stock values
(2,1,2),
(3,2,1),
(4,3,3)
GO

INSERT INTO Inventario values
(50,1,2),
(10,2,1),
(15,3,2),
(25,1,2)
GO

INSERT INTO Cliente VALUES
(0,'20-00000000-0','DefaultUser','DefaultUser',5)

INSERT INTO Cliente values
(45000222,'20-45000222-5','Tomas','Wolf',2),
(40555111,'20-40555111-7','Florencio','Chavez',1)

INSERT INTO PuntoDeVenta values
(1,2),
(2,2),
(1,1),
(2,1)

INSERT INTO Vendedor values
(1111,'Ramirez',' Nicolas','nramirez','admin123',1,2),
(1112,'Villa','Nicolas','nvilla','admin123',1,1),
(1113,'Chisi','Facundo','fchisi','admin123',1,1),
(1114,'Yeyi','Agustin','ayeyi','admin123',1,3)


INSERT INTO DetallePagoTarjeta VALUES ('Debito','5165165')
INSERT INTO Pago VALUES (15000.5,'ARS',1,'20240305',1)
INSERT INTO Venta(SucursalId,FechaVenta,VendedorId,PagoId,ClienteId,TipoComprobanteId,PuntoDeVentaId,Importe)
VALUES(1,'20240305',1,1,1,1,1,15000.5)
GO



	select * from Inventario i
	inner join Stock s on s.Id = i.StockId
	inner join Color col on col.Id = s.ColorId
	inner join Talle t on t.Id = s.TalleId
	inner join Sucursal sc on sc.Id = i.SucursalId 
	inner join Articulo ar on ar.Id = s.ArticuloId
	inner join Categoria ct on ct.Id = ar.CategoriaId
	inner join Marca mar on mar.Id = ar.MarcaId


	--Consulta a Inventario
select i.Id, ct.Descripcion as categoria,mar.Nombre as Marca,ar.Descripcion,ar.CodigoBarras,t.TalleArticulo,col.Nombre as Color, i.Cantidad,sc.Nombre as Sucursal 
from Inventario i
inner join Stock s on s.Id = i.StockId 
inner join Color col on col.Id = s.ColorId
inner join Talle t on t.Id = s.TalleId
inner join Sucursal sc on sc.Id = i.SucursalId 
inner join Articulo ar on ar.Id = s.ArticuloId
inner join Categoria ct on ct.Id = ar.CategoriaId
inner join Marca mar on mar.Id = ar.MarcaId

select * from Pago
select * from DetallePagoTarjeta

select * from venta v
inner join Sucursal s on s.Id = v.SucursalId
inner join Vendedor vdor on vdor.Id = v.VendedorId
inner join Pago p on p.Id = v.PagoId
inner join Cliente c on c.Id = v.ClienteId
inner join TipoComprobante tc on tc.Id = v.TipoComprobanteId
inner join PuntoDeVenta pv on pv.Id = v.PuntoDeVentaId









---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--CONSULTAS----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--select * from Articulo
--select * from Marca
--select * from Categoria

--select * from Talle
--select * from TipoTalle
--select * from Color
--select * from Articulo
--select * from Sucursal

--select a.*,c.*,t.* from Stock s
--inner join Talle t on t.id = s.talleid
--inner join Color c on c.id = s.colorid
--inner join Articulo a on a.id = s.articuloid

--select cantidad,ar.CodigoBarras,cat.Descripcion,mar.Nombre nombreMarca,t.Descripcion,c.Nombre color,sl.Nombre from inventario i
--inner join Stock s on s.IdStock = i.idStock
--inner join sucursal sl on sl.IdSucursal = i.idsucursal
--inner join Articulo ar on ar.IdArticulo = s.IdArticulo
--inner join talle t on t.IdTalle = s.IdTalle
--inner join color c on c.IdColor = s.IdColor
--inner join Categoria cat on cat.IdCategoria = ar.IdCategoria
--inner join Marca mar on mar.IdMarca = ar.IdMarca

--SELECT PICANTE ACTUALIZADO 
--  select cantidad,ar.CodigoBarras,cat.Descripcion,mar.Nombre nombreMarca,t.TalleArticulo,c.Nombre color,sl.Nombre Sucursal from inventario i
--inner join Stock s on s.Id = i.id
--inner join sucursal sl on sl.Id = i.id
--inner join Articulo ar on ar.Id = s.Id
--inner join talle t on t.Id = s.Id
--inner join color c on c.Id = s.Id
--inner join Categoria cat on cat.Id = ar.Id
--inner join Marca mar on mar.Id = ar.Id

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