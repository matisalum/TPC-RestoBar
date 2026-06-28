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

            if (!IsPostBack)
            {
                EmpleadoNegocio empleado = new EmpleadoNegocio();
                ddlEmpleados.DataSource = empleado.listarConSp();
                ddlEmpleados.DataTextField = "nombre";
                ddlEmpleados.DataValueField = "idEmpleado";
                ddlEmpleados.DataBind();
                ddlEmpleados.Items.Insert(0, new ListItem("Sin Asignar / Libre", ""));

                if (id != "")
                {
                    MesasNegocio mesa = new MesasNegocio();
                    Mesa select = mesa.filtrarId(int.Parse(id));

                    Session.Add("mesaS", select);

                    txtNumero.Text = select.numero.ToString();
                    txtCapacidad.Text = select.capacidad.ToString();

                    if(select.idEmpleado != null)
                    {
                        if(ddlEmpleados.Items.FindByValue(select.idEmpleado.ToString()) != null)
                        {
                            ddlEmpleados.SelectedValue = select.idEmpleado.ToString();
                        }
                    }
                    else
                    {
                        ddlEmpleados.SelectedValue = "";
                    }

                    if (!select.estado)
                        BtnInactivar.Text = "Reactivar";
                }
                else
                {
                    BtnInactivar.Visible = false;
                    btnLiberar.Visible = false;
                }
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
                //Valdidaciones de cantidad y numero positivos 
                lblMensajeN.Text = "";
                if (int.Parse(txtNumero.Text) <= 0)
                {
                    lblMensajeN.Text = "El numero de mesa debe ser mayor a 0";
                    return;
                }
                lblMensajeC.Text = "";
                if (int.Parse(txtCapacidad.Text) <= 0)
                {
                    lblMensajeC.Text = "La capacidad debe ser mayor a 0";
                    return;
                }
                //Asignacion
                nueva.numero = int.Parse(txtNumero.Text);
                nueva.capacidad = int.Parse(txtCapacidad.Text);

                // Evalua idEmpleado
                if(string.IsNullOrEmpty(ddlEmpleados.SelectedValue))
                {
                    nueva.idEmpleado = null;
                }
                else
                {
                    nueva.idEmpleado = int.Parse(ddlEmpleados.SelectedValue);
                }
                //Evalua idMESA
                if (Request.QueryString["id"] != null)
                {
                    Mesa aux = (Mesa)Session["mesaS"];
                    nueva.idMesa = int.Parse(Request.QueryString["id"]);
                    nueva.estado = aux.estado;
                    negocio.modificarConSp(nueva);
                }
                else
                    negocio.agregar(nueva);

                Response.Redirect("Mesas.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
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

        protected void btnLiberar_Click(object sender, EventArgs e)
        {
            try
            {
                Mesa nueva = (Mesa)Session["mesaS"];
                MesasNegocio negocio = new MesasNegocio();

                nueva.numero = int.Parse(txtNumero.Text);
                nueva.capacidad = int.Parse(txtCapacidad.Text);

                nueva.idEmpleado = null;

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
                //Session.Add("error", ex);
                throw ex;
            }
        }
    }
}