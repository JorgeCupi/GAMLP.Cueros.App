using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Cueros.App.Core.Models;
using System.Collections.ObjectModel;
using Cueros.App.Core.Services;
using Cueros.App.Phone.Models;

namespace Cueros.App.Phone.Views
{
    public partial class Catalogo : PhoneApplicationPage
    {
         public ObservableCollection<Category> categoria;
        public ObservableCollection<Product> novedades;
        public ObservableCollection<Product> destacados;
        Product p;
        public Catalogo()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            BuildLocalizedApplicationBar();
            categoria = new Almacenar<Category>().Deserialize("categorias.json");
            novedades = new Almacenar<Product>().Deserialize("novedades.json");
            destacados = new Almacenar<Product>().Deserialize("destacados.json");
            if (categoria != null && categoria.Count != 0)
                lstcategoria.ItemsSource = categoria;
            if (novedades != null && novedades.Count != 0)
                lstnovedades.ItemsSource = novedades;
            if (destacados != null && destacados.Count != 0)
                lstdestacados.ItemsSource = destacados;
            Cargar();
        }

        //protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
       // {
          //  base.OnBackKeyPress(e);
           // while (NavigationService.CanGoBack) NavigationService.RemoveBackEntry();
       // }

        void Cargar()
        {
            obtenerdestacados();
            obtenerproductos();
            obtenernovedades();
        }

        public async void obtenerproductos()
        {
            try
            {
                List<Category> cat = await CategoriesServices.GetListOfCategories();
                categoria = new ObservableCollection<Category>(cat);
                new Almacenar<Category>().Serialize(categoria, "categorias.json");
                if (categoria != null && categoria.Count != 0)
                    lstcategoria.ItemsSource = categoria;
            }
            catch (Exception)
            {
                //MessageBox.Show("no inter");
            }
        }

        public async void obtenernovedades()
        {
            try
            {
                List<Product> pro = await ProductsServices.GetRecentProducts(10);
                novedades = new ObservableCollection<Product>(pro);
                new Almacenar<Product>().Serialize(novedades, "novedades.json");
                if (novedades != null && novedades.Count != 0)
                    lstnovedades.ItemsSource = novedades;
            }
            catch (Exception)
            {
                //MessageBox.Show("no inter");
            }
        }

        public async void obtenerdestacados()
        {
            try
            {
                List<Product> pro = await ProductsServices.GetTopProducts(10);
                destacados = new ObservableCollection<Product>(pro);
                new Almacenar<Product>().Serialize(destacados, "destacados.json");
                if (destacados != null && destacados.Count != 0)
                    lstdestacados.ItemsSource = destacados;
            }
            catch (Exception)
            {
                //MessageBox.Show("no inter");
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstcategoria.SelectedItem != null)
            {
                Category c = lstcategoria.SelectedItem as Category;
                //MessageBox.Show("go list de prod "+ c.Nombre);
                NavigationService.Navigate(new Uri("/Views/ListaProductos.xaml?id=" + c.CategoryID + "&categoria=" + c.Name, UriKind.Relative));
            }
        }

        private void BuildLocalizedApplicationBar()
        {
            ApplicationBar = new ApplicationBar();
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/refresh.png", UriKind.Relative));
            appBarButton.Text = "Refresh";
            ApplicationBar.Buttons.Add(appBarButton);
            appBarButton.Click += appBarButton_Click;

            ApplicationBarIconButton VerPedido = new ApplicationBarIconButton(new Uri("/Assets/AppBar/cart.png", UriKind.Relative));
            VerPedido.Text = "Pedidos";
            ApplicationBar.Buttons.Add(VerPedido);
            VerPedido.Click += VerPedido_Click;

            
        }
        void VerPedido_Click(object sender, EventArgs e)
        {
            //aca codigo para mandar a la base de datos para guardar el pedido
            NavigationService.Navigate(new Uri("/Views/Carrito.xaml", UriKind.Relative));
        }

        void appBarButton_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void lstnovedades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p = lstnovedades.SelectedItem as Product;
            if (lstnovedades.SelectedItem != null)
            {
                //MessageBox.Show("det Prod "+p.Nombre);
                NavigationService.Navigate(new Uri("/Views/DetalleProducto.xaml", UriKind.Relative));
               // NavigationService.Navigate(new Uri("/View/DetalleProducto.xml?producto=" + p.Id, UriKind.Relative));
            }
        }

        private void lstdestacados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p = lstdestacados.SelectedItem as Product;
            if (lstdestacados.SelectedItem != null)
            {
                NavigationService.Navigate(new Uri("/Views/DetalleProducto.xaml", UriKind.Relative));
            }
        }
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            DetalleProducto detProd = e.Content as DetalleProducto;
            if (detProd != null)
            {
                detProd.DataContext = p;
            }
        }
        
    }
}