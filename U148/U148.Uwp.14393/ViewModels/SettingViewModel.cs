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

        private readonly IImageLoader _imageLoader;

        private readonly IU148Settings _u148Settings;

        private readonly IU148ShareService _u148ShareService;

        private RelayCommand _clearAuthenticationCommand;

        private RelayCommand _clearImageCacheCommand;

        private bool _isBusy;

        public SettingViewModel(IU148Settings u148Settings, IImageLoader imageLoader, IAppToastService appToastService, IU148ShareService u148ShareService)
        {
            _u148Settings = u148Settings;
            _imageLoader = imageLoader;
            _appToastService = appToastService;
            _u148ShareService = u148ShareService;
        }

        public long CacheImageSize => _imageLoader.CalculateCacheSize();

        public RelayCommand ClearAuthenticationCommand
        {
            get
            {
                _clearAuthenticationCommand = _clearAuthenticationCommand ?? new RelayCommand(() =>
                {
                    _u148ShareService.ClearAuthorization();
                });
                return _clearAuthenticationCommand;
            }
        }

        public RelayCommand ClearImageCacheCommand
        {
            get
            {
                _clearImageCacheCommand = _clearImageCacheCommand ?? new RelayCommand(async () =>
                {
                    if (IsBusy)
                    {
                        return;
                    }

                    IsBusy = true;
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
                        IsBusy = false;
                        RaisePropertyChanged(nameof(CacheImageSize));
                    }
                }, () => !IsBusy);
                return _clearImageCacheCommand;
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