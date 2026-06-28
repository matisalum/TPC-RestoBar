using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using dominio;

namespace TPCRestoBar
{
    public partial class Categorias : System.Web.UI.Page
    {
        void cargarTabla()
        {
            CategoriaNegocio cat = new CategoriaNegocio();
            Session.Add("listarCategorias", cat.listar());
            dvgCategoria.DataSource = Session["listarCategorias"];
            dvgCategoria.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                cargarTabla();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioCategoria.aspx");
        }

        protected void dvgCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)dvgCategoria.SelectedDataKey.Value;
            Response.Redirect("FormularioCategoria.aspx?id=" + id);
        }

        protected void dvgCategoria_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dvgCategoria.PageIndex = e.NewPageIndex;
            cargarTabla();
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Categoria> lista = (List<Categoria>)Session["listarCategorias"];
            if (lista == null)
            {
                dvgCategoria.DataSource = null;
                dvgCategoria.DataBind();
                return;
            }

            if (string.IsNullOrEmpty(txtFiltro.Text))
            {
                cargarTabla();
                return;
            }

            else
            {
                List<Categoria> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                dvgCategoria.DataSource = listaFiltrada;
                dvgCategoria.DataBind();
            }
        }
    }
}