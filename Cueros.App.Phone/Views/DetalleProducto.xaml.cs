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
using Cueros.App.Phone.Models;

namespace Cueros.App.Phone.Views
{
    public partial class DetalleProducto : PhoneApplicationPage
    {
        string idProductoObt;
        public ObservableCollection<Producto> producto;
        public Producto pro;

        public DetalleProducto()
        {
            InitializeComponent();
            Loaded += DetalleProducto_Loaded;
           // lstMateriales.ItemsSource = 
        }

        void DetalleProducto_Loaded(object sender, RoutedEventArgs e)
        {
            CargarAppBar();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            NavigationContext.QueryString.TryGetValue("id", out idProductoObt);
        }

        private void Select(object sender, SelectionChangedEventArgs e)
        {
            //if (lstMateriales.SelectedItem != null)
            //{
            //    Material c = lstMateriales.SelectedItem as Material;
            //    NavigationService.Navigate(new Uri("/Views/DetalleMaterial.xaml?nombre=" + c.Nombre, UriKind.Relative));
            //    // c = lstProductos.SelectedItem as Producto;
            //    //NavigationService.Navigate(new Uri("/Views/DetalleProducto.xaml?nombre=" + c.Nombre, UriKind.Relative));
            //}
        }
        private void CargarAppBar()
        {
            ApplicationBar = new ApplicationBar();
            ApplicationBarIconButton AgregarPedido = new ApplicationBarIconButton(new Uri("/Assets/AppBar/refresh.png", UriKind.Relative));
            AgregarPedido.Text = "Añadir Pedido";
            ApplicationBar.Buttons.Add(AgregarPedido);
            AgregarPedido.Click += AgregarPedido_Click;
            // VerPedido.Click += VerPedido_Click;
        }

        void AgregarPedido_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/AgregarPedido.xaml", UriKind.Relative));
        }
    }
}