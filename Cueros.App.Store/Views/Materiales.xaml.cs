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
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Cueros.App.Store.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Materiales : Page
    {

        Producto bx = null;
        Material m = new Material();
        ProductoAgregable NewP = new ProductoAgregable();
        List<Material> listMat = new List<Material>();
        List<Proveedor> listProv = new List<Proveedor>();

        public Materiales()
        {
            this.InitializeComponent();
            this.Loaded += Materiales_Loaded;
        }

        void Materiales_Loaded(object sender, RoutedEventArgs e)
        {
            obtenerMateriales(bx);
        }

        void obtenerMateriales(Producto a)
        {
            listMat = a.Materiales;
            ListaDeMateriales.ItemsSource = listMat;
            FlipViewImagenes.ItemsSource = a.Fotos;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            bx = e.Parameter as Producto;
            
        }
        private void AppBarButtonCrear_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void AppButtonAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxCantidadProductos.Text == null)
            {
                MessageDialog dialog = new MessageDialog("tengo Sueño", "Joder");
                await dialog.ShowAsync();
            }
            int cantidad = int.Parse(TextBoxCantidadProductos.Text);
            ProductoCantidad pc = new ProductoCantidad() {Pro = bx, Cantidad = cantidad};
            this.Frame.Navigate(typeof(PedidoView), pc);
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
            TextNombreProductoCabezera.Text = m.Nombre;
            TextNombreComercial.Text = m.NombreComercial;
            TextColorMaterial.Text = m.Color.ToString();
            TextTipoUnidad.Text = m.TipoUnidad;
            TextCostoUnidadMaterial.Text = m.CostoUnidad.ToString();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
        private void BotonAceptar_Click(object sender, RoutedEventArgs e)
        {

        }
    }


    public class ProductoAgregable : Producto
    {
        public int cantidad { get; set; }
    }
}
