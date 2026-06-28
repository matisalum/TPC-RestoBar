USE RestoDB

select * from Empleado

create procedure storeAltaEmpleado
	@Nombre VARCHAR(255),
	@User VARCHAR(255),
	@Apellido VARCHAR(255),
	@Pass VARCHAR(255),
	@Estado BIT,
	@Rol VARCHAR(50)
	as
Insert into Empleado (Nombre, Usuario, Apellido, Contrasena, Estado, Rol) values ( @Nombre, @User, @Apellido, @Pass, @Estado , @Rol) 


create procedure storeModificarEmpleado
	@Nombre VARCHAR(255),
	@User VARCHAR(255),
	@Apellido VARCHAR(255),
	@Pass VARCHAR(255),
	@Estado BIT,
	@Rol VARCHAR(50),
	@id INT
	as
Update Empleado  set  Nombre=@Nombre, Usuario = @User, Apellido= @Apellido, Contrasena= @Pass, Estado= @Estado , Rol= @Rol 
WHERE id = @id; 


create procedure storeListarEmpleado
as
begin
Select * 
From Empleado
end

-- MESA
CREATE OR ALTER PROCEDURE storeModificarMesa
    @id INT,
    @Numero INT,
    @Capacidad INT,
    @IdEmpleado INT,
    @Estado bit
AS
BEGIN
    UPDATE Mesa  
    SET Numero = @Numero, 
        Capacidad = @Capacidad, 
        IdEmpleado = @IdEmpleado,
        Estado = @Estado
    WHERE id = @id;
END;
GO

-- CATEGORIA    
CREATE OR ALTER PROCEDURE storeModificarCategoria
    @id INT,
    @Nombre NVARCHAR(255),
    @Estado BIT
AS
BEGIN
    UPDATE Categoria  
    SET nombre = @Nombre, 
        estado = @Estado
    WHERE id = @id;
END;
GO

INSERT INTO Imagen (Url)
VALUES ('https://via.placeholder.com/150');


-- PEDIDO 
Use RestoDB
GO
CREATE OR ALTER PROCEDURE storeListarPedidos
As 
Begin 
Select P.id AS IdPedido, P.FechaPedido, P.Estado, M.Numero as NumeroMesa, E.Nombre as NombreEmpleado , E.Apellido as ApellidoEmpleado from Pedido P
join Mesa M on P.idMesa = M.id
join Empleado E on P.idEmpleado = E.id
END

GO

INSERT INTO Mesa (Numero, Capacidad, Estado, idEmpleado)
VALUES
(1, 4, 1, 1),
(2, 6, 1, 2),
(3, 2, 1, 3);

INSERT INTO Pedido (FechaPedido, Estado, idMesa, idEmpleado)
VALUES
(GETDATE(), 0, 1, 1),  -- Pendiente
(GETDATE(), 1, 2, 2),  -- En preparación
(GETDATE(), 2, 3, 3);  -- Listo

Select * from Pedido
Select * from Mesa
