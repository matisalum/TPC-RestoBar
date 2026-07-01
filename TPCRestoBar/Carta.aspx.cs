using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace TPCRestoBar
{
    public partial class Carta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Pedido pedido = (Pedido)Session["PedidoActual"];
            if (!IsPostBack)
            {

                if (!IsPostBack)
                {
                    CategoriaNegocio negocio = new CategoriaNegocio();

                    ddlCategoria.DataSource = negocio.listar();

                    ddlCategoria.DataTextField = "Nombre";

                    ddlCategoria.DataValueField = "Id";

                    ddlCategoria.DataBind();

                    ddlCategoria.Items.Insert(0, new ListItem("Todas las categorías", "0"));


                    ProductoNegocio prod = new ProductoNegocio();

                    repProductos.DataSource = prod.listarCarta();

                    repProductos.DataBind();
                }
            }
        }
        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            ProductoNegocio negocio = new ProductoNegocio();

            List<Producto> lista = negocio.listarCarta();

            lista = lista.FindAll(x => x.nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));

            repProductos.DataSource = lista;

            repProductos.DataBind();

        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductoNegocio negocio =
                new ProductoNegocio();

            List<Producto> lista =
                negocio.listarCarta();

            int id =
                int.Parse(ddlCategoria.SelectedValue);

            if (id != 0)
            {
                lista = lista.FindAll(
                    x => x.idCategoria == id);
            }

            repProductos.DataSource = lista;
            repProductos.DataBind();
        }

        private void CargarGrid()
        {
            dgvPedido.DataSource = Carrito;
            dgvPedido.DataBind();
        }

        protected void btnAgregar_Click( object sender, EventArgs e)
        { 
            Button btn =  (Button)sender;

            int idProducto = Convert.ToInt32( btn.CommandArgument );
             
            ProductoNegocio negocio = new ProductoNegocio();
             
            Producto prod = negocio.obtenerPorId( idProducto );


            DetallePedido item = Carrito.Find( x => x.Producto.idProducto ==  idProducto );


            if (item == null)
            {

                item =  new DetallePedido();

                item.Producto = prod;

                item.Cantidad = 1;

                item.PrecioUnitario = prod.precio;

                Carrito.Add(item);

            }

            else
            { 
                item.Cantidad++; 
            }
             
            CargarGrid();

        }

        protected void btnRestar_Click( object sender, EventArgs e)
        {

            Button btn =  (Button)sender;

            int id = Convert.ToInt32( btn.CommandArgument );

            DetallePedido item =  Carrito.Find(  x => x.Producto.idProducto  == id  );


            if (item != null)
            { 
                item.Cantidad--;

                if (item.Cantidad <= 0)

                    Carrito.Remove(item); 
            } 

            CargarGrid();

        }

        protected void btnNPedido_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int idMesa = Convert.ToInt32(btn.CommandArgument);

            Response.Redirect( "Carta.aspx?idMesa="  + idMesa );

        }
        private List<DetallePedido> Carrito
        {
            get
            {
                if (Session["Carrito"] == null)
                    Session["Carrito"] = new List<DetallePedido>();

                return (List<DetallePedido>)
                    Session["Carrito"];
            }

            set
            {
                Session["Carrito"] = value;
            }
        }


        protected void btnConfirmar_Click( object sender, EventArgs e)
        {

            Pedido pedido = new Pedido();

            pedido.fechaPedido =
                DateTime.Now;

            pedido.Detalles =
                Carrito;

            pedido.estadoPedido =
                Pedido.EstadoPedido.Pendiente;

            Mesa mesa = (Mesa)Session["MesaActual"];

            pedido.mesa = mesa;

            pedido.empleado = new Empleado();

            pedido.empleado.idEmpleado = mesa.idEmpleado.Value;

            PedidoNegocio negocio = new PedidoNegocio();
            negocio.GuardarPedido( pedido);

            Session.Remove("Carrito");

            Response.Redirect(
                "MasasMeseros.aspx");
        }


        /*protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Recuperamos el carrito y datos de la sesión
            List<DetallePedido> carrito = (List<DetallePedido>)Session["Carrito"];
            Mesa mesaActual = (Mesa)Session["MesaActual"];
            Empleado empleadoActual = (Empleado)Session["EmpleadoLogueado"];

            if (carrito == null || carrito.Count == 0)
            {
                Response.Write("<script>alert('El carrito está vacío');</script>");
                return;
            }

            // =========================================================================
            // CASO A: MODO EDICIÓN
            // =========================================================================
            if (mesaActual != null && mesaActual.estado == true)
            {
                AccesoADatos datosBusqueda = new AccesoADatos();
                try
                {
                    // Limpiamos cualquier error previo
                    lblErrorBD.Text = "";

                    // 1. Buscamos el ID del pedido usando las columnas genéricas 'id' y 'estado'
                    
                    datosBusqueda.setearConsulta("SELECT id FROM Pedido WHERE idMesa = @idMesa AND estado = 0");
                    datosBusqueda.setearParametro("@idMesa", mesaActual.idMesa);
                    datosBusqueda.ejecutarLectura();

                    int idPedidoExistente = 0;
                    if (datosBusqueda.Lector.Read())
                    {
                        idPedidoExistente = Convert.ToInt32(datosBusqueda.Lector["id"]);
                    }
                    datosBusqueda.cerrarConexion();

                    if (idPedidoExistente > 0)
                    {
                        // 2. Borramos el detalle viejo de ese pedido
                        AccesoADatos datosDelete = new AccesoADatos();
                        datosDelete.setearConsulta("DELETE FROM DetallePedido WHERE idPedido = @idPedido");
                        datosDelete.setearParametro("@idPedido", idPedidoExistente);
                        datosDelete.ejecutarAccion();

                        // 3. Insertamos el nuevo estado del carrito
                        foreach (var detalle in carrito)
                        {
                            AccesoADatos datosDetalle = new AccesoADatos();
                            string consultaDetalle = "INSERT INTO DetallePedido (idPedido, idProducto, cantidad, precioUnitario) " +
                                                     "VALUES (@idPedido, @idProducto, @cantidad, @precioUnitario)";

                            datosDetalle.setearConsulta(consultaDetalle);
                            datosDetalle.setearParametro("@idPedido", idPedidoExistente);
                            datosDetalle.setearParametro("@idProducto", detalle.Producto.idProducto);
                            datosDetalle.setearParametro("@cantidad", detalle.Cantidad);
                            datosDetalle.setearParametro("@precioUnitario", detalle.Producto.precio);

                            datosDetalle.ejecutarAccion();
                        }

                        // Limpiamos la sesión del carrito
                        Session["Carrito"] = null;

                        // Redireccionamos al panel general
                        Response.Redirect("MasasMeseros.aspx");
                    }
                    else
                    {
                        lblErrorBD.Text = "⚠️ No se encontró un pedido activo en la base de datos para esta mesa.";
                    }
                }
                catch (Exception ex)
                {
                    // CORREGIDO: Mapeamos el error en el Label para evitar el congelamiento de la página
                    lblErrorBD.Text = "❌ ERROR EN BASE DE DATOS: " + ex.Message;
                }
                finally
                {
                    datosBusqueda.cerrarConexion();
                }
            }
            // =========================================================================
            // CASO B: MODO NUEVO PEDIDO (Tu código base original corregido en nombres de tablas)
            // =========================================================================
            else
            {
                AccesoADatos datos = new AccesoADatos();
                try
                {
                    // ETAPA 10: Guardar Pedido Cabecera (Cambiado a 'Pedido')
                    string consultaPedido = "INSERT INTO Pedido (idMesa, idEmpleado, fechaPedido, estadoPedido) " +
                                            "OUTPUT INSERTED.idPedido " +
                                            "VALUES (@idMesa, @idEmpleado, @fechaPedido, @estadoPedido)";

                    datos.setearConsulta(consultaPedido);
                    datos.setearParametro("@idMesa", mesaActual.idMesa);
                    datos.setearParametro("@idEmpleado", empleadoActual.idEmpleado);
                    datos.setearParametro("@fechaPedido", DateTime.Now);
                    datos.setearParametro("@estadoPedido", 0); // 0 = Pendiente

                    // Reemplazá 'ejecutarAccionScalar' por el método equivalente que tengas en tu clase AccesoADatos
                    int idPedidoGenerado = datos.ejecutarAccionScalar();

                    // ETAPA 11: Guardar DetallePedido (Cambiado a 'DetallePedido')
                    foreach (var detalle in carrito)
                    {
                        AccesoADatos datosDetalle = new AccesoADatos();
                        string consultaDetalle = "INSERT INTO DetallePedido (idPedido, idProducto, cantidad, precioUnitario) " +
                                                 "VALUES (@idPedido, @idProducto, @cantidad, @precioUnitario)";

                        datosDetalle.setearConsulta(consultaDetalle);
                        datosDetalle.setearParametro("@idPedido", idPedidoGenerado);
                        datosDetalle.setearParametro("@idProducto", detalle.Producto.idProducto);
                        datosDetalle.setearParametro("@cantidad", detalle.Cantidad);
                        datosDetalle.setearParametro("@precioUnitario", detalle.Producto.precio);

                        datosDetalle.ejecutarAccion();
                    }

                    // ETAPA 12: Cambiar estado de mesa (En singular 'Mesa' y filtrando por 'id')
                    AccesoADatos datosMesa = new AccesoADatos();
                    string consultaMesa = "UPDATE Mesa SET Estado = 1 WHERE id = @idMesa";
                    datosMesa.setearConsulta(consultaMesa);
                    datosMesa.setearParametro("@idMesa", mesaActual.idMesa);
                    datosMesa.ejecutarAccion();

                    // Limpiamos la sesión tras el éxito
                    Session["Carrito"] = null;

                    // Redireccionamos a tu pantalla del listado
                    Response.Redirect("MasasMeseros.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error al crear nuevo pedido: " + ex.Message.Replace("'", "\\'") + "');</script>");
                }
            }
        }*/
    }
}