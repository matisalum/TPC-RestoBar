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

    }
}
