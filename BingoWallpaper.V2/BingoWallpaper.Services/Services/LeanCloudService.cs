using System;
using System.Collections.Generic;
using System.Linq;
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

        public override async Task<LeanCloudResultCollection<Archive>> GetArchivesAsync(IEnumerable<string> objectIds)
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
            var url = $"{Constants.LeanCloudUrlBase}/1.1/classes/Archive?where={WebUtility.UrlEncode(JsonConvert.SerializeObject(where))}&order=-createdAt";
            using (var client = CreateHttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<LeanCloudResultCollection<Archive>>(json);
            }
        }

        public override async Task<LeanCloudResultCollection<Archive>> GetArchivesAsync(int page = 1, int pageSize = 20, string[] areas = null)
        {
            if (page < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(page));
            }
            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            var url = $"{Constants.LeanCloudUrlBase}/1.1/classes/Archive?";
            if (areas != null)
            {
                var where = new
                {
                    market = new Dictionary<string, IEnumerable<string>>()
                    {
                        {
                            "$in",
                            areas
                        }
                    }
                };
                url = url + $"where={WebUtility.UrlEncode(JsonConvert.SerializeObject(where))}&";
            }
            url = url + $"order=-createdAt&skip={pageSize * (page - 1)}&limit={pageSize}";
            using (var client = CreateHttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<LeanCloudResultCollection<Archive>>(json);
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

        public override async Task<LeanCloudResultCollection<Image>> GetImagesAsync(IEnumerable<string> objectIds)
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
            var url = $"{Constants.LeanCloudUrlBase}/1.1/classes/Image?where={WebUtility.UrlEncode(JsonConvert.SerializeObject(where))}&order=-createdAt";
            using (var client = CreateHttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<LeanCloudResultCollection<Image>>(json);
            }
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

        public override async Task<IEnumerable<Wallpaper>> GetWallpapersAsync(IEnumerable<string> objectIds)
        {
            if (objectIds == null)
            {
                throw new ArgumentNullException(nameof(objectIds));
            }

            var archives = await GetArchivesAsync(objectIds);
            var images = await GetImagesAsync(archives.Select(temp => temp.Image.ObjectId));
            return from archive in archives
                   let image = images.Single(temp => temp.ObjectId == archive.Image.ObjectId)
                   select new Wallpaper()
                   {
                       Archive = archive,
                       Image = image
                   };
        }

        public override async Task<IEnumerable<Wallpaper>> GetWallpapersAsync(int page = 1, int pageSize = 20, string[] areas = null)
        {
            var archives = await GetArchivesAsync(page, pageSize, areas);
            var images = await GetImagesAsync(archives.Select(temp => temp.Image.ObjectId));
            return from archive in archives
                   let image = images.Single(temp => temp.ObjectId == archive.Image.ObjectId)
                   select new Wallpaper()
                   {
                       Archive = archive,
                       Image = image
                   };
        }
    }
}