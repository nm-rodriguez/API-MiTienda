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
('Medias','1211-1111',500,0.5,750,500					,0.21,11,9),
('Remera manga cortas','1211-1222',15000,0.5,null,null	,0.21,11,7),
('Remera manga cortas','1211-1333',12000,0.5,null,null	,0.21,13,7),
('Pantalon jean','1211-4566',22000,0.5,null,null		,0.21,12,8),
('Remera deportiva','1211-3322',8000,0.5,null,null		,0.21,14,7)

select * from Articulo
select * from Marca
select * from Categoria

--delete from Articulo where IdArticulo > 27
--delete from Marca 
--delete from Categoria
---------------------------------------------------------------------------------------------------------------------------------------------------------------------