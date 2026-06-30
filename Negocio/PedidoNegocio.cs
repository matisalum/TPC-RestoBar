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


        public Pedido ObtenerPorId(int idPedido)
        {
            Pedido pedido = null;
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("SELECT id, Estado FROM Pedido WHERE Id = @IdPedido");

                datos.setearParametro("@idPedido", idPedido);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    pedido = new Pedido();

                    pedido.idPedido = (int)datos.Lector["id"];
                    pedido.estadoPedido = (Pedido.EstadoPedido)(byte)datos.Lector["Estado"];
                }

                return pedido;
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

        public void AvanzarEstado(int idPedido)
        {
            Pedido pedido = ObtenerPorId(idPedido);

            if (pedido == null)
                return;

            if (pedido.estadoPedido == Pedido.EstadoPedido.Pendiente)
                pedido.estadoPedido = Pedido.EstadoPedido.EnProceso;

            else if (pedido.estadoPedido == Pedido.EstadoPedido.EnProceso)
                pedido.estadoPedido = Pedido.EstadoPedido.Entregado;

            else
                return;

            ActualizarEstado(idPedido, pedido.estadoPedido);
        }

        public void CancelarPedido(int idPedido)
        {
            Pedido pedido = ObtenerPorId(idPedido);

            if (pedido == null)
                return;

            if (pedido.estadoPedido == Pedido.EstadoPedido.Entregado)
                return;

            pedido.estadoPedido = Pedido.EstadoPedido.Cancelado;

            ActualizarEstado(idPedido, pedido.estadoPedido);
        }
        private void ActualizarEstado(int idPedido, Pedido.EstadoPedido estado)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("UPDATE Pedido SET Estado = @Estado WHERE id = @IdPedido");

                datos.setearParametro("@Estado", (byte)estado);
                datos.setearParametro("@IdPedido", idPedido);

                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
