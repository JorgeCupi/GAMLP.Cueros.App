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
using Cueros.App.Phone.Views;

namespace Cueros.App.Phone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public ObservableCollection<Categoria> categoria;
        public ObservableCollection<Producto> novedades;
        public ObservableCollection<Producto> destacados;
        Producto p;
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            BuildLocalizedApplicationBar();
            categoria = new Almacenar<Categoria>().Deserialize("categorias.xml");
            novedades = new Almacenar<Producto>().Deserialize("novedades.xml");
            destacados = new Almacenar<Producto>().Deserialize("destacados.xml");
            if (categoria != null && categoria.Count != 0)
                lstcategoria.ItemsSource = categoria;
            if (novedades != null && novedades.Count != 0)
                lstnovedades.ItemsSource = novedades;
            if (destacados != null && destacados.Count != 0)
                lstdestacados.ItemsSource = destacados;
            Cargar();
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
                new Almacenar<Categoria>().Serialize(categoria, "categorias.xml");
                if (categoria != null && categoria.Count != 0)
                    lstcategoria.ItemsSource = categoria;
            }
            catch (Exception)
            {
                MessageBox.Show("no inter");
            }
        }

        public async void obtenernovedades()
        {
            try
            {
                List<Producto> pro = await ServiciosDeProductos.GetRecentProducts(10);
                novedades = new ObservableCollection<Producto>(pro);
                new Almacenar<Producto>().Serialize(novedades, "novedades.xml");
                if (novedades != null && novedades.Count != 0)
                    lstnovedades.ItemsSource = novedades;
            }
            catch (Exception)
            {
                MessageBox.Show("no inter");
            }
        }

        public async void obtenerdestacados()
        {
            try
            {
                List<Producto> pro = await ServiciosDeProductos.GetTopProducts(10);
                destacados = new ObservableCollection<Producto>(pro);
                new Almacenar<Producto>().Serialize(destacados, "destacados.xml");
                if (destacados != null && destacados.Count != 0)
                    lstdestacados.ItemsSource = destacados;
            }
            catch (Exception)
            {
                MessageBox.Show("no inter");
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstcategoria.SelectedItem != null)
            {
                Categoria c = lstcategoria.SelectedItem as Categoria;
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
        }

        void appBarButton_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void lstnovedades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstnovedades.SelectedItem != null)
            {
                p = lstnovedades.SelectedItem as Producto;
                NavigationService.Navigate(new Uri("/DetalleProducto.xaml", UriKind.Relative));
               // NavigationService.Navigate(new Uri("/View/DetalleProducto.xml?producto=" + p.Id, UriKind.Relative));
            }
        }

        private void lstdestacados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstdestacados.SelectedItem != null)
            {
                p = lstdestacados.SelectedItem as Producto;
                NavigationService.Navigate(new Uri("/DetalleProducto.xaml", UriKind.Relative));
               // NavigationService.Navigate(new Uri("/View/DetalleProducto.xml?producto=" + p.Id, UriKind.Relative));
            }
        }
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            DetalleProducto detProd = e.Content as DetalleProducto;
            //Pagina2 pagina2 = e.Content as Pagina2;

            if (detProd != null)
            {
                Producto prod = lstdestacados.SelectedItem as Producto;
                detProd.DataContext = prod;
                //pagina2.DataContext = telefono;
            }
        }
    }
}