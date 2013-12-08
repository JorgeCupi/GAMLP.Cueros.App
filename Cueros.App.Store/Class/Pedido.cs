using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cueros.App.Core.Models;
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

        //private static List<Product> listPedidos;

        //public static List<Product> ListPedidos
        //{
        //    get { return Pedido.listPedidos; }
        //    set { Pedido.listPedidos = value; }
        //}
        
    }
}
