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
         public ObservableCollection<Categoria> categoria;
        public ObservableCollection<Producto> novedades;
        public ObservableCollection<Producto> destacados;
        Producto p;
        public Catalogo()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            BuildLocalizedApplicationBar();
            categoria = new Almacenar<Categoria>().Deserialize("categorias.json");
            novedades = new Almacenar<Producto>().Deserialize("novedades.json");
            destacados = new Almacenar<Producto>().Deserialize("destacados.json");
            if (categoria != null && categoria.Count != 0)
                lstcategoria.ItemsSource = categoria;
            if (novedades != null && novedades.Count != 0)
                lstnovedades.ItemsSource = novedades;
            if (destacados != null && destacados.Count != 0)
                lstdestacados.ItemsSource = destacados;
            Cargar();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
            while (NavigationService.CanGoBack) NavigationService.RemoveBackEntry();
        }

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
                List<Categoria> cat = await ServiciosDeCategorias.GetListOfCategories();
                categoria = new ObservableCollection<Categoria>(cat);
                new Almacenar<Categoria>().Serialize(categoria, "categorias.json");
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
                List<Producto> pro = await ServiciosDeProductos.GetRecentProducts(10);
                novedades = new ObservableCollection<Producto>(pro);
                new Almacenar<Producto>().Serialize(novedades, "novedades.json");
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
                List<Producto> pro = await ServiciosDeProductos.GetTopProducts(10);
                destacados = new ObservableCollection<Producto>(pro);
                new Almacenar<Producto>().Serialize(destacados, "destacados.json");
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
                Categoria c = lstcategoria.SelectedItem as Categoria;
                //MessageBox.Show("go list de prod "+ c.Nombre);
                NavigationService.Navigate(new Uri("/Views/ListaProductos.xaml?id=" + c.Id + "&categoria=" + c.Nombre, UriKind.Relative));
            }
        }

        private void BuildLocalizedApplicationBar()
        {
            ApplicationBar = new ApplicationBar();
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/refresh.png", UriKind.Relative));
            appBarButton.Text = "Refresh";
            ApplicationBar.Buttons.Add(appBarButton);
            appBarButton.Click += appBarButton_Click;

            ApplicationBarIconButton VerPedido = new ApplicationBarIconButton(new Uri("/Assets/AppBar/refresh.png", UriKind.Relative));
            VerPedido.Text = "Ver Pedido";
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
            p = lstnovedades.SelectedItem as Producto;
            if (lstnovedades.SelectedItem != null)
            {
                //MessageBox.Show("det Prod "+p.Nombre);
                NavigationService.Navigate(new Uri("/Views/DetalleProducto.xaml", UriKind.Relative));
               // NavigationService.Navigate(new Uri("/View/DetalleProducto.xml?producto=" + p.Id, UriKind.Relative));
            }
        }

        private void lstdestacados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p = lstdestacados.SelectedItem as Producto;
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