using System.Collections.Generic;

namespace Cueros.App.Core.Models
{
    public class ProductsResults
    {
        public string success { get; set; }
        public string message { get; set; }
        public List<Product> data{ get; set; }
    }

    public class CategoriesResults
    {
        public string success { get; set; }
        public string message { get; set; }
        public List<Category> data { get; set; }
    }

    public class SuppliersResults
    {
        public List<Supplier> Suppliers { get; set; }
    }

    public class MaterialsResults 
    {
        public string success { get; set; }
        public string message { get; set; }
        public List<Material> data { get; set; }
    }
}