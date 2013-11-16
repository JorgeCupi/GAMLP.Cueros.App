using System.Collections.Generic;

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