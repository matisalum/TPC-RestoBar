using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace TPCRestoBar
{
    public partial class VerPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Recuperamos la mesa que guardamos en la sesión en la pantalla anterior
                Mesa mesaActual = (Mesa)Session["MesaActual"];

                if (mesaActual != null)
                {
                    lblNroMesa.Text = "Mesa " + mesaActual.numero;
                    cargarPedidoAbierto(mesaActual.idMesa);
                }
                else
                {
                    Response.Redirect("MasasMeseros.aspx");
                }
            }
        }
        private void cargarPedidoAbierto(int idMesa)
        {
            AccesoADatos datos = new AccesoADatos();

            List<DetallePedido> detalles =
                new List<DetallePedido>();

            decimal total = 0;

            try
            {
                datos.setearConsulta(@"

SELECT

p.FechaPedido,

dp.id,
dp.Cantidad,

pr.id,
pr.Nombre,
pr.Precio

FROM Pedido p

INNER JOIN DetallePedido dp
ON p.id = dp.idPedido

INNER JOIN Producto pr
ON pr.id = dp.idProducto

WHERE p.idMesa = @idMesa
AND p.Estado IN (0,1)

");

                datos.setearParametro(
                    "@idMesa",
                    idMesa);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    DetallePedido det =
                        new DetallePedido();

                    det.IdDetalle =
                        Convert.ToInt32(
                            datos.Lector["id"]);

                    det.Cantidad =
                        Convert.ToInt32(
                            datos.Lector["Cantidad"]);

                    det.Producto =
                        new Producto();

                    det.Producto.idProducto =
                        Convert.ToInt32(
                            datos.Lector["id"]);

                    det.Producto.nombre =
                        datos.Lector["Nombre"].ToString();

                    det.PrecioUnitario =
                        Convert.ToDecimal(
                            datos.Lector["Precio"]);

                    lblFecha.Text =
                        Convert.ToDateTime(
                            datos.Lector["FechaPedido"])
                        .ToString("dd/MM/yyyy HH:mm");

                    total += det.Subtotal;

                    detalles.Add(det);
                }

                dgvDetallePedido.DataSource =
                    detalles;
               // Response.Write(detalles.Count);
                dgvDetallePedido.DataBind();

                lblTotal.Text =
                    "$ " + total.ToString("N2");
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            // 1. En lugar de buscar en la URL, recuperamos la Mesa que YA guardaste en Sesión
            Mesa mesaActual = (Mesa)Session["MesaActual"];

            // 2. Validamos que la sesión contenga la mesa y tenga un ID válido
            if (mesaActual != null && mesaActual.idMesa > 0)
            {
                // Forzamos el estado a true (ocupada) para que la Cartilla reconozca el modo edición
                mesaActual.estado = true;
                Session["MesaActual"] = mesaActual;

                // Levantamos los productos actuales de la base de datos usando ese ID real
                List<DetallePedido> detallesDeLaBD = obtenerDetallesDesdeBD(mesaActual.idMesa);

                // Guardamos los productos en el carrito temporal de la sesión para el Offcanvas
                Session["Carrito"] = detallesDeLaBD;

                // Te redireccionamos directamente a la Cartilla (Carta.aspx)
                Response.Redirect("Carta.aspx");
            }
            else
            {
                // Si por algún motivo extraño la sesión está completamente vacía, 
                // mostramos este aviso para saber qué objeto falta.
                Response.Write("<script>alert('Error: No se encontró la MesaActual en la Sesión de esta página.');</script>");
            }
        }

        // Método rápido para recuperar los detalles y subirlos a la sesión
        private List<DetallePedido> obtenerDetallesDesdeBD(int idMesa)
        {
            List<DetallePedido> lista =
                new List<DetallePedido>();

            AccesoADatos datos =
                new AccesoADatos();

            try
            {
                datos.setearConsulta(@"

SELECT

dp.Cantidad,

pr.id,
pr.Nombre,
pr.Precio

FROM Pedido p

INNER JOIN DetallePedido dp
ON p.id = dp.idPedido

INNER JOIN Producto pr
ON pr.id = dp.idProducto

WHERE p.idMesa = @idMesa
AND p.Estado IN (0,1)

");

                datos.setearParametro(
                    "@idMesa",
                    idMesa);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    DetallePedido det =
                        new DetallePedido();

                    det.Cantidad =
                        Convert.ToInt32(
                            datos.Lector["Cantidad"]);

                    det.Producto =
                        new Producto();

                    det.Producto.idProducto =
                        Convert.ToInt32(
                            datos.Lector["id"]);

                    det.Producto.nombre =
                        datos.Lector["Nombre"]
                        .ToString();

                    det.Producto.precio =
                        Convert.ToDecimal(
                            datos.Lector["Precio"]);

                    det.PrecioUnitario =
                        det.Producto.precio;

                    lista.Add(det);
                }

                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MasasMeseros.aspx");
        }
    }
}