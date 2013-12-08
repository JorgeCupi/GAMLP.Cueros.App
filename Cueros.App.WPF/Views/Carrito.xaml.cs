using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cueros.App.Core.Models;
using Cueros.App.Core.Services;

namespace Cueros.App.WPF.Views
{
    /// <summary>
    /// Interaction logic for Carrito.xaml
    /// </summary>
    public partial class Carrito : Page
    {
        public List<Product> Pro = new List<Product>();
        public List<Order> LP = new List<Order>();
        public Carrito(List<Order> L)
        {
            LP = L;
            InitializeComponent();
        }

        private async void MandarOrden()
        {

            foreach(var a in LP)
            {
                bool sw = await OrdersServices.TryCreateOrder(a);
                if (sw)
                {
                    MessageBox.Show("Se ha añadido a la orden");
                }
                else
                {
                    MessageBox.Show("Se ha producido un error");
                }
            }

            
        }

    }
}
