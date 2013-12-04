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
using Cueros.App.Core.Models;
using Cueros.App.Core.Services;
using Cueros.App.WPF.Views;
using MahApps.Metro.Controls;
using Newtonsoft.Json;
using System.IO;

namespace Cueros.App.WPF
{
    /// <summary>
    /// Interaction logic for Informacion.xaml
    /// </summary>
    /// 
    public partial class Informacion :MetroWindow
    {
       String cate;
       private MainWindow mainWindow;

        public Informacion(Category c, MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            cate = c.CategoryID;
            InitializeComponent();
            Loaded += Page1_Loaded;

            Todos.SelectionChanged += Todos_SelectionChanged;
            Novedades.SelectionChanged += Novedades_SelectionChanged;
            Destacados.SelectionChanged += Destacados_SelectionChanged;
        }

        private void Page1_Loaded(object sender, RoutedEventArgs e)
        {
            ProductOfCategories();
        }

        async void ProductOfCategories()
        {
            try
            {
                pgrBar.Visibility = Visibility.Visible;
                Categorias.Opacity = 0;
                List<Product> All = await ProductsServices.GetProductsFromThisCategory(cate);
                Todos.ItemsSource = All;
                List<Product> Nov = await ProductsServices.GetRecentProductsFromThisCategory(cate);
                Novedades.ItemsSource = Nov;
                List<Product> Des = await ProductsServices.GetRecentProductsFromThisCategory(cate);
                Destacados.ItemsSource = Des;
                pgrBar.Visibility = Visibility.Collapsed;
                textb.Visibility = Visibility.Collapsed;
                Categorias.Opacity = 1;
            }
            catch(Exception)
            {
                List<Product> get_list = new List<Product>();
                get_list.Add(new Product()
                {
                    Name = "O.o oops, ahora no podemos conextarnos, intenta más tarde"
                });
                Todos.ItemsSource = get_list;
                Novedades.ItemsSource = get_list;
                Destacados.ItemsSource = get_list;
                
            }

        }

        void Todos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var producto = Todos.SelectedItem as Product;
            det.DataContext = producto;
            imagenes.ItemsSource = producto.Pictures;
        }
        void Novedades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var producto = Novedades.SelectedItem as Product;
            det.DataContext = producto;
            imagenes.ItemsSource = producto.Pictures;
        }
        void Destacados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var producto = Destacados.SelectedItem as Product;
            det.DataContext = producto;
            imagenes.ItemsSource = producto.Pictures;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var producto = Todos.SelectedItem as Product;
            Detalle dp = new Detalle(producto, this);
            dp.Show();
            this.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var producto = Novedades.SelectedItem as Product;
            Detalle dp = new Detalle(producto, this);
            dp.Show();
            this.Hide();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var producto = Destacados.SelectedItem as Product;
            Detalle dp = new Detalle(producto, this);
            dp.Show();
            this.Hide();
        }

    }
}
