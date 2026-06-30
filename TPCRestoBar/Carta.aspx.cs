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
            if (pedido != null)
            {
                lblPrueba.Text = "Mesa: " + pedido.mesa.numero;
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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            //Trae el id del producto 
            Button btn = (Button)sender;

            int idProducto = int.Parse(btn.CommandArgument);

            //Trae el pedido con los datos de la mesa seleccionada
            Pedido pedidoActual = (Pedido)Session["PedidoActual"];

            ProductoNegocio negocio = new ProductoNegocio();
            //Trae el producto por el id
            Producto producto = negocio.buscarPorId(idProducto);
            //Busca si el producto ya fue agregado a la lista de productos
            DetallePedido detalleExistente = pedidoActual.Detalles.Find(
                x => x.producto.idProducto == idProducto);
            //Si ya existe agrega una cantidad
            if (detalleExistente != null)
            {
                detalleExistente.cantidad++;
            }
            else
            {
                //Si no existe generamos el detalle en cantidad 1 y lo agregamos a la lista
                DetallePedido detalle = new DetallePedido();

                detalle.producto = producto;
                detalle.pedido = pedidoActual;
                detalle.cantidad = 1;

                pedidoActual.Detalles.Add(detalle);
            }
            //Cargamos la lista al grid
            dgvPedido.DataSource = pedidoActual.Detalles;
            dgvPedido.DataBind();
        }
        protected void btnRestar_Click(object sender, EventArgs e)
        {
            //Primero evaluar que tengas una cantidad > 0 para poder restar 
            Button btn = (Button)sender;

            int idProducto = int.Parse(btn.CommandArgument);
        }
    }
}