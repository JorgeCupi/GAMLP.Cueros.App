using Cueros.App.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cueros.App.Core.Services
{
    public static class ProductsServices
    {
        #region Atributes
        public static string url { get; set; }
        public static string response { get; set; }
        public static List<Product> list { get; set; }
        #endregion

        #region All products
        /// <summary>
        /// Obtiene todos los productos de la base de datos.
        /// </summary>
        public static async Task<List<Product>> GetProducts()
        {
            url = "http://cadepiacueros.azurewebsites.net/product/getall";
            response = await Utilities.DownloadJsonFromThisUrl(url);
            if (response != "Error 400" && response != "Error 404")
                return Utilities.TransformToProductList(response);
            else return null;
        }
        /// <summary>
        /// Obtiene los N productos mas nuevos de la base de datos.
        /// </summary>
        /// <param name="MaxResults">Numero maximo de resultados a obtener.</param>
        public static async Task<List<Product>> GetRecentProducts(int MaxResults)
        {
            list = await GetProducts();
            MaxResults = CheckValueForMaxResult(MaxResults, list.Count);
            return GetRecentProducts(list).Take(MaxResults).ToList();
        }
        /// <summary>
        /// Obtiene los ultimos N productos mas vendidos de la base de datos.
        /// </summary>
        /// <param name="MaxResults">Numero maximo de resultados a obtener.</param>
        public static async Task<List<Product>> GetTopProducts(int MaxResults)
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
        public static async Task<List<Product>> GetProductsFromThisCategory(string IdCategory)
        {
            url = "http://cadepiacueros.azurewebsites.net/product/getall";
            response = await Utilities.DownloadJsonFromThisUrl(url);
            list = Utilities.TransformToProductList(response);
            return GetProductsFromThisCategory(list, IdCategory);
        }
        /// <summary>
        /// Obtiene los ultimos N productos de una categoria.
        /// </summary>
        /// <param name="IdCategory">Id de la categoria.</param>
        /// <param name="MaxResults">Numero maximo de resultados que se desea obtener.</param>
        public static async Task<List<Product>> GetProductsFromThisCategory(string IdCategory, int MaxResults)
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
        public static async Task<List<Product>> GetRecentProductsFromThisCategory(string IdCategory)
        {
            url = "http://cadepiacueros.azurewebsites.net/product/getall";
            response = await Utilities.DownloadJsonFromThisUrl(url);
            list = await GetProductsFromThisCategory(IdCategory);
            return GetRecentProducts(list);
        }
        /// <summary>
        /// Obtiene los ultimos N productos mas recientes de una categoria.
        /// </summary>
        /// <param name="IdCategory">Id de la categoria.</param>
        /// <param name="MaxResults">Numero maximo de resultados que se desea obtener.</param>
        public static async Task<List<Product>> GetRecentProductsFromThisCategory(string IdCategory, int MaxResults)
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
        public static async Task<List<Product>> GetTopProductsFromThisCategory(string IdCategory)
        {
            url = "http://cadepiacueros.azurewebsites.net/product/getall";
            response = await Utilities.DownloadJsonFromThisUrl(url);
            list = await GetProductsFromThisCategory(IdCategory);
            return GetTopProducts(list);
        }
        /// <summary>
        /// Obtiene los ultimos N productos mas vendidos de una categoria.
        /// </summary>
        /// <param name="IdCategory">Id de la categoria.</param>
        /// <param name="MaxResults">Numero maximo de resultados que se desea obtener.</param>
        public static async Task<List<Product>> GetTopProductsFromThisCategory(string IdCategory, int MaxResults)
        {
            list = await GetProductsFromThisCategory(IdCategory);
            MaxResults = CheckValueForMaxResult(MaxResults, list.Count);
            return list.Take(MaxResults).ToList();
        }
        #endregion

        #region Single product queries
        public static async Task<Product> GetProduct(int ID)
        {
            url = "http://cadepiacueros.azurewebsites.net/supplier/get?ProductID=/" + ID;
            response = await Utilities.DownloadJsonFromThisUrl(url);

            return Utilities.TransformToProduct(response);
        }

        public static bool QuantityIsAvailable(int ProductQuantity, int QuantityRequired)
        {
            if (ProductQuantity >= QuantityRequired)
                return true;
            return false;
        }

        public static int GetEstimatedProductionTime(int ProductProductionTime, int QuantityRequired, int NumberOfEmployees)
        {
            return (ProductProductionTime * QuantityRequired / NumberOfEmployees);
        }
        #endregion

        #region Private Methods

        private static int CheckValueForMaxResult(int MaxResult, int ListCount)
        {
            if (MaxResult > ListCount || MaxResult <= 0)
                return ListCount;
            else return MaxResult;
        }

        private static List<Product> GetTopProducts(List<Product> list)
        {
            IEnumerable<Product> query = (from P in list
                                          orderby P.SoldUnits descending
                                          select P);
            return query.ToList();
        }

        private static List<Product> GetRecentProducts(List<Product> list)
        {
            IEnumerable<Product> query = (from P in list
                                          orderby P.OnSaleDate descending
                                          select P);
            return query.ToList();
        }

        private static List<Product> GetProductsFromThisCategory(List<Product> list, string IdCategory)
        {
            IEnumerable<Product> query = (from P in list
                                          where P.Category.CategoryID == IdCategory
                                          select P);
            return query.ToList();
        }
        #endregion

        #region POST requests
        public static async Task<bool> CreateProduct(Product newProduct)
        {
            return true;
        }
        #endregion
    }
}
