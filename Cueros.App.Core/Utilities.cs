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

        internal static List<Product> TransformToProductList(string response)
        {
            ProductsResults res = JsonConvert.DeserializeObject<ProductsResults>(response);
            return res.data;
        }

        internal static List<Category> TransformToCategoriesList(string response)
        {
            CategoriesResults res = JsonConvert.DeserializeObject<CategoriesResults>(response);
            return res.data;
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
            catch (Exception e)
            {
                string ex = e.ToString();
                return "Error 400"; // No se pudo realizar la descarga del string.
            }
        }

        internal static Category TransformToCategory(string response)
        {
            return JsonConvert.DeserializeObject<Category>(response);
        }

        internal static List<Supplier> TransformToSuppliersList(string response)
        {
            return JsonConvert.DeserializeObject<List<Supplier>>(response);
        }

        internal static Supplier TransformToSupplier(string response)
        {
            return JsonConvert.DeserializeObject<Supplier>(response);
        }

        internal static Product TransformToProduct(string response)
        {
            return JsonConvert.DeserializeObject<Product>(response);
        }

        internal static List<Material> TransformToMaterialsList(string response)
        {
            MaterialsResults res = JsonConvert.DeserializeObject<MaterialsResults>(response);
            return res.data;
        }

        internal static Material TransformToMaterial(string response)
        {
            return JsonConvert.DeserializeObject<Material>(response);
        }

        internal static List<Order> TransformToOrdersList(string response)
        {
            return JsonConvert.DeserializeObject<List<Order>>(response);
        }

        internal static Order TransformToOrder(string response)
        {
            return JsonConvert.DeserializeObject<Order>(response);
        }

        internal static List<Picture> TransformToPicturesList(string response)
        {
            return JsonConvert.DeserializeObject<List<Picture>>(response);
        }

        internal static Picture TransformToPicture(string response)
        {
            return JsonConvert.DeserializeObject<Picture>(response);
        }
    }
}