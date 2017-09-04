using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BingoWallpaper.Models.LeanCloud;
using BingoWallpaper.Properties;
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
                throw new ArgumentException(string.Format(Resources.EmptyStringExceptionMessage, nameof(objectId)), nameof(objectId));
            }

            var url = $"{Constants.LeanCloudUrlBase}/1.1/classes/Archive/{WebUtility.UrlEncode(objectId)}";
            using (var client = CreateHttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<Archive>(json);
            }
        }

        public override async Task<object> GetArchivesAsync(IEnumerable<string> objectIds)
        {
            if (objectIds == null)
            {
                throw new ArgumentNullException(nameof(objectIds));
            }

            var where = new
            {
                objectId = new Dictionary<string, IEnumerable<string>>()
                {
                    {
                        "$in",
                        objectIds
                    }
                }
            };
            var url = $"{Constants.LeanCloudUrlBase}/1.1/classes/Archive?where={WebUtility.UrlEncode(JsonConvert.SerializeObject(where))}&order=-updatedAt";
            using (var client = CreateHttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject(json);
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
                throw new ArgumentException(string.Format(Resources.EmptyStringExceptionMessage, nameof(objectId)), nameof(objectId));
            }

            var url = $"{Constants.LeanCloudUrlBase}/1.1/classes/Image/{WebUtility.UrlEncode(objectId)}";
            using (var client = CreateHttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<Image>(json);
            }
        }

        public override async Task<object> GetImagesAsync(IEnumerable<string> objectIds)
        {
            if (objectIds == null)
            {
                throw new ArgumentNullException(nameof(objectIds));
            }

            var where = new
            {
                objectId = new Dictionary<string, IEnumerable<string>>()
                {
                    {
                        "$in",
                        objectIds
                    }
                }
            };
            var url = $"{Constants.LeanCloudUrlBase}/1.1/classes/Image?where={WebUtility.UrlEncode(JsonConvert.SerializeObject(where))}&order=-updatedAt";
            using (var client = CreateHttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject(json);
            }
        }

        public override async Task<Wallpaper> GetWallpaperAsync(string objectId)
        {
            var archiveTask = GetArchiveAsync(objectId);
            var imageTask = GetImageAsync(objectId);
            return new Wallpaper()
            {
                Archive = await archiveTask,
                Image = await imageTask
            };
        }

        public override Task<object> GetWallpapersAsync(IEnumerable<string> objectIds)
        {
            throw new NotImplementedException();
        }
    }
}