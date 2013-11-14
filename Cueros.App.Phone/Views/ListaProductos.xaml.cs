using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Cueros.App.Phone.ViewModels;

namespace Cueros.App.Phone.Views
{
    public partial class ListaProductos : PhoneApplicationPage
    {
        public ListaProductos()
        {
            InitializeComponent();
            Loaded += ListaProductos_Loaded;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("categoria"))
            {
                categoria.Text = NavigationContext.QueryString["categoria"];
                new CategoriaViewModel().prodcat(categoria.Text);
            }
        }

        void ListaProductos_Loaded(object sender, RoutedEventArgs e)
        {
            boton.Click+=boton_Click;
        }

        private void boton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/DetalleProducto.xaml", UriKind.Relative));
        }
    }
}