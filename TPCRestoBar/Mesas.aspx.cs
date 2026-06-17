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
            dgvMesa.DataSource = negocio.listar();
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

        protected void dgvMesa_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void dgvMesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)dgvMesa.SelectedDataKey.Value;
            Response.Redirect("FormularioMesa.aspx?id=" + id);
        }

        protected void dgvMesa_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvMesa.PageIndex = e.NewPageIndex;
            cargarmesa();
        }
    }
}