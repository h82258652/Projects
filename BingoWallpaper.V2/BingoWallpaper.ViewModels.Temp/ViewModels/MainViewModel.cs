using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BingoWallpaper.Configuration;
using BingoWallpaper.Models.LeanCloud;
using BingoWallpaper.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BingoWallpaper.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private readonly IAppToastService _appToastService;

        private readonly IBingoWallpaperSettings _bingoWallpaperSettings;

        private readonly ILeanCloudService _leanCloudService;

        private int _currentPage = 1;

        private bool _isLoading;

        private RelayCommand _loadMoreCommand;

        private RelayCommand<Wallpaper> _wallpaperClickCommand;

        private ObservableCollection<Wallpaper> _wallpapers;

        public MainViewModel(ILeanCloudService leanCloudService, IBingoWallpaperSettings bingoWallpaperSettings, IAppToastService appToastService)
        {
            _leanCloudService = leanCloudService;
            _bingoWallpaperSettings = bingoWallpaperSettings;
            _appToastService = appToastService;

            LoadMoreCommand.Execute(null);
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

                        var wallpapers = await _leanCloudService.GetWallpapersAsync(_currentPage, areas: _bingoWallpaperSettings.SelectedAreas);
                        foreach (var wallpaper in wallpapers)
                        {
                            Wallpapers.Add(wallpaper);
                        }

                        _currentPage++;
                    }
                    catch (Exception ex)
                    {
                        _appToastService.ShowError(ex.Message);
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
                    // TODO
                    throw new NotImplementedException();
                });
                return _wallpaperClickCommand;
            }
        }

        public ObservableCollection<Wallpaper> Wallpapers
        {
            get
            {
                _wallpapers = _wallpapers ?? new ObservableCollection<Wallpaper>();
                return _wallpapers;
            }
        }
    }
}