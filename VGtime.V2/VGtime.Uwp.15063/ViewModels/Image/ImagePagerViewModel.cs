﻿using System;
using System.IO;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SoftwareKobo.Controls;
using VGtime.Models.Games;
using VGtime.Services;
using VGtime.Uwp.Services;

namespace VGtime.Uwp.ViewModels.Image
{
    public class ImagePagerViewModel : ViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly IImageLoader _imageLoader;

        private readonly IVGtimeFileService _vgtimeFileService;

        private GameAlbum[] _photos;

        private RelayCommand<GameAlbum> _saveCommand;

        public ImagePagerViewModel(IImageLoader imageLoader, IAppToastService appToastService, IVGtimeFileService vgtimeFileService)
        {
            _imageLoader = imageLoader;
            _appToastService = appToastService;
            _vgtimeFileService = vgtimeFileService;
        }

        public GameAlbum[] Photos
        {
            get
            {
                return _photos;
            }
            set
            {
                Set(ref _photos, value);
            }
        }

        public RelayCommand<GameAlbum> SaveCommand
        {
            get
            {
                _saveCommand = _saveCommand ?? new RelayCommand<GameAlbum>(async photo =>
                {
                    if (photo == null)
                    {
                        return;
                    }

                    try
                    {
                        var url = photo.Url;
                        var bytes = await _imageLoader.GetBytesAsync(url);
                        var result = await _vgtimeFileService.SaveFileAsync(bytes, Path.Combine(url));
                        if (result)
                        {
                            _appToastService.ShowMessage(LocalizedStrings.SaveSuccess);
                        }
                    }
                    catch (Exception ex)
                    {
                        _appToastService.ShowError(ex.Message);
                    }
                });
                return _saveCommand;
            }
        }
    }
}