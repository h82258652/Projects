using System;
using System.Collections.ObjectModel;
using BingoWallpaper.Models.LeanCloud;
using GalaSoft.MvvmLight;

namespace BingoWallpaper.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        public MainViewModel()
        {
        }

        public ObservableCollection<Wallpaper> Wallpapers
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}