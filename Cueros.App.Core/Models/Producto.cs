using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cueros.App.Core.Models
{
    public class Producto
    {
        public string Id { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string Linea { get; set; }
        public string Temporada { get; set; }
        public List<Foto> Fotos { get; set; }
        public List<Material> Materiales { get; set; }
    }
}
