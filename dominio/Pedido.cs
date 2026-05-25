using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    internal class Pedido
    {
        public int idPedido { get; set; }

        public Mesa mesaPedido { get; set; }

        public Empleado empleadoMesa { get; set; }

        DateTime fechaPedido { get; set; }

       public bool estadoPedido { get; set; }

    }
}
