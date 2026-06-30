using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class DetallePedido
    {

        public int IdDetalle { get; set; }
        public Producto Producto { get; set; }
        public Pedido Pedido { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal
        {
            get
            {
                return Cantidad *  PrecioUnitario;
            }
        }
    }
}
