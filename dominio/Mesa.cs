using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Mesa
    {
        public int idMesa { get; set; }
        public int numero { get; set; }
        public int capacidad { get; set; }
        public bool estado { get; set; }
        public int? idEmpleado { get; set; }
    }

}
