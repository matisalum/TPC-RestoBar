using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Negocio
{
    public class EmpleadoNegocio
    {
        public List<Empleado> listar()
        {
            List<Empleado> lista = new List<Empleado>();

            SqlConnection conexion = new SqlConnection(
                "server=localhost\\SQLEXPRESS;database=RestoDB;trusted_connection=true"
            );

            SqlCommand comando = new SqlCommand(
                "SELECT * FROM Empleado",
                conexion
            );

            conexion.Open();

            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Empleado empleado = new Empleado();

                empleado.idEmpleado = (int)lector["id"];
                empleado.nombre = lector["Nombre"].ToString();
                empleado.apellido = lector["Apellido"].ToString();
                empleado.usuario = lector["Usuario"].ToString();
                empleado.password = lector["Contrasena"].ToString();
                empleado.rol = lector["Rol"].ToString();
                empleado.estado = (bool)lector["Activo"];
      

                lista.Add(empleado);
            }

            conexion.Close();

            return lista;
        }

        public void agregar(Empleado nuevo)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("Insert into Empleado (Nombre, Usuario, Apellido, Contrasena, Estado, Rol) values ( @Nombre, @User, @Apellido, @Pass, @Estado, @Rol) ");
                datos.setearParametro("@Nombre", nuevo.nombre);
                datos.setearParametro("@User", nuevo.usuario);
                datos.setearParametro("@Apellido", nuevo.apellido);
                datos.setearParametro("@Pass", nuevo.password);
                datos.setearParametro("@Estado", nuevo.estado);
                datos.setearParametro("@Rol", nuevo.rol);
               

                datos.ejecutarAccion();

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

    }
}