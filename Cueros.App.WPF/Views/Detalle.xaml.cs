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
using Cueros.App.Core.Services;
using Cueros.App.Core.Models;
using System.Collections.ObjectModel;
using Cueros.App.WPF.Views;
using MahApps.Metro.Controls;

namespace Cueros.App.WPF.Views
{
    /// <summary>
    /// Interaction logic for Detalle.xaml
    /// </summary>
    public partial class Detalle : MetroWindow
    {
        private Product producto1;
        private MainWindow mainWindow;
        private Informacion informacion;
        List<Order> ListaPedido;


        public Detalle(Product pro, MainWindow mainWindow, List<Order> L)
        {
            producto1 = pro;
            ListaPedido = L;
            this.mainWindow = mainWindow; 
            InitializeComponent();
            Loaded += Detalle_Loaded;
        }
        public Detalle(Product pro, Informacion info)
        {
            producto1 = pro;
            this.informacion = info;
            InitializeComponent();
            Loaded += Detalle_Loaded;
        }
        void Detalle_Loaded(object sender, RoutedEventArgs e)
        {
            pro.DataContext = producto1;
            imagenes.ItemsSource = producto1.Pictures;
            ListaMateriales.ItemsSource=producto1.Materials;
            ListaMateriales.SelectionChanged += ListaMateriales_SelectionChanged;
        }
        void ListaMateriales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var material = ListaMateriales.SelectedItem as Material;
            Prov.ItemsSource = material.Suppliers;
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
                RPedido p = new RPedido(producto1, this, ListaPedido);
                p.Show();
                this.Hide();
        }

    }
}
