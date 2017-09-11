using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BingoWallpaper.Models.LeanCloud;
using BingoWallpaper.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BingoWallpaper.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private readonly ILeanCloudService _leanCloudService;

        private bool _isLoading;

        private RelayCommand _loadMoreCommand;

        private RelayCommand<Wallpaper> _wallpaperClickCommand;

        public MainViewModel(ILeanCloudService leanCloudService)
        {
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

                        await _leanCloudService.GetWallpapersAsync(null);

                        throw new NotImplementedException();
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
                throw new NotImplementedException();
            }
        }
    }
}