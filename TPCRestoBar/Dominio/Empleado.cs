using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPCRestoBar.Dominio
{
    public class Empleado
    {
        public int id { get; set; }
        public string nombre{ get; set; }
        public string apellido { get; set; }
        public string usuario { get; set; }
        public string passaword { get; set; }
        public string irold { get; set; }
        public bool activo { get; set; }
        
    }
}