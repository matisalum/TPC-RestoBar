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

        public Mesa mesa { get; set; }

        public Empleado empleado { get; set; }

        public DateTime fechaPedido { get; set; }

        public byte estadoPedido { get; set; }

        public string EstadoTexto
        {

            get
            {

                switch (estadoPedido)
                {
                    case 0:
                        return "Pendiente";

                    case 1:
                        return "En preparación";

                    case 2:
                        return "Listo";

                    case 3:
                        return "Entregado";

                    case 4:
                        return "Cancelado";


                    default:
                        return "Desconocido";

                }
            }

        }

    }
}
