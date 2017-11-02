using System.Windows.Input;
using BingoWallpaper.Models.LeanCloud;

namespace BingoWallpaper.ViewModels
{
    public interface IDetailViewModel
    {
        ICommand SaveCommand
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