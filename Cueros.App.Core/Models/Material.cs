using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cueros.App.Core.Models
{
    public class Material
    {
        public string Nombre { get; set; }
        public string NombreComercial { get; set; }
        public string Color { get; set; }
        public string TipoUnidad { get; set; }
        public double CostoUnidad { get; set; }
        public List<Proveedor> Proveedores { get; set; }
    }
}
