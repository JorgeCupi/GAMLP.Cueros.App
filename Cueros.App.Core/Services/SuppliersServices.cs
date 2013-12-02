using Cueros.App.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cueros.App.Core.Services
{
    public static class SuppliersServices
    {
        public static async Task<List<Supplier>> GetSuppliers()
        {
            string url = "http://cadepiacueros.azurewebsites.net/supplier/getall";
            string response = await Utilities.DownloadJsonFromThisUrl(url);

            return Utilities.TransformToSuppliersList(response);
        }

        public static async Task<Supplier> GetSupplier(int ID)
        {
            string url = "http://cadepiacueros.azurewebsites.net/supplier/get?SupplierID=/" + ID;
            string response = await Utilities.DownloadJsonFromThisUrl(url);

            return Utilities.TransformToSupplier(response);
        }

        public static async Task<List<Supplier>> GetSuppliersForThisMaterial(Material material)
        {
            List<Supplier> suppliers = await GetSuppliers();
            IEnumerable<Supplier> query = from S in suppliers
                                          where S.Materials.Contains(material)
                                          select S;
            return query.ToList();
        }
    }
}
