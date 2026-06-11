using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCRestoBar
{
    public partial class Empleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmpleadoNegocio negocio = new EmpleadoNegocio();

                dgvEmpleados.DataSource = negocio.listarConSp();
                dgvEmpleados.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioEmpleado.aspx", false);
        }

        protected void dgvEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)dgvEmpleados.SelectedDataKey.Value;
            Response.Redirect("FormularioEmpleado.aspx?id=" + id);
        }
    }
}