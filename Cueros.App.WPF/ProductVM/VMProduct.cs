using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Cueros.App.Core;
using Cueros.App.Core.Models;
using System.Windows.Input;

namespace Cueros.App.WPF.ProductVM
{
    
    public class VMProduct : INotifyPropertyChanged
    {
        private ProductRepo repo;
        private List<Producto> ListOfProducts;
        public List<Producto> ListProduct {
            get { return ListOfProducts; }
            set { ChangeProperty("ProductList");
            ListOfProducts = value;
            }
        }
        public VMProduct() {
            repo = new ProductRepo();
            this.ListOfProducts = repo.GetProducts().ToList();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void ChangeProperty(String PropertyName) {

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));

        }
        
    }
}
