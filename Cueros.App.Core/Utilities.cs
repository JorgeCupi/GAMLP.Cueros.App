using Cueros.App.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cueros.App.Core
{
    public static class Utilities
    {
        private static HttpClient client { get; set; }

        internal static List<Producto> TransformToProductList(string response)
        {
            Resultado res = JsonConvert.DeserializeObject<Resultado>(response);
            return res.Productos;
        }

        internal static List<Categoria> TransformToCategoriesList(string response)
        {
            ResultadoDeCategorias res =JsonConvert.DeserializeObject<ResultadoDeCategorias>(response);
            return res.Categorias;
        }

        public static async Task<string> DownloadJsonFromThisUrl(string url)
        {
            client = new HttpClient();
            try
            {
                Byte[] result = await client.GetByteArrayAsync(url);
                string res = System.Text.Encoding.UTF8.GetString(result, 0, result.Length);
                if (res != null)
                    return res;
                return "Error 404"; //No hay informacion.
            }
            catch (Exception)
            {
                return "Error 400"; // No se pudo realizar la descarga del string.
            }
        }

        internal static Categoria TransformToCategory(string response)
        {
            return JsonConvert.DeserializeObject<Categoria>(response);
        }
    }
}