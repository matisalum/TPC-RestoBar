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
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "" && !IsPostBack)
            {
                MesasNegocio mesa = new MesasNegocio();
                Mesa select = mesa.filtrarId(int.Parse(id));

                Session.Add("mesaS", select);

                txtNumero.Text = select.numero.ToString();
                txtCapacidad.Text = select.capacidad.ToString();

                if (!select.estado)
                    BtnInactivar.Text = "Reactivar";
            }
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
                nueva.estado = true;

                if (Request.QueryString["id"] != null)
                {
                    nueva.idMesa = int.Parse(Request.QueryString["id"]);
                    negocio.modificarConSp(nueva);
                }
                else
                    negocio.agregar(nueva);

                Response.Redirect("Mesas.aspx");           
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void BtnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                MesasNegocio negocio = new MesasNegocio();
                Mesa select = (Mesa)Session["mesaS"];

                negocio.eliminacionLogica(select.idMesa, !select.estado);
                Response.Redirect("Mesas.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}