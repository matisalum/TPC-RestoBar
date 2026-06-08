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
                empleado.Rol = (bool)lector["Gerente"];
                empleado.activo = (bool)lector["Activo"];

                lista.Add(empleado);
            }

            conexion.Close();

            return lista;
        }
    }
}