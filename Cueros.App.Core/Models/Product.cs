using System;
using System.Collections.Generic;

namespace Cueros.App.Core.Models
{
    public class Product
    {
        public string ProductID { get; set; }

        public int Quantity { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Model { get; set; }

        public string Season { get; set; }

        public int ProductionTime { get; set; }

        public int SoldUnits { get; set; }

        public Category Category { get; set; }

        public List<Picture> Pictures { get; set; }

        public List<Material> Materials { get; set; }

        public DateTime OnSaleDate { get; set; }
    }
}