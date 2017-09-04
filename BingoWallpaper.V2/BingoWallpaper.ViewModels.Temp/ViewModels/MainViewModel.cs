using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BingoWallpaper.Models.LeanCloud;
using BingoWallpaper.Services;
using GalaSoft.MvvmLight;

namespace BingoWallpaper.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private readonly ILeanCloudService _leanCloudService;

        public MainViewModel(ILeanCloudService leanCloudService)
        {
            _leanCloudService = leanCloudService;
        }

        public ICommand LoadMoreCommand
        {
            get
            {
                throw new NotImplementedException();
            }
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