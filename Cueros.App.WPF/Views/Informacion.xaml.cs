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

namespace Cueros.App.WPF
{
    /// <summary>
    /// Interaction logic for Informacion.xaml
    /// </summary>
    public partial class Informacion : Window
    {
       String cate;
       private MainWindow mainWindow;

        public Informacion(Categoria c, MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            cate = c.Id;
            InitializeComponent();
            Loaded += Page1_Loaded;
        }

        private void Page1_Loaded(object sender, RoutedEventArgs e)
        {
            ProductOfCategories();
        }

        async void ProductOfCategories()
        {
            try
            {
                List<Producto> get_list = await ServiciosDeProductos.GetProductsFromThisCategory(cate);
                ListaCategoria.ItemsSource = get_list;
                ListaCategoria.SelectionChanged += ListaCategoria_SelectionChanged;
            }
            catch(Exception)
            {
                List<Producto> get_list = new List<Producto>();
                get_list.Add(new Producto()
                {
                    Nombre = "O.o oops, ahora no podemos conextarnos, intenta más tarde"
                });
                ListaCategoria.ItemsSource = get_list;
                
            }

        }

        void ListaCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var producto = ListaCategoria.SelectedItem as Producto;
            DetalleProducto dp = new DetalleProducto(producto, this);
            dp.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            this.Hide();
        }
    }
}
