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
    public sealed partial class Materiales : Page
    {
        public Materiales()
        {
            this.InitializeComponent();
            this.Loaded += Materiales_Loaded;
        }

    void Materiales_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMaterialList();
        }

    async void LoadMaterialList() {
        var get_list = await ServiciosDeProductos.GetProducts();
        //NewProduct product;
        List<Material> list_new = new List<Material>();
        Material m;
        foreach (var item in get_list)
        {
            m = new Material() {Nombre = item.Materiales.FirstOrDefault().Nombre,
            Color = item.Materiales.FirstOrDefault().Color, 
            NombreComercial=item.Materiales.FirstOrDefault().NombreComercial,
            TipoUnidad =item.Materiales.FirstOrDefault().TipoUnidad,
            CostoUnidad= item.Materiales.FirstOrDefault().CostoUnidad};
            list_new.Add(m);
        }
        ListaDeMateriales.ItemsSource = list_new;
    
    }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        
        
        }

  
    }
}
