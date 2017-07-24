using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BingoWallpaper.Models;
using BingoWallpaper.Models.LeanCloud;
using BingoWallpaper.Properties;
using Newtonsoft.Json;

namespace BingoWallpaper.Services
{
    public class LeanCloudWallpaperService : ILeanCloudWallpaperService
    {
        public async Task<LeanCloudResultCollection<Archive>> GetArchivesAsync(int pageIndex = 1, int pageSize = 100, params string[] areas)
        {
            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex));
            }
            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }
            if (pageSize > 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            var requestUrl = $"{Constants.LeanCloudUrlBase}/1.1/classes/Archive?skip={pageSize * (pageIndex - 1)}&limit={pageSize}&order=-date";
            if (areas?.Any() == true)
            {
                var where = new
                {
                    market = new Dictionary<string, string[]>()
                    {
                        ["$in"] = areas
                    }
                };
                requestUrl += $"&where={WebUtility.UrlEncode(JsonConvert.SerializeObject(where))}";
            }

            using (var client = CreateHttpClient())
            {
                var json = await client.GetStringAsync(requestUrl);
                return JsonConvert.DeserializeObject<LeanCloudResultCollection<Archive>>(json);
            }
        }

        public virtual async Task<LeanCloudResultCollection<Archive>> GetArchivesInMonthAsync(int year, int month, string area)
        {
            var viewMonth = new DateTime(year, month, 1);
            if (viewMonth < Constants.MinimumViewMonth)
            {
                throw new ArgumentOutOfRangeException(nameof(viewMonth));
            }
            if (area == null)
            {
                throw new ArgumentNullException(nameof(area));
            }
            if (area.Length <= 0)
            {
                throw new ArgumentException(Resources.EmptyStringExceptionMessage, nameof(area));
            }

            var where = new
            {
                market = area,
                date = new Dictionary<string, string>()
                {
                    {
                        "$regex",
                        @"\Q" + viewMonth.ToString("yyyyMM") + @"\E"
                    }
                }
            };

            var requestUrl = $"{Constants.LeanCloudUrlBase}/1.1/classes/Archive?where={WebUtility.UrlEncode(JsonConvert.SerializeObject(where))}&order=-date";

            using (var client = CreateHttpClient())
            {
                var json = await client.GetStringAsync(requestUrl);
                return JsonConvert.DeserializeObject<LeanCloudResultCollection<Archive>>(json);
            }
        }

        public virtual async Task<Image> GetImageAsync(string objectId)
        {
            if (objectId == null)
            {
                throw new ArgumentNullException(nameof(objectId));
            }
            if (objectId.Length <= 0)
            {
                throw new ArgumentException(Resources.EmptyStringExceptionMessage, nameof(objectId));
            }

            var requestUrl = $"{Constants.LeanCloudUrlBase}/1.1/classes/Image/{objectId}";

            using (var client = CreateHttpClient())
            {
                var json = await client.GetStringAsync(requestUrl);
                return JsonConvert.DeserializeObject<Image>(json);
            }
        }

        public virtual async Task<LeanCloudResultCollection<Image>> GetImagesAsync(IEnumerable<string> objectIds)
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

            var requestUrl = $"{Constants.LeanCloudUrlBase}/1.1/classes/Image?where={WebUtility.UrlEncode(JsonConvert.SerializeObject(where))}&order=-updatedAt";

            using (var client = CreateHttpClient())
            {
                var json = await client.GetStringAsync(requestUrl);
                return JsonConvert.DeserializeObject<LeanCloudResultCollection<Image>>(json);
            }
        }

        public IReadOnlyList<string> GetSupportedAreas()
        {
            return new[]
            {
                "de-DE",
                "en-AU",
                "en-CA",
                "en-GB",
                "en-IN",
                "en-US",
                "fr-CA",
                "fr-FR",
                "ja-JP",
                "pt-BR",
                "zh-CN",
            };
        }

        public IReadOnlyList<WallpaperSize> GetSupportedWallpaperSizes()
        {
            return new[]
            {
                new WallpaperSize(480,800),
                new WallpaperSize(768,1280),
                new WallpaperSize(800,480),
                new WallpaperSize(1080,1920),
                new WallpaperSize(1366,768),
                new WallpaperSize(1920,1080),
                new WallpaperSize(1920,1200),
            };
        }

        public string GetUrl(IImage image, WallpaperSize size)
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }
            if (!GetSupportedWallpaperSizes().Contains(size))
            {
                throw new NotSupportedException();
            }

            return $"{Constants.ImageUrlBase}{image.UrlBase}_{size.Width}x{size.Height}.jpg";
        }

        public async Task<IEnumerable<Wallpaper>> GetWallpapersAsync(int year, int month, string area)
        {
            var viewMonth = new DateTime(year, month, 1);
            if (viewMonth < Constants.MinimumViewMonth)
            {
                throw new ArgumentOutOfRangeException(nameof(viewMonth));
            }
            if (area == null)
            {
                throw new ArgumentNullException(nameof(area));
            }
            if (area.Length <= 0)
            {
                throw new ArgumentException(Resources.EmptyStringExceptionMessage, nameof(area));
            }

            var archives = (await GetArchivesInMonthAsync(year, month, area)).ToList();
            var imageIds = archives.Select(temp => temp.Image.ObjectId);
            var images = await GetImagesAsync(imageIds);
            return from archive in archives
                   let image = images.FirstOrDefault(temp => temp.ObjectId == archive.Image.ObjectId)
                   select new Wallpaper()
                   {
                       Archive = archive,
                       Image = image
                   };
        }

        private static HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            var headers = client.DefaultRequestHeaders;
            headers.Add("X-AVOSCloud-Application-Id", Constants.LeanCloudAppId);
            headers.Add("X-AVOSCloud-Application-Key", Constants.LeanCloudAppKey);
            return client;
        }
    }
}