using System;
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

        private int _currentPage = 1;

        private bool _isLoading;

        private ICommand _loadMoreCommand;

        private ICommand _wallpaperClickCommand;

        private ObservableCollection<Wallpaper> _wallpapers;

        public MainViewModel(IAppNavigationService appNavigationService, ILeanCloudService leanCloudService)
        {
            _appNavigationService = appNavigationService;
            _leanCloudService = leanCloudService;
        }

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            private set
            {
                Set(ref _isLoading, value);
            }
        }

        public ICommand LoadMoreCommand
        {
            get
            {
                _loadMoreCommand = _loadMoreCommand ?? new RelayCommand(async () =>
                {
                    if (IsLoading)
                    {
                        return;
                    }

                    try
                    {
                        IsLoading = true;

                        // TODO
                        var wallpapers = await _leanCloudService.GetWallpapersAsync(new[] { "" });
                        foreach (var wallpaper in wallpapers)
                        {
                            Wallpapers.Add(wallpaper);
                        }
                        _currentPage++;
                    }
                    catch (Exception ex)
                    {
                        // TODO
                    }
                    finally
                    {
                        IsLoading = false;
                    }
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
                    //_appNavigationService.NavigateTo(ViewModelLocatorBase.DetailViewKey, wallpaper);
                });
                return _wallpaperClickCommand;
            }
        }

        public ObservableCollection<Wallpaper> Wallpapers
        {
            get
            {
                _wallpapers = _wallpapers ?? new ObservableCollection<Wallpaper>();
                _wallpapers.Add(new Wallpaper());
                _wallpapers.Add(new Wallpaper());
                _wallpapers.Add(new Wallpaper());
                return _wallpapers;
            }
        }
    }
}