using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Storage;
using Microsoft.Toolkit.Uwp;
using Newtonsoft.Json;
using SoftwareKobo.Extensions;
using U148.Models;

namespace U148.Services
{
    public class ArticleServiceWithCache : ArticleService, IArticleServiceWithCache
    {
        private const string CacheFolderName = "ArticleCache";

        public long CalculateCacheSize()
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
                var cacheFolderPath = GetCacheFolderPath();
                if (Directory.Exists(cacheFolderPath))
                {
                    Directory.Delete(cacheFolderPath, true);
                }
            });
        }

        public override async Task<ResultBase<ArticleDetail>> GetArticleDetailAsync(int id)
        {
            var cacheFolderPath = GetCacheFolderPath();
            var cacheFilePath = Path.Combine(cacheFolderPath, $"article_detail-{id}.json");
            ResultBase<ArticleDetail> result;
            if (NetworkHelper.Instance.ConnectionInformation.IsInternetAvailable)
            {
                var url = $"{Constants.UrlBase}/json/article/{id}";
                using (var client = new HttpClient())
                {
                    var json = await client.GetStringAsync(url);
                    result = JsonConvert.DeserializeObject<ResultBase<ArticleDetail>>(json);
                    if (result.ErrorCode == 0)
                    {
                        async void AsyncAction()
                        {
                            try
                            {
                                Directory.CreateDirectory(cacheFolderPath);
                                await FileExtensions.WriteAllTextAsync(cacheFilePath, json);
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }
                        AsyncAction();

                        return result;
                    }
                }
            }

            if (File.Exists(cacheFilePath))
            {
                var json = await FileExtensions.ReadAllTextAsync(cacheFilePath);
                try
                {
                    result = JsonConvert.DeserializeObject<ResultBase<ArticleDetail>>(json);
                    if (result.ErrorCode == 0)
                    {
                        return result;
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
                // 缓存不可用，丢弃缓存。
                async void AsyncAction()
                {
                    try
                    {
                        await FileExtensions.DeleteAsync(cacheFilePath);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
                AsyncAction();
            }

            return await base.GetArticleDetailAsync(id);
        }

        public override async Task<ResultBase<Page<Article>>> GetArticlesAsync(ArticleCategory category, int page = 1)
        {
            if (!Enum.IsDefined(typeof(ArticleCategory), category))
            {
                throw new ArgumentOutOfRangeException(nameof(category));
            }
            if (page < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(page));
            }

            var cacheFolderPath = GetCacheFolderPath();
            var cacheFilePath = Path.Combine(cacheFolderPath, $"article-{(int)category}-{page}.json");
            ResultBase<Page<Article>> result;
            if (NetworkHelper.Instance.ConnectionInformation.IsInternetAvailable)
            {
                var url = $"{Constants.UrlBase}/json/{(int)category}/{page}";
                using (var client = new HttpClient())
                {
                    var json = await client.GetStringAsync(url);
                    result = JsonConvert.DeserializeObject<ResultBase<Page<Article>>>(json);
                    if (result.ErrorCode == 0)
                    {
                        async void AsyncAction()
                        {
                            try
                            {
                                Directory.CreateDirectory(cacheFolderPath);
                                await FileExtensions.WriteAllTextAsync(cacheFilePath, json);
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }
                        AsyncAction();

                        return result;
                    }
                }
            }

            if (File.Exists(cacheFilePath))
            {
                var json = await FileExtensions.ReadAllTextAsync(cacheFilePath);
                try
                {
                    result = JsonConvert.DeserializeObject<ResultBase<Page<Article>>>(json);
                    if (result.ErrorCode == 0)
                    {
                        return result;
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
                // 缓存不可用，丢弃缓存。
                async void AsyncAction()
                {
                    try
                    {
                        await FileExtensions.DeleteAsync(cacheFilePath);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
                AsyncAction();
            }

            return await base.GetArticlesAsync(category, page);
        }

        public string GetCacheFolderPath()
        {
            return Path.Combine(ApplicationData.Current.LocalCacheFolder.Path, CacheFolderName);
        }
    }
}