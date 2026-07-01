using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPCRestoBar
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Empleado usuario = new Empleado();
            EmpleadoNegocio negocio = new EmpleadoNegocio();
            try
            {
                usuario.usuario = txtUsuario.Text;
                usuario.password = txtContrasenia.Text;

                if (negocio.Loguear(usuario))
                {
                    if (!usuario.Activo)
                    {
                        Session.Add("error", "El usuario se encuentra inactivo");
                        Response.Redirect("Error.aspx", false);

                    }
                    else
                    {
                        Session.Add("usuario", usuario);
                        Response.Redirect("Default.aspx", false);
                    }
                }
                else
                {
                    Session.Add("error", "Error al ingresar usuario o contraseña...");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}