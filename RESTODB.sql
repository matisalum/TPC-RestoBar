
USE MASTER
GO
-- CRACION DE BASE DE DATOS
CREATE DATABASE RestoDB;
GO

USE RestoDB 
GO
-- CREACION DE TABLAS
CREATE TABLE Imagen (
    id      INT IDENTITY(1,1) NOT NULL,
    Url     VARCHAR(255),
    PRIMARY KEY (id)
);
GO 

CREATE TABLE Empleado (
    id          INT IDENTITY(1,1) NOT NULL,
    Nombre      VARCHAR(255),
    Usuario     VARCHAR(255),
    Apellido    VARCHAR(255),
    Contrasena  VARCHAR(255),
    Estado      BIT,
    Rol VARCHAR(50),
    IdImagen    INT,
    PRIMARY KEY (id),
    CONSTRAINT fk_Igmagen_id_Empleado
        FOREIGN KEY (IdImagen) REFERENCES Imagen(id)
);
GO

CREATE TABLE Mesa (
    id          INT IDENTITY(1,1) NOT NULL,
    Numero      SMALLINT ,
    Capacidad   SMALLINT ,
    Estado      BIT DEFAULT 0,
    idEmpleado  INT,
    PRIMARY KEY (id),
    CONSTRAINT fk_Mesa_idEmpleado
        FOREIGN KEY (idEmpleado) REFERENCES Empleado(id)
);
GO

CREATE TABLE Pedido (
    id           INT IDENTITY(1,1) NOT NULL,
    FechaPedido  DATE,
    Estado       TINYINT,
    idMesa       INT,
    idEmpleado   INT,
    PRIMARY KEY (id),
    CONSTRAINT fk_Pedido_idMesa
        FOREIGN KEY (idMesa) REFERENCES Mesa(id),
    CONSTRAINT fk_Pedido_idEmpleado
        FOREIGN KEY (idEmpleado) REFERENCES Empleado(id)
);
GO

CREATE TABLE Categoria (
    id           INT IDENTITY(1,1) NOT NULL,
    nombre NVARCHAR(100) NOT NULL,
    PRIMARY KEY (id)
);
GO

CREATE TABLE Producto (
    id          INT IDENTITY(1,1) NOT NULL,
    nombre      VARCHAR(255),
    Precio      DECIMAL,
    stock       SMALLINT,
    activo      BIT,
    idCategoria INT,
    idImagen    INT,
    PRIMARY KEY (id),
    CONSTRAINT fk_Categoria_id_Producto
        FOREIGN KEY (idCategoria) REFERENCES Categoria(id),
    CONSTRAINT fk_Producto_idImagen_Igmagen
        FOREIGN KEY (idImagen) REFERENCES Imagen(id)
);
GO

CREATE TABLE DetallePedido (
    id          INT IDENTITY(1,1) NOT NULL,
    idPedido    INT,
    idProducto  INT,
    Cantidad    SMALLINT,
    idEmpleado  INT,
    PRIMARY KEY (id),
    CONSTRAINT fk_DetallePedido_idPedido
        FOREIGN KEY (idPedido) REFERENCES Pedido(id),
    CONSTRAINT fk_DetallePedido_idProducto_Producto
        FOREIGN KEY (idProducto) REFERENCES Producto(id),
    CONSTRAINT fk_DetallePedido_idEmpleado
        FOREIGN KEY (idEmpleado) REFERENCES Empleado(id)
);
GO
-- INSERT DE EMPLEADOS
USE RestoDB
GO
INSERT INTO Empleado (Nombre, Usuario, Apellido, Contrasena, Estado , Rol, IdImagen)
VALUES
    ('Carlos',   'cgomez',    'Gomez',      'pass1234',  1, 'Gerente', NULL),  -- Gerente
    ('Maria',    'mlopez',    'Lopez',      'pass5678',  1, 'Mesero', NULL),
    ('Juan',     'jperez',    'Perez',      'pass9012',  1, 'Mesero', NULL),
    ('Laura',    'lmartinez', 'Martinez',   'pass3456',  1, 'Mesero', NULL),
    ('Diego',    'drodriguez','Rodriguez',  'pass7890',  0, 'Mesero', NULL);
GO

Select * from Empleado
GO

