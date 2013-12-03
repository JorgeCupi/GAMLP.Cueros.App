using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Cueros.App.Phone.Testing.Resources;
using Cueros.App.Core.Services;
using Cueros.App.Core.Models;

namespace Cueros.App.Phone.Testing
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
            lstCategorias.Tap += lstCategorias_Tap;

            lstTop.Tap += NavigateThisProduct;
            lstNuevos.Tap += NavigateThisProduct;
            FillListNews();
        }

        void NavigateThisProduct(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DetalleProducto.xaml", UriKind.Relative));
        }

        private void FillListNews()
        {
            lstNuevos.Items.Add("blaa");
            lstNuevos.Items.Add("blaa");
            lstNuevos.Items.Add("blaa");
            lstNuevos.Items.Add("blaa");
            lstNuevos.Items.Add("blaa");
            lstNuevos.Items.Add("blaa");

            lstTop.Items.Add("bleee");
            lstTop.Items.Add("bleee");
            lstTop.Items.Add("bleee");
            lstTop.Items.Add("bleee");
            lstTop.Items.Add("bleee");
            lstTop.Items.Add("bleee");
            lstTop.Items.Add("bleee");
            lstTop.Items.Add("bleee");
        }

        void lstCategorias_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Productos.xaml", UriKind.Relative));
        }

        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //List<Product> products = await ProductsServices.GetProducts();
            //MessageBox.Show(products.Count.ToString());

            //lstCategorias.ItemsSource = await CategoriesServices.GetListOfCategories();

            //List<Supplier> suppliers = await SuppliersServices.GetSuppliers();
            //MessageBox.Show(suppliers.Count.ToString());

            //Supplier supplier = await SuppliersServices.GetSupplier(4);
            //MessageBox.Show(supplier.Name);

            //List<Material> materials = await MaterialsServices.GetMaterials();
            //MessageBox.Show(materials.Count.ToString());

            List<Picture> pictures = await PicturesServices.GetPictures();
            MessageBox.Show(pictures.Count.ToString());
        }
    }
}
