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
    public partial class Producto1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                ProductoNegocio negocio = new ProductoNegocio();

                dgvProductos.DataSource = negocio.listar();
                dgvProductos.DataBind();

                pnlFiltroAvanzado.Visible = false;
                ddlCampo.Items.Add("Nombre");
                ddlCampo.Items.Add("Precio");
                ddlCampo.Items.Add("Stock");

                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void dgvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(dgvProductos.DataKeys[index].Value);

                ProductoNegocio negocio = new ProductoNegocio();
                negocio.eliminar(id);

                Response.Redirect("Producto.aspx");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            dgvProductos.DataSource = negocio.buscarPorNombre(txtBuscar.Text);
            dgvProductos.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            pnlFiltroAvanzado.Visible = chkAvanzado.Checked;
            txtBuscar.Enabled = !chkAvanzado.Checked;
            btnBuscar.Enabled = !chkAvanzado.Checked;

        }
        protected void btnBuscarAvanzado_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();

            List<Producto> lista = negocio.listar();

            string campo = ddlCampo.SelectedItem.Text;
            string criterio = ddlCriterio.SelectedItem.Text;
            string filtro = txtFiltro.Text;

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                if (campo == "Nombre")
                {
                    if (criterio == "Contiene")
                        lista = lista.FindAll(x =>
                            x.nombre.ToLower().Contains(filtro.ToLower()));

                    else if (criterio == "Comienza con")
                        lista = lista.FindAll(x =>
                            x.nombre.ToLower().StartsWith(filtro.ToLower()));

                    else if (criterio == "Termina con")
                        lista = lista.FindAll(x =>
                            x.nombre.ToLower().EndsWith(filtro.ToLower()));
                }
            }

            if (ddlEstado.SelectedValue == "1")
                lista = lista.FindAll(x => x.activo);

            else if (ddlEstado.SelectedValue == "2")
                lista = lista.FindAll(x => !x.activo);

            dgvProductos.DataSource = lista;
            dgvProductos.DataBind();
        }
    }
}