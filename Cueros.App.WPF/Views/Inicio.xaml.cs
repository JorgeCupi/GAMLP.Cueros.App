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
    public partial class Inicio : Window
    {
        public Inicio()
        {
            InitializeComponent();

        }
        private void Click_Cueros(object sender, RoutedEventArgs e)
        {
            MainWindow MainW = new MainWindow();
            MainW.Show();
            this.Hide();
        }
        private void Click_work(object sender, RoutedEventArgs e)
        {
            Working MainW = new Working();
            MainW.Show();
            this.Hide();
        }
        
    }
}
