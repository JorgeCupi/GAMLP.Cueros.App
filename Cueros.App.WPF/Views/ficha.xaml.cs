using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using Cueros.App.Core.Models;
using Cueros.App.Core.Services;

namespace Cueros.App.WPF.Views
{
    /// <summary>
    /// Interaction logic for ficha.xaml
    /// </summary>
    public partial class ficha :MetroWindow
    {
        public ficha()
        {
            InitializeComponent();
            Loaded += ficha_Loaded;
        }

        void ficha_Loaded(object sender, RoutedEventArgs e)
        {
            MaterialesFicha();
        }

        async void MaterialesFicha()
        {
            try
            {
                List<Material> materiales = await MaterialsServices.GetMaterials();
                ListaMateriales.ItemsSource = materiales;
            }
            catch (Exception ) 
            {
                List<Material> get_list = new List<Material>();
                get_list.Add(new Material()
                {
                    Name = "O.o oops, ahora no podemos conextarnos, intenta más tarde"
                });
            }
        }

        private void ListaMateriales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Material = ListaMateriales.SelectedItem as Material;
            Proveedores.ItemsSource = Material.Suppliers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
