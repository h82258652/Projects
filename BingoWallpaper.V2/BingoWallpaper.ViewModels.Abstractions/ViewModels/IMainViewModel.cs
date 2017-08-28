using System.Collections.ObjectModel;

namespace BingoWallpaper.ViewModels
{
    public interface IMainViewModel
    {
        ObservableCollection<object> Wallpapers
        {
            get;
        }
    }
}