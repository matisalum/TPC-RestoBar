
CREATE DATABASE RestoDB;
use RestoDB 

CREATE TABLE Igmagen (
    id      INT IDENTITY(1,1) NOT NULL,
    Url     VARCHAR(255),
    PRIMARY KEY (id)
);
 

CREATE TABLE Empleado (
    id          INT IDENTITY(1,1) NOT NULL,
    Nombre      VARCHAR(255),
    Usuario     VARCHAR(255),
    Apellido    VARCHAR(255),
    Contrasena  VARCHAR(255),
    Activo      BIT,
    Gerente     BIT,
    IdImagen    INT,
    PRIMARY KEY (id),
    CONSTRAINT fk_Igmagen_id_Empleado
        FOREIGN KEY (IdImagen) REFERENCES Igmagen(id)
);
 

CREATE TABLE Mesa (
    id          INT IDENTITY(1,1) NOT NULL,
    Numero      SMALLINT,
    Capacidad   SMALLINT,
    Estado      BIT,
    idEmpleado  INT,
    PRIMARY KEY (id),
    CONSTRAINT fk_Mesa_idEmpleado
        FOREIGN KEY (idEmpleado) REFERENCES Empleado(id)
);

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
 

CREATE TABLE Categorai (
    id           INT IDENTITY(1,1) NOT NULL,
    descripcion  NVARCHAR(255),
    PRIMARY KEY (id)
);
 

CREATE TABLE Producto (
    id          INT IDENTITY(1,1) NOT NULL,
    nombre      VARCHAR(255),
    Precio      DECIMAL,
    stock       SMALLINT,
    activo      BIT,
    idCategoria INT,
    idImagen    INT,
    PRIMARY KEY (id),
    CONSTRAINT fk_Categorai_id_Producto
        FOREIGN KEY (idCategoria) REFERENCES Categorai(id),
    CONSTRAINT fk_Producto_idImagen_Igmagen
        FOREIGN KEY (idImagen) REFERENCES Igmagen(id)
);
 

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