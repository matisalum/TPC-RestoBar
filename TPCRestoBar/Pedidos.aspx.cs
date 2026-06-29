using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static dominio.Pedido;

namespace TPCRestoBar
{
    public partial class Pedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            PedidoNegocio negocio = new PedidoNegocio();
            dgvPedidos.DataSource = negocio.listar();
            dgvPedidos.DataBind();

            }
        }

        protected void dgvPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Pedido pedido = (Pedido)e.Row.DataItem;

                Label lblEstado = (Label)e.Row.FindControl("lblEstado");

                switch (pedido.estadoPedido)
                {
                    case Pedido.EstadoPedido.Pendiente:
                        lblEstado.CssClass = "badge bg-warning";
                        break;

                    case EstadoPedido.EnPreparacion:
                        lblEstado.CssClass = "badge bg-info";
                        break;

                    case EstadoPedido.Listo:
                        lblEstado.CssClass = "badge bg-success";
                        break;

                    case EstadoPedido.Entregado:
                        lblEstado.CssClass = "badge bg-secondary";
                        break;

                    case EstadoPedido.Cancelado:
                        lblEstado.CssClass = "badge bg-danger";
                        break;

                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioPedido.aspx", false);
        }
    }
}