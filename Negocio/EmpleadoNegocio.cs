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
    { public List<Empleado> listar ()
        {
            List<Empleado> lista = new List<Empleado>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                ///Trae todos los articulos tengan campos "validos" o no
                string consulta = "SELECT id_Empleado, Usuario, NombreEmpleado, ApellidoEmpleado, Constraseña, RolEmpleado, Activo";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleado empledo = new Empleado();

                    empledo.idEmpleado = (int)datos.Lector["id_Empleado"];
                    empledo.usuario = (string)datos.Lector ["Usuario"];
                    empledo.nombre = (string)datos.Lector["NombreEmpleado"];
                    empledo.apellido = (string)datos.Lector["ApellidoEmpleado"];
                    empledo.password = (string)datos.Lector["Constraseña"];
                    empledo.rol = (string)datos.Lector["RolEmpleado"];
                    empledo.activo = (bool)datos.Lector["Activo"];

                    


                    lista.Add(empledo);

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
