﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BingoWallpaper.Models.LeanCloud;
using Newtonsoft.Json;
using SoftwareKobo.Extensions;
using SoftwareKobo.Utils;
using Windows.Storage;

namespace BingoWallpaper.Services
{
    public class LeanCloudWallpaperServiceWithCache : LeanCloudWallpaperService, ILeanCloudWallpaperServiceWithCache
    {
        private const string CacheFolderName = "LeanCloudCache";

        public long CalculateSize()
        {
            var cacheFolderPath = GetCacheFolderPath();
            if (Directory.Exists(cacheFolderPath))
            {
                return (from cacheFilePath in Directory.EnumerateFiles(cacheFolderPath)
                        select new FileInfo(cacheFilePath).Length).Sum();
            }
            return 0;
        }

        public async Task DeleteAllCacheAsync()
        {
            await Task.Run(() =>
            {
                Directory.Delete(GetCacheFolderPath(), true);
            });
        }

        public override async Task<LeanCloudResultCollection<Archive>> GetArchivesAsync(int year, int month, string area)
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
                throw new ArgumentException(LocalizedStrings.EmptyStringExceptionMessage, nameof(area));
            }

            var where = new
            {
                market = area,
                date = new Dictionary<string, string>()
                {
                    ["$regex"] = @"\Q" + viewMonth.ToString("yyyyMM") + @"\E"
                }
            };

            var requestUrl = $"{Constants.LeanCloudUrlBase}/1.1/classes/Archive?where={WebUtility.UrlEncode(JsonConvert.SerializeObject(where))}&order=-date";

            var cacheFilePath = Path.Combine(GetCacheFolderPath(), HashHelper.GenerateMD5Hash(requestUrl) + ".json");
            LeanCloudResultCollection<Archive> result = null;
            if (File.Exists(cacheFilePath))
            {
                var json = await FileExtensions.ReadAllTextAsync(cacheFilePath);
                try
                {
                    result = JsonConvert.DeserializeObject<LeanCloudResultCollection<Archive>>(json);
                    if (result.Count() >= DateTime.DaysInMonth(year, month))
                    {
                        // 已经缓存过当月所有信息，直接返回。
                        return result;
                    }
                }
                catch (Exception)
                {
                    // 缓存不可用，丢弃缓存。
                    File.Delete(cacheFilePath);
                }
            }

            try
            {
                using (var client = CreateHttpClient())
                {
                    var json = await client.GetStringAsync(requestUrl);
                    result = JsonConvert.DeserializeObject<LeanCloudResultCollection<Archive>>(json);

                    if (result.Any())
                    {
                        try
                        {
                            // 创建缓存文件夹（假设不存在）。
                            Directory.CreateDirectory(Path.GetDirectoryName(cacheFilePath));
                            await FileExtensions.WriteAllTextAsync(cacheFilePath, json);
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }
                }
            }
            catch (Exception)
            {
                if (result == null || result.Any() == false)
                {
                    throw;
                }
            }

            return result;
        }

        public string GetCacheFolderPath()
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, CacheFolderName);
        }

        public override Task<Image> GetImageAsync(string objectId)
        {
            throw new NotImplementedException();
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
                    ["$in"] = objectIds
                }
            };

            var requestUrl = $"{Constants.LeanCloudUrlBase}/1.1/classes/Image?where={WebUtility.UrlEncode(JsonConvert.SerializeObject(where))}&order=-updatedAt";

            var cacheFilePath = Path.Combine(GetCacheFolderPath(), HashHelper.GenerateMD5Hash(requestUrl) + ".json");
            if (File.Exists(cacheFilePath))
            {
                var json = await FileExtensions.ReadAllTextAsync(cacheFilePath);
                try
                {
                    return JsonConvert.DeserializeObject<LeanCloudResultCollection<Image>>(json);
                }
                catch (Exception)
                {
                    // 缓存不可用，丢弃缓存。
                    File.Delete(cacheFilePath);
                }
            }

            using (var client = CreateHttpClient())
            {
                var json = await client.GetStringAsync(requestUrl);
                var result = JsonConvert.DeserializeObject<LeanCloudResultCollection<Image>>(json);

                if (result.Any())
                {
                    try
                    {
                        // 创建缓存文件夹（假设不存在）。
                        Directory.CreateDirectory(Path.GetDirectoryName(cacheFilePath));
                        await FileExtensions.WriteAllTextAsync(cacheFilePath, json);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }

                return result;
            }
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