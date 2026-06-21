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
    public partial class FormularioCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categorias.aspx");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria cat = new Categoria();
                CategoriaNegocio negocio = new CategoriaNegocio();

                cat.Nombre = txtNombre.Text.ToString();
                cat.Estado = true;

                negocio.agregar(cat);

                Response.Redirect("Categorias.aspx");
                 
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}