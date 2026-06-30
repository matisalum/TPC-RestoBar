using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using dominio;

namespace TPCRestoBar
{
    public partial class MasasMeseros : System.Web.UI.Page
    {
        public List<Mesa> listaMesas { get; set; }
        private void cargarCartas()
        {
            MesasNegocio negocio = new MesasNegocio();
            listaMesas = negocio.listar();
            listaMesas = listaMesas.FindAll(x => x.estado == true);
            listaMesas = listaMesas.FindAll(x => x.idEmpleado != -1);

            repRepetidor.DataSource = listaMesas;
            repRepetidor.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                cargarCartas();
            }
        }

        protected void btnLiberar_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
            MesasNegocio negocio = new MesasNegocio();

            try
            {
                if (string.IsNullOrEmpty(valor))
                    return;

                Mesa mesa = negocio.filtrarId(int.Parse(valor));

                mesa.idEmpleado = null;
                negocio.modificarConSp(mesa);
                cargarCartas();

            }
            catch (Exception ex)
            {
                Session.Add("error",ex);
                throw;
            }
        }

        protected void btnNPedido_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;

            Response.Redirect("Carta.aspx");
        }
    }
}