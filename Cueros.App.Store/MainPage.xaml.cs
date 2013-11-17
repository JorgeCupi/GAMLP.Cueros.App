﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
//Referencia al servicio Cueros
using Cueros.App.Core.Services;
using Cueros.App.Core.Models;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Cueros.App.Store
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadProductList();
            ListCategories();
            ViewDestacados();
            
        }

        private void ViewDestacados()
        {
            Cueros.App.Store.UserControls.LargeTileForMainPage large = new UserControls.LargeTileForMainPage();
            
        }

        
        async void LoadProductList()
        {
            var get_list = await ServiciosDeProductos.GetProducts();
            NewProduct product;
            List<NewProduct> list_new = new List<NewProduct>();
            foreach (var item in get_list)
            {
                product = new NewProduct() 
                {
                    name = item.Nombre, description = item.Descripcion,
                    modelo = item.Modelo, url = item.Fotos.FirstOrDefault().URL, temporada = item.Temporada
                };
                list_new.Add(product);
            }
            ListaDeProductos.ItemsSource = list_new;

            #region Pruebas
            //List<Producto> list_producto = new List<Producto>();
           // for (int i = 0; i < 12; i++)
           // {
           //     Producto my_product = new Producto() 
           //     {
           //        Nombre = "Nombre del producto", 
           //         Descripcion = "Descripcion del producto", 
           //        Modelo = "Modelo del producto", 
           //         Temporada = "Temporada"
           //    };
           //    list_producto.Add(my_product);
           // }
            // ListaDeProductos.ItemsSource = list_producto;
            #endregion
        }




        async void ListCategories() 
        {

            var get_list = await ServiciosDeCategorias.ObtenerListaDeCategorias();
            NewCategoria categoria;
            List<NewCategoria> list_new = new List<NewCategoria>();
            foreach (var item in get_list)
            {
                categoria = new NewCategoria()
                {
                    nameCategoria = item.Nombre,
                    urlCategoria = item.UrlImagen
                };
                list_new.Add(categoria);
            }
            ComboBoxCategoria.ItemsSource = list_new;
   
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void AppBarBotonListaPedido_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Views.ListaPedido));
        }

        async void ListaDeProductos_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (ListaDeProductos.SelectedItem != null) 
            {
                var my_product = ((ListaDeProductos.SelectedItem) as NewProduct).name;

                var msgDlg = new Windows.UI.Popups.MessageDialog(my_product);
                msgDlg.DefaultCommandIndex = 1;
                await msgDlg.ShowAsync();
            }
        }

        private void ComboBoxCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    //Clase para mostrar la lista de productos
    class NewProduct
    {
        public string name { get; set; }
        public string description { get; set; }
        public string modelo { get; set; }
        public string line { get; set; }
        public string url { get; set; }
        public string temporada { get; set; }
    }

    class NewCategoria
    {
        public string IdCategoria { get; set; }
        public string nameCategoria { get; set; }
        public string urlCategoria { get; set; }
    }

}
