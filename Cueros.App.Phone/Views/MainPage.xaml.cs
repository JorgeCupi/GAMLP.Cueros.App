using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Cueros.App.Phone.Resources;
using Cueros.App.Phone.Models;
using Cueros.App.Core.Services;
using System.Collections.ObjectModel;
using Cueros.App.Core.Models;
using Cueros.App.Phone.Views;

namespace Cueros.App.Phone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        private void SeleccionaRubro(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/Catalogo.xaml", UriKind.Relative));
        }
    }
}