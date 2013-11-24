using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Cueros.App.Phone.Views
{
    public partial class AgregarPedido : PhoneApplicationPage
    {
        public AgregarPedido()
        {
            InitializeComponent();
            Loaded += AgregarPedido_Loaded;
        }

        void AgregarPedido_Loaded(object sender, RoutedEventArgs e)
        {
            CargarAppBar();
        }
        private void CargarAppBar()
        {
            ApplicationBar = new ApplicationBar();
            ApplicationBarIconButton GuardarPedido = new ApplicationBarIconButton(new Uri("/Assets/AppBar/refresh.png", UriKind.Relative));
            GuardarPedido.Text = "Guardar Pedido";
            ApplicationBar.Buttons.Add(GuardarPedido);
            GuardarPedido.Click += GuardarPedido_Click;
        }

        void GuardarPedido_Click(object sender, EventArgs e)
        {
            //mandar a la lista de pedidos
            NavigationService.GoBack();
        }
    }
}