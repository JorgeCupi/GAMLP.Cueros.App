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
        private Producto pro;

        public Materiales(Producto pro)
        {
            InitializeComponent();
            this.pro = pro;
            listarMateriales();
            btnInicio.Click += btnInicio_Click;
        }

        void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            this.Hide();
            home.Show();

        }

        void listaProveedores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var material = ListaMateriales.SelectedItem as Material;

            List<Proveedor> prov = new List<Proveedor>();

            string pr;

            foreach (var item in material)
            {
 
            }
        }

        void listarProveedores()
        {
            

        }

        void listarMateriales()
        {

            var ListaM = pro.Materiales;
            List<string> Mat = new List<string>();
            string M;


            foreach (var item in ListaM)
            {
                
                M = "Material: " + item.Nombre;
                M = M + " \n";
                M = M + "Nombre Comercial: " + item.NombreComercial;
                M = M + " \n";
                M = M + "Tipo Unidad: " + item.TipoUnidad;
                M = M + " \n";
                M = M + "Color: " + item.Color;
                M = M + " \n";
                M = M + "Costo unidad: " + item.CostoUnidad;
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
