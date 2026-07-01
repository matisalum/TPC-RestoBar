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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Sesion activa ?
            if (!(Page is Login || Page is Error))
            {
                if (!(Seguridad.sesionActiva(Session["usuario"])))
                {
                    Session.Add("error", "Inicia sesión para continuar...");
                    Response.Redirect("Login.aspx", false);
                }
            }
            if (Page is Categorias || Page is Empleados || Page is Producto1 || Page is FormularioCategoria
                || Page is FormularioEmpleado || Page is FormularioMesa || Page is FormularioPedido ||
                Page is ProductoFormulario || Page is Pedidos || Page is Mesas)
            {
                if ((Seguridad.sesionActiva(Session["usuario"])))
                {
                    if (!(Seguridad.esAdmin(Session["usuario"])))
                    {
                        Session.Add("error", "No tienes permiso para continuar...");
                        Response.Redirect("Error.aspx", false);
                    }
                }
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Session.Remove("usuario");
                Response.Redirect("Login.aspx", false);
            }
        }
    }
}