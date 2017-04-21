using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SoftwareKobo.Controls;
using U148.Configuration;
using U148.Models;
using U148.Services;
using U148.Uwp.Services;
using WinRTXamlToolkit.Tools;

namespace U148.Uwp.ViewModels
{
    public class SettingViewModel : ViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly IArticleServiceWithCache _articleServiceWithCache;

        private readonly IImageLoader _imageLoader;

        private readonly IU148Settings _u148Settings;

        private readonly IU148ShareService _u148ShareService;

        private RelayCommand _clearDataCacheCommand;

        private RelayCommand _clearImageCacheCommand;

        private RelayCommand _clearSinaWeiboAuthenticationCommand;

        private bool _isCleaningDataCache;

        private bool _isCleaningImageCache;

        public SettingViewModel(IU148Settings u148Settings, IImageLoader imageLoader, IAppToastService appToastService, IU148ShareService u148ShareService, IArticleServiceWithCache articleServiceWithCache)
        {
            _u148Settings = u148Settings;
            _imageLoader = imageLoader;
            _appToastService = appToastService;
            _u148ShareService = u148ShareService;
            _articleServiceWithCache = articleServiceWithCache;
        }

        public long CacheDataSize => _articleServiceWithCache.CalculateCacheSize();

        public long CacheImageSize => _imageLoader.CalculateCacheSize();

        public RelayCommand ClearDataCacheCommand
        {
            get
            {
                _clearDataCacheCommand = _clearDataCacheCommand ?? new RelayCommand(async () =>
                {
                    if (IsCleaningDataCache)
                    {
                        return;
                    }

                    IsCleaningDataCache = true;
                    try
                    {
                        await _articleServiceWithCache.DeleteAllCacheAsync();
                        _appToastService.ShowMessage(LocalizedStrings.ClearDataCacheFinish);
                    }
                    catch (Exception ex)
                    {
                        _appToastService.ShowError(ex.Message);
                    }
                    finally
                    {
                        IsCleaningDataCache = false;
                        RaisePropertyChanged(nameof(CacheDataSize));
                    }
                }, () => !IsCleaningDataCache);
                return _clearDataCacheCommand;
            }
        }

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

                    IsCleaningImageCache = true;
                    try
                    {
                        await _imageLoader.DeleteAllCacheAsync();
                        _appToastService.ShowMessage(LocalizedStrings.ClearImageCacheFinish);
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
                }, () => !IsCleaningImageCache);
                return _clearImageCacheCommand;
            }
        }

        public RelayCommand ClearSinaWeiboAuthenticationCommand
        {
            get
            {
                _clearSinaWeiboAuthenticationCommand = _clearSinaWeiboAuthenticationCommand ?? new RelayCommand(() =>
                {
                    _u148ShareService.ClearSinaWeiboAuthorization();

                    _appToastService.ShowMessage(LocalizedStrings.ClearSinaWeiboAuthenticationSuccess);
                });
                return _clearSinaWeiboAuthenticationCommand;
            }
        }

        public bool IsCleaningDataCache
        {
            get
            {
                return _isCleaningDataCache;
            }
            private set
            {
                Set(ref _isCleaningDataCache, value);
                ClearDataCacheCommand.RaiseCanExecuteChanged();
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
                ClearImageCacheCommand.RaiseCanExecuteChanged();
            }
        }

        public SimulateDevice SimulateDevice
        {
            get
            {
                return _u148Settings.SimulateDevice;
            }
            set
            {
                _u148Settings.SimulateDevice = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<SimulateDevice> SimulateDevices
        {
            get;
        } = EnumExtensions.GetValues<SimulateDevice>();
    }
}