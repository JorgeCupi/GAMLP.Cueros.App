using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
//Referencia al servicio Cueros
using Cueros.App.Core.Services;
using Cueros.App.Core.Models;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Cueros.App.Store
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //ListCategories();
            //ListDestacados();
        }

        async void ListDestacados()
        {
            var list_url = new List<string>();
            var get_list =  await ServiciosDeProductos.ObtenerProductosDestacados(5);
            foreach (var item in get_list)
            {
                list_url.Add(item.Fotos.FirstOrDefault().URL);
            }
            //List_Destacados.ItemsSource = list_url;
        }

        async void ListCategories()
        {
            //var get_list = await ServiciosDeCategorias.ObtenerListaDeCategorias();
            Categoria categoria;
            List<Categoria> list_new = new List<Categoria>();
            foreach (var item in await ServiciosDeCategorias.ObtenerListaDeCategorias())
            {
                categoria = new Categoria()
                {
                    Nombre = item.Nombre,
                    UrlImagen = item.UrlImagen
                };
                list_new.Add(categoria);
            }
            ListaDeProductos.ItemsSource = list_new;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void AppBarBotonListaPedido_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Views.ListaPedido));
        }

        private void ListaDeProductos_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (ListaDeProductos.SelectedItem != null)
            {
                var my_categoria = ListaDeProductos.SelectedItem as Producto;
                Frame.Navigate(typeof(Views.ViewCategoria), my_categoria);
            }
        }
    }

}
