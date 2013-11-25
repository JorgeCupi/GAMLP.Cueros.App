using System;
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
using Cueros.App.Core.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Cueros.App.Store.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PedidoView : Page
    {
        private double preciototal = 0;
        public double PrecioTotal 
        {
            get { return PrecioTotal; }
            set { PrecioTotal = value; }
        }

        private List<RequestProduct> pedido = new List<RequestProduct>();
        public List<RequestProduct> Pedido
        {
            get { return pedido; }
            set { pedido = value; }
        }

        public PedidoView()
        {
            this.InitializeComponent();
            txbPrecioFinal.Text = "\t" + preciototal;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var Nuevo = e.Parameter as ProductoCantidad;
            var NuevoProducto = new RequestProduct() { PName = Nuevo.Pro.Nombre, PPriceT = GetPrecio(Nuevo) * Nuevo.Cantidad, PPriceU = GetPrecio(Nuevo), 
                PNItems = Nuevo.Cantidad, PurlImage = Nuevo.Pro.Fotos.FirstOrDefault().URL };
            Pedido.Add(NuevoProducto);
            txbPrecioFinal.Text = "\t" + GetPrecioTotal();
        }

        private double GetPrecioTotal()
        {
            double precio = 0;
            foreach (var item in Pedido)
            {
                precio += item.PPriceT;
            }
            return precio;
        }
        private double GetPrecio(ProductoCantidad x)
        {
            double precio = 0;
            foreach (var material in x.Pro.Materiales)
            {
                precio += material.CostoUnidad;
            }
            return precio;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Productos));
        }
    }

    public class RequestProduct
    {
        public string PName { get; set; }
        public double PPriceT { get; set; }
        public double PPriceU { get; set; }
        public double PNItems { get; set; }
        public string PurlImage { get; set; }
    }
}
