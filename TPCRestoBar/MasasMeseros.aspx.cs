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
        protected void Page_Load(object sender, EventArgs e)
        {
            MesasNegocio negocio = new MesasNegocio();
            listaMesas = negocio.listar();
            listaMesas = listaMesas.FindAll(x => x.estado == true);

            if(!IsPostBack)
            {
                repRepetidor.DataSource = listaMesas;
                repRepetidor.DataBind();
            }
        }

        protected void btnLiberar_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
        }
    }
}