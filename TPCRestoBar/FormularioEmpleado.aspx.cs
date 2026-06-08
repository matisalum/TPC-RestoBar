using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace TPCRestoBar
{
    public partial class FormularioEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;

            try
            {
                if (!IsPostBack)
                {

                    ddlRol.Items.Clear();
                    ddlRol.Items.Add(new ListItem("Gerente", "true"));
                    ddlRol.Items.Add(new ListItem("Mesero", "false"));

                }

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
                throw;
            }


        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado empleado = new Empleado();

                empleado.nombre = txtNombre.Text;
                empleado.apellido = txtApellido.Text;
                empleado.password = txtContrasena.Text;



            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }


        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empleados.aspx", false);
        }

    }
}