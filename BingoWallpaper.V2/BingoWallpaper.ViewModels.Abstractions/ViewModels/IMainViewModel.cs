using System.Collections.ObjectModel;
using BingoWallpaper.Models.LeanCloud;

namespace BingoWallpaper.ViewModels
{
    public interface IMainViewModel
    {
        ObservableCollection<Wallpaper> Wallpapers
        {
            get;
        }
    }
}