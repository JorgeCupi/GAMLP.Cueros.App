using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Cueros.App.Core.Models;
using Cueros.App.Phone.Models;
using System.Collections.ObjectModel;

namespace Cueros.App.Phone.Views
{
    public partial class Carrito : PhoneApplicationPage
    {
        ObservableCollection<Order> pro;

        public Carrito()
        {
            InitializeComponent();
            Loaded += Carrito_Loaded;
        }

        void Carrito_Loaded(object sender, RoutedEventArgs e)
        {
            pro = new Almacenar<Order>().Deserialize("Pedidos.json");
            if (pro == null)
            {
                pro = new ObservableCollection<Order>();
            }
            pendientes.ItemsSource = pro.ToList();
        }
    }
}