using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cueros.App.Phone.ViewModels
{
    public class CategoriaViewModel : NotificationEnabledObject
    {
        private ObservableCollection<Models.Categoria> categoria;
        public ObservableCollection<Models.Categoria> Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public CategoriaViewModel()
        {
        }
    }
}
