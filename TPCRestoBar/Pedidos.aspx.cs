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
    }
}