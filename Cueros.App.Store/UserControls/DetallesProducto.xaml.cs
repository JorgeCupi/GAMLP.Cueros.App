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
    public sealed partial class DetallesProducto : UserControl
    {
        private string name;
        private string nomCaracterista1;
        private string nomCaracterista3;
        private string nomCaracterista2;
        private string textValorCaracteristica1;
        private string textValorCaracteristica2;
        private string textValorCaracteristica3;

        public string ProdName
        {
            set
            {
                name = value;
                NombreProducto.Text = ProdName;
            }
            get
            {
                return name;
            }
        }


        public string NomCaracteristica1
        {
            set
            {
                nomCaracterista1 = value;
                NomProperty1.Text = this.NomCaracteristica1;
            }
            get
            {
                return nomCaracterista1;
            }
        }

        public string NomCaracteristica2
        {
            set
            {
                nomCaracterista2 = value;
                NomProperty2.Text = NomCaracteristica2;
            }
            get
            {
                return nomCaracterista2;
            }
        }
        public string NomCaracteristica3
        {
            set
            {
                nomCaracterista3 = value;
                NomProperty3.Text = NomCaracteristica3;
            }
            get
            {
                return nomCaracterista3;
            }
        }



        public string TextValorCaracteristica1
        {
            set
            {
                textValorCaracteristica1 = value;
                Property1.Text = TextValorCaracteristica1;
            }
            get
            {
                return textValorCaracteristica1;
            }
        }


        public string TextValorCaracteristica2
        {
            set
            {
                textValorCaracteristica2 = value;
                Property2.Text = TextValorCaracteristica2;
            }
            get
            {
                return textValorCaracteristica2;
            }
        }


        public string TextValorCaracteristica3
        {
            set
            {
                textValorCaracteristica3 = value;
                Property3.Text = TextValorCaracteristica3;
            }
            get
            {
                return textValorCaracteristica3;
            }
        }

        private void BotonAgregar_Click(object sender, RoutedEventArgs e)
        {
            //implementar agregar producto
        }


        public DetallesProducto()
        {
            this.InitializeComponent();
        }
    }
}
