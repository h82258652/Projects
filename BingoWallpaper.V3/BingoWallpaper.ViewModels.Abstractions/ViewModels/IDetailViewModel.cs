using System.Windows.Input;

namespace BingoWallpaper.ViewModels
{
    public interface IDetailViewModel
    {
        ICommand SaveCommand
        {
            get;
        }
    }
}