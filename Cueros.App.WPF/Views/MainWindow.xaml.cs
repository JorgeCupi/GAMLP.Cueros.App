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
using Cueros.App.WPF.Views;
using MahApps.Metro.Controls;

namespace Cueros.App.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private Inicio inicio;
        public MainWindow( Inicio Ini)
        {
            inicio = Ini;
            InitializeComponent();

            lstCategorias.SelectionChanged += lstCategorias_SelectionChanged;
            lstProductosDest.SelectionChanged += lstProductosDest_SelectionChanged;
            Loaded+=ListaProductos_Loaded;
        }

        void lstProductosDest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var producto = lstProductosDest.SelectedItem as Product;
            Detalle dp = new Detalle(producto, this);
            dp.Show();
            this.Hide();
        }

        void lstProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var producto = lstProductos.SelectedItem as Product;
            Detalle dp = new Detalle(producto,this);
            dp.Show();
            this.Hide();
        }

        void lstCategorias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var categoria = lstCategorias.SelectedItem as Category;
            Informacion inf = new Informacion(categoria, this);
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
                pgrBar.Visibility = Visibility.Visible;
                brdMain.Opacity = 0;
                List<Product> pro = await ProductsServices.GetRecentProducts(10);
                lstProductos.ItemsSource = pro;
                pro = await ProductsServices.GetTopProducts(10);
                lstProductosDest.ItemsSource = pro;
                List<Category> cat = await CategoriesServices.GetListOfCategories();
                lstCategorias.ItemsSource = cat;
                pgrBar.Visibility = Visibility.Collapsed;
                brdMain.Opacity = 1;
            }
            catch (Exception)
            {
                List<Product> pro = new List<Product>();
                pro.Add(new Product()
                {
                    Name = "O.o oops, ahora no podemos conextarnos, intenta más tarde"
                });
                lstProductos.ItemsSource = pro;
                lstProductosDest.ItemsSource = pro;
                lstCategorias.ItemsSource = pro;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            inicio.Show();
            this.Hide();
        }
    }
}
