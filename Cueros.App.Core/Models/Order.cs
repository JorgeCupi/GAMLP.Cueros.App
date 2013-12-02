using System;
using System.Collections.Generic;

namespace Cueros.App.Core.Models
{
    public class Order
    {
        public string OrderID { get; set; }

        public DateTime Date { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }
    }
}