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
        public IEnumerable<Producto> GetProducts() 
        {
            List<Producto> Products = new List<Producto>();
         List<Producto> listaP;
            while(true){
                Products.Add(new Producto
                    {
                    });
                return Products;
            }
        }
    }
}
