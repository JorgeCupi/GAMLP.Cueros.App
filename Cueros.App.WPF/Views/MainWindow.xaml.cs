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
using Newtonsoft.Json;
using System.IO;

namespace Cueros.App.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private Inicio inicio;
        
        String json;
        String jsonDest;
        String jsonCat;

        List<Order> ListaPedido;

        public MainWindow( Inicio Ini)
        {
            inicio = Ini;
            InitializeComponent();

            lstCategorias.SelectionChanged += lstCategorias_SelectionChanged;
            lstProductosDest.SelectionChanged += lstProductosDest_SelectionChanged;
            Loaded+=ListaProductos_Loaded;

            btnCarrito.Click += btnCarrito_Click;

        }

        void btnCarrito_Click(object sender, RoutedEventArgs e)
        {
            Carrito Carro = new Carrito(ListaPedido);
            Carro.Show();
        }

        void lstProductosDest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var producto = lstProductosDest.SelectedItem as Product;
            Detalle dp = new Detalle(producto, this, ListaPedido);
            dp.Show();
            this.Hide();
        }

        void lstProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var producto = lstProductos.SelectedItem as Product;
            Detalle dp = new Detalle(producto,this, ListaPedido);
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
                StreamWriter escritor = new StreamWriter("D:\\registros.json");
                //Guarda Productos
                json = JsonConvert.SerializeObject(pro);
                escritor.WriteLine(json);
                escritor.Close();
                lstProductos.ItemsSource = pro;
                pro = await ProductsServices.GetTopProducts(10);
                jsonDest = JsonConvert.SerializeObject(pro);
                StreamWriter escritor1 = new StreamWriter("D:\\registros1.json");
                //Guarda Destacados
                escritor1.WriteLine(jsonDest);
                escritor1.Close();
                lstProductosDest.ItemsSource = pro;
                List<Category> cat = await CategoriesServices.GetCategories();
                jsonCat = JsonConvert.SerializeObject(pro);
                StreamWriter escritor2 = new StreamWriter("D:\\registros2.json");
                //Guarda Categorias
                escritor2.WriteLine(jsonCat);
                escritor2.Close();
                lstCategorias.ItemsSource = cat;
                pgrBar.Visibility = Visibility.Collapsed;
                textb.Visibility = Visibility.Collapsed;
                brdMain.Opacity = 1;
            }
            catch (Exception)
            {
                //productos
                StreamReader lector = new StreamReader("D:\\registros.json");

                json = lector.ReadToEnd();
                lector.Close();
                //Destacados
                StreamReader lector1 = new StreamReader("D:\\registros1.json");
                jsonDest = lector1.ReadToEnd();
                lector1.Close();
                //Categirias
                StreamReader lector2 = new StreamReader("D:\\registros2.json");
                jsonCat = lector2.ReadToEnd();
                lector2.Close();

                List<Product> res = JsonConvert.DeserializeObject < List < Product >> (json);

                List<Product> resDest = JsonConvert.DeserializeObject<List<Product>>(jsonDest);
                List<Product> resCat = JsonConvert.DeserializeObject<List<Product>>(jsonCat);

                lstProductos.ItemsSource = res;
                lstProductosDest.ItemsSource = resDest;
                lstCategorias.ItemsSource = resCat;

                pgrBar.Visibility = Visibility.Collapsed;
                textb.Visibility = Visibility.Collapsed;
                brdMain.Opacity = 1;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            inicio.Show();
            this.Hide();
        }
    }
}
