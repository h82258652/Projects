using Windows.Storage;

namespace BingoWallpaper.Configuration
{
    public class BingoWallpaperSettings : IBingoWallpaperSettings
    {
        public bool IsAutoUpdateLockScreen
        {
            get
            {
                return (bool)ApplicationData.Current.LocalSettings.Values[nameof(IsAutoUpdateLockScreen)];
            }
            set
            {
                ApplicationData.Current.LocalSettings.Values[nameof(IsAutoUpdateLockScreen)] = value;
            }
        }

        public bool IsAutoUpdateWallpaper
        {
            get
            {
                return (bool)ApplicationData.Current.LocalSettings.Values[nameof(IsAutoUpdateWallpaper)];
            }
            set
            {
                ApplicationData.Current.LocalSettings.Values[nameof(IsAutoUpdateWallpaper)] = value;
            }
        }
    }
}