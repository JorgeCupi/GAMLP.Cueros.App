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
using Cueros.App.Store.Class;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Cueros.App.Store.Class
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
            gdvContainer.ItemsSource = Pedido.Pedidos;
            txbPrecioFinal.Text = "\t" + GetPrecioTotal();
        }

        private double GetPrecioTotal()
        {
            double precio = 0;
            foreach (var item in Pedido.Pedidos)
            {
                precio += item.PPriceT;
            }
            return precio;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Productos), Pedido.Pedidos);
        }
    }

}
