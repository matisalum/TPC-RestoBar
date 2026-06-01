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
                "server=localhost\\SQLEXPRESS;database=RestoBar;trusted_connection=true"
            );

            SqlCommand comando = new SqlCommand(
                "SELECT * FROM Empleado",
                conexion
            );

            conexion.Open();

            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Empleado aux = new Empleado();

                aux.idEmpleado = (int)lector["Id_Empleado"];
                aux.nombre = lector["NombreEmpleado"].ToString();
                aux.apellido = lector["ApellidoEmpleado"].ToString();
                aux.usuario = lector["Usuario"].ToString();
                aux.password = lector["Constrasenia"].ToString();
                aux.rol = lector["RolEmpleado"].ToString();
                aux.activo = (bool)lector["Activo"];

                lista.Add(aux);
            }

            conexion.Close();

            return lista;
        }
    }
}