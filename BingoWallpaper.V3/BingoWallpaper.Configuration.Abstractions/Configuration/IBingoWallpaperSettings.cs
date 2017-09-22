namespace BingoWallpaper.Configuration
{
    public interface IBingoWallpaperSettings
    {
        bool IsAutoUpdateLockScreen
        {
            get;
            set;
        }

        bool IsAutoUpdateWallpaper
        {
            get;
            set;
        }
    }
}