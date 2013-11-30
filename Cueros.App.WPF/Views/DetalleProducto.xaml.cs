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

namespace Cueros.App.WPF
{
    /// <summary>
    /// Interaction logic for DetalleProducto.xaml
    /// </summary>
    public partial class DetalleProducto : Window
    {

        string nombreProductoObt;
        public ObservableCollection<Producto> producto;
        private Producto producto1;
        private List<Producto> Carrito;
        private int cantidad;
        private MainWindow mainWindow;
        private Informacion informacion;


        public DetalleProducto(Producto producto1, MainWindow mainWindow)
        {
            this.producto1 = producto1;
            this.mainWindow = mainWindow;           
            InitializeComponent();
            this.Loaded += DetalleProducto_Loaded;
            btnMateriales.Click += btnMateriales_Click;
            btnIncio.Click += btnIncio_Click;
            btnCarrito.Click += btnCarrito_Click;
            btnPedido.Click += btnPedido_Click;
        }

        public DetalleProducto(Producto producto1, Informacion informacion)
        {
            this.producto1 = producto1;
            this.informacion = informacion;
            InitializeComponent();
            this.Loaded += DetalleProducto_Loaded;
            btnMateriales.Click += btnMateriales_Click;
            btnIncio.Click += btnIncio_Click;
            btnCarrito.Click += btnCarrito_Click;
            btnPedido.Click += btnPedido_Click;
        }

        void btnPedido_Click(object sender, RoutedEventArgs e)
        {
            if (!TextCantidad.Text.Equals(""))
            {
                this.cantidad = Convert.ToInt32(TextCantidad.Text);
                Owner = this;
               Show();
            }
            else
            {
                MessageBox.Show("Necesita introducir una cantidad en la caja de texto de la derecha por favor");
            }

        }

        void btnCarrito_Click(object sender, RoutedEventArgs e)
        {
            //Carrito.Add(producto1);
        }

        void btnIncio_Click(object sender, RoutedEventArgs e)
        {
            if (mainWindow != null)
            {
                mainWindow.Show();
            }
            if (informacion != null)
            {
                informacion.Show();
            }
            this.Hide();            
        }

        void btnMateriales_Click(object sender, RoutedEventArgs e)
        {
            Materiales Ma = new Materiales(producto1);
            Ma.Owner = this;
           // this.Hide();
            Ma.Show();
        }

        void DetalleProducto_Loaded(object sender, RoutedEventArgs e)
        {
            
                ProductoLista();
            
            
        }

        void ProductoLista()
        {

            txtId.Text = producto1.Id;
            
            txtLinea.Text = producto1.Nombre;
            txtDescripcion.Text = producto1.Descripcion;
            
            txtModelo.Text = producto1.Modelo;
            txtTemporada.Text = producto1.Temporada;

        }
    }
}
