using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCRestoBar
{
    public partial class ProductoFormulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);

                    ProductoNegocio negocio = new ProductoNegocio();
                    Producto producto = negocio.buscarPorId(id);

                    txtNombre.Text = producto.nombre;
                    txtPrecio.Text = producto.precio.ToString();
                    txtStock.Text = producto.stock.ToString();
                    chkActivo.Checked = producto.activo;

                    btnAgregar.Text = "Modificar";
                }
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();

            producto.nombre = txtNombre.Text;
            producto.precio = decimal.Parse(txtPrecio.Text);
            producto.stock = int.Parse(txtStock.Text);
            producto.activo = chkActivo.Checked;

            ProductoNegocio negocio = new ProductoNegocio();

            if (Request.QueryString["id"] != null)
            {
                producto.idProducto = int.Parse(Request.QueryString["id"]);
                negocio.modificar(producto);
            }
            else
            {
                negocio.agregar(producto);
            }

            Response.Redirect("Producto.aspx");
        }


        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Producto.aspx");
        }
    }
}