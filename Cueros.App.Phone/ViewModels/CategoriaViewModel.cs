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
        public ObservableCollection<Producto> Productos
        {
            get { return productos; }
            set { productos = value; }
        }

        public CategoriaViewModel()
        {
            productos = new Almacenar<Producto>().Deserialize("lista.xml");
            datos();
        }

        public async void datos()
        {
            List<Producto> pro = await ServiciosDeProductos.ObtenerProductos();
            productos = new ObservableCollection<Producto>(pro);
            new Almacenar<Producto>().Serialize(productos, "lista.xml");
        }


    }
}
