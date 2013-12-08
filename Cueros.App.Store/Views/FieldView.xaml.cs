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

namespace Cueros.App.Store.Class
{
    public sealed partial class FieldView : Page
    {
        public FieldView()
        {
            this.InitializeComponent();
            this.Loaded += FieldView_Loaded;
        }

        #region Loaded
        void FieldView_Loaded(object sender, RoutedEventArgs e)
        {
            Pedido.Pedidos = new List<RequestProduct>();
        }
        #endregion

        #region GridViewMenu Tapped
        private void GridViewMenu_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Productos));
        }
        #endregion
    }
}
