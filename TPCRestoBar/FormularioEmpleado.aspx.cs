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
    public partial class FormularioEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;

            if (!IsPostBack)
            {
                EmpleadoNegocio empeldo = new EmpleadoNegocio();
                List<Empleado> lista = empeldo.listar();

                ddlRol.DataSource = lista;
                ddlRol.DataValueField = "idEmpleado";
                ddlRol.DataTextField = "rol";
                ddlRol.DataBind();

            }


        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empleados.aspx", false);
        }
    }
}