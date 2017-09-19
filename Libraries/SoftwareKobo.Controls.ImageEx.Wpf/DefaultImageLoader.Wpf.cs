using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using SoftwareKobo.Extensions;
using Weakly;

namespace SoftwareKobo.Controls
{
    public sealed partial class DefaultImageLoader
    {
        private static readonly WeakValueDictionary<string, BitmapImage> CacheBitmapImages = new WeakValueDictionary<string, BitmapImage>();

        public async Task<BitmapResult> GetBitmapAsync(string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            // 检查内存缓存。
            BitmapImage bitmap;
            if (CacheBitmapImages.TryGetValue(source, out bitmap))
            {
                // 内存缓存存在，直接使用内存缓存。
                return new BitmapResult(bitmap);
            }
            else
            {
                var uriSource = ToUriSource(source);
                if (IsHttpUri(uriSource))
                {
                    var cacheFilePath = GetCacheFilePath(uriSource);
                    if (File.Exists(cacheFilePath))
                    {
                        try
                        {
                            bitmap = await Task.Run(() =>
                            {
                                var asyncBitmap = new BitmapImage();
                                asyncBitmap.BeginInit();
                                asyncBitmap.UriSource = new Uri(cacheFilePath);
                                asyncBitmap.EndInit();
                                asyncBitmap.Freeze();
                                return asyncBitmap;
                            });
                            // 放入内存缓存。
                            CacheBitmapImages[source] = bitmap;

                            return new BitmapResult(bitmap);
                        }
                        catch (NotSupportedException ex)
                        {
                            // 缓存文件无法加载，删除缓存文件。
                            async void AsyncAction()
                            {
                                await Task.Run(() =>
                                {
                                    try
                                    {
                                        File.Delete(cacheFilePath);
                                    }
                                    catch (Exception)
                                    {
                                        // ignored
                                    }
                                });
                            }
                            AsyncAction();

                            return new BitmapResult(ex);
                        }
                    }
                    else
                    {
                        Task<byte[]> imageDownloadTask;
                        if (!ImageDownloadTasks.TryGetValue(source, out imageDownloadTask))
                        {
                            imageDownloadTask = DownloadImageAsync(uriSource);
                            ImageDownloadTasks[source] = imageDownloadTask;
                        }

                        byte[] bytes;
                        try
                        {
                            bytes = await imageDownloadTask;
                        }
                        catch (HttpRequestException ex)
                        {
                            ImageDownloadTasks.TryRemove(source, out imageDownloadTask);
                            return new BitmapResult(ex);
                        }

                        try
                        {
                            bitmap = await Task.Run(() =>
                            {
                                var asyncBitmap = new BitmapImage();
                                asyncBitmap.BeginInit();
                                asyncBitmap.StreamSource = new MemoryStream(bytes);
                                asyncBitmap.EndInit();
                                asyncBitmap.Freeze();
                                return asyncBitmap;
                            });
                            // 放入内存缓存。
                            CacheBitmapImages[source] = bitmap;

                            Action asyncAction = async () =>
                            {
                                try
                                {
                                    Directory.CreateDirectory(ImageExSettings.CacheFolderPath);
                                    await FileExtensions.WriteAllBytesAsync(cacheFilePath, bytes);
                                }
                                catch (Exception)
                                {
                                    // ignored
                                }
                                finally
                                {
                                    ImageDownloadTasks.TryRemove(source, out imageDownloadTask);
                                }
                            };
                            asyncAction.Invoke();

                            return new BitmapResult(bitmap);
                        }
                        catch (NotSupportedException ex)
                        {
                            ImageDownloadTasks.TryRemove(source, out imageDownloadTask);
                            return new BitmapResult(ex);
                        }
                    }
                }
                else
                {
                    try
                    {
                        bitmap = await Task.Run(() =>
                        {
                            var asyncBitmap = new BitmapImage();
                            asyncBitmap.BeginInit();
                            asyncBitmap.UriSource = uriSource;
                            asyncBitmap.EndInit();
                            asyncBitmap.Freeze();
                            return asyncBitmap;
                        });
                        // 放入内存缓存。
                        CacheBitmapImages[source] = bitmap;

                        return new BitmapResult(bitmap);
                    }
                    catch (FileNotFoundException ex)
                    {
                        return new BitmapResult(ex);
                    }
                    catch (IOException ex)
                    {
                        return new BitmapResult(ex);
                    }
                    catch (NotSupportedException ex)
                    {
                        return new BitmapResult(ex);
                    }
                }
            }
        }

        public async Task<byte[]> GetBytesAsync(string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var uriSource = ToUriSource(source);
            if (IsHttpUri(uriSource))
            {
                var cacheFilePath = GetCacheFilePath(uriSource);
                if (File.Exists(cacheFilePath))
                {
                    return await FileExtensions.ReadAllBytesAsync(cacheFilePath);
                }
                else
                {
                    byte[] bytes;
                    using (var httpClient = new HttpClient())
                    {
                        bytes = await httpClient.GetByteArrayAsync(uriSource);
                    }

                    Action asyncAction = async () =>
                    {
                        try
                        {
                            var bitmap = await Task.Run(() =>
                            {
                                var asyncBitmap = new BitmapImage();
                                asyncBitmap.BeginInit();
                                asyncBitmap.StreamSource = new MemoryStream(bytes);
                                asyncBitmap.EndInit();
                                asyncBitmap.Freeze();
                                return asyncBitmap;
                            });
                            // 放入内存缓存。
                            CacheBitmapImages[source] = bitmap;

                            Directory.CreateDirectory(ImageExSettings.CacheFolderPath);
                            await FileExtensions.WriteAllBytesAsync(cacheFilePath, bytes);
                        }
                        catch (NotSupportedException)
                        {
                        }
                    };
                    asyncAction.Invoke();

                    return bytes;
                }
            }
            else
            {
                if (string.Equals(uriSource.Scheme, Uri.UriSchemeFile, StringComparison.OrdinalIgnoreCase))
                {
                    // 绝对路径。
                    return await FileExtensions.ReadAllBytesAsync(source);
                }
                else
                {
                    // pack://application:,,,/，其它路径不支持。
                    var streamResourceInfo = System.Windows.Application.GetResourceStream(uriSource);
                    if (streamResourceInfo != null)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await streamResourceInfo.Stream.CopyToAsync(memoryStream);
                            return memoryStream.ToArray();
                        }
                    }
                    else
                    {
                        throw new FileNotFoundException();
                    }
                }
            }
        }

        private static bool IsHttpUri(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            var scheme = uri.Scheme;
            return uri.IsAbsoluteUri
                   && (string.Equals(scheme, Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase)
                       || string.Equals(scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase));
        }

        private static Uri ToUriSource(string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            Uri uriSource;
            if (Uri.TryCreate(source, UriKind.RelativeOrAbsolute, out uriSource))
            {
                if (!uriSource.IsAbsoluteUri)
                {
                    Uri.TryCreate("pack://application:,,,/" + (source.StartsWith("/") ? source.Substring(1) : source), UriKind.Absolute, out uriSource);
                }
            }

            if (uriSource == null)
            {
                throw new NotSupportedException();
            }

            return uriSource;
        }
    }
}