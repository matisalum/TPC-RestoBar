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
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string consulta = "SELECT ID, NUMERO, CAPACIDAD, ESTADO, IDEMPLEADO FROM MESA";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Mesa mesa = new Mesa();

                    if (!(datos.Lector["ID"] is DBNull))
                        mesa.idMesa = (int)datos.Lector["ID"];
                    else
                        mesa.idMesa = -1;
                    if (!(datos.Lector["NUMERO"] is DBNull))
                        mesa.numero = (int)datos.Lector["NUMERO"];
                    else
                        mesa.numero = -1;
                    if (!(datos.Lector["CAPACIDAD"] is DBNull))
                        mesa.capacidad = (int)datos.Lector["CAPACIDAD"];
                    else
                        mesa.capacidad = -1;
                    if (!(datos.Lector["ESTADO"] is DBNull))
                        mesa.estado = (bool)datos.Lector["ESTADO"];
                    else
                        mesa.estado = false;
                    if (!(datos.Lector["IDEMPLEADO"] is DBNull))
                        mesa.idEmpleado = (int)datos.Lector["IDEMPLEADO"];
                    else
                        mesa.idEmpleado = -1;

                    lista.Add(mesa);

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
        public void agregar(Mesa nuevo)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("INSERT INTO MESA (NUMERO, CAPACIDAD) VALUES (@NUMERO, @CAPACIDAD)");
                datos.setearParametro("@NUMERO", nuevo.numero);
                datos.setearParametro("@CAPACIDAD", nuevo.capacidad);

                datos.ejecutarAccion();
            }
            catch (Exception)
            {

            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }

}
