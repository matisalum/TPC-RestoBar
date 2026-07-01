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
        public List<Empleado> listarConSp()
        {
            List<Empleado> lista = new List<Empleado>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearProcedimiento("storeListarEmpleado");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleado empleado = new Empleado();

                    empleado.idEmpleado = (int)datos.Lector["id"];
                    empleado.nombre = datos.Lector["Nombre"].ToString();
                    empleado.apellido = datos.Lector["Apellido"].ToString();
                    empleado.usuario = datos.Lector["Usuario"].ToString();
                    empleado.password = datos.Lector["Contrasena"].ToString();
                    empleado.rol = datos.Lector["Rol"].ToString();
                    empleado.Activo = (bool)datos.Lector["Estado"];


                    lista.Add(empleado);
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

        public void agregarConSp(Empleado nuevo)
        {
            AccesoADatos datos = new AccesoADatos();


            try
            {
                datos.setearProcedimiento("storeAltaEmpleado ");
                datos.setearParametro("@Nombre", nuevo.nombre);
                datos.setearParametro("@User", nuevo.usuario);
                datos.setearParametro("@Apellido", nuevo.apellido);
                datos.setearParametro("@Pass", nuevo.password);
                datos.setearParametro("@Estado", nuevo.Activo);
                datos.setearParametro("@Rol", nuevo.rol);
               

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

        public void modificarConSp(Empleado nuevo)
        {
            AccesoADatos datos = new AccesoADatos();


            try
            {
                datos.setearProcedimiento("storeModificarEmpleado ");
                datos.setearParametro("@Nombre", nuevo.nombre);
                datos.setearParametro("@User", nuevo.usuario);
                datos.setearParametro("@Apellido", nuevo.apellido);
                datos.setearParametro("@Pass", nuevo.password);
                datos.setearParametro("@Estado", nuevo.Activo);
                datos.setearParametro("@Rol", nuevo.rol);
                datos.setearParametro("@id", nuevo.idEmpleado);


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





        public Empleado obtenerPorId(int id)
        {

            AccesoADatos datos = new AccesoADatos();


            try
            {
                datos.setearConsulta("SELECT * FROM Empleado WHERE id=@id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    Empleado empleado = new Empleado();

                    empleado.idEmpleado = (int)datos.Lector["id"];
                    empleado.nombre = datos.Lector["Nombre"].ToString();
                    empleado.apellido = datos.Lector["Apellido"].ToString();
                    empleado.usuario = datos.Lector["Usuario"].ToString();
                    empleado.password = datos.Lector["Contrasena"].ToString();
                    empleado.rol = datos.Lector["Rol"].ToString();
                    empleado.Activo = (bool)datos.Lector["Estado"];



                    return empleado;
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

        public void eliminarLogico(int id, bool activo = false)
        {
            try
            {
                AccesoADatos datos = new AccesoADatos();
                datos.setearConsulta("update Empleado set Estado = @Activo where id=@id");
                datos.setearParametro("@id", id);
                datos.setearParametro("@Activo", activo);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool ExisteUsuario(string usuario)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Empleado WHERE Usuario = @Usuario");
                datos.setearParametro("@Usuario", usuario);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                    return (int)datos.Lector[0] > 0;

                return false;
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

        public bool Loguear(Empleado empleado)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.setearConsulta("SELECT ID, ROL FROM EMPLEADO WHERE @USUARIO = USUARIO AND @CONTRASENA = CONTRASENA");
                datos.setearParametro("@USUARIO", empleado.usuario);
                datos.setearParametro("@CONTRASENA", empleado.password);

                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    empleado.idEmpleado = (int)datos.Lector["ID"];
                    empleado.rol = (string)datos.Lector["ROL"];
                    return true;
                }
                return false;
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