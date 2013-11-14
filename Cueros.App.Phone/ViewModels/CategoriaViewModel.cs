using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cueros.App.Core.Models;
using Cueros.App.Core.Services;
using Cueros.App.Phone.Models;

namespace Cueros.App.Phone.ViewModels
{
    public class CategoriaViewModel : NotificationEnabledObject
    {
        private ObservableCollection<Producto> productos;
        private ObservableCollection<Categoria> categorias;
        private ObservableCollection<Producto> productoscategoria;

        public ObservableCollection<Producto> ProductosCategoria
        {
            get { return productoscategoria; }
            set
            {
                productoscategoria = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Categoria> Categorias
        {
            get { return categorias; }
            set
            {
                categorias = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Producto> Productos
        {
            get { return productos; }
            set
            {
                productos = value;
                OnPropertyChanged();
            }
        }

        public CategoriaViewModel()
        {
            productos = new Almacenar<Producto>().Deserialize("lista.xml");
            categorias = new Almacenar<Categoria>().Deserialize("categoria.xml");
            obtenerdatos();
        }

        public async void obtenerdatos()
        {
            try
            {
                List<Producto> pro = await ServiciosDeProductos.ObtenerProductos();
                productos = new ObservableCollection<Producto>(pro);
                categoria();
                new Almacenar<Producto>().Serialize(productos, "lista.xml");
                new Almacenar<Categoria>().Serialize(categorias, "categoria.xml");
            }
            catch (Exception)
            {
            }
        }

        public void categoria()
        {
            categorias = new ObservableCollection<Categoria>();
            foreach (var item in productos)
            {
                if(categorias.Where(i => i.categoria.Equals(item.Linea)).Count() == 0){
                    categorias.Add(new Categoria()
                    {
                        categoria = item.Linea,
                        image = "/Assets/Tiles/FlipCycleTileSmall.png"
                        //image = item.Fotos.First().URL
                    });
                }
            }
        }

        public void prodcat(string categoria)
        {
            productoscategoria = new ObservableCollection<Producto>();
            foreach (var item in productos)
            {
                if (item.Linea.Equals(categoria))
                {
                    productoscategoria.Add(item);
                }
            }
        }
    }
}
