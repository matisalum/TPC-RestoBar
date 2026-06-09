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
                    ddlRol.Items.Add(new ListItem("Gerente"));
                    ddlRol.Items.Add(new ListItem("Mesero"));

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
                EmpleadoNegocio negocio = new EmpleadoNegocio();

                empleado.nombre = txtNombre.Text;
                empleado.apellido = txtApellido.Text;
                empleado.usuario = txtUsuario.Text;
                empleado.password = txtContrasena.Text;
                empleado.rol = ddlRol.SelectedValue;
                empleado.estado = chkActivo.Checked;

                negocio.agregar(empleado);
                Response.Redirect("Empleados.aspx", false);

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