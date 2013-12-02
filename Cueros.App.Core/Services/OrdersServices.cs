using Cueros.App.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cueros.App.Core.Services
{
    public static class OrdersServices
    {
        public static async Task<bool> TryCreateOrder(Order newOrder)
        {
            return true;
        }

        public static async Task<List<Order>> GetOrders()
        {
            string url = "http://cadepiacueros.azurewebsites.net/order/getall";
            string response = await Utilities.DownloadJsonFromThisUrl(url);

            return Utilities.TransformToOrdersList(response);
        }

        public static async Task<Order> GetOrder(int ID)
        {
            string url = "http://cadepiacueros.azurewebsites.net/order/get?OrderID=" + ID;
            string response = await Utilities.DownloadJsonFromThisUrl(url);

            return Utilities.TransformToOrder(response);
        }
    }
}
