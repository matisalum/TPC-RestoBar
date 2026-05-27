using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dominio
{
    public class Empleado
    {
        public int idEmpleado { get; set; }
        public string nombre{ get; set; }
        public string apellido { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string rol { get; set; }
        public bool activo { get; set; }
        
    }
}