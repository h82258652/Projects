using BingoWallpaper.Configuration;
using GalaSoft.MvvmLight;

namespace BingoWallpaper.ViewModels
{
    public class SettingViewModel : ViewModelBase, ISettingViewModel
    {
        private readonly IBingoWallpaperSettings _bingoWallpaperSettings;

        public SettingViewModel(IBingoWallpaperSettings bingoWallpaperSettings)
        {
            _bingoWallpaperSettings = bingoWallpaperSettings;
        }

        public bool IsAutoUpdateLockScreen
        {
            get
            {
                return _bingoWallpaperSettings.IsAutoUpdateLockScreen;
            }
            set
            {
                _bingoWallpaperSettings.IsAutoUpdateLockScreen = value;
                RaisePropertyChanged();
            }
        }

        public bool IsAutoUpdateWallpaper
        {
            get
            {
                return _bingoWallpaperSettings.IsAutoUpdateWallpaper;
            }
            set
            {
                _bingoWallpaperSettings.IsAutoUpdateWallpaper = value;
                RaisePropertyChanged();
            }
        }
    }
}