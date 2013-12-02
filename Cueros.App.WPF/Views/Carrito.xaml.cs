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

namespace Cueros.App.WPF.Views
{
    /// <summary>
    /// Interaction logic for Carrito.xaml
    /// </summary>
    public partial class Carrito : Page
    {
        List<Product> Pro = new List<Product>();
        public Carrito(List<Product> p)
        {
            Pro = p;
            InitializeComponent();
        }

    }
}
