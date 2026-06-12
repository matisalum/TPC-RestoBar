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


alter procedure storeListarEmpleado
as
begin
Select * 
From Empleado
end

-- MESA
CREATE PROCEDURE storeModificarMesa
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
        Estado = @Estado
    WHERE id = @id;
END;
GO

