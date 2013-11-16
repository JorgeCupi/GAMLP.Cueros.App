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
            //LoadProductList();
            ListCategories();
        }

        
        async void LoadProductList()
        {
            var get_list = await ServiciosDeProductos.ObtenerProductos();
            NewProduct product;
            List<NewProduct> list_new = new List<NewProduct>();
            foreach (var item in get_list)
            {
                product = new NewProduct() 
                {
                    name = item.Nombre, description = item.Descripcion, line = item.Linea, modelo = item.Modelo, url = item.Fotos.FirstOrDefault().URL, temporada = item.Temporada
                };
                list_new.Add(product);
            }
            ListaDeProductos.ItemsSource = list_new;

            #region Pruebas
            //List<Producto> list_producto = new List<Producto>();
           // for (int i = 0; i < 12; i++)
           // {
           //     Producto my_product = new Producto() 
           //     {
           //        Nombre = "Nombre del producto", 
           //         Descripcion = "Descripcion del producto", 
           //        Modelo = "Modelo del producto", 
           //         Temporada = "Temporada"
           //    };
           //    list_producto.Add(my_product);
           // }
            // ListaDeProductos.ItemsSource = list_producto;
            #endregion
        }

        async void ListCategories() 
        {
            //Mando la linea del producto, ejemplo Mochila
            var _list = await ServiciosDeProductos.ObtenerProductos("Mochilas");
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }

    //Clase para mostrar la lista de productos
    class NewProduct
    {
        public string name { get; set; }
        public string description { get; set; }
        public string modelo { get; set; }
        public string line { get; set; }
        public string url { get; set; }
        public string temporada { get; set; }
    }
}
