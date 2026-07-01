
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
 
 DELETE FROM MESA

 DELETE FROM Empleado

 DELETE FROM Pedido

 SELECT * FROM MESA