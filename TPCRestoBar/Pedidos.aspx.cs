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

                Button btnAvanzar = (Button)e.Row.FindControl("btnAvanzar");
                Button btnCancelar = (Button)e.Row.FindControl("btnCancelar");

                switch (pedido.estadoPedido)
                {
                    case Pedido.EstadoPedido.Pendiente:
                        lblEstado.CssClass = "badge bg-warning";
                        break;

                    case Pedido.EstadoPedido.EnProceso:
                        lblEstado.CssClass = "badge bg-info";
                        break;

                    case Pedido.EstadoPedido.Entregado:
                        lblEstado.CssClass = "badge bg-secondary";
                        break;

                    case Pedido.EstadoPedido.Cancelado:
                        lblEstado.CssClass = "badge bg-danger";
                        break;

                }

                if (pedido.estadoPedido == Pedido.EstadoPedido.Entregado ||
                    pedido.estadoPedido == Pedido.EstadoPedido.Cancelado)
                {
                    btnAvanzar.Visible = false;
                    btnCancelar.Visible = false;
                }
            }
        }

        protected void btnAvanzar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int idPedido = int.Parse(btn.CommandArgument);

            PedidoNegocio negocio = new PedidoNegocio();

            negocio.AvanzarEstado(idPedido);

            dgvPedidos.DataSource = negocio.listar();
            dgvPedidos.DataBind();

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int idPedido = int.Parse(btn.CommandArgument);

            PedidoNegocio negocio = new PedidoNegocio();

            negocio.CancelarPedido(idPedido);

            dgvPedidos.DataSource = negocio.listar();
            dgvPedidos.DataBind();
        }
    }
}