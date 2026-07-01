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

                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                ddlCategoria.DataSource = categoriaNegocio.listar();
                ddlCategoria.DataTextField = "Nombre";
                ddlCategoria.DataValueField = "id";
                ddlCategoria.DataBind();
                 

                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);

                    ProductoNegocio negocio = new ProductoNegocio();
                    Producto producto = negocio.buscarPorId(id);

                    txtNombre.Text = producto.nombre;
                    txtPrecio.Text = producto.precio.ToString();
                    txtStock.Text = producto.stock.ToString();
                    chkActivo.Checked = producto.activo;

                    if (producto.imagen != null)
                    {
                        txtImagen.Text = producto.imagen.Url;
                        imgPreview.ImageUrl = producto.imagen.Url;
                    }

                    ddlCategoria.SelectedValue = producto.idCategoria.ToString();
                    btnAgregar.Text = "Modificar";
                }
            }
        }

        protected void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            imgPreview.ImageUrl = txtImagen.Text;
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            lblMensaje.Text = "";


            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                lblMensaje.Text = "Debe ingresar un nombre para el producto.";
                return;
            }



            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, out precio) || precio <= 0)
            {
                lblMensaje.Text = "Ingrese un precio numérico válido mayor a 0.";
                return;
            }

           
            int stock;
            if (!int.TryParse(txtStock.Text, out stock) || stock < 0)
            {
                lblMensaje.Text = "Ingrese un stock válido (0 o mayor).";
                return;
            }
            if (Request.QueryString["id"] == null)
            {
                int idInactivo = negocio.obtenerIdProductoInactivo(txtNombre.Text);

                if (idInactivo > 0)
                {
                    negocio.activarProducto(idInactivo);

                    lblMensaje.Text = "El producto ya existía y fue reactivado.";

                    return;
                }

                if (negocio.existeProducto(txtNombre.Text))
                {
                    lblMensaje.Text = "Ya existe un producto con ese nombre.";

                    return;
                }
            }

            Producto producto = new Producto();

            producto.nombre = txtNombre.Text;
            producto.precio = precio;
            producto.stock = stock;
            producto.activo = chkActivo.Checked;
            producto.idCategoria = int.Parse(ddlCategoria.SelectedValue);
            producto.imagen = new Imagen();
            producto.imagen.Url = txtImagen.Text;
            


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
        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            imgPreview.ImageUrl = txtImagen.Text;
        }
    }
}