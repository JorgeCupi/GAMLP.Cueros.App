using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Cueros.App.Core.Services;
using Cueros.App.Core.Models;
using Windows.Storage;
using System.Xml.Serialization;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;
using Windows.UI.Popups;

namespace Cueros.App.Store.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Productos : Page
    {
        public Productos()
        {
            this.InitializeComponent();
            this.Loaded += Productos_Loaded;
        }

        
        async void Productos_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var _hayConexion = IsInternetAvailable();
                var now = IsInternetAvailable();
                if (!_hayConexion && !now)
                {
                    //_hayConexion = false;
                    my_list_productos.ItemsSource = await Deserializar();
                    //Código a ejecutar cuando se pierda la red
                }
                else if (_hayConexion && now)
                {
                    //_hayConexion = true;
                    ListProduct();
                    //Código a ejecutar cuando se recupere la red
                }
            }
            catch (Exception)
            {
                Error();
            }

        }

        public async void ListProduct() 
        {
            List<Product> _list = new List<Product>();
            Product _product;
            try
            {
                foreach (var item in await ServiciosDeProductos.GetProducts())
                {
                    _product = new Product() { Name = item.Nombre, UrlImage = item.Fotos.FirstOrDefault().URL, Temporada = item.Temporada, Id = item.Id };
                    _list.Add(_product);
                }
                my_list_productos.ItemsSource = _list;
                Serializar();
            }
            catch (Exception)
            {
                Error();
            }
        }

        async void Error()
        {
            var msgDlg = new Windows.UI.Popups.MessageDialog("Sin conexion", "Conexion fallida :(");
            msgDlg.DefaultCommandIndex = 1;
            await msgDlg.ShowAsync();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        async void my_list_productos_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                Producto _objeto = null;
                if (my_list_productos.SelectedItem != null)
                {
                    var _idProducto = (my_list_productos.SelectedItem as Product).Id;
                    var result = from item in await ServiciosDeProductos.GetProducts()
                                 where item.Id == _idProducto
                                 select item;
                    _objeto = result.ToList().FirstOrDefault();
                }
                Frame.Navigate(typeof(Materiales), _objeto);
            }
            catch (Exception)
            {
                Error();
                Frame.Navigate(typeof(FieldView));
            }
            
        }

        public async void Serializar() 
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync("Cadepia.xml", CreationCollisionOption.ReplaceExisting);
            using (Stream stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync("Cadepia.xml", CreationCollisionOption.ReplaceExisting))
            {
                var _list = await ServiciosDeProductos.GetProducts();
                XmlSerializer serializer = new XmlSerializer(_list.GetType());
                serializer.Serialize(stream, _list);
                await stream.FlushAsync();
            }
        }

        List<Producto> list = new List<Producto>();
        async Task<List<Producto>> Deserializar() 
        {
            //Abrimos el fichero donde están los datos serializados
            StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync("Cadepia.xml");
            //Abrimos el stream del fichero
            using (Stream stream = await file.OpenStreamForReadAsync())
            {
                //Comprobamos que se ha creado bien el stream
                if (stream != null)
                {
                    //Inicializamos el serializador y desserializamos
                    XmlSerializer serializer = new XmlSerializer(list.GetType());
                    //Tenemos que definir a que tipo de objeto tiene que convertir el objeto deserializado
                    list = serializer.Deserialize(stream) as List<Producto>;
                }
            }
            return list;
        }

        private bool IsInternetAvailable()
        {
            var internetProfile = NetworkInformation.GetInternetConnectionProfile();
            return internetProfile != null &&
                internetProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;
        }
    }

    public class Product 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UrlImage { get; set; }
        public string Temporada { get; set; }
    }
}
