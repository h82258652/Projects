using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SoftwareKobo.Controls;
using SoftwareKobo.Services;
using VGtime.Uwp.Services;

namespace VGtime.Uwp.ViewModels.Settings
{
    public class SettingViewModel : ViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly IImageLoader _imageLoader;

        private readonly INavigationService _navigationService;

        private readonly IStoreService _storeService;

        private RelayCommand _clearImageCacheCommand;

        private bool _isCleaningImageCache;

        private RelayCommand _praiseCommand;

        private RelayCommand _showCoverCommand;

        public SettingViewModel(IAppToastService appToastService, IImageLoader imageLoader, IStoreService storeService, INavigationService navigationService)
        {
            _appToastService = appToastService;
            _imageLoader = imageLoader;
            _storeService = storeService;
            _navigationService = navigationService;
        }

        public long CacheImageSize => _imageLoader.CalculateCacheSize();

        public RelayCommand ClearImageCacheCommand
        {
            get
            {
                _clearImageCacheCommand = _clearImageCacheCommand ?? new RelayCommand(async () =>
                {
                    if (IsCleaningImageCache)
                    {
                        return;
                    }

                    try
                    {
                        IsCleaningImageCache = true;

                        await _imageLoader.DeleteAllCacheAsync();
                        _appToastService.ShowMessage("清除图片缓存成功");
                    }
                    catch (Exception ex)
                    {
                        _appToastService.ShowError(ex.Message);
                    }
                    finally
                    {
                        IsCleaningImageCache = false;
                        RaisePropertyChanged(nameof(CacheImageSize));
                    }
                });
                return _clearImageCacheCommand;
            }
        }

        public bool IsCleaningImageCache
        {
            get
            {
                return _isCleaningImageCache;
            }
            private set
            {
                Set(ref _isCleaningImageCache, value);
            }
        }

        public RelayCommand PraiseCommand
        {
            get
            {
                _praiseCommand = _praiseCommand ?? new RelayCommand(async () =>
                {
                    await _storeService.OpenCurrentAppReviewPageAsync();
                });
                return _praiseCommand;
            }
        }

        public RelayCommand ShowCoverCommand
        {
            get
            {
                _showCoverCommand = _showCoverCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.ShowCoverViewKey);
                });
                return _showCoverCommand;
            }
        }
    }
}