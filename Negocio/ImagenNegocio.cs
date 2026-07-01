using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> listar()
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "SELECT ID, URL FROM IMAGEN";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen img = new Imagen();

                    if (!(datos.Lector["ID"] is DBNull))
                        img.id = (int)datos.Lector["ID"];
                    else
                        img.id = -1;
                    if (!(datos.Lector["URL"] is DBNull))
                        img.Url = (string)datos.Lector["URL"];
                    else
                        img.Url = "https://i.pinimg.com/736x/43/3a/83/433a83a38b10d863c0b9b911a50bb2ee.jpg";

                    lista.Add(img);
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
        public void agregar(Imagen nuevo)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("INSERT INTO IMAGEN (URL) VALUES (@URL)");
                datos.setearParametro("@URL", nuevo.Url);

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
        public Imagen filtrarId(int id)
        {

            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("SELECT URL FROM IMAGEN WHERE id=@id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    Imagen img = new Imagen();

                    if (!(datos.Lector["URL"] is DBNull))
                        img.Url = (string)datos.Lector["URL"];
                    else
                        img.Url = "https://i.pinimg.com/736x/43/3a/83/433a83a38b10d863c0b9b911a50bb2ee.jpg";

                    return img;
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
        public void modificar(Imagen img)
        {
            try
            {
                AccesoADatos datos = new AccesoADatos();

                datos.setearConsulta(@"UPDATE Imagen SET Url = @url WHERE id = (SELECT idImagen FROM Producto WHERE id = @id)");

                datos.setearParametro("@url", img.Url);
                datos.setearParametro("@id", img.id);

                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
