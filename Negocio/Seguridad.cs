using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(object user)
        {
            Empleado empleado = user != null ? (Empleado)user : null;
            if (empleado != null && empleado.idEmpleado != 0)
            {
                return true;
            }
            else
                return false;
        }
        public static bool esAdmin(object user)
        {
            if (user == null)
                return false;

            Empleado empleado = (Empleado)user;

            return empleado.rol.Equals("Gerente", StringComparison.OrdinalIgnoreCase);
        }
    }
}
