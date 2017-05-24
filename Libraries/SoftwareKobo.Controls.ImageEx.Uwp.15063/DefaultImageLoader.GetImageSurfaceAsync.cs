using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using SoftwareKobo.Controls.Extensions;
using SoftwareKobo.Extensions;
using Weakly;
using Windows.UI.Xaml.Media;

namespace SoftwareKobo.Controls
{
    public partial class DefaultImageLoader
    {
        private static readonly WeakValueDictionary<string, LoadedImageSurface> CacheImageSurfaces = new WeakValueDictionary<string, LoadedImageSurface>();

        public async Task<ImageSurfaceResult> GetImageSurfaceAsync(string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            // 检查内存缓存。
            LoadedImageSurface imageSurface;
            if (CacheImageSurfaces.TryGetValue(source, out imageSurface))
            {
                // 内存缓存存在，直接使用内存缓存。
                return new ImageSurfaceResult(imageSurface, LoadedImageSourceLoadStatus.Success);
            }
            else
            {
                var uriSource = ToUriSource(source);
                if (IsHttpUri(uriSource))
                {
                    var cacheFilePath = GetCacheFilePath(uriSource);
                    if (File.Exists(cacheFilePath))
                    {
                        imageSurface = LoadedImageSurface.StartLoadFromUri(new Uri(cacheFilePath, UriKind.Absolute));
                        var args = await imageSurface.WaitForLoadCompletedAsync();
                        if (args.Status == LoadedImageSourceLoadStatus.Success)
                        {
                            // 放入内存缓存。
                            CacheImageSurfaces[source] = imageSurface;
                        }
                        else
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
                        }

                        return new ImageSurfaceResult(imageSurface, args.Status);
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
                        catch (TaskCanceledException)
                        {
                            ImageDownloadTasks.TryRemove(source, out imageDownloadTask);
                            return new ImageSurfaceResult(null, LoadedImageSourceLoadStatus.Other);
                        }
                        catch (OperationCanceledException)
                        {
                            ImageDownloadTasks.TryRemove(source, out imageDownloadTask);
                            return new ImageSurfaceResult(null, LoadedImageSourceLoadStatus.Other);
                        }
                        catch (HttpRequestException)
                        {
                            ImageDownloadTasks.TryRemove(source, out imageDownloadTask);
                            return new ImageSurfaceResult(null, LoadedImageSourceLoadStatus.Other);
                        }

                        imageSurface = LoadedImageSurface.StartLoadFromStream(new MemoryStream(bytes).AsRandomAccessStream());
                        var args = await imageSurface.WaitForLoadCompletedAsync();
                        if (args.Status == LoadedImageSourceLoadStatus.Success)
                        {
                            // 放入内存缓存。
                            CacheImageSurfaces[source] = imageSurface;

                            async void AsyncAction()
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
                            }
                            AsyncAction();
                        }

                        return new ImageSurfaceResult(imageSurface, args.Status);
                    }
                }
                else
                {
                    imageSurface = LoadedImageSurface.StartLoadFromUri(uriSource);
                    var args = await imageSurface.WaitForLoadCompletedAsync();
                    if (args.Status == LoadedImageSourceLoadStatus.Success)
                    {
                        // 放入内存缓存。
                        CacheImageSurfaces[source] = imageSurface;
                    }

                    return new ImageSurfaceResult(imageSurface, args.Status);
                }
            }
        }
    }
}