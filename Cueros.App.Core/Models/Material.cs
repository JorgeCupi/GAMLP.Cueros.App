using System.Collections.Generic;

namespace Cueros.App.Core.Models
{
    public class Material
    {
        public int MaterialID { get; set; }

        public string Name { get; set; }

        public string CommercialName { get; set; }

        public string Unit { get; set; }

        public double UnitPrice { get; set; }

        public double Quantity { get; set; }

        public List<Supplier> Suppliers { get; set; }

        public string Color { get; set; }
    }
}