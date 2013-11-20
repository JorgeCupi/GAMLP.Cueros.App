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
        }

        void listarMateriales()
        {
            var ListaM = pro.Materiales;
            
            List<Material> list_new = new List<Material>();
            Material m;

            foreach(var item in ListaM)
            {
                m = new Material()
                {
                    Nombre = item.Nombre,
                    Color = item.Color,
                    NombreComercial = item.NombreComercial,
                    TipoUnidad = item.TipoUnidad,
                    CostoUnidad = item.CostoUnidad
                };
                list_new.Add(m);
            }
            ListaMateriales.ItemsSource = list_new;
        }

    }
}
