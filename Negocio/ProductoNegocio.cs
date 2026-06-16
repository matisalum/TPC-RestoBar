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

        public void agregar(Producto nuevo)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta(
                    "INSERT INTO Producto (nombre, Precio, stock, activo, idCategoria, idImagen) " +
                    "VALUES (@nombre, @precio, @stock, @activo, @idCategoria, @idImagen)");

                datos.setearParametro("@nombre", nuevo.nombre);
                datos.setearParametro("@precio", nuevo.precio);
                datos.setearParametro("@stock", nuevo.stock);
                datos.setearParametro("@activo", nuevo.activo);
                datos.setearParametro("@idCategoria", 1);
                datos.setearParametro("@idImagen", 1);

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
                datos.setearConsulta("SELECT id, nombre, Precio, stock, activo FROM Producto WHERE id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    producto.idProducto = Convert.ToInt32(datos.Lector["id"]);
                    producto.nombre = datos.Lector["nombre"].ToString();
                    producto.precio = Convert.ToDecimal(datos.Lector["Precio"]);
                    producto.stock = Convert.ToInt32(datos.Lector["stock"]);
                    producto.activo = Convert.ToBoolean(datos.Lector["activo"]);
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
                datos.setearConsulta(
                    "UPDATE Producto " +
                    "SET nombre = @nombre, " +
                    "    Precio = @precio, " +
                    "    stock = @stock, " +
                    "    activo = @activo " +
                    "WHERE id = @id");

                datos.setearParametro("@nombre", producto.nombre);
                datos.setearParametro("@precio", producto.precio);
                datos.setearParametro("@stock", producto.stock);
                datos.setearParametro("@activo", producto.activo);
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

    }
}
