using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BingoWallpaper.Models.LeanCloud;

namespace BingoWallpaper.Services
{
    public abstract class LeanCloudServiceBase : ILeanCloudService
    {
        public abstract Task<Archive> GetArchiveAsync(string objectId);

        public abstract Task<LeanCloudResultCollection<Archive>> GetArchivesAsync(IEnumerable<string> objectIds);

        public abstract Task<Image> GetImageAsync(string objectId);

        public abstract Task<LeanCloudResultCollection<Image>> GetImagesAsync(IEnumerable<string> objectIds);

        public abstract Task<Wallpaper> GetWallpaperAsync(string objectId);

        public abstract Task<IEnumerable<Wallpaper>> GetWallpapersAsync(IEnumerable<string> objectIds);

        protected HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            var headers = client.DefaultRequestHeaders;
            headers.Add("X-AVOSCloud-Application-Id", Constants.LeanCloudAppId);
            headers.Add("X-AVOSCloud-Application-Key", Constants.LeanCloudAppKey);
            return client;
        }
    }
}