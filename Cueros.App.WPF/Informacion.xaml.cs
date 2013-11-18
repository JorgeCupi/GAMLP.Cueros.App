﻿using System;
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

namespace Cueros.App.WPF
{
    /// <summary>
    /// Interaction logic for Informacion.xaml
    /// </summary>
    public partial class Informacion : Window
    {
        private Core.Models.Categoria categoria;

        public Informacion(Core.Models.Categoria categoria)
        {
            InitializeComponent();
            this.categoria = categoria;
        }
    }
}
