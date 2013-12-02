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
using Cueros.App.Core.Models;
using Cueros.App.Core.Services;

namespace Cueros.App.WPF
{
    /// <summary>
    /// Interaction logic for Materiales.xaml
    /// </summary>
    public partial class Materiales : Window
    {
        private Product pro;

        public Materiales(Product pro)
        {
            InitializeComponent();
            this.pro = pro;
            listarMateriales();
            btnInicio.Click += btnInicio_Click;
        }

        void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

        }

        void listaProveedores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var material = ListaMateriales.SelectedItem as Material;

            List<Supplier> prov = new List<Supplier>();

            string pr;

            
        }

        void listarProveedores()
        {
            

        }

        void listarMateriales()
        {

            var ListaM = pro.Materials;
            List<string> Mat = new List<string>();
            string M;


            foreach (var item in ListaM)
            {
                
                M = "Material: " + item.Name;
                M = M + " \n";
                M = M + "Nombre Comercial: " + item.CommercialName;
                M = M + " \n";
                M = M + "Tipo Unidad: " + item.Unit;
                M = M + " \n";
                M = M + "Color: " + item.Color;
                M = M + " \n";
                M = M + "Costo unidad: " + item.UnitPrice;
                Mat.Add(M);
                
            }

            //List<Material> list_new = new List<Material>();
            //Material m;

            //foreach (var item in ListaM)
            //{
            //    m = new Material()
            //    {
            //        Nombre = item.Nombre,
            //        Color = item.Color,
            //        NombreComercial = item.NombreComercial,
            //        TipoUnidad = item.TipoUnidad,
            //        CostoUnidad = item.CostoUnidad
            //    };
            //    list_new.Add(m);
            //}
            //ListaMateriales.ItemsSource = list_new;

            ListaMateriales.ItemsSource = Mat;
        }

    }
}
