using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cueros.App.Core.Models;

namespace Cueros.App.Phone.Models
{
    class pedido
    {
        public Order order { get; set; }
        public Product product { get; set; }
        public Double total { get; set; }
    }
}
