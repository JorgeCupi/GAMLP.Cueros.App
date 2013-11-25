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
        public List<Core.Models.Proveedor> p;
        public Material m;

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

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m = lstmateriales.SelectedItem as Material;
            if (m != null)
            {
                p = m.Proveedores;
                NavigationService.Navigate(new Uri("/Views/Proveedor.xaml", UriKind.Relative));
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            Proveedor pro = e.Content as Proveedor;
            if (pro != null)
            {
                pro.lstProveedores.ItemsSource = p;
                pro.material.Text = m.Nombre;
            }
            AgregarPedido ap = e.Content as AgregarPedido;
            if (ap != null)
            {
                ap.detalles.DataContext = this.DataContext;
                Double CostoUnidad = 0;
                foreach (var item in lstmateriales.ItemsSource)
                {
                    Material pedido = item as Material;
                    CostoUnidad += pedido.CostoUnidad;
                }
                ap.CostoUnidad.Text = CostoUnidad.ToString();
            }
        }
    }
}