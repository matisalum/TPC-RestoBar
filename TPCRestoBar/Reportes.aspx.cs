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

                
                dgvProductosMasVendidos.DataSource = datos.Lector;
                dgvProductosMasVendidos.DataBind();
            }
            catch (Exception ex)
            {
                
                System.Diagnostics.Debug.WriteLine("ERROR: " + ex.Message);
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
                
                 string query = @"SELECT CAST(p.fechaPedido AS DATE) AS Fecha,
                                       SUM(dp.cantidad * pr.precio) AS TotalRecaudado
                                FROM Pedido p
                                INNER JOIN DetallePedido dp ON p.id = dp.idPedido
                                INNER JOIN Producto pr ON pr.id = dp.idProducto
                                WHERE p.estado = 2
                                GROUP BY CAST(p.fechaPedido AS DATE)
                                ORDER BY Fecha DESC";

                datos.setearConsulta(query);
                datos.ejecutarLectura();

                dgvRecaudacionDiaria.DataSource = datos.Lector;
                dgvRecaudacionDiaria.DataBind();
            }
            catch (Exception ex)
            {
                
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
                
                string query = @"SELECT (e.nombre + ' ' + e.apellido) AS Mozo,
                                   SUM(dp.cantidad * pr.precio) AS TotalFacturado
                            FROM Pedido p
                            INNER JOIN DetallePedido dp ON p.id = dp.idPedido
                            INNER JOIN Producto pr ON pr.id = dp.idProducto
                            INNER JOIN Empleado e ON e.id = p.idEmpleado
                            WHERE p.estado = 2
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