using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Cueros.App.Core;
using Cueros.App.Phone;
using Cueros.App.Phone.Models;
using Cueros.App.Core.Models;
using Cueros.App.Core.Services;

namespace Cueros.App.Phone.Views
{
    public partial class ListaProductos : PhoneApplicationPage
    {
        public ObservableCollection<Product> novedades;
        public ObservableCollection<Product> destacados;
        public ObservableCollection<Product> productos;
        String id;
        String categoria;
        Product p;
        public ListaProductos()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("id") && NavigationContext.QueryString.ContainsKey("categoria"))
            {
                id = NavigationContext.QueryString["id"];
                categoria = NavigationContext.QueryString["categoria"];
                panorama.Title = categoria;
                novedades = new Almacenar<Product>().Deserialize(categoria + "_novedades.json");
                destacados = new Almacenar<Product>().Deserialize(categoria + "_destacados.json");
                productos = new Almacenar<Product>().Deserialize(categoria + "_categorias.json");
                if (novedades != null && novedades.Count != 0)
                    lstnovedades.ItemsSource = novedades;
                if (destacados != null && destacados.Count != 0)
                    lstdestacados.ItemsSource = destacados;
                if (productos != null && productos.Count != 0)
                    lstproductos.ItemsSource = productos;
                cargar();
            }
        }

        public void cargar()
        {
            obtenernovedades();
            obtenerdestacados();
            obtenerproductos();
        }

        public async void obtenernovedades()
        {
            try
            {
                List<Product> nov = await ProductsServices.GetRecentProductsFromThisCategory(id, 10);
                novedades = new ObservableCollection<Product>(nov);
                new Almacenar<Product>().Serialize(novedades, categoria + "_novedades.json");
                lstnovedades.ItemsSource = nov;
            }
            catch (Exception)
            {
            }
        }

        public async void obtenerdestacados()
        {
            try
            {
                List<Product> des = await ProductsServices.GetTopProductsFromThisCategory(id, 10);
                destacados = new ObservableCollection<Product>(des);
                new Almacenar<Product>().Serialize(destacados, categoria + "_destacados.json");
                lstdestacados.ItemsSource = des;
            }
            catch (Exception)
            {
            }
        }

        public async void obtenerproductos()
        {
            try
            {
                List<Product> pro = await ProductsServices.GetProductsFromThisCategory(id);
                productos = new ObservableCollection<Product>(pro);
                new Almacenar<Product>().Serialize(productos, categoria + "_productos.json");
                lstproductos.ItemsSource = pro;
            }
            catch (Exception)
            {
            }
        }

        private void lstnovedades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p = lstnovedades.SelectedItem as Product;
            if (lstnovedades.SelectedItem != null)
            {
                // MessageBox.Show("det Prod " + p.Nombre);
                NavigationService.Navigate(new Uri("/Views/DetalleProducto.xaml", UriKind.Relative));
                // NavigationService.Navigate(new Uri("/View/DetalleProducto.xml?producto=" + p.Id, UriKind.Relative));
            }
            //NavigationService.Navigate(new Uri("/Views/DetalleProducto.xaml", UriKind.Relative));
        }

        private void lstdestacados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p = lstdestacados.SelectedItem as Product;
            if (lstdestacados.SelectedItem != null)
            {
                // MessageBox.Show("det Prod " + p.Nombre);
                NavigationService.Navigate(new Uri("/Views/DetalleProducto.xaml", UriKind.Relative));
                // NavigationService.Navigate(new Uri("/View/DetalleProducto.xml?producto=" + p.Id, UriKind.Relative));
            }
            //NavigationService.Navigate(new Uri("/Views/DetalleProducto.xaml", UriKind.Relative));
        }

        private void lstproductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p = lstproductos.SelectedItem as Product;
            if (lstproductos.SelectedItem != null)
            {
                // MessageBox.Show("det Prod " + p.Nombre);
                NavigationService.Navigate(new Uri("/Views/DetalleProducto.xaml", UriKind.Relative));
                // NavigationService.Navigate(new Uri("/View/DetalleProducto.xml?producto=" + p.Id, UriKind.Relative));
            }
            //NavigationService.Navigate(new Uri("/Views/DetalleProducto.xaml", UriKind.Relative));
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