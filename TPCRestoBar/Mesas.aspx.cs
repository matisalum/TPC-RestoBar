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
        public bool filtroAvanzado { get; set; }
        private void cargarmesa()
        {
            MesasNegocio negocio = new MesasNegocio();
            Session.Add("listarMesas", negocio.listar());
            dgvMesa.DataSource = Session["listarMesas"];
            dgvMesa.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            filtroAvanzado = chbAvanzado.Checked;
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
        //PAGINACION 
        protected void dgvMesa_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvMesa.PageIndex = e.NewPageIndex;
            cargarmesa();
        }
        // FILTRO RAPIDO
        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {

            List<Mesa> lista = (List<Mesa>)Session["listarMesas"];
            if (lista == null)
            {
                dgvMesa.DataSource = null;
                dgvMesa.DataBind();
                return;
            }

            if (!int.TryParse(txtFiltro.Text, out int numero))
            {
                if(string.IsNullOrEmpty(txtFiltro.Text))
                    cargarmesa();

                return;
            }

            else
            {
                List<Mesa> listaFiltrada = lista.FindAll(x => x.numero == numero);
                dgvMesa.DataSource = listaFiltrada;
                dgvMesa.DataBind();
            }
        }

        protected string buscarEmpleado(int ide)
        {
            EmpleadoNegocio negocio = new EmpleadoNegocio();
            Empleado empleado = new Empleado();

            if (negocio.obtenerPorId(ide) == null)
                return "sin asignar";

            empleado = negocio.obtenerPorId(ide);
            return empleado.nombre;
        }

        protected void chbAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            filtroAvanzado = chbAvanzado.Checked;
            txtFiltro.Enabled = !filtroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw ex;
            }
        }
    }
}