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
        List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "SELECT Id_Producto, Nombre_Producto, Precio, STOCK FROM PRODUCTO";

                datos.setearConsulta(consulta);
                datos.ejecutarAccion();

                while (datos.Lector.Read())
                {
                    Producto productos = new Producto();

                    productos.idProducto = (int)datos.Lector["Id_Producto"];
                    productos.nombre = (string)datos.Lector["Nombre_Producto"];
                    productos.precio = (decimal)datos.Lector["Precio"];
                    productos.stock = (int)datos.Lector["STOCK"];

                    lista.Add(productos);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
