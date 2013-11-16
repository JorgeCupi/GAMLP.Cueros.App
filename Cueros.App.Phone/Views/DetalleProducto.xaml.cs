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
        string nombreProductoObt;
        public ObservableCollection<Producto> producto;
        public Producto pro;

        public DetalleProducto()
        {
            InitializeComponent();
            Loaded += DetalleProducto_Loaded;
        }

        void DetalleProducto_Loaded(object sender, RoutedEventArgs e)
        {
            NombreTitulo.Title = nombreProductoObt;
            producto = new Almacenar<Producto>().Deserialize("lista.xml");
            foreach (var item in producto)
            {
                if (item.Nombre.Equals(nombreProductoObt))
                {
                    pro = item;
                }
            }
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //try
            //{
            NavigationContext.QueryString.TryGetValue("nombre", out nombreProductoObt);
            //MessageBox.Show(nombreProductoObt);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("no se obtuvo nada");
            //}
        }
        async public void CargarDatos()
        {
            
        }
        private void Select(object sender, SelectionChangedEventArgs e)
        {
            if (lstMateriales.SelectedItem != null)
            {
                // c = lstProductos.SelectedItem as Producto;
                //NavigationService.Navigate(new Uri("/Views/DetalleProducto.xaml?nombre=" + c.Nombre, UriKind.Relative));
            }
        }
    }
}