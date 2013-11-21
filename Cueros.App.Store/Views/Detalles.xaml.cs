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
using Cueros.App.Core.Services;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Cueros.App.Store.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Detalles : Page
    {
        //Este será el pedido, se sincronizará en todos los views
        private List<Producto> Pedido = new List<Producto>();

        public Detalles()
        {
            this.InitializeComponent();
            this.Loaded += Detalles_Loaded;
        }

        void Detalles_Loaded(object sender, RoutedEventArgs e)

        { 
        
        
        
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var Lista = e.Parameter as List<Producto>;
            this.Pedido = Lista;

        }
        async void ObtenerProducto() {

            Producto producto;
            List<Producto> list_new = new List<Producto>();
            foreach (var item in await ServiciosDeProductos.GetProducts())
            {
                producto= new Producto()
                {
                    Nombre = item.Nombre,
                 Descripcion=item.Descripcion,
                };
                list_new.Add(producto);
            }
         
            GridImagen.DataContext = list_new;
        }



    }
}
