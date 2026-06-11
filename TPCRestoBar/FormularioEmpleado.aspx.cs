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

                //Configuracion de los desplegables
                if (!IsPostBack)
                {

                    ddlRol.Items.Clear();
                    ddlRol.Items.Add(new ListItem("Gerente"));
                    ddlRol.Items.Add(new ListItem("Mesero"));

                }

                //configuracion si estamos modificando el empledo
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    EmpleadoNegocio empleado = new EmpleadoNegocio();
                    Empleado selecionado = empleado.obtenerPorId(int.Parse(id));

                    txtNombre.Text = selecionado.nombre;
                    txtApellido.Text = selecionado.apellido;
                    txtUsuario.Text = selecionado.usuario;
                    txtContrasena.Text = selecionado.password;
                    ddlRol.SelectedValue = selecionado.rol;
                    chkActivo.Checked = selecionado.estado;


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

            // COFIGURACION AGREGAR UN NUEVO MESERO O GERENTE 
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