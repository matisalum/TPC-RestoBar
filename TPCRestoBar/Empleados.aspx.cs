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
    public partial class Empleados : System.Web.UI.Page
    {
        public bool filtroAvanzado { get; set; }

        private void CargarEmpleados()
        {
            EmpleadoNegocio negocio = new EmpleadoNegocio();
            Session["listarEmpleados"] = negocio.listarConSp();
            dgvEmpleados.DataSource = Session["listarEmpleados"];
            dgvEmpleados.DataBind();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            filtroAvanzado = chbAvanzado.Checked;
            if (!IsPostBack)
            {
                CargarEmpleados();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioEmpleado.aspx", false);
        }

        protected void dgvEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)dgvEmpleados.SelectedDataKey.Value;
            Response.Redirect("FormularioEmpleado.aspx?id=" + id);
        }


        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Empleado> lista = (List<Empleado>)Session["listarEmpleados"];

            if (lista == null) { dgvEmpleados.DataSource = null; dgvEmpleados.DataBind(); return; }

            if (string.IsNullOrWhiteSpace(txtFiltro.Text)) { CargarEmpleados(); return; }

            string buscar = txtFiltro.Text.Trim().ToLower();
            dgvEmpleados.DataSource = lista.FindAll(x =>
                x.nombre.ToLower().Contains(buscar) ||
                x.apellido.ToLower().Contains(buscar));
            dgvEmpleados.DataBind();
        }

        protected void chbAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            filtroAvanzado = chbAvanzado.Checked;
            txtFiltro.Enabled = !filtroAvanzado;
        }


        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e) { }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Empleado> lista = (List<Empleado>)Session["listarEmpleados"];

            if (lista == null) { dgvEmpleados.DataSource = null; dgvEmpleados.DataBind(); return; }

            List<Empleado> listaFiltrada = lista;

            // Estado
            if (ddlEstado.Text == "Activos")
                listaFiltrada = listaFiltrada.FindAll(x => x.Activo == true);
            else if (ddlEstado.Text == "Inactivos")
                listaFiltrada = listaFiltrada.FindAll(x => x.Activo == false);

            // Rol
            if (ddlRol.Text != "Todos")
                listaFiltrada = listaFiltrada.FindAll(x =>
                    x.rol.Equals(ddlRol.Text, StringComparison.OrdinalIgnoreCase));

            // Campo + texto
            string valor = txbFiltroA.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(valor))
            {
                switch (ddlCampo.Text)
                {
                    case "Nombre":
                        listaFiltrada = listaFiltrada.FindAll(x => x.nombre.ToLower().Contains(valor)); break;
                    case "Apellido":
                        listaFiltrada = listaFiltrada.FindAll(x => x.apellido.ToLower().Contains(valor)); break;
                    case "Usuario":
                        listaFiltrada = listaFiltrada.FindAll(x => x.usuario.ToLower().Contains(valor)); break;
                }
            }

            dgvEmpleados.DataSource = listaFiltrada;
            dgvEmpleados.DataBind();
        }


    }


}