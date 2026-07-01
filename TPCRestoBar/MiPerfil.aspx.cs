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
    public partial class MiPerfil : System.Web.UI.Page
    {
        private void cargar()
        {
            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                Empleado empleado = (Empleado)Session["usuario"];
                Image imagen = new Image();
                txtNombre.Text = empleado.nombre;
                txtApellido.Text = empleado.apellido;
                txtUsuario.Text = empleado.usuario;
                txtContrasena.Text = empleado.password;
                txtCargo.Text = empleado.rol;

                ImagenNegocio negocio = new ImagenNegocio();
                Imagen img = negocio.filtrarId(empleado.idImagen);
                if (img != null && !string.IsNullOrEmpty(img.Url))
                {
                    txtImagen.Text = img.Url;
                    imgPerfil.ImageUrl = img.Url;
                }
                else
                {
                    txtImagen.Text = string.Empty;
                    imgPerfil.ImageUrl = "https://i.pinimg.com/736x/43/3a/83/433a83a38b10d863c0b9b911a50bb2ee.jpg";
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!(Seguridad.sesionActiva(Session["usuario"])))
            //{
            //    Session.Add("error", "Inicia sesión para continuar...");
            //    Response.Redirect("Error.aspx", false);
            //}
            if(!IsPostBack)
                cargar();
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            imgPerfil.ImageUrl = txtImagen.Text;
        }
    }
}