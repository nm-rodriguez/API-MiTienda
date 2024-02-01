create database MiTienda
go
use MiTienda
go


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
('Medias','1211-1111',500,0.5,750,500,0.21,1,1),
('Remera manga cortas','1211-1222',15000,0.5,null,null,0.21,4,2),
('Remera manga cortas','1211-1333',12000,0.5,null,null,0.21,3,2),
('Pantalon jean','1211-4566',22000,0.5,null,null,0.21,3,3),
('Remera deportiva','1211-3322',8000,0.5,null,null,0.21,5,2)

select * from Articulo
select * from Marca
select * from Categoria


