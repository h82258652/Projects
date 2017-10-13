using System.Collections.ObjectModel;
using System.Windows.Input;
using BingoWallpaper.Models.LeanCloud;
using BingoWallpaper.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace BingoWallpaper.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private readonly IAppNavigationService _appNavigationService;

        private readonly ILeanCloudService _leanCloudService;

        private ICommand _loadMoreCommand;

        private ICommand _wallpaperClickCommand;

        public MainViewModel(IAppNavigationService appNavigationService, ILeanCloudService leanCloudService)
        {
            _appNavigationService = appNavigationService;
            _leanCloudService = leanCloudService;
        }

        public ICommand LoadMoreCommand
        {
            get
            {
                _loadMoreCommand = _loadMoreCommand ?? new RelayCommand(() =>
                {
                    // TODO
                });
                return _loadMoreCommand;
            }
        }

        public ICommand WallpaperClickCommand
        {
            get
            {
                _wallpaperClickCommand = _wallpaperClickCommand ?? new RelayCommand<Wallpaper>(wallpaper =>
                {
                    _appNavigationService.NavigateTo(ViewModelLocatorBase.DetailViewKey, wallpaper);
                });
                return _wallpaperClickCommand;
            }
        }

        public ObservableCollection<Wallpaper> Wallpapers
        {
            get
            {
                // TODO
                return new ObservableCollection<Wallpaper>()
                {
                    new Wallpaper(),
                    new Wallpaper(),
                    new Wallpaper()
                };
            }
        }
    }
}