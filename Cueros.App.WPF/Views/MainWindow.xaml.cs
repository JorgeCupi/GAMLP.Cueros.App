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
using Cueros.App.Core.Services;
using Cueros.App.Core.Models;
using System.Collections.ObjectModel;

namespace Cueros.App.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded+=ListaProductos_Loaded;
        }

        void lstProductosDest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var producto = lstProductosDest.SelectedItem as Producto;
            DetalleProducto dp = new DetalleProducto(producto);
            dp.Show();
            this.Hide();
        }

        void lstProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var producto = lstProductos.SelectedItem as Producto;
            DetalleProducto dp = new DetalleProducto(producto);
            dp.Show();
            this.Hide();
        }

        void lstCategorias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var categoria = lstCategorias.SelectedItem as Categoria;
            Informacion inf = new Informacion(categoria);
            inf.Show();
            this.Hide();
        }
        void ListaProductos_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatos();

        }
        async void CargarDatos()
        {
            try
            {
                List<Producto> pro = await ServiciosDeProductos.GetRecentProducts(10);
                lstProductos.ItemsSource = pro;
                pro = await ServiciosDeProductos.GetTopProducts(10);
                lstProductosDest.ItemsSource = pro;
                List<Categoria> cat = await ServiciosDeCategorias.GetListOfCategories();
                lstCategorias.ItemsSource = cat;
                lstCategorias.SelectionChanged += lstCategorias_SelectionChanged;
                lstProductos.SelectionChanged += lstProductos_SelectionChanged;
                lstProductosDest.SelectionChanged += lstProductosDest_SelectionChanged;
            }
            catch (Exception)
            {
                List<Producto> pro = new List<Producto>();
                pro.Add(new Producto()
                {
                    Nombre = "O.o oops, ahora no podemos conextarnos, intenta más tarde"
                });
                lstProductos.ItemsSource = pro;
                lstProductosDest.ItemsSource = pro;
                lstCategorias.ItemsSource = pro;
            }
        }
    }
}
