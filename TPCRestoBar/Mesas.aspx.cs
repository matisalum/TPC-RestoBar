using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCRestoBar
{
    public partial class Mesas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MesasNegocio negocio = new MesasNegocio();

                dgvMesa.DataSource = negocio.listar();
                dgvMesa.DataBind();

            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioMesa.aspx");
        }
    }
}