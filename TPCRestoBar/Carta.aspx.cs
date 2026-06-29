using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace TPCRestoBar
{
    public partial class Carta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoriaNegocio negocio = new CategoriaNegocio();

                ddlCategoria.DataSource = negocio.listar();

                ddlCategoria.DataTextField = "Nombre";

                ddlCategoria.DataValueField = "Id";

                ddlCategoria.DataBind();

                ddlCategoria.Items.Insert( 0,  new ListItem( "Todas las categorías", "0"));


                ProductoNegocio prod = new ProductoNegocio();

                repProductos.DataSource = prod.listarCarta();

                repProductos.DataBind();
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            ProductoNegocio negocio = new ProductoNegocio();

            List<Producto> lista = negocio.listarCarta();

            lista = lista.FindAll(x => x.nombre.ToUpper().Contains( txtBuscar.Text.ToUpper()));

            repProductos.DataSource = lista;

            repProductos.DataBind();

        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductoNegocio negocio =
                new ProductoNegocio();

            List<Producto> lista =
                negocio.listarCarta();

            int id =
                int.Parse(ddlCategoria.SelectedValue);

            if (id != 0)
            {
                lista = lista.FindAll(
                    x => x.idCategoria == id);
            }

            repProductos.DataSource = lista;
            repProductos.DataBind();
        }
    }
}