using Cueros.App.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cueros.App.Core.Services
{
    public static class ServiciosDeCategorias
    {
        public static async Task<List<Categoria>> ObtenerListaDeCategorias()
        {
            string url = "https://dl.dropboxusercontent.com/s/7f402dzmqmw871m/CUEROS.json?dl=1&token_hash=AAHNw7NngxtL3TRef5pTNFNe-jYRKekuEczDA8bhEnvdsQ";
            string response = await Utilities.DownloadJsonFromThisUrl(url);

            return Utilities.TransformToCategoriesList(response);
        }
    }
}
