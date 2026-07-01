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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                cargarDashboard();
            }
        }

        private void cargarDashboard()
        {
            MesasNegocio mesaNegocio = new MesasNegocio();
            ProductoNegocio productoNegocio = new ProductoNegocio();
            PedidoNegocio pedidoNegocio = new PedidoNegocio();
            EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();

            lblMesas.Text =
                mesaNegocio.listar().Count.ToString();

            lblProductos.Text =
                productoNegocio.listar().Count.ToString();

            lblPedidos.Text =
                pedidoNegocio.listar().Count.ToString();

            lblEmpleados.Text =
                empleadoNegocio.listarConSp().Count.ToString();

        }
    }
}