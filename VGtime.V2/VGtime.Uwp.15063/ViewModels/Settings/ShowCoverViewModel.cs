using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SoftwareKobo.Controls;
using VGtime.Services;
using VGtime.Uwp.Services;

namespace VGtime.Uwp.ViewModels.Settings
{
    public class ShowCoverViewModel : ViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly IInitService _initService;

        private IImageLoader _imageLoader;

        private RelayCommand _saveCommand;

        private IVGtimeFileService _vgtimeFileService;

        public ShowCoverViewModel(IImageLoader imageLoader, IVGtimeFileService vgtimeFileService, IInitService initService, IAppToastService appToastService)
        {
            _imageLoader = imageLoader;
            _vgtimeFileService = vgtimeFileService;
            _initService = initService;
            _appToastService = appToastService;
        }

        public RelayCommand SaveCommand
        {
            get
            {
                _saveCommand = _saveCommand ?? new RelayCommand(() =>
                {
                    try
                    {
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