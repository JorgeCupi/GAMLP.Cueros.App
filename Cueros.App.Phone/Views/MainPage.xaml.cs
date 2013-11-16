using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Cueros.App.Phone.Resources;
using Cueros.App.Phone.Models;
using Cueros.App.Core.Services;
using System.Collections.ObjectModel;
using Cueros.App.Core.Models;

namespace Cueros.App.Phone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public ObservableCollection<Producto> productos;
        public ObservableCollection<Categoria> categorias;
        
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //BuildLocalizedApplicationBar();
            productos = new Almacenar<Producto>().Deserialize("lista.xml");
            categorias = new Almacenar<Categoria>().Deserialize("categoria.xml");
            obtenerproductos();
        }

        public async void obtenerproductos()
        {
            try
            {
                List<Producto> pro = await ServiciosDeProductos.ObtenerProductos();
                productos = new ObservableCollection<Producto>(pro);
                categoria();
                lstcategoria.ItemsSource = categorias.ToList();
                new Almacenar<Producto>().Serialize(productos, "lista.xml");
                new Almacenar<Categoria>().Serialize(categorias, "categoria.xml");
            }
            catch (Exception)
            {
            }
        }

        public void categoria()
        {
            categorias = new ObservableCollection<Categoria>();
            foreach (var item in productos)
            {
                if (categorias.Where(i => i.categoria.Equals(item.Linea)).Count() == 0)
                {
                    categorias.Add(new Categoria()
                    {
                        categoria = item.Linea,
                        image = "/Assets/Tiles/FlipCycleTileSmall.png"
                        //image = item.Fotos.First().URL
                    });
                }
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstcategoria.SelectedItem != null)
            {
                Categoria c = lstcategoria.SelectedItem as Categoria;
                NavigationService.Navigate(new Uri("/Views/ListaProductos.xaml?categoria=" + c.categoria, UriKind.Relative));
            }
        }

        // Sample code for building a localized ApplicationBar
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.refresh.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarButtonText;
            ApplicationBar.Buttons.Add(appBarButton);
        }
    }
}