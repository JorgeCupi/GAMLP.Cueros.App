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
//My Inport
using Cueros.App.Core.Services;
using Cueros.App.Core.Models;
using Windows.Storage;
using System.Xml.Serialization;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;
using Windows.UI.Popups;
using Cueros.App.Store.Class;

namespace Cueros.App.Store.Class
{
    public sealed partial class Productos : Page
    {
        List<Product> list = new List<Product>();
        private static List<RequestProduct> pedido;
        public static List<RequestProduct> Pedido
        {
            get { return pedido; }
            set { pedido = value; }
        }

        #region Constructor
        public Productos()
        {
            this.InitializeComponent();
            this.Loaded += Productos_Loaded;
        }
        #endregion

        #region Load Page
        async void Productos_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var _hayConexion = IsInternetAvailable();
                var now = IsInternetAvailable();
                if (!_hayConexion && !now)
                {
                    ListProducts.ItemsSource = await Deserializar();
                    AnilloProgreso.Visibility = Visibility.Collapsed;
                }
                else if (_hayConexion && now)
                {
                    ListProduct();
                }
            }
            catch (Exception)
            {
                ErrorConexion();
            }
        }
        #endregion

        #region ListProduct | Carga la lista de productos
        public async void ListProduct()
        {
            AnilloProgreso.Visibility = Visibility.Visible;
            var listProducts = await ProductsServices.GetProducts();
            try
            {
                ListProducts.ItemsSource = listProducts;
                Serializar();
                AnilloProgreso.Visibility = Visibility.Collapsed;
            }
            catch (Exception)
            {
                ErrorConexion();
                AnilloProgreso.Visibility = Visibility.Collapsed;
            }
        }
        #endregion

        #region ErrorConexion
        async void ErrorConexion()
        {
            var message = new Windows.UI.Popups.MessageDialog("Sin conexion", "Conexion fallida :(");
            message.DefaultCommandIndex = 1;
            await message.ShowAsync();
        }
        #endregion

        #region Click Back
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
        #endregion

        #region Serializar y Deserelizar
        public async void Serializar() 
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync("Cadepia.xml", CreationCollisionOption.ReplaceExisting);
            using (Stream stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync("Cadepia.xml", CreationCollisionOption.ReplaceExisting))
            {
                var _list = await ProductsServices.GetProducts();
                XmlSerializer serializer = new XmlSerializer(_list.GetType());
                serializer.Serialize(stream, _list);
                await stream.FlushAsync();
            }
        }

        async Task<List<Product>> Deserializar() 
        {
            StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync("Cadepia.xml");
            using (Stream stream = await file.OpenStreamForReadAsync())
            {
                if (stream != null)
                {
                    XmlSerializer serializer = new XmlSerializer(list.GetType());
                    list = serializer.Deserialize(stream) as List<Product>;
                }
            }
            return list;
        }
        #endregion

        #region IsInternetAvailable
        private bool IsInternetAvailable()
        {
            var internetProfile = NetworkInformation.GetInternetConnectionProfile();
            return internetProfile != null &&
                internetProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;
        }
        #endregion

        private void ListViewSelection_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(ListViewSelection.SelectedItem!=null){
               int value = ListViewSelection.SelectedIndex;
                switch(value){
                    case 0:
                        ListProducts.Visibility = Visibility.Collapsed;
                        ListViewCategorias.Visibility = Visibility.Visible;
                        CargarListaCategorias();
                        break;
                }
            }
        }

        #region Cargar Lista Categorias
        public async void CargarListaCategorias()
        {
            AnilloProgreso.Visibility = Visibility.Visible;
            List<Category> ListCategorias = new List<Category>();
            Category categoria;
            try
            {
                foreach (var item in await CategoriesServices.GetCategories())
                {
                    categoria = new Category() { Name=item.Name,Url=item.Url, CategoryID=item.CategoryID };
                    ListCategorias.Add(categoria);
                }
                ListViewCategorias.ItemsSource = ListCategorias;
                Serializar();
                AnilloProgreso.Visibility = Visibility.Collapsed;
            }
            catch (Exception)
            {
                ErrorConexion();
            }
        }
        #endregion

        #region ListProducts Tapped
        private async void ListProducts_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Windows.UI.Popups.MessageDialog message;
            try
            {
                Cueros.App.Core.Models.Product _objeto = null;
                var listProducts = await ProductsServices.GetProducts();
                if (ListProducts.SelectedItem != null)
                {
                    var _idProducto = (ListProducts.SelectedItem as Product).ProductID;
                    var result = from item in listProducts
                                 where item.ProductID == _idProducto
                                 select item;
                    _objeto = result.ToList().FirstOrDefault();
                    Frame.Navigate(typeof(Materiales), _objeto);
                }
                else
                {
                    message = new Windows.UI.Popups.MessageDialog("Seleccione un producto", "Seleccion");
                    await message.ShowAsync();
                }
            }
            catch (Exception ex)
            {
                message = new Windows.UI.Popups.MessageDialog(ex.Message.ToString());
                message.ShowAsync();
            }

        }
        #endregion
    }
}
