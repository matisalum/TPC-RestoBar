using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = @"SELECT id, nombre, Precio, stock FROM Producto WHERE activo = 1";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto producto = new Producto();

                    producto.idProducto = Convert.ToInt32(datos.Lector["id"]);
                    producto.nombre = datos.Lector["nombre"].ToString();
                    producto.precio = Convert.ToDecimal(datos.Lector["Precio"]);
                    producto.stock = Convert.ToInt32(datos.Lector["stock"]);

                    lista.Add(producto);
                }

                return lista;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public List<Producto> listarCarta()
        {
            List<Producto> lista = new List<Producto>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta(
                    "SELECT p.id, p.nombre, p.Precio, p.stock, p.activo, i.Url " +
                    "FROM Producto p " +
                    "INNER JOIN Imagen i ON p.idImagen = i.id " +
                    "WHERE p.activo = 1");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto producto = new Producto();

                    producto.idProducto = (int)datos.Lector["id"];
                    producto.nombre = datos.Lector["nombre"].ToString();
                    producto.precio = (decimal)datos.Lector["Precio"];
                    producto.stock = (short)datos.Lector["stock"];
                    producto.activo = (bool)datos.Lector["activo"];

                    producto.imagen = new Imagen();
                    producto.imagen.Url = datos.Lector["Url"].ToString();

                    lista.Add(producto);
                }

                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Producto nuevo)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta(
                    "INSERT INTO Imagen (Url) OUTPUT INSERTED.id VALUES (@url)");

                datos.setearParametro("@url", nuevo.imagen.Url);

                int idImagen = datos.ejecutarAccionScalar();

                datos.cerrarConexion();

                datos = new AccesoADatos();

                datos.setearConsulta(
                    "INSERT INTO Producto (nombre, Precio, stock, activo, idCategoria, idImagen) " +
                    "VALUES (@nombre, @precio, @stock, @activo, @idCategoria, @idImagen)");

                datos.setearParametro("@nombre", nuevo.nombre);
                datos.setearParametro("@precio", nuevo.precio);
                datos.setearParametro("@stock", nuevo.stock);
                datos.setearParametro("@activo", nuevo.activo);
                datos.setearParametro("@idCategoria", nuevo.idCategoria);
                datos.setearParametro("@idImagen", idImagen);

                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Producto buscarPorId(int id)
        {
            AccesoADatos datos= new AccesoADatos();
            Producto producto= new Producto();

            try
            {
                datos.setearConsulta(@"
                                        SELECT p.id,
                                               p.nombre,
                                               p.Precio,
                                               p.stock,
                                               p.activo,
                                               i.Url,
                                               p.idCategoria
                                        FROM Producto p
                                        LEFT JOIN Imagen i ON p.idImagen = i.id
                                        WHERE p.id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    producto.idProducto = Convert.ToInt32(datos.Lector["id"]);
                    producto.nombre = datos.Lector["nombre"].ToString();
                    producto.precio = Convert.ToDecimal(datos.Lector["Precio"]);
                    producto.stock = Convert.ToInt32(datos.Lector["stock"]);
                    producto.activo = Convert.ToBoolean(datos.Lector["activo"]);
                    producto.idCategoria = Convert.ToInt32(datos.Lector["idCategoria"]);

                    producto.imagen = new Imagen();

                    if (!(datos.Lector["Url"] is DBNull))
                        producto.imagen.Url = datos.Lector["Url"].ToString();
                }
                

                return producto;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Producto producto)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                          datos.setearConsulta(@"
                            UPDATE Producto
                            SET nombre = @nombre,
                                Precio = @precio,
                                stock = @stock,
                                activo = @activo,
                                idCategoria = @idCategoria
                            WHERE id = @id");

                datos.setearParametro("@nombre", producto.nombre);
                datos.setearParametro("@precio", producto.precio);
                datos.setearParametro("@stock", producto.stock);
                datos.setearParametro("@activo", producto.activo);
                datos.setearParametro("@id", producto.idProducto);
                datos.setearParametro("@idCategoria", producto.idCategoria);

                datos.ejecutarAccion();
                datos.cerrarConexion();

                datos = new AccesoADatos();

                datos.setearConsulta(@"
                                        UPDATE Imagen
                                        SET Url = @url
                                        WHERE id = (
                                            SELECT idImagen
                                            FROM Producto
                                            WHERE id = @id
                                        )");

                datos.setearParametro("@url", producto.imagen.Url);
                datos.setearParametro("@id", producto.idProducto);

                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta(
                    "UPDATE Producto SET Activo = 0 WHERE id = @id");

                datos.setearParametro("@id", id);

                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Producto> buscarPorNombre(string nombre)
        {
            List<Producto> lista = new List<Producto>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta(
                    "SELECT id, nombre, Precio, stock " +
                    "FROM Producto " +
                    "WHERE nombre LIKE @nombre AND activo = 1");

                datos.setearParametro("@nombre", "%" + nombre + "%");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto producto = new Producto();

                    producto.idProducto = Convert.ToInt32(datos.Lector["id"]);
                    producto.nombre = datos.Lector["nombre"].ToString();
                    producto.precio = Convert.ToDecimal(datos.Lector["Precio"]);
                    producto.stock = Convert.ToInt32(datos.Lector["stock"]);

                    lista.Add(producto);
                }

                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
