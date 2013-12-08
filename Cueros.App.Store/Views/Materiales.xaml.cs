using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Cueros.App.Core.Models;
using Cueros.App.Core.Services;
using Windows.UI.Popups;

namespace Cueros.App.Store.Class
{
    public sealed partial class Materiales : Page
    {
        Cueros.App.Core.Models.Product tmpProduct = null;
        Material tmpMaterial = new Material();
        ProductoCantidad NewP = new ProductoCantidad();
        List<Material> listMaterial = new List<Material>();
        List<Supplier> listProveedor = new List<Supplier>();

        public Materiales()
        {
            this.InitializeComponent();
            AppButtonAgregar.Click +=AppButtonAgregar_Click;
            AppButtonVer.Click += AppButtonVer_Click;
        }

        void obtenerMateriales(Cueros.App.Core.Models.Product a)
        {
            listMaterial = a.Materials;
            ListaDeMateriales.ItemsSource = listMaterial;
            FlipViewImagenes.ItemsSource = a.Pictures;
            TextNombreProductoCabezera.Text = a.Name;
            TextoDescripcionProducto.Text = a.Description;
            TextoModeloProducto.Text = a.Model;
            TextoTemporadaProducto.Text = a.Season;
            TextoVentasProductos.Text = a.SoldUnits.ToString();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            tmpProduct = e.Parameter as Cueros.App.Core.Models.Product;
            obtenerMateriales(tmpProduct);
        }
        RequestProduct NuevoRequestProduct;
        private void AppButtonAgregar_Click(object sender, RoutedEventArgs e)
        {
            int cantidad = int.Parse(TextBoxCantidadProductos.Text);
            ProductoCantidad pc = new ProductoCantidad() { Producto = tmpProduct, Cantidad = cantidad };
            double PrecioU = GetPrecio(pc);
            double PrecioT = PrecioU * cantidad;
            NuevoRequestProduct = new RequestProduct {PName = tmpProduct.Name, PNItems =  cantidad, PPriceU = PrecioU, PPriceT = PrecioT, PurlImage = tmpProduct.Pictures.FirstOrDefault().URL};
            Pedido.Pedidos.Add(NuevoRequestProduct);
            AppButtonAgregar.IsEnabled = false;
        }

        private void AppButtonVer_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PedidoView));
        }

        private async void ListaDeMateriales_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (ListaDeMateriales.SelectedItem != null)
            {
                tmpMaterial.Name = (ListaDeMateriales.SelectedItem as Material).Name;
                tmpMaterial.CommercialName= (ListaDeMateriales.SelectedItem as Material).CommercialName;
                tmpMaterial.Unit = (ListaDeMateriales.SelectedItem as Material).Unit;
                tmpMaterial.UnitPrice= (ListaDeMateriales.SelectedItem as Material).UnitPrice;
                tmpMaterial.Color = (ListaDeMateriales.SelectedItem as Material).Color;
                listProveedor = (ListaDeMateriales.SelectedItem as Material).Suppliers;
                ListBoxProveedores.ItemsSource = listProveedor;
                cargardoDedatosFeo(tmpMaterial);
            }
            else 
            {
                var message = new Windows.UI.Popups.MessageDialog("No se pudo obtener datos de los materiales", "Conexion");
                message.DefaultCommandIndex = 1;
                await message.ShowAsync();
            }
        }
        public void cargardoDedatosFeo(Material a)
        {
            TextNombreComercial.Text = tmpMaterial.CommercialName;
            TextColorMaterial.Text = tmpMaterial.Color.ToString();
            TextTipoUnidad.Text = tmpMaterial.Unit;
            TextCostoUnidadMaterial.Text = tmpMaterial.UnitPrice.ToString();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Productos));
        }
        
        private double GetPrecio(ProductoCantidad x)
        {
            double precio = 0;
            foreach (var material in x.Producto.Materials)
            {
                precio += material.UnitPrice;
            }
            return precio;
        }
    }
}
