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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Cueros.App.Store.UserControls
{
    public sealed partial class TileListaPedido : UserControl
    {
        private string precioUnitario;
        private string precioTotal;
        private string nombreProductoTile;
        public ImageSource imagenTile;
        private SolidColorBrush fondoDeTile;


        public SolidColorBrush FondoDeTile
        {

            set
            {
                fondoDeTile = value;
                TileProducto.Background = value;
            }
            get
            {
                return fondoDeTile;
            }

        }
        public ImageSource ImagenTile
        {
            set
            {
                imagenTile = value;
                ImagenMiniaturaTile.Source = ImagenTile;
            }
            get
            {
                return imagenTile;
            }

        }



        public string NombreProductoTile
        {
            set
            {
                nombreProductoTile = value;
                TextoNombreProducto.Text = NombreProductoTile;
            }
            get
            {
                return nombreProductoTile;
            }
        }

        public string PrecioTotal
        {
            set
            {
                precioTotal = value;
                TextoPrecioTotal.Text = PrecioTotal;
            }
            get
            {
                return precioTotal;
            }
        }

        public string PrecioUnitario
        {
            set
            {
                precioUnitario = value;
                TextoPrecioUnitario.Text = PrecioUnitario;
            }
            get
            {
                return precioUnitario;
            }
        }
        public TileListaPedido()
        {
            this.InitializeComponent();
        }
    }
}
