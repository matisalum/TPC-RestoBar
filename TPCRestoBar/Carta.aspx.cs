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
            
            Pedido pedido = (Pedido)Session["PedidoActual"];
            if (!IsPostBack)
            {

                int mesa = Convert.ToInt32( Request.QueryString["idMesa"] );

                lblMesa.Text = "Mesa " + mesa;

            }
            if (!IsPostBack)
            {
                CategoriaNegocio negocio = new CategoriaNegocio();

                ddlCategoria.DataSource = negocio.listar();

                ddlCategoria.DataTextField = "Nombre";

                ddlCategoria.DataValueField = "Id";

                ddlCategoria.DataBind();

                ddlCategoria.Items.Insert(0, new ListItem("Todas las categorías", "0"));


                ProductoNegocio prod = new ProductoNegocio();

                repProductos.DataSource = prod.listarCarta();

                repProductos.DataBind();
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            ProductoNegocio negocio = new ProductoNegocio();

            List<Producto> lista = negocio.listarCarta();

            lista = lista.FindAll(x => x.nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));

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

        private void CargarGrid()
        {
            dgvPedido.DataSource = Carrito;
            dgvPedido.DataBind();
        }

        protected void btnAgregar_Click( object sender, EventArgs e)
        { 
            Button btn =  (Button)sender;

            int idProducto = Convert.ToInt32( btn.CommandArgument );
             
            ProductoNegocio negocio = new ProductoNegocio();
             
            Producto prod = negocio.obtenerPorId( idProducto );


            DetallePedido item = Carrito.Find( x => x.Producto.idProducto ==  idProducto );


            if (item == null)
            {

                item =  new DetallePedido();

                item.Producto = prod;

                item.Cantidad = 1;

                item.PrecioUnitario = prod.precio;

                Carrito.Add(item);

            }

            else
            { 
                item.Cantidad++; 
            }
             
            CargarGrid();

        }

        protected void btnRestar_Click( object sender, EventArgs e)
        {

            Button btn =  (Button)sender;

            int id = Convert.ToInt32( btn.CommandArgument );

            DetallePedido item =  Carrito.Find(  x => x.Producto.idProducto  == id  );


            if (item != null)
            { 
                item.Cantidad--;

                if (item.Cantidad <= 0)

                    Carrito.Remove(item); 
            } 

            CargarGrid();

        }

        protected void btnNPedido_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int idMesa = Convert.ToInt32(btn.CommandArgument);

            Response.Redirect( "Carta.aspx?idMesa="  + idMesa );

        }
        private List<DetallePedido> Carrito
        {
            get
            {
                if (Session["Carrito"] == null)
                    Session["Carrito"] = new List<DetallePedido>();

                return
                    (List<DetallePedido>)
                        Session["Carrito"];
            }
            set
            {
                Session["Carrito"] = value;
            }
        }
    }
}