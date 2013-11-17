﻿using System;
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
        public ObservableCollection<Producto> productos;
        string id;
        public ListaProductos()
        {
            InitializeComponent();
            Loaded += ListaProductos_Loaded;
        }

        void ListaProductos_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatos();
        }
        async public void CargarDatos()
        {
            List<Producto> pro = await ServiciosDeProductos.ObtenerProductosDeEstaCategoria(id);
            lstProductos.ItemsSource = pro;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("categoria"))
            {
                //categoria.Text = NavigationContext.QueryString["categoria"];
                //new CategoriaViewModel().prodcat(categoria.Text);
                //lineax = categoria.Text;
            }
        }

        private void Select(object sender, SelectionChangedEventArgs e)
        {
            if (lstProductos.SelectedItem != null)
            {
                Producto c = lstProductos.SelectedItem as Producto;
                NavigationService.Navigate(new Uri("/Views/DetalleProducto.xaml?id=" + c.Id, UriKind.Relative));
            }
        }
        

    }
}