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
                string consulta = "SELECT Id_Producto, Nombre_Producto, Precio, STOCK FROM PRODUCTO";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto productos = new Producto();

                    if (!(datos.Lector["Id_Producto"] is DBNull))
                        productos.idProducto = (int)datos.Lector["Id_Producto"];
                    else
                        productos.idProducto = 0;
                    if (!(datos.Lector["Nombre_Producto"] is DBNull))
                        productos.nombre = (string)datos.Lector["Nombre_Producto"];
                    else
                        productos.nombre = "Sin Nombre";
                    if (!(datos.Lector["Precio"] is DBNull))
                        productos.precio = (decimal)datos.Lector["Precio"];
                    else
                        productos.precio = 0;
                    if (!(datos.Lector["STOCK"] is DBNull))
                        productos.stock = (int)datos.Lector["STOCK"];
                    else
                        productos.stock = 0;

                    lista.Add(productos);
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
