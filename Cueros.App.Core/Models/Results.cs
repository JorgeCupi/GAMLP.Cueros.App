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
        public List<Category> Categories { get; set; }
    }

    public class SuppliersResults
    {
        public List<Supplier> Suppliers { get; set; }
    }
}