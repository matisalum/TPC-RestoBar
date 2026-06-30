using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;

namespace TPCRestoBar
{
    public partial class FormularioPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Pedido pedido = new Pedido();
            PedidoNegocio negocio = new PedidoNegocio();
           
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}