using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPORestobar
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Podrías poner una validación acá para que solo entren administradores:
                // if (Session["EmpleadoLogueado"] == null || ((Empleado)Session["EmpleadoLogueado"]).Perfil != "Admin") 
                //     Response.Redirect("Default.aspx");

                CargarReporteProductos();
                CargarReporteRecaudacion();
                CargarReporteMozos();
            }
        }

        private void CargarReporteProductos()
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                // Query que agrupa los detalles de pedidos cobrados/cerrados y suma las cantidades
                string query = @"SELECT ROW_NUMBER() OVER (ORDER BY SUM(dp.cantidad) DESC) AS Ranking,
                                        pr.nombre AS Producto, 
                                        SUM(dp.cantidad) AS CantidadVendida
                                 FROM DetallePedido dp
                                 INNER JOIN Producto pr ON dp.idProducto = pr.id
                                 INNER JOIN Pedido p ON dp.idPedido = p.id
                                 WHERE p.estado = 2 -- Asumiendo que 2 es 'Finalizado/Cobrado'
                                 GROUP BY pr.nombre";

                datos.setearConsulta(query);
                datos.ejecutarLectura();

                // Cargamos el GridView usando el Lector directamente
                dgvProductosMasVendidos.DataSource = datos.Lector;
                dgvProductosMasVendidos.DataBind();
            }
            catch (Exception ex)
            {
                // Manejo de error si falla
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private void CargarReporteRecaudacion()
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                // Ajustado: Usamos idPedido en lugar de id para enlazar las tablas
                string query = @"SELECT CAST(p.fechaPedido AS DATE) AS Fecha,
                                SUM(dp.cantidad * dp.precioUnitario) AS TotalRecaudado
                         FROM Pedido p
                         INNER JOIN DetallePedido dp ON p.idPedido = dp.idPedido
                         GROUP BY CAST(p.fechaPedido AS DATE)
                         ORDER BY Fecha DESC";

                datos.setearConsulta(query);
                datos.ejecutarLectura();

                dgvRecaudacionDiaria.DataSource = datos.Lector;
                dgvRecaudacionDiaria.DataBind();
            }
            catch (Exception ex)
            {
                // Si falla, te va a escribir el error exacto de SQL en la consola de Visual Studio
                System.Diagnostics.Debug.WriteLine("ERROR RECAUDACION: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private void CargarReporteMozos()
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                // Ajustado: Enlazamos por idPedido y idEmpleado según tus clases originales
                string query = @"SELECT (e.nombre + ' ' + e.apellido) AS Mozo,
                                SUM(dp.cantidad * dp.precioUnitario) AS TotalFacturado
                         FROM Pedido p
                         INNER JOIN DetallePedido dp ON p.idPedido = dp.idPedido
                         INNER JOIN Empleado e ON p.idEmpleado = e.idEmpleado
                         GROUP BY e.nombre, e.apellido
                         ORDER BY TotalFacturado DESC";

                datos.setearConsulta(query);
                datos.ejecutarLectura();

                dgvRendimientoMozos.DataSource = datos.Lector;
                dgvRendimientoMozos.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR MOZOS: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}