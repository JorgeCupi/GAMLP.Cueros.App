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
using Cueros.App.Core.Services;
using Cueros.App.Core.Models;
using System.Collections.ObjectModel;
using Cueros.App.WPF.Views;
using MahApps.Metro.Controls;

namespace Cueros.App.WPF.Views
{
    /// <summary>
    /// Interaction logic for RPedido.xaml
    /// </summary>
    public partial class RPedido : MetroWindow
    {

        private Producto pro;
        private double precioTotal;
        private double costo = 15.5;
        private int cantidad;
        private int tiempo = 45;
        private int tiempoCreacion;
        private int t = 1440;
        private int dias;
        private Pedido pedidos;
        private List<Producto> listaProductos;
        private Detalle det;

        public RPedido(Producto p, Detalle Detail)
        {
            InitializeComponent();
            det = Detail;
            pro = p;
            listaProductos = new List<Producto>();
            Loaded += RPedido_Loaded;
            Cant.TextChanged +=Cant_TextChanged;
        }

        void RPedido_Loaded(object sender, RoutedEventArgs e)
        {
            DetallesP.DataContext = pro;
            imagen.ItemsSource = pro.Fotos;
            precioTotal = costo * Convert.ToInt32(Cant.Text);
            Total.Content = precioTotal;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            det.Show();
            this.Hide();
        }

        private void Cant_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Cant.Text.Equals(""))
            {
                this.precioTotal = costo * Convert.ToInt32(Cant.Text);
                Total.Content = precioTotal.ToString();
            }
            
        }
    }
}