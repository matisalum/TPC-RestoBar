using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    internal class DetallePedido
    {
        public int IdDetalle {  get; set; }
        public Producto producto { get; set; }

        public Pedido pedido { get; set; }
        public int cantidad { get; set; }

    }
}
