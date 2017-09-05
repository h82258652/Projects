using System.Collections.ObjectModel;
using System.Windows.Input;
using BingoWallpaper.Models.LeanCloud;

namespace BingoWallpaper.ViewModels
{
    public interface IMainViewModel
    {
        ICommand LoadMoreCommand
        {
            get;
        }

        ICommand WallpaperClickCommand
        {
            get;
        }

        ObservableCollection<Wallpaper> Wallpapers
        {
            get;
        }
    }
}