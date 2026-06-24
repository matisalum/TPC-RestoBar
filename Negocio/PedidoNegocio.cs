using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Negocio
{
    public class PedidoNegocio
    {
        public List<Pedido> listar()
        {
            List<Pedido> lista = new List<Pedido>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearProcedimiento("storeListarPedidos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.mesa = new Mesa();
                    pedido.empleado = new Empleado();

                    pedido.idPedido = (int)datos.Lector["IdPedido"];
                    pedido.mesa.numero = (int)datos.Lector["NumeroMesa"];
                    pedido.empleado.nombre = datos.Lector["NombreEmpleado"].ToString(); 
                    pedido.empleado.apellido = datos.Lector["ApellidoEmpleado"].ToString(); 
                    pedido.fechaPedido = (DateTime)datos.Lector["FechaPedido"];
                    pedido.estadoPedido = (int)datos.Lector["Estado"];


                    lista.Add(pedido);
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
