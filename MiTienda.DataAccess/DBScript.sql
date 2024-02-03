create database MiTienda
go
use MiTienda
go

--ARTICULO y tablas relacionadas directamente---------------------------------
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


INSERT INTO Tienda values
('20401112227',NULL)

INSERT INTO Sucursal values
(1,'San Miguel de Tucuman',1),
(3,'Tafi Viejo',1),
(2,'Yerba Buena',1)

INSERT INTO Stock values
--talle - color - articulo - sucursal
(10,1,1,1,1),
(15,2,2,2,1),
(9,3,3,3,1),
(11,4,4,4,1)



select * from Articulo
select * from Marca
select * from Categoria


select * from Talle
select * from TipoTalle
select * from Color
select * from Articulo
select * from Stock

--delete from Articulo where IdArticulo > 27
--delete from Marca 
--delete from Categoria
---------------------------------------------------------------------------------------------------------------------------------------------------------------------