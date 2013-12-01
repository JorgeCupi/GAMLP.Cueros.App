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

namespace Cueros.App.WPF.Views
{
    /// <summary>
    /// Interaction logic for Inicio.xaml
    /// </summary>
    public partial class Inicio 
    {
        public Inicio()
        {
            InitializeComponent();

        }

        private void Cueros_MouseDown(object sender, MouseButtonEventArgs e)
        {

            MainWindow MainW = new MainWindow(this);
            MainW.Show();
            this.Hide();
        }

        private void Work_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Working MainW = new Working();
            MainW.Show();
            this.Hide();
        }
                
    }
}
