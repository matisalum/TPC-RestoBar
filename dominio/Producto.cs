using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    internal class Producto
    {
        public int idProducto {  get; set; }
        public string nombre { get; set; }
        public decimal precio {  get; set; }
        public int stock { get; set; }
        bool activo { get; set; }
    }
}
