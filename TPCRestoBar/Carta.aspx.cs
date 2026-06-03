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
            ProductoNegocio productos = new ProductoNegocio();

            Producto prod = new Producto();

            prod.idProducto = 1;
            prod.nombre = "COCA COLA";
            prod.precio = 7500;
            prod.stock = 20;

            List<Producto> lista = new List<Producto>();

            lista.Add(prod);      

            dvgCartilla.DataSource = lista;
            dvgCartilla.DataBind();
        }
    }
}