using System;
using System.Collections.Generic;
using BingoWallpaper.Models;
using BingoWallpaper.Uwp.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SoftwareKobo.Controls;

namespace BingoWallpaper.Uwp.ViewModels
{
    public class SettingViewModel : ViewModelBase, INavigable
    {
        private readonly IAppToastService _appToastService;

        private readonly IBingoShareService _bingoShareService;

        private readonly IImageLoader _imageLoader;

        private readonly ILeanCloudWallpaperServiceWithCache _leanCloudWallpaperServiceWithCache;

        private readonly IBingoWallpaperSettings _settings;

        private RelayCommand _clearAuthenticationCommand;

        private RelayCommand _clearCacheCommand;

        private bool _isBusy;

        private string _previousSelectedArea;

        public SettingViewModel(ILeanCloudWallpaperServiceWithCache leanCloudWallpaperServiceWithCache, IBingoWallpaperSettings settings, IBingoShareService bingoShareService, IAppToastService appToastService, IImageLoader imageLoader)
        {
            _leanCloudWallpaperServiceWithCache = leanCloudWallpaperServiceWithCache;
            _settings = settings;
            _bingoShareService = bingoShareService;
            _appToastService = appToastService;
            _imageLoader = imageLoader;
        }

        public IReadOnlyList<string> Areas => _leanCloudWallpaperServiceWithCache.GetSupportedAreas();

        public string CacheDataSizeString => _leanCloudWallpaperServiceWithCache.CalculateSizeString();

        public string CacheImageSizeString => _imageLoader.CalculateCacheSizeString();

        public RelayCommand ClearAuthenticationCommand
        {
            get
            {
                _clearAuthenticationCommand = _clearAuthenticationCommand ?? new RelayCommand(() =>
                {
                    _bingoShareService.ClearAuthorization();
                    _appToastService.ShowMessage(LocalizedStrings.ClearAuthorizationFinish);
                });
                return _clearAuthenticationCommand;
            }
        }

        public RelayCommand ClearCacheCommand
        {
            get
            {
                _clearCacheCommand = _clearCacheCommand ?? new RelayCommand(async () =>
                {
                    IsBusy = true;
                    try
                    {
                        try
                        {
                            await _leanCloudWallpaperServiceWithCache.DeleteAllCacheAsync();
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                        try
                        {
                            await _imageLoader.DeleteAllCacheAsync();
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }
                    finally
                    {
                        IsBusy = false;
                    }
                    RaisePropertyChanged(nameof(CacheDataSizeString));
                    RaisePropertyChanged(nameof(CacheImageSizeString));
                    _appToastService.ShowMessage(LocalizedStrings.ClearCacheFinish);
                });
                return _clearCacheCommand;
            }
        }

        public bool IsAutoUpdateLockScreen
        {
            get
            {
                return _settings.IsAutoUpdateLockScreen;
            }
            set
            {
                _settings.IsAutoUpdateLockScreen = value;
                RaisePropertyChanged();
            }
        }

        public bool IsAutoUpdateWallpaper
        {
            get
            {
                return _settings.IsAutoUpdateWallpaper;
            }
            set
            {
                _settings.IsAutoUpdateWallpaper = value;
                RaisePropertyChanged();
            }
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            private set
            {
                Set(ref _isBusy, value);
            }
        }

        public IReadOnlyList<SaveLocation> SaveLocations
        {
            get;
        } = EnumExtensions.GetValues<SaveLocation>();

        public string SelectedArea
        {
            get
            {
                return _settings.SelectedArea;
            }
            set
            {
                _settings.SelectedArea = value;
                RaisePropertyChanged();
            }
        }

        public SaveLocation SelectedSaveLocation
        {
            get
            {
                return _settings.SelectedSaveLocation;
            }
            set
            {
                _settings.SelectedSaveLocation = value;
                RaisePropertyChanged();
            }
        }

        public WallpaperSize SelectedWallpaperSize
        {
            get
            {
                return _settings.SelectedWallpaperSize;
            }
            set
            {
                _settings.SelectedWallpaperSize = value;
                RaisePropertyChanged();
            }
        }

        public IReadOnlyList<WallpaperSize> WallpaperSizes => _leanCloudWallpaperServiceWithCache.GetSupportedWallpaperSizes();

        public void Activate(object parameter)
        {
            _previousSelectedArea = SelectedArea;
        }

        public void Deactivate(object parameter)
        {
            if (_previousSelectedArea != SelectedArea)
            {
                MessengerInstance.Send(new SelectedAreaChangedMessage());
            }
        }
    }
}