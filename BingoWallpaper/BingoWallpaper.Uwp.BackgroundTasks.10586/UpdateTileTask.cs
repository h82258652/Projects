using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using BingoWallpaper.Services;
using Microsoft.Practices.Unity;
using Windows.ApplicationModel.Background;

namespace BingoWallpaper.Uwp.BackgroundTasks
{
    public sealed class UpdateTileTask : IBackgroundTask
    {
        private readonly IBingoWallpaperSettings _bingoWallpaperSettings;

        private readonly IBingWallpaperService _bingWallpaperService;

        private readonly ISystemSettingService _systemSettingService;

        private readonly ITileService _tileService;

        public UpdateTileTask()
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<IWallpaperService, BingWallpaperService>();
            unityContainer.RegisterType<IBingWallpaperService, BingWallpaperService>();
            unityContainer.RegisterType<IScreenService, ScreenService>();
            unityContainer.RegisterType<IBingoWallpaperSettings, BingoWallpaperSettings>();
            unityContainer.RegisterType<ITileService, TileService>();
            unityContainer.RegisterType<ISystemSettingService, SystemSettingService>();

            _bingWallpaperService = unityContainer.Resolve<IBingWallpaperService>();
            _bingoWallpaperSettings = unityContainer.Resolve<IBingoWallpaperSettings>();
            _tileService = unityContainer.Resolve<ITileService>();
            _systemSettingService = unityContainer.Resolve<ISystemSettingService>();
        }

        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            var deferral = taskInstance?.GetDeferral();
            try
            {
                var result = await _bingWallpaperService.GetAsync(0, 1, _bingoWallpaperSettings.SelectedArea);
                var image = result?.Images.FirstOrDefault();
                if (image != null)
                {
                    var copyright = image.Copyright;
                    var text = Regex.Replace(copyright, @"\(©.*", string.Empty).Trim();
                    _tileService.UpdatePrimaryTile(image, text);

                    if (_bingoWallpaperSettings.IsAutoUpdateWallpaper || _bingoWallpaperSettings.IsAutoUpdateLockScreen)
                    {
                        using (var client = new HttpClient())
                        {
                            var bytes = await client.GetByteArrayAsync(_bingWallpaperService.GetUrl(image, _bingoWallpaperSettings.SelectedWallpaperSize));
                            if (bytes != null && bytes.Length > 0)
                            {
                                if (_bingoWallpaperSettings.IsAutoUpdateWallpaper)
                                {
                                    await _systemSettingService.SetWallpaperAsync(bytes);
                                }
                                if (_bingoWallpaperSettings.IsAutoUpdateLockScreen)
                                {
                                    await _systemSettingService.SetLockScreenAsync(bytes);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }
            finally
            {
                deferral?.Complete();
            }
        }
    }
}