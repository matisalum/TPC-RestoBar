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
                string consulta = @"SELECT id, nombre, Precio, stock FROM Producto";

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
                    "INSERT INTO Producto (Nombre_Producto, Precio, Stock, Activo) " +
                    "VALUES (@nombre, @precio, @stock, @activo)");

                datos.setearParametro("@nombre", nuevo.nombre);
                datos.setearParametro("@precio", nuevo.precio);
                datos.setearParametro("@stock", nuevo.stock);
                datos.setearParametro("@activo", nuevo.activo);

                datos.ejecutarAccion();
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
                    "UPDATE Producto SET " +
                    "Nombre_Producto=@nombre, " +
                    "Precio=@precio, " +
                    "Stock=@stock, " +
                    "Activo=@activo " +
                    "WHERE Id_Producto=@id");

                datos.setearParametro("@id", producto.idProducto);
                datos.setearParametro("@nombre", producto.nombre);
                datos.setearParametro("@precio", producto.precio);
                datos.setearParametro("@stock", producto.stock);
                datos.setearParametro("@activo", producto.activo);

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
                    "UPDATE Producto SET Activo = 0 WHERE Id_Producto = @id");

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
