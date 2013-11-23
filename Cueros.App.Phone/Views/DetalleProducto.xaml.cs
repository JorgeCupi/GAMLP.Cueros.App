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
           // lstMateriales.ItemsSource = 
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            NavigationContext.QueryString.TryGetValue("id", out idProductoObt);
        }

        private void Select(object sender, SelectionChangedEventArgs e)
        {
            if (lstMateriales.SelectedItem != null)
            {
                Material c = lstMateriales.SelectedItem as Material;
                NavigationService.Navigate(new Uri("/Views/DetalleMaterial.xaml?nombre=" + c.Nombre, UriKind.Relative));
                // c = lstProductos.SelectedItem as Producto;
                //NavigationService.Navigate(new Uri("/Views/DetalleProducto.xaml?nombre=" + c.Nombre, UriKind.Relative));
            }
        }
    }
}