using System.Collections.Generic;

namespace Cueros.App.Core.Models
{
    public class Resultado
    {
        public List<Producto> Productos { get; set; }
    }

    public class ResultadoDeCategorias
    {
        public List<Categoria> Categorias { get; set; }
    }
}