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
using System.Windows.Shapes;
using Cueros.App.Core.Services;
using Cueros.App.Core.Models;
using System.Collections.ObjectModel;

namespace Cueros.App.WPF
{
    /// <summary>
    /// Interaction logic for DetalleProducto.xaml
    /// </summary>
    public partial class DetalleProducto : Window
    {

        string nombreProductoObt;
        public ObservableCollection<Producto> producto;
        public Producto pro;
        private Producto producto1;

        public DetalleProducto(Producto producto1)
        {
            
            this.producto1 = producto1;
            InitializeComponent();
            this.Loaded += DetalleProducto_Loaded;
        }

        void DetalleProducto_Loaded(object sender, RoutedEventArgs e)
        {
            ProductoLista();
        }

        async void ProductoLista()
        {
            var get_lista = await ServiciosDeProductos.GetProducts();

            List<Producto> list = new List<Producto>();
            foreach(var item in get_lista)
            {
                if (item.Nombre.Equals(nombreProductoObt))
                {
                    pro = item;
                }
            }

        }
    }
}
