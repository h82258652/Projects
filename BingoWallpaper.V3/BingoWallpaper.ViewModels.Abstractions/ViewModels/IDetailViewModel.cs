using System.Windows.Input;
using BingoWallpaper.Models.LeanCloud;

namespace BingoWallpaper.ViewModels
{
    public interface IDetailViewModel
    {
        ICommand GoBackCommand
        {
            get;
        }

        ICommand SaveCommand
        {
            get;
        }

        ICommand SetAsLockScreenCommand
        {
            get;
        }

        ICommand SetAsWallpaperCommand
        {
            get;
        }

        Wallpaper Wallpaper
        {
            get;
            set;
        }
    }
}