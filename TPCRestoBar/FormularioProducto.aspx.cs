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

        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            
            Producto nuevo = new Producto();

            nuevo.nombre = txtNombre.Text;
            nuevo.precio = decimal.Parse(txtPrecio.Text);
            nuevo.stock = int.Parse(txtStock.Text);
            nuevo.activo = chkActivo.Checked;

            ProductoNegocio negocio = new ProductoNegocio();
            negocio.agregar(nuevo);

            Response.Redirect("Producto.aspx");
        }
        

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Producto.aspx");
        }
    }
}