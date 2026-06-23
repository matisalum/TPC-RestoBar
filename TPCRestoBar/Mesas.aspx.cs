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
    public partial class Mesas : System.Web.UI.Page
    {
        private void cargarmesa()
        {
            MesasNegocio negocio = new MesasNegocio();
            Session.Add("listarMesas", negocio.listar());
            dgvMesa.DataSource = Session["listarMesas"];
            dgvMesa.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarmesa();
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioMesa.aspx");
        }


        protected void dgvMesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)dgvMesa.SelectedDataKey.Value;
            Response.Redirect("FormularioMesa.aspx?id=" + id);
        }
        //protected void dgvMesa_RowDataBound(object sender, GridViewRowEventArgs e)
        //{

        //}
        //PAGINACION 
        protected void dgvMesa_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvMesa.PageIndex = e.NewPageIndex;
            cargarmesa();
        }
        // FILTRO RAPIDO
        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            //List<Mesa> lista = (List<Mesa>)Session["listarCategorias"];
            //List<Mesa> listaFiltrada = lista.FindAll(x => x.numero == int.Parse(txtFiltro.Text));
            //dgvMesa.DataSource = listaFiltrada;

            //dgvMesa.DataBind();

            //var lista = Session["listarCategorias"] as List<Mesa>;
            //if (lista == null)
            //{
            //    dgvMesa.DataSource = null;
            //    dgvMesa.DataBind();
            //    return;
            //}

            //if (!int.TryParse(txtFiltro.Text, out int numero))
            //{
            //    return;
            //}

            //var listaFiltrada = lista.Where(x => x.numero == numero).ToList();
            //dgvMesa.DataSource = listaFiltrada;
            //dgvMesa.DataBind();
        }
    }
}