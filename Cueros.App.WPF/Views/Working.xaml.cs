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
    /// Interaction logic for Working.xaml
    /// </summary>
    public partial class Working : Window
    {
        public Working()
        {
            InitializeComponent();
        }
        private void Click_Volver(object sender, RoutedEventArgs e)
        {
            Inicio MainW = new Inicio();
            MainW.Show();
            this.Hide();
        }
    }
}
