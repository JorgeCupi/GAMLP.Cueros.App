using System;
using System.Collections.Generic;

namespace Cueros.App.Core.Models
{
    public class Pedido
    {
        public string Id { get; set; }

        public List<Producto> Productos { get; set; }

        public DateTime FechaPedido { get; set; }

        public string NombreCliente { get; set; }
    }
}