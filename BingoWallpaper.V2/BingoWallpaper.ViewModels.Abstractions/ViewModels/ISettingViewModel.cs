namespace BingoWallpaper.ViewModels
{
    public interface ISettingViewModel
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