using System;

namespace BingoWallpaper.Configuration
{
    public class BingoWallpaperSettings : IBingoWallpaperSettings
    {
        public bool IsAutoUpdateLockScreen
        {
            get
            {
                return Properties.Settings.Default.IsAutoUpdateLockScreen;
            }
            set
            {
                Properties.Settings.Default.IsAutoUpdateLockScreen = value;
            }
        }

        public bool IsAutoUpdateWallpaper
        {
            get
            {
                return Properties.Settings.Default.IsAutoUpdateWallpaper;
            }
            set
            {
                Properties.Settings.Default.IsAutoUpdateWallpaper = value;
            }
        }
    }
}