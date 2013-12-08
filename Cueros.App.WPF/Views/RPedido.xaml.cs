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

        private Product pro;
        private double precioTotal;
        private double costo = 15.5;
        private int cantidad;
        private int tiempo = 45;
        private int tiempoCreacion;
        private int t = 1440;
        private int dias;
        private Order pedidos;
        private List<Product> listaProductos;
        private Detalle det;

        public RPedido(Product p, Detalle Detail)
        {
            InitializeComponent();
            det = Detail;
            pro = p;
            listaProductos = new List<Product>();
            Loaded += RPedido_Loaded;
           // Cant.TextChanged +=Cant_TextChanged;
        }

        void RPedido_Loaded(object sender, RoutedEventArgs e)
        {
            DetallesP.DataContext = pro;
            imagen.ItemsSource = pro.Pictures;
            precioTotal = costo * Convert.ToInt32(Cant.Text);
            //Total.Content = precioTotal;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            hacerPedido();
        }

        private async void hacerPedido()
        {
            Order or = new Order();
            or.ProductID = int.Parse(pro.ProductID);
            or.Quantity = Convert.ToInt32(Cant.Text);
            or.Date = DateTime.Today;
            bool sw = await OrdersServices.TryCreateOrder(or);
            if (sw)
            {
                MessageBox.Show("Se ha añadido a la orden");
            }
            else
            {
                MessageBox.Show("Se ha producido un error");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            det.Show();
            this.Close();
        }

        //private void Cant_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (!Cant.Text.Equals(""))
        //    {
        //        this.precioTotal = costo * Convert.ToInt32(Cant.Text);
        //        Total.Content = precioTotal.ToString();
        //    }
            
        //}
    }
}