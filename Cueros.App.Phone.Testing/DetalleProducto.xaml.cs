using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Cueros.App.Phone.Testing
{
    public partial class DetalleProducto : PhoneApplicationPage
    {
        public DetalleProducto()
        {
            InitializeComponent();
            FillPictures();
        }

        private void FillPictures()
        {
            lstMateriales.Items.Add("blaaa");
            lstMateriales.Items.Add("blaaa");
            lstMateriales.Items.Add("blaaa");
            lstMateriales.Items.Add("blaaa");
            lstMateriales.Items.Add("blaaa");
            lstMateriales.Items.Add("blaaa");

            lstFotos.Items.Add("mee");
            lstFotos.Items.Add("mee");
            lstFotos.Items.Add("mee");
            lstFotos.Items.Add("mee");
        }
    }
}