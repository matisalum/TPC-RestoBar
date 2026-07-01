using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPCRestoBar
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Sesion activa ?
            //if (!(Page is Login))
            //{
            //    if (!(Seguridad.sesionActiva(Session["usuario"])))
            //    {
            //        Session.Add("error", "Inicia sesión para continuar...");
            //        Response.Redirect("Login.aspx", false);
            //    }
            //}
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