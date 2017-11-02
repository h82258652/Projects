using System;
using System.Net;
using System.Threading.Tasks;
using BingoWallpaper.Models;
using BingoWallpaper.Models.LeanCloud;
using Newtonsoft.Json;

namespace BingoWallpaper.Services
{
    public class LeanCloudService : LeanCloudServiceBase
    {
        public override async Task<Archive> GetArchiveAsync(string objectId)
        {
            if (objectId == null)
            {
                throw new ArgumentNullException(nameof(objectId));
            }
            if (objectId.Length <= 0)
            {
                // TODO
                throw new ArgumentException("");
            }

            var url = $"{Constants.LeanCloudUrlBase}/1.1/classes/Archive/{WebUtility.UrlEncode(objectId)}";
            using (var client = CreateHttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<Archive>(json);
            }
        }

        public override async Task<Image> GetImageAsync(string objectId)
        {
            if (objectId == null)
            {
                throw new ArgumentNullException(nameof(objectId));
            }
            if (objectId.Length <= 0)
            {
                // TODO
                throw new ArgumentException("");
            }

            var url = $"{Constants.LeanCloudUrlBase}/1.1/classes/Image/{WebUtility.UrlEncode(objectId)}";
            using (var client = CreateHttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<Image>(json);
            }
        }

        public override string GetUrl(IImage image, WallpaperSize size)
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            throw new NotImplementedException();
        }

        public override async Task<Wallpaper> GetWallpaperAsync(string objectId)
        {
            var archive = await GetArchiveAsync(objectId);
            var image = await GetImageAsync(archive.Image.ObjectId);
            return new Wallpaper()
            {
                Archive = archive,
                Image = image
            };
        }
    }
}