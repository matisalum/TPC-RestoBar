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
                    pedido.estadoPedido = (Pedido.EstadoPedido)(byte)datos.Lector["Estado"];


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

        public void agregarConSp(Pedido nuevo)
        {

            AccesoADatos datos = new AccesoADatos();


            try
            {
                datos.setearProcedimiento("storeAgregarPedido");

                datos.setearParametro("@FechaPedido", nuevo.fechaPedido);
                datos.setearParametro("@Estado", (byte)nuevo.estadoPedido);
                datos.setearParametro("@idMesa", nuevo.mesa.idMesa);
                datos.setearParametro("@idEmpleado", nuevo.empleado.idEmpleado);

                datos.ejecutarAccion();
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
