using Cueros.App.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cueros.App.Core.Services
{
    public static class ServiciosDeProductos
    {
        /// <summary>
        /// Metodo RE CONTRA beta para realizar pruebas ante un archivo JSON que a futuro sera descargado desde la DB ya con ciertos parametros. Por el momento, no se realizan consultas especificas, si no solo se recibe una lista de 18 productos.
       /// </summary>
        /// <returns></returns>
        public static async Task<List<Producto>> ObtenerProductos()
        {
            string url = "https://dl.dropboxusercontent.com/s/7f402dzmqmw871m/CUEROS.json?dl=1&token_hash=AAHNw7NngxtL3TRef5pTNFNe-jYRKekuEczDA8bhEnvdsQ";
            string response = await Utilities.DownloadJsonFromThisUrl(url);

            return Utilities.TransformToList(response);
        }

        public static async Task<List<Producto>> ObtenerProductos(string Linea)
        {
            string url = "https://dl.dropboxusercontent.com/s/7f402dzmqmw871m/CUEROS.json?dl=1&token_hash=AAHNw7NngxtL3TRef5pTNFNe-jYRKekuEczDA8bhEnvdsQ";
            string response = await Utilities.DownloadJsonFromThisUrl(url);

            return Utilities.GetProductsWithThisLine(response, Linea);
        }
    }
}
