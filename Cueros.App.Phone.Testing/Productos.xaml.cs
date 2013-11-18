using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Cueros.App.Phone.Testing
{
    public partial class Productos : PhoneApplicationPage
    {
        public Productos()
        {
            InitializeComponent();

            lstNuevos.Tap += NavigateToThisProduct;
            lstTodos.Tap += NavigateToThisProduct;
            lstTop.Tap += NavigateToThisProduct;

            FillItems();
        }

        private void FillItems()
        {
            lstTodos.Items.Add("meh");
            lstTodos.Items.Add("meh");
            lstTodos.Items.Add("meh");
            lstTodos.Items.Add("meh");
            lstTodos.Items.Add("meh");
            lstTodos.Items.Add("meh");
            lstTodos.Items.Add("meh");
            lstTodos.Items.Add("meh");
            lstTodos.Items.Add("meh");
            lstTodos.Items.Add("meh");
            lstTodos.Items.Add("meh");

            lstNuevos.Items.Add("bla");
            lstNuevos.Items.Add("bla");
            lstNuevos.Items.Add("bla");
            lstNuevos.Items.Add("bla");
            lstNuevos.Items.Add("bla");

            lstTop.Items.Add("blaa");
            lstTop.Items.Add("blaa");
            lstTop.Items.Add("blaa");
            lstTop.Items.Add("blaa");
            lstTop.Items.Add("blaa");
        }

        private void NavigateToThisProduct(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DetalleProducto.xaml",UriKind.Relative));
        }
    }
}