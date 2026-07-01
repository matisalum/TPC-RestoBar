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
            //listaMesas = listaMesas.FindAll(x => x.estado == true);
            listaMesas = listaMesas.FindAll(x => x.idEmpleado != -1);

            repRepetidor.DataSource = listaMesas;
            repRepetidor.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 1. Intentamos traer el empleado de la sesión
                Empleado empleadoActual = (Empleado)Session["EmpleadoLogueado"];

                // 2. DESACTIVACIÓN TEMPORAL DEL LOGIN:
                // Si es nulo, creamos un empleado de prueba para poder testear todo el flujo
                if (empleadoActual == null)
                {
                    empleadoActual = new Empleado();
                    empleadoActual.idEmpleado = 2; // Poné acá el ID de un mozo que ya tengas cargado en tu Base de Datos
                                                   // empleadoActual.nombre = "Mozo de Prueba"; // Por si usás el nombre en algún lado

                    // Lo guardamos en la sesión para que el resto de las pantallas (como la Cartilla) también lo usen
                    Session["EmpleadoLogueado"] = empleadoActual;
                }

                // 3. Continuamos con la carga normal usando el empleado (ya sea el real o el de prueba)
                cargarMesasDelMozo(empleadoActual.idEmpleado);
                cargarCartas();
            }
        }

        /* protected void Page_Load(object sender, EventArgs e)
         {
             if (!IsPostBack)
             {
                 // Reutilizamos el empleado que tenés en sesión
                 Empleado empleadoActual = (Empleado)Session["EmpleadoLogueado"];

                 if (empleadoActual != null)
                 {
                     cargarMesasDelMozo(empleadoActual.idEmpleado);
                 }
                 else
                 {
                     // Si no hay empleado en sesión, redirigir al Login
                     Response.Redirect("Login.aspx");
                 }
             }
         }
        */
        protected void btnNPedido_Click(object sender, EventArgs e)
        {
            // Capturamos el idMesa del botón presionado
            Button btn = (Button)sender;
            int idMesaSeleccionada = Convert.ToInt32(btn.CommandArgument);

            // Buscamos los datos completos de esa mesa para guardarla en Sesión
            Mesa mesaSeleccionada = obtenerMesaPorId(idMesaSeleccionada);
            Session["MesaActual"] = mesaSeleccionada;

            // Dependiendo del estado de la mesa, decidimos a dónde va:
            if (mesaSeleccionada.estado)
            {
                // ETAPA 14: Si está ocupada, va a ver el pedido abierto
                Response.Redirect("VerPedido.aspx");
            }
            else
            {
                // Si está libre, va a la carta para empezar el carrito
                Response.Redirect("Cartilla.aspx");
            }
        }

        private Mesa obtenerMesaPorId(int idMesa)
        {
            AccesoADatos datos = new AccesoADatos();
            Mesa mesa = null;
            try
            {
                // CORREGIDO: Cambiado "Mesas" por "Mesa" e igualadas las mayúsculas/minúsculas de tu DB
                datos.setearConsulta("SELECT id AS idMesa, Numero, Capacidad, Estado, idEmpleado FROM Mesa WHERE id = @idMesa");
                datos.setearParametro("@idMesa", idMesa);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    mesa = new Mesa();
                    mesa.idMesa = Convert.ToInt32(datos.Lector["idMesa"]);
                    mesa.numero = Convert.ToInt32(datos.Lector["Numero"]);
                    mesa.capacidad = Convert.ToInt32(datos.Lector["Capacidad"]);

                    // Conversión segura de estado
                    string estadoString = datos.Lector["Estado"].ToString();
                    mesa.estado = (estadoString == "1" || estadoString.ToLower() == "true");

                    mesa.idEmpleado = datos.Lector["idEmpleado"] != DBNull.Value ? (int?)Convert.ToInt32(datos.Lector["idEmpleado"]) : null;
                }
                return mesa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private void cargarMesasDelMozo(int idEmpleado)
        {
            List<Mesa> listaMesas = new List<Mesa>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                // Traemos las columnas tal cual coinciden con tu base de datos.
                // Nota: Si la primera columna de tu tabla Mesa se llama 'id' en lugar de 'idMesa', 
                // usamos "id AS idMesa" para renombrarla y que tu objeto C# la reciba bien.
                datos.setearConsulta("SELECT id AS idMesa, Numero, Capacidad, Estado, idEmpleado FROM Mesa WHERE idEmpleado = @idEmpleado");
                datos.setearParametro("@idEmpleado", idEmpleado);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Mesa aux = new Mesa();

                    // Leemos usando conversiones seguras
                    aux.idMesa = Convert.ToInt32(datos.Lector["idMesa"]);
                    aux.numero = Convert.ToInt32(datos.Lector["Numero"]);
                    aux.capacidad = Convert.ToInt32(datos.Lector["Capacidad"]);

                    // Evaluamos el estado: si en tu tabla el Estado 'Activo' (visto en tu grilla) 
                    // se guarda como un número 1 o 0 (o true/false), lo convertimos de forma segura:
                    string estadoString = datos.Lector["Estado"].ToString();
                    aux.estado = (estadoString == "1" || estadoString.ToLower() == "true");

                    aux.idEmpleado = idEmpleado;

                    listaMesas.Add(aux);
                }

                // Enlazamos al Repeater
                repRepetidor.DataSource = listaMesas;
                repRepetidor.DataBind();
            }
            catch (Exception ex)
            {
                // PARCHE DE DIAGNÓSTICO: Si hay un error de nombres de columna, 
                // esto va a imprimir el error exacto arriba de todo en tu pantalla web
                Response.Write("<script>alert('Error en la carga: " + ex.Message.Replace("'", "\\'") + "');</script>");
            }
            finally
            {
                datos.cerrarConexion();
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

       /* protected void btnNPedido_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
            MesasNegocio negocio = new MesasNegocio();
            EmpleadoNegocio negocio2 = new EmpleadoNegocio();
            if (string.IsNullOrEmpty(valor))
                return;

            Mesa mesa = negocio.filtrarId(int.Parse(valor));

            Pedido pedido = new Pedido
            {
                //Datos provisorios / actualizar cuando tegamos login
                mesa = mesa,
                empleado = negocio2.obtenerPorId(12),
                fechaPedido = DateTime.Now,
                estadoPedido = Pedido.EstadoPedido.Pendiente,
                Detalles = new List<DetallePedido>()
            };
            //Guarda el pedido con los datos de la mesa seleccionada
            Session["PedidoActual"] = pedido;

            Response.Redirect("Carta.aspx");
        }*/
    }
}