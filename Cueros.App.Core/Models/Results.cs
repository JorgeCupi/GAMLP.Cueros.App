using System.Collections.Generic;

namespace Cueros.App.Core.Models
{
    public class ProductsResults
    {
        public List<Product> Products { get; set; }
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