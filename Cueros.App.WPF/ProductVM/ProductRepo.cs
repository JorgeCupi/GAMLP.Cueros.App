using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cueros.App.Core.Models;

namespace Cueros.App.WPF.ProductVM
{
    public class ProductRepo
    {
        public ProductRepo() 
        { 
        }
        public IEnumerable<Product> GetProducts() 
        {
            List<Product> Products = new List<Product>();
         List<Product> listaP;
            while(true){
                Products.Add(new Product
                    {
                    });
                return Products;
            }
        }
    }
}
