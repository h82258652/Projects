using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SoftwareKobo.Controls;
using VGtime.Models.Games;
using VGtime.Uwp.Services;

namespace VGtime.Uwp.ViewModels.Image
{
    public class ImagePagerViewModel : ViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly IImageLoader _imageLoader;

        private GameAlbum[] _photos;

        private RelayCommand<GameAlbum> _saveCommand;

        public ImagePagerViewModel(IImageLoader imageLoader, IAppToastService appToastService)
        {
            _imageLoader = imageLoader;
            _appToastService = appToastService;
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
                        var bytes = await _imageLoader.GetBytesAsync(photo.Url);

                        throw new NotImplementedException();
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