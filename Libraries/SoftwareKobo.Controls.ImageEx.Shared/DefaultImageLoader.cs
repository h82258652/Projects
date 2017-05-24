using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SoftwareKobo.Extensions;
using SoftwareKobo.Utils;

namespace SoftwareKobo.Controls
{
    public partial class DefaultImageLoader : IImageLoader
    {
        private static readonly ConcurrentDictionary<string, Task<byte[]>> ImageDownloadTasks = new ConcurrentDictionary<string, Task<byte[]>>();

        private DefaultImageLoader()
        {
        }

        public static IImageLoader Instance
        {
            get;
        } = new DefaultImageLoader();

        public long CalculateCacheSize()
        {
            if (Directory.Exists(ImageExSettings.CacheFolderPath))
            {
                return (from cacheFilePath in Directory.EnumerateFiles(ImageExSettings.CacheFolderPath)
                        select new FileInfo(cacheFilePath).Length).Sum();
            }
            return 0;
        }

        public bool ContainsCache(string source)
        {
            if (source == null)
            {
                return false;
            }

            return GetCacheFilePath(source) != null;
        }

        public async Task DeleteAllCacheAsync()
        {
            await Task.Run(() =>
            {
                if (Directory.Exists(ImageExSettings.CacheFolderPath))
                {
                    Directory.Delete(ImageExSettings.CacheFolderPath, true);
                }
            });
        }

        public async Task<bool> DeleteCacheAsync(string source)
        {
            if (source == null)
            {
                return false;
            }

            var cacheFilePath = GetCacheFilePath(source);
            if (File.Exists(cacheFilePath))
            {
                await FileExtensions.DeleteAsync(cacheFilePath);
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetCacheFilePath(string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var uriSource = ToUriSource(source);
            var cacheFilePath = GetCacheFilePath(uriSource);
            if (File.Exists(cacheFilePath))
            {
                return cacheFilePath;
            }
            else
            {
                return null;
            }
        }

        private static string GetCacheFilePath(Uri uriSource)
        {
            if (uriSource == null)
            {
                throw new ArgumentNullException(nameof(uriSource));
            }

            var originalString = uriSource.OriginalString;
            var extension = Path.GetExtension(originalString);
            var cacheFileName = HashHelper.GenerateMD5Hash(originalString) + extension;
            return Path.Combine(ImageExSettings.CacheFolderPath, cacheFileName);
        }

        private async Task<byte[]> DownloadImageAsync(Uri uriSource)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetByteArrayAsync(uriSource);
            }
        }
    }
}