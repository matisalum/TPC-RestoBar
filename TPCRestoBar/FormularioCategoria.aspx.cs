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
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "" && !IsPostBack)
            {
                CategoriaNegocio cat = new CategoriaNegocio();
                Categoria select = cat.filtrarId(int.Parse(id));

                Session.Add("categoriaS", select);

                txtNombre.Text = select.Nombre.ToString();

                if (!select.Estado)
                    BtnInactivar.Text = "Reactivar";
            }
            else
                BtnInactivar.Visible = false;
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
                lblMensaje.Text = "";

                if(string.IsNullOrEmpty(txtNombre.Text))
                {
                    lblMensaje.Text = "Campo obligatorio...";
                    return;
                }
                cat.Nombre = txtNombre.Text.ToString();

                if (Request.QueryString["id"] != null)
                {
                    Categoria aux = (Categoria)Session["categoriaS"];
                    cat.Id = int.Parse(Request.QueryString["id"]);
                    cat.Estado = aux.Estado;
                    negocio.modificarConSp(cat);
                }
                else
                    negocio.agregar(cat);

                Response.Redirect("Categorias.aspx");
                 
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void BtnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                Categoria select = (Categoria)Session["categoriaS"];

                negocio.eliminacionLogica(select.Id, !select.Estado);
                Response.Redirect("Categorias.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}