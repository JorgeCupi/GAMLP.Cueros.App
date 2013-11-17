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
        #region Atributes
        public static string url { get; set; }
        public static string response { get; set; }
        public static List<Producto> list { get; set; }
        #endregion

        #region All products
        /// <summary>
        /// Obtiene todos los productos de la base de datos.
        /// </summary>
        public static async Task<List<Producto>> GetProducts()
        {
            url = "https://dl.dropboxusercontent.com/s/sz7n21swk4vv15s/CUEROS.json?dl=1&token_hash=AAGvd8odSNROK7fuPa3aUMscH5nR2wbUqvtBZEkCDYFpYQ";
            response = await Utilities.DownloadJsonFromThisUrl(url);

            return Utilities.TransformToProductList(response);
        }
        /// <summary>
        /// Obtiene los N productos mas nuevos de la base de datos.
        /// </summary>
        /// <param name="MaxResults">Numero maximo de resultados a obtener.</param>
        public static async Task<List<Producto>> GetRecentProducts(int MaxResults)
        {
            list = await GetProducts();
            MaxResults = CheckValueForMaxResult(MaxResults, list.Count);
            return GetRecentProducts(list).Take(MaxResults).ToList();
        }
        /// <summary>
        /// Obtiene los ultimos N productos mas vendidos de la base de datos.
        /// </summary>
        /// <param name="MaxResults">Numero maximo de resultados a obtener.</param>
        public static async Task<List<Producto>> GetTopProducts(int MaxResults)
        {
            list = await GetProducts();
            MaxResults = CheckValueForMaxResult(MaxResults, list.Count);
            return GetTopProducts(list).Take(MaxResults).ToList();
        }
        #endregion

        #region Products from this category
        /// <summary>
        /// Obtiene todos los productos de una categoria.
        /// </summary>
        /// <param name="IdCategory">Id de la categoria.</param>
        public static async Task<List<Producto>> GetProductsFromThisCategory(string IdCategory)
        {
            url = "https://dl.dropboxusercontent.com/s/sz7n21swk4vv15s/CUEROS.json?dl=1&token_hash=AAGvd8odSNROK7fuPa3aUMscH5nR2wbUqvtBZEkCDYFpYQ";
            response = await Utilities.DownloadJsonFromThisUrl(url);
            list = Utilities.TransformToProductList(response);
            return GetProductsFromThisCategory(list, IdCategory);
        }
        /// <summary>
        /// Obtiene los ultimos N productos de una categoria.
        /// </summary>
        /// <param name="IdCategory">Id de la categoria.</param>
        /// <param name="MaxResults">Numero maximo de resultados que se desea obtener.</param>
        public static async Task<List<Producto>> GetProductsFromThisCategory(string IdCategory, int MaxResults)
        {
            list = await GetProductsFromThisCategory(IdCategory);
            MaxResults = CheckValueForMaxResult(MaxResults, list.Count);
            return list.Take(MaxResults).ToList();
        }
        #endregion

        #region Recent products from this category
        /// <summary>
        /// Obtiene todos los productos de una categoria, ordenados por su fecha de creacion.
        /// </summary>
        /// <param name="IdCategory">Id de la categoria.</param>
        public static async Task<List<Producto>> GetRecentProductsFromThisCategory(string IdCategory)
        {
            url = "https://dl.dropboxusercontent.com/s/sz7n21swk4vv15s/CUEROS.json?dl=1&token_hash=AAGvd8odSNROK7fuPa3aUMscH5nR2wbUqvtBZEkCDYFpYQ";
            response = await Utilities.DownloadJsonFromThisUrl(url);
            list = await GetProductsFromThisCategory(IdCategory);
            return GetRecentProducts(list);
        }
        /// <summary>
        /// Obtiene los ultimos N productos mas recientes de una categoria.
        /// </summary>
        /// <param name="IdCategory">Id de la categoria.</param>
        /// <param name="MaxResults">Numero maximo de resultados que se desea obtener.</param>
        public static async Task<List<Producto>> GetRecentProductsFromThisCategory(string IdCategory, int MaxResults)
        {
            list = await GetRecentProductsFromThisCategory(IdCategory);
            MaxResults = CheckValueForMaxResult(MaxResults, list.Count);
            return list.Take(MaxResults).ToList();
        }
        #endregion

        #region Top products from this category
        /// <summary>
        /// Obtiene todos los productos de una categoria, ordenados por su numero de ventas.
        /// </summary>
        /// <param name="IdCategory">Id de la categoria.</param>
        public static async Task<List<Producto>> GetTopProductsFromThisCategory(string IdCategory)
        {
            url = "https://dl.dropboxusercontent.com/s/sz7n21swk4vv15s/CUEROS.json?dl=1&token_hash=AAGvd8odSNROK7fuPa3aUMscH5nR2wbUqvtBZEkCDYFpYQ";
            response = await Utilities.DownloadJsonFromThisUrl(url);
            list = await GetProductsFromThisCategory(IdCategory);
            return GetTopProducts(list);
        }
        /// <summary>
        /// Obtiene los ultimos N productos mas vendidos de una categoria.
        /// </summary>
        /// <param name="IdCategory">Id de la categoria.</param>
        /// <param name="MaxResults">Numero maximo de resultados que se desea obtener.</param>
        public static async Task<List<Producto>> GetTopProductsFromThisCategory(string IdCategory, int MaxResults)
        {
            list = await GetProductsFromThisCategory(IdCategory);
            MaxResults = CheckValueForMaxResult(MaxResults, list.Count);
            return list.Take(MaxResults).ToList();
        }
        #endregion

        #region Private Methods

        private static int CheckValueForMaxResult(int MaxResult, int ListCount)
        {
            if (MaxResult > ListCount || MaxResult <= 0)
                return ListCount;
            else return MaxResult;
        }

        private static List<Producto> GetTopProducts(List<Producto> list)
        {
            IEnumerable<Producto> query = (from P in list
                                           orderby P.VentasRealizadas descending
                                           select P);
            return query.ToList();
        }

        private static List<Producto> GetRecentProducts(List<Producto> list)
        {
            IEnumerable<Producto> query = (from P in list
                                           orderby P.FechaPublicacion descending
                                           select P);
            return query.ToList();
        }

        private static List<Producto> GetProductsFromThisCategory(List<Producto> list, string IdCategory)
        {
            IEnumerable<Producto> query = (from P in list
                                           where P.Categoria.Id == IdCategory
                                           select P);
            return query.ToList();
        }
        #endregion
    }
}
