using Cueros.App.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cueros.App.Core.Services
{
    public static class CategoriesServices
    {
        public static async Task<List<Category>> GetCategories()
        {
            string url = "http://cadepiacueros.azurewebsites.net/category/getall";
            string url = "https://dl.dropboxusercontent.com/s/6ysajpdq04qkcxv/Categorias.json?dl=1&token_hash=AAEesyUbBh7vEzrybQ_5Ik7DtEDgTWOmCe2wT7Cv61rTEQ";
            string response = await Utilities.DownloadJsonFromThisUrl(url);

            return Utilities.TransformToCategoriesList(response);
        }

        public static async Task<Category> GetCategory(string IdCategory)
        {
            string url = "http://cadepiacueros.azurewebsites.net/category/get?CategoryID="+ IdCategory;
            string response = await Utilities.DownloadJsonFromThisUrl(url);

            return Utilities.TransformToCategory(response);
        }
    }
}
