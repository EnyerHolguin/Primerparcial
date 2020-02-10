Create DATABASE ProductosDb
GO 
USE ProductosDb
GO
CREATE TABLE Productos
(
   PrestamosId int primary key identity,
   Descripcion varchar(30),
   Existentia decimal,
   Costo decimal,
   Valorinventario decimal,


)