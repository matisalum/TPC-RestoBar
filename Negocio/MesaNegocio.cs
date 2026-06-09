using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    internal class MesaNegocio
    {
        public List<Mesa> listar()
        {
            List<Mesa> lista = new List<Mesa>();

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
                Mesa aux = new Mesa();

                aux.idMesa = (int)lector["Id_Mesa"];
                aux.numero = lector["NumeroMesa"].ToString();
                aux.capacidad = lector["Capacidad"].ToString();
                aux.estado = (bool)lector["Estado"];
               
                lista.Add(aux);
            }

            conexion.Close();

            return lista;
        }
    }
}
