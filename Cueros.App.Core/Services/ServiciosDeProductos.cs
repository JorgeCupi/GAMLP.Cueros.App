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

            return Utilities.TransformToProductList(response);
        }

        /// <summary>
        /// Metodo para obtener una lista de los productos de la categoria solicitada
        /// </summary>
        /// <param name="IdCategoria">Id de la categoria de la cual se quiere una lista de productos</param>
        /// <returns></returns>
        public static async Task<List<Producto>> ObtenerProductosDeEstaCategoria(string IdCategoria)
        {
            string url = "https://dl.dropboxusercontent.com/s/7f402dzmqmw871m/CUEROS.json?dl=1&token_hash=AAHNw7NngxtL3TRef5pTNFNe-jYRKekuEczDA8bhEnvdsQ";
            string response = await Utilities.DownloadJsonFromThisUrl(url);

            return GetProductsWithThisLine(response, IdCategoria);
        }

        /// <summary>
        /// Metodo para obtener los productos mas novedosos
        /// </summary>
        /// <param name="numeroMaximoDeResultados">Maximo numero de resultados que se desea obtener</param>
        /// <returns></returns>
        public static async Task<List<Producto>> ObtenerProductosMasNovedosos(int numeroMaximoDeResultados)
        {
            string url = "https://dl.dropboxusercontent.com/s/7f402dzmqmw871m/CUEROS.json?dl=1&token_hash=AAHNw7NngxtL3TRef5pTNFNe-jYRKekuEczDA8bhEnvdsQ";
            string response = await Utilities.DownloadJsonFromThisUrl(url);

            return GetRecentProducts(response, numeroMaximoDeResultados);
        }

        /// <summary>
        /// Metodo para obtener los productos mas destacados
        /// </summary>
        /// <param name="numeroMaximoDeResultados">Maximo numero de resultados que se desea obtener</param>
        /// <returns></returns>
        public static async Task<List<Producto>> ObtenerProductosDestacados(int numeroMaximoDeResultados)
        {
            string url = "https://dl.dropboxusercontent.com/s/7f402dzmqmw871m/CUEROS.json?dl=1&token_hash=AAHNw7NngxtL3TRef5pTNFNe-jYRKekuEczDA8bhEnvdsQ";
            string response = await Utilities.DownloadJsonFromThisUrl(url);

            return GetTopProducts(response, numeroMaximoDeResultados);
        }

        #region Private Methods
        private static List<Producto> GetTopProducts(string response, int n)
        {
            List<Producto> list = Utilities.TransformToProductList(response);

            IEnumerable<Producto> query = (from P in list
                                           orderby P.VentasRealizadas
                                           select P).Take(n);
            return query.ToList();
        }

        private static List<Producto> GetRecentProducts(string response, int n)
        {
            List<Producto> list = Utilities.TransformToProductList(response);

            IEnumerable<Producto> query = (from P in list
                                           orderby P.FechaPublicacion
                                           select P).Take(n);
            return query.ToList();
        }

        private static List<Producto> GetProductsWithThisLine(string response, string IdCategorie)
        {
            List<Producto> list = Utilities.TransformToProductList(response);

            IEnumerable<Producto> query = from P in list
                                          where P.Categoria.Id == IdCategorie
                                          select P;

            return query.ToList();
        }
        #endregion
        
    }
}
