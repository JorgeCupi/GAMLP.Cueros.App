using Cueros.App.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cueros.App.Core.Services
{
    public static class PicturesServices
    {
        public static async Task<List<Picture>> GetPictures()
        {
            string url = "http://cadepiacueros.azurewebsites.net/picture/getall";
            string response = await Utilities.DownloadJsonFromThisUrl(url);

            return Utilities.TransformToPicturesList(response);
        }

        public static async Task<Picture> GetCategory(string ID)
        {
            string url = "http://cadepiacueros.azurewebsites.net/picture/get?PictureID=" + ID;
            string response = await Utilities.DownloadJsonFromThisUrl(url);

            return Utilities.TransformToPicture(response);
        }
    }
}
