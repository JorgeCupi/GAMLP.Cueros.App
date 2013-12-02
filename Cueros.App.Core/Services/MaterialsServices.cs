using Cueros.App.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cueros.App.Core.Services
{
    public static class MaterialsServices
    {
        public static async Task<List<Material>> GetMaterials()
        {
            string url = "http://cadepiacueros.azurewebsites.net/material/getall";
            string response = await Utilities.DownloadJsonFromThisUrl(url);

            return Utilities.TransformToMaterialsList(response);
        }

        public static async Task<Material> GetMaterial(int ID)
        {
            string url = "http://cadepiacueros.azurewebsites.net/material/get?MaterialID=/" + ID;
            string response = await Utilities.DownloadJsonFromThisUrl(url);

            return Utilities.TransformToMaterial(response);
        }
    }
}
