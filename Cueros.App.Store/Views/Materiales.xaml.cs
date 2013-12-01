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
using Cueros.App.Store.Class;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Cueros.App.Store.Class
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Materiales : Page
    {
        Producto bx = null;
        Material m = new Material();
        ProductoCantidad NewP = new ProductoCantidad();
        List<Material> listMat = new List<Material>();
        List<Proveedor> listProv = new List<Proveedor>();

        public Materiales()
        {
            this.InitializeComponent();
            this.Loaded += Materiales_Loaded;
            AppButtonAgregar.Click +=AppButtonAgregar_Click;
            AppButtonVer.Click += AppButtonVer_Click;
        }

        void Materiales_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        void obtenerMateriales(Producto a)
        {
            listMat = a.Materiales;
            ListaDeMateriales.ItemsSource = listMat;
            FlipViewImagenes.ItemsSource = a.Fotos;
            TextNombreProductoCabezera.Text = a.Nombre;
            TextoDescripcionProducto.Text = a.Descripcion;
            TextoModeloProducto.Text = a.Modelo;
            TextoTemporadaProducto.Text = a.Temporada;
            TextoVentasProductos.Text = a.VentasRealizadas.ToString();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            bx = e.Parameter as Producto;
            obtenerMateriales(bx);
        }

        private void AppButtonAgregar_Click(object sender, RoutedEventArgs e)
        {
            int cantidad = int.Parse(TextBoxCantidadProductos.Text);
            ProductoCantidad pc = new ProductoCantidad() { Producto = bx, Cantidad = cantidad };
            double PrecioU = GetPrecio(pc);
            double PrecioT = PrecioU * cantidad;
            RequestProduct NuevoRequestProduct = new RequestProduct {PName = bx.Nombre, PNItems =  cantidad, PPriceU = PrecioU, PPriceT = PrecioT, PurlImage = bx.Fotos.FirstOrDefault().URL};
            Pedido.Pedidos.Add(NuevoRequestProduct);
            AppButtonAgregar.IsEnabled = false;
        }

        private void AppButtonVer_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PedidoView));
        }

        private void ListaDeMateriales_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (ListaDeMateriales.SelectedItem != null)
            {
                m.Nombre = (ListaDeMateriales.SelectedItem as Material).Nombre;
                m.NombreComercial = (ListaDeMateriales.SelectedItem as Material).NombreComercial;
                m.TipoUnidad = (ListaDeMateriales.SelectedItem as Material).TipoUnidad;
                m.CostoUnidad = (ListaDeMateriales.SelectedItem as Material).CostoUnidad;
                m.Color = (ListaDeMateriales.SelectedItem as Material).Color;
                listProv = (ListaDeMateriales.SelectedItem as Material).Proveedores;
                ListBoxProveedores.ItemsSource = listProv;
                cargardoDedatosFeo(m);
            }
        }
        public void cargardoDedatosFeo(Material a)
        {
           
            TextNombreComercial.Text = m.NombreComercial;
            TextColorMaterial.Text = m.Color.ToString();
            TextTipoUnidad.Text = m.TipoUnidad;
            TextCostoUnidadMaterial.Text = m.CostoUnidad.ToString();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
        
        private double GetPrecio(ProductoCantidad x)
        {
            double precio = 0;
            foreach (var material in x.Producto.Materiales)
            {
                precio += material.CostoUnidad;
            }
            return precio;
        }
    }
}
