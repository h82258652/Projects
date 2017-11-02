﻿using System.Net.Http;
using System.Threading.Tasks;
using BingoWallpaper.Models;
using BingoWallpaper.Models.LeanCloud;

namespace BingoWallpaper.Services
{
    public abstract class LeanCloudServiceBase : ILeanCloudService
    {
        public abstract Task<Archive> GetArchiveAsync(string objectId);

        public abstract Task<Image> GetImageAsync(string objectId);

        public abstract string GetUrl(IImage image, WallpaperSize size);

        public abstract Task<Wallpaper> GetWallpaperAsync(string objectId);

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