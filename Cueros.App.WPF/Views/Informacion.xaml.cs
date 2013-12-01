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

namespace Cueros.App.WPF
{
    /// <summary>
    /// Interaction logic for Informacion.xaml
    /// </summary>
    public partial class Informacion :MetroWindow
    {
       String cate;
       private MainWindow mainWindow;

        public Informacion(Categoria c, MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            cate = c.Id;
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
                List<Producto> All = await ServiciosDeProductos.GetProductsFromThisCategory(cate);
                Todos.ItemsSource = All;
                List<Producto> Nov = await ServiciosDeProductos.GetRecentProductsFromThisCategory(cate);
                Novedades.ItemsSource = Nov;
                List<Producto> Des = await ServiciosDeProductos.GetRecentProductsFromThisCategory(cate);
                Destacados.ItemsSource = Des;
                pgrBar.Visibility = Visibility.Collapsed;
                Categorias.Opacity = 1;
            }
            catch(Exception)
            {
                List<Producto> get_list = new List<Producto>();
                get_list.Add(new Producto()
                {
                    Nombre = "O.o oops, ahora no podemos conextarnos, intenta más tarde"
                });
                Todos.ItemsSource = get_list;
                Novedades.ItemsSource = get_list;
                Destacados.ItemsSource = get_list;
                
            }

        }

        void Todos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var producto = Todos.SelectedItem as Producto;
            det.DataContext = producto;
            imagenes.ItemsSource = producto.Fotos;
        }
        void Novedades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var producto = Novedades.SelectedItem as Producto;
            det.DataContext = producto;
            imagenes.ItemsSource = producto.Fotos;
        }
        void Destacados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var producto = Destacados.SelectedItem as Producto;
            det.DataContext = producto;
            imagenes.ItemsSource = producto.Fotos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var producto = Todos.SelectedItem as Producto;
            Detalle dp = new Detalle(producto, this);
            dp.Show();
            this.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var producto = Novedades.SelectedItem as Producto;
            Detalle dp = new Detalle(producto, this);
            dp.Show();
            this.Hide();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var producto = Destacados.SelectedItem as Producto;
            Detalle dp = new Detalle(producto, this);
            dp.Show();
            this.Hide();
        }

    }
}
