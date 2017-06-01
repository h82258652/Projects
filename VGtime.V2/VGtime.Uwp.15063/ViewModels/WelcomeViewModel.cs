using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SoftwareKobo.Controls;
using VGtime.Configuration;
using VGtime.Services;

namespace VGtime.Uwp.ViewModels
{
    public class WelcomeViewModel : ViewModelBase
    {
        private readonly IImageLoader _imageLoader;

        private readonly IInitService _initService;

        private readonly IVGtimeSettings _vgtimeSettings;

        private RelayCommand _deleteStartPictureCommand;

        private bool _isLoadingHotword;

        public WelcomeViewModel(IInitService initService, IVGtimeSettings vgtimeSettings, IImageLoader imageLoader)
        {
            _initService = initService;
            _vgtimeSettings = vgtimeSettings;
            _imageLoader = imageLoader;

            Initialize();
        }

        public RelayCommand DeleteStartPictureCommand
        {
            get
            {
                _deleteStartPictureCommand = _deleteStartPictureCommand ?? new RelayCommand(() =>
                {
                    try
                    {
                        _imageLoader.DeleteCacheAsync(_vgtimeSettings.StartPicture);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                });
                return _deleteStartPictureCommand;
            }
        }

        public bool IsLoadingHotword
        {
            get
            {
                return _isLoadingHotword;
            }
            private set
            {
                Set(ref _isLoadingHotword, value);
            }
        }

        public string StartPicture
        {
            get
            {
                var startPicture = _vgtimeSettings.StartPicture;
                if (string.IsNullOrEmpty(startPicture))
                {
                    return null;
                }
                var cacheStartPictureFilePath = _imageLoader.GetCacheFilePath(startPicture);
                if (string.IsNullOrEmpty(cacheStartPictureFilePath))
                {
                    return null;
                }
                else
                {
                    return cacheStartPictureFilePath;
                }
            }
        }

        private void Initialize()
        {
            InitializeStartpic();
            InitializeHotword();
        }

        private async void InitializeHotword()
        {
            try
            {
                IsLoadingHotword = true;

                var result = await _initService.GetHotwordAsync();
                if (result.Retcode == 0)
                {
                    // TODO
                }
            }
            catch (Exception)
            {
                // ignored
            }
            finally
            {
                IsLoadingHotword = false;
            }
        }

        private async void InitializeStartpic()
        {
            try
            {
                var result = await _initService.GetStartpicAsync(Constants.AppVersionName);
                if (result.Retcode == Constants.SuccessCode)
                {
                    var startPictureUrl = result.Data.StartPicture;

                    if (!_imageLoader.ContainsCache(startPictureUrl))
                    {
                        await _imageLoader.GetBytesAsync(startPictureUrl);

                        _vgtimeSettings.StartPicture = startPictureUrl;
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}