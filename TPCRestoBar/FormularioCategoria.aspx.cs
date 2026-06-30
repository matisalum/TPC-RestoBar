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
        private bool existeNombre(string nom, int id)
        {
            CategoriaNegocio aux = new CategoriaNegocio();
            List<Categoria> lista = aux.listar();

            return lista.Any(x => x.Nombre.ToUpper() == nom.ToUpper() && x.Id != id);
        }
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

                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    lblMensaje.Text = "Campo obligatorio...";
                    return;
                }

                int idAux = 0;
                if (Request.QueryString["id"] != null)
                {
                    idAux = int.Parse(Request.QueryString["id"]);
                }

                if (existeNombre(txtNombre.Text.ToString(), idAux))
                {
                    lblMensaje.Text = "El nombre ya existe...";
                    return;
                }

                cat.Nombre = txtNombre.Text.ToString();

                if (Request.QueryString["id"] != null)
                {
                    Categoria aux = (Categoria)Session["categoriaS"];
                    cat.Id = idAux;
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