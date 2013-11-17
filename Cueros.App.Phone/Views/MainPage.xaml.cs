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
        public ObservableCollection<Categoria> categoria;

        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            BuildLocalizedApplicationBar();
            Cargar();
        }

        void Cargar()
        {
            categoria = new Almacenar<Categoria>().Deserialize("categorias.xml");
            if (categoria != null && categoria.Count != 0)
                lstcategoria.ItemsSource = categoria;
            obtenerproductos();
        }

        public async void obtenerproductos()
        {
            try
            {
                List<Categoria> cat = await ServiciosDeCategorias.ObtenerListaDeCategorias();
                categoria = new ObservableCollection<Categoria>(cat);
                new Almacenar<Categoria>().Serialize(categoria, "categorias.xml");
                if (categoria != null && categoria.Count != 0)
                    lstcategoria.ItemsSource = categoria;
            }
            catch (Exception)
            {
                MessageBox.Show("no!");
            }
        }

        //public async obtenernovedades()
        //{
        //    try
        //    {
        //        List
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstcategoria.SelectedItem != null)
            {
                Categoria c = lstcategoria.SelectedItem as Categoria;
                NavigationService.Navigate(new Uri("/Views/ListaProductos.xaml?categoria=" + c.Id, UriKind.Relative));
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
    }
}