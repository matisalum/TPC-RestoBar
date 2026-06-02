using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace Negocio
{
    public class MesasNegocio
    {
        public List<Mesa> listar()
        {
            List<Mesa> lista = new List<Mesa>();

            SqlConnection conexion = new SqlConnection(
                   "server=localhost\\SQLEXPRESS;database=RestoDB;trusted_connection=true"
               );

            SqlCommand comando = new SqlCommand(
                "SELECT * FROM Mesa",
                conexion
            );


            conexion.Open();

            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Mesa mesa = new Mesa();

                mesa.idMesa = (int)lector["IdMesa"];
                mesa.numero = (int)lector["Numero"];
                mesa.capadicad = (int)lector["Capacidad"];
                mesa.estado = (bool)lector["Estado"];

                lista.Add(mesa);

            }

            conexion.Close();

            return lista;

        }

    }
}
