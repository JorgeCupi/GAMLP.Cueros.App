using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cueros.App.Store.Class
{
    public static class Pedido
    {
        private static List<RequestProduct> pedido;
        public static List<RequestProduct> Pedidos
        {
            get { return pedido; }
            set { pedido = value; }
        }

    }
}
