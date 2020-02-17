Create DATABASE ProductosDb
GO 
USE ProductosDb
GO
CREATE TABLE Productos
(
   ProductoId int primary key identity,
   Descripcion varchar(30),
   Existencia decimal,
   Costo decimal,
   Valorinventario decimal,


)

drop table Productos