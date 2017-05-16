using System;
using System.Net;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SoftwareKobo.Controls;
using VGtime.Configuration;
using VGtime.Services;

namespace VGtime.Uwp.ViewModels
{
    public class SplashScreenViewModel : ViewModelBase
    {
        private readonly IImageLoader _imageLoader;

        private readonly IPostService _postService;

        private readonly IVGtimeSettings _vgtimeSettings;

        private RelayCommand _deleteStartPictureCommand;

        public SplashScreenViewModel(IVGtimeSettings vgtimeSettings, IPostService postService, IImageLoader imageLoader)
        {
            _vgtimeSettings = vgtimeSettings;
            _postService = postService;
            _imageLoader = imageLoader;

            Initialize();
        }

        public RelayCommand DeleteStartPictureCommand
        {
            get
            {
                _deleteStartPictureCommand = _deleteStartPictureCommand ?? new RelayCommand(async () =>
                {
                    try
                    {
                        await _imageLoader.DeleteCacheAsync(_vgtimeSettings.StartPicture);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                });
                return _deleteStartPictureCommand;
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

        private async void Initialize()
        {
            try
            {
                var result = await _postService.GetStartPicAsync();
                if (result.ErrorCode == HttpStatusCode.OK)
                {
                    var startPictureUrl = result.Data.Data;

                    if (_imageLoader.ContainsCache(startPictureUrl) == false)
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