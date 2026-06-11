using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;

namespace TPCRestoBar
{
    public partial class FormularioMesa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mesas.aspx");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Mesa nueva = new Mesa();
                MesasNegocio negocio = new MesasNegocio();

                nueva.numero = int.Parse(txtNumero.Text);
                nueva.capacidad = int.Parse(txtCapacidad.Text);

                negocio.agregar(nueva);

                Response.Redirect("Mesas.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}