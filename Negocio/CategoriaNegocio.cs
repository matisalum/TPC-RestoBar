using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Negocio
{
    internal class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
			List<Categoria> lista = new List<Categoria>(); 
			AccesoADatos datos = new AccesoADatos();
			
			try
			{
				string consulta = "SELECT ID, DESCRIPCION FROM CATEGORIA ";
				datos.setearConsulta(consulta);
				datos.ejecutarAccion();

				while(datos.Lector.Read())
				{
					Categoria cat = new Categoria();
					if (!(datos.Lector["ID"] is DBNull))
						cat.Id = (int)datos.Lector["ID"];
					else
						cat.Id = -1;
					if (!(datos.Lector["DESCRIPCION"] is DBNull))
						cat.Desccripcion = (string)datos.Lector["DESCRIPCION"];
					else
						cat.Desccripcion = "";

					lista.Add(cat);
				}

				return lista;
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
