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
        String id;
        String categoria;
        Producto p;
        public ListaProductos()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("id") &&NavigationContext.QueryString.ContainsKey("categoria"))
            {
                id = NavigationContext.QueryString["id"];
                categoria = NavigationContext.QueryString["categoria"];
                panorama.Title = categoria;
                cargar();
            }
        }

        public void cargar()
        {
            novedades();
            destacados();
            productos();
        }

        public async void novedades()
        {
            try
            {
                List<Producto> novedades = await ServiciosDeProductos.GetRecentProductsFromThisCategory(id, 10);
                lstnovedades.ItemsSource = novedades;
            }
            catch (Exception)
            {
            }
        }

        public async void destacados()
        {
            try
            {
                List<Producto> destacados = await ServiciosDeProductos.GetTopProductsFromThisCategory(id, 10);
                lstdestacados.ItemsSource = destacados;
            }
            catch (Exception)
            {
            }
        }

        public async void productos()
        {
            try
            {
                List<Producto> productos = await ServiciosDeProductos.GetProductsFromThisCategory(id);
                lstproductos.ItemsSource = productos;
            }
            catch (Exception)
            {
            }
        }

        private void lstnovedades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p = lstnovedades.SelectedItem as Producto;
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
            p = lstdestacados.SelectedItem as Producto;
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
            p = lstproductos.SelectedItem as Producto;
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