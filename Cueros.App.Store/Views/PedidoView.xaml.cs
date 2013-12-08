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


namespace Cueros.App.Store.Class
{
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            GridViewPedido.ItemsSource = Pedido.Pedidos;
            txbPrecioFinal.Text = "\t" + GetPrecioTotal();
        }

        private double GetPrecioTotal()
        {
            double precio = 0;
            var listPedido = Pedido.Pedidos;
            foreach (var item in listPedido)
            {
                precio += item.PPriceT;
            }
            return precio;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Productos), Pedido.Pedidos);
        }
    }

}
