using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Pedido
    {
        public int idPedido { get; set; }

        public Mesa mesaPedido { get; set; }

        public Empleado empleadoMesa { get; set; }

       public DateTime fechaPedido { get; set; }

       public int estadoPedido { get; set; }

    }
}
