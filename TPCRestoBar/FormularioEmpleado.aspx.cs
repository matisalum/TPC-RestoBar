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
            btnBaja.Visible = false;

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
                    btnBaja.Visible = true;
                    btnAgregar.Visible = false;
                    EmpleadoNegocio empleado = new EmpleadoNegocio();
                    Empleado selecionado = empleado.obtenerPorId(int.Parse(id));
                    //guardo empleado seleccionado en session
                    Session.Add("empleadoSeleccionado", selecionado);

                    // PRE carga de todos los campos.
                    txtId.Text = selecionado.idEmpleado.ToString();
                    txtNombre.Text = selecionado.nombre;
                    txtApellido.Text = selecionado.apellido;
                    txtUsuario.Text = selecionado.usuario;
                    txtContrasena.Text = selecionado.password;
                    ddlRol.SelectedValue = selecionado.rol;
             

                    // cofigurar baja logica / alta 
                    if(!selecionado.Activo)
                      btnBaja.Text= "ALTA EMPLEDO";

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
                //  AGREGAR UN NUEVO MESERO O GERENTE 
                Empleado empleado = new Empleado();
                    EmpleadoNegocio negocio = new EmpleadoNegocio();

                    empleado.nombre = txtNombre.Text;
                    empleado.apellido = txtApellido.Text;
                    empleado.usuario = txtUsuario.Text;
                    empleado.password = txtContrasena.Text;
                    empleado.rol = ddlRol.SelectedValue;
                    empleado.Activo = true;

                // If para que el btn sepa si estamos agregando o modificando 

                if (Request.QueryString["id"] != null)
                {
                    empleado.idEmpleado = int.Parse(txtId.Text);
                    negocio.modificarConSp(empleado);

                }
                else { negocio.agregarConSp(empleado); }

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

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
            EmpleadoNegocio negocio = new EmpleadoNegocio();
            Empleado seleccionado = (Empleado)Session["empleadoSeleccionado"];

            negocio.eliminarLogico(seleccionado.idEmpleado, !seleccionado.Activo);
            Response.Redirect("Empleados.aspx", false);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}