using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
			List<Categoria> lista = new List<Categoria>(); 
			AccesoADatos datos = new AccesoADatos();
			
			try
			{
				string consulta = "SELECT ID, NOMBRE, ESTADO FROM CATEGORIA ";
				datos.setearConsulta(consulta);
				datos.ejecutarLectura();

				while(datos.Lector.Read())
				{
					Categoria cat = new Categoria();
					if (!(datos.Lector["ID"] is DBNull))
						cat.Id = (int)datos.Lector["ID"];
					else
						cat.Id = -1;
					if (!(datos.Lector["NOMBRE"] is DBNull))
						cat.Nombre = (string)datos.Lector["NOMBRE"];
					else
						cat.Nombre = "";
					if (!(datos.Lector["ESTADO"] is DBNull))
						cat.Estado = (bool)datos.Lector["ESTADO"];
					else
						cat.Estado = true;

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
		public void agregar(Categoria cat)
		{
			AccesoADatos datos = new AccesoADatos();
			try
			{
				datos.setearConsulta("INSERT INTO CATEGORIA (NOMBRE, ESTADO) VALUES (@NOMBRE, @ESTADO)");
				datos.setearParametro("@NOMBRE", (string)cat.Nombre);
				datos.setearParametro("@ESTADO", true);

				datos.ejecutarAccion();
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				datos.cerrarConexion();
			}
		}
        public Categoria filtrarId(int id)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("SELECT * FROM CATEGORIA WHERE id=@id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    Categoria cat = new Categoria();

                    if (!(datos.Lector["ID"] is DBNull))
                        cat.Id = (int)datos.Lector["ID"];
                    else
                        cat.Id = -1;
                    if (!(datos.Lector["NOMBRE"] is DBNull))
                        cat.Nombre = (string)datos.Lector["NOMBRE"];
                    else
                        cat.Nombre = "";
                    if (!(datos.Lector["ESTADO"] is DBNull))
                        cat.Estado = (bool)datos.Lector["ESTADO"];
                    else
                        cat.Estado = true;
                   

                    return cat;
                }
                else
                {
                    return null;
                }

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
        public void modificarConSp(Categoria cat)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.setearProcedimiento("storeModificarCategoria");
                datos.setearParametro("@id", cat.Id);
                datos.setearParametro("@Nombre", cat.Nombre);
                datos.setearParametro("@Estado", cat.Estado);

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
        public void eliminacionLogica(int id, bool estado = false)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.setearConsulta("UPDATE CATEGORIA SET ESTADO = @estado WHERE ID = @id");
                datos.setearParametro("@id", id);
                datos.setearParametro("@estado", estado);
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
