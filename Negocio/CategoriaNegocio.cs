using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

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
				string consulta = "SELECT ID, NOMBRE ,DESCRIPCION FROM CATEGORIA ";
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
					if (!(datos.Lector["DESCRIPCION"] is DBNull))
						cat.Descripcion = (string)datos.Lector["DESCRIPCION"];
					else
						cat.Descripcion = "";

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
				datos.setearConsulta("INSERT INTO CATEGORIA (NOMBRE, DESCRIPCION) VALUES (@NOMBRE, @DESCRIPCION)");
				datos.setearParametro("@NOMBRE", (string)cat.Nombre);
				datos.setearParametro("@DESCRIPCION", (string)cat.Descripcion);

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
                    if (!(datos.Lector["DESCRIPCION"] is DBNull))
                        cat.Descripcion = (string)datos.Lector["DESCRIPCION"];
                    else
                        cat.Descripcion = "";
                   

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
                datos.setearParametro("@Descripcion", cat.Descripcion);

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