insert into Empleado (Nombre, Usuario, Apellido, Contrasena, estado, Rol, IdImagen) 
values 
('Ana', 'alopez', 'Lopez', 'pass1234', 1, 'Mesero', NULL) 
GO
USE RestoDB
GO
    

-- AJUSTE DE TABLA MESA
ALTER TABLE MESA
ALTER COLUMN NUMERO int;
ALTER TABLE MESA
ALTER COLUMN CAPACIDAD int;

-- AJUSTE DE TABLA CATEGORIA
EXEC sp_rename 'categorai', 'Categoria';
GO  
ALTER TABLE Categoria
ADD nombre NVARCHAR(100) NOT NULL;
GO

ALTER TABLE Categoria
ADD estado BIT DEFAULT 1 NOT NULL; 

ALTER TABLE Categoria
DROP COLUMN descripcion; 
GO


INSERT INTO Categoria (nombre, descripcion) 
SELECT 'BEBIDA', 'PARA TOMAS' UNION
SELECT 'POSTRE', 'PARA COMER'  
GO
--AJUSTE DE TABLA IMAGEN
select * from Imagen

EXEC sp_rename 'Igmagen', 'Imagen';
 
DELETE FROM Mesa;
DELETE FROM Producto;
DELETE FROM Imagen;



DELETE FROM DetallePedido;
DBCC CHECKIDENT ('DetallePedido', RESEED, 0);

DELETE FROM Pedido;
DBCC CHECKIDENT ('Pedido', RESEED, 0);

DELETE FROM Producto;
DBCC CHECKIDENT ('Producto', RESEED, 0);

DELETE FROM Mesa;
DBCC CHECKIDENT ('Mesa', RESEED, 0);

DELETE FROM Imagen;
DBCC CHECKIDENT ('Imagen', RESEED, 0);

 SELECT * FROM Mesa
 SELECT * FROM Producto
 select * from Imagen

 INSERT INTO Imagen (Url) VALUES
('https://images.unsplash.com/photo-1568901346375-23c9450c58cd'), -- Hamburguesa clásica
('https://images.unsplash.com/photo-1550547660-d9450f859349'), -- Hamburguesa doble
('https://images.unsplash.com/photo-1513104890138-7c749659a591'), -- Pizza muzzarella
('https://images.unsplash.com/photo-1565299624946-b28f40a0ae38'), -- Pizza especial
('https://images.unsplash.com/photo-1544025162-d76694265947'), -- Milanesa con papas
('https://images.unsplash.com/photo-1626200419199-391ae4be7a41'), -- Empanadas
('https://images.unsplash.com/photo-1559847844-5315695dadae'), -- Lomo completo
('https://images.unsplash.com/photo-1564419320461-6870880221ad'), -- Agua mineral
('https://images.unsplash.com/photo-1622484212850-eb596d769edc'), -- Sprite
('https://images.unsplash.com/photo-1514362545857-3bc16c4c7d1b'), -- Fernet
('https://images.unsplash.com/photo-1436076863939-06870fe779c2'), -- Cerveza artesanal
('https://images.unsplash.com/photo-1570197788417-0e82375c9371'), -- Helado
('https://images.unsplash.com/photo-1551024506-0bccd828d307'), -- Flan
('https://images.unsplash.com/photo-1533134242443-d4fd215305ad'), -- Cheesecake
('https://images.unsplash.com/photo-1546793665-c74683f339c1'); -- Ensalada César

INSERT INTO Producto
(nombre,precio,stock,activo,idCategoria,idImagen)
VALUES
('Hamburguesa Clasica',12000,50,1,1,1),
('Hamburguesa Doble',15500,40,1,1,2),
('Pizza Muzarella',18000,30,1,3,3),
('Pizza Especial',22000,25,1,3,4),
('Milanesa con Papas',17000,35,1,3,5),
('Empanadas x6',9000,40,1,1,6),
('Lomo Completo',19000,20,1,3,7),
('Agua Mineral',2500,80,1,1,8),
('Sprite 2L',4200,40,1,1,9),
('Fernet 750ml',16000,25,1,2,10),
('Cerveza Artesanal',7000,50,1,2,11),
('Helado 1kg',11000,15,1,4,12),
('Flan Casero',5500,25,1,4,13),
('Cheesecake',6500,20,1,4,14),
('Ensalada Cesar',9500,30,1,3,15);


