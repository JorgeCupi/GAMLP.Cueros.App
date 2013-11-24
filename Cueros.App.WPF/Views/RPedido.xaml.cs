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

namespace Cueros.App.WPF.Views
{
    /// <summary>
    /// Interaction logic for RPedido.xaml
    /// </summary>
    public partial class RPedido : Window
    {

        private Producto pro = new Producto();
        private double precioTotal;
        private double costo = 15.5;
        private int cantidad;
        private int tiempo = 45;
        private int tiempoCreacion;
        private int t = 1440;
        private int dias;




        public RPedido(Producto p, int c)
        {

            this.pro = p;
            InitializeComponent();

            this.cantidad = c;
            LlenarTextos();

            btncalcular.Click += btncalcular_Click;
        }

        void btncalcular_Click(object sender, RoutedEventArgs e)
        {
            precioTotal = cantidad * costo;
            txtCostoTotal.Text = txtCostoTotal.Text + precioTotal.ToString() + " Bs.";
        }

        void LlenarTextos()
        {
            txtNombreP.Text = pro.Id;
            txtCantidad.Text = this.cantidad.ToString() + " Unidades";
            txtCostoU.Text = txtCostoU.Text + costo.ToString();
            tiempoCreacion = tiempo * cantidad;
            dias = tiempoCreacion / t;
            txtTC.Text = txtTC.Text + tiempoCreacion.ToString() + " minutos \n" + "El pedido se entregara en " + Convert.ToInt32(dias + 1).ToString() + " dias";
        }

    }
}