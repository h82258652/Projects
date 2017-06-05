using System;
using System.IO;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SoftwareKobo.Controls;
using VGtime.Configuration;
using VGtime.Services;
using VGtime.Uwp.Services;

namespace VGtime.Uwp.ViewModels.Settings
{
    public class ShowCoverViewModel : ViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly IImageLoader _imageLoader;

        private readonly IInitService _initService;

        private readonly IVGtimeFileService _vgtimeFileService;

        private readonly IVGtimeSettings _vgtimeSettings;

        private RelayCommand _saveCommand;

        public ShowCoverViewModel(IImageLoader imageLoader, IVGtimeFileService vgtimeFileService, IInitService initService, IAppToastService appToastService, IVGtimeSettings vgtimeSettings)
        {
            _imageLoader = imageLoader;
            _vgtimeFileService = vgtimeFileService;
            _initService = initService;
            _appToastService = appToastService;
            _vgtimeSettings = vgtimeSettings;
        }

        public RelayCommand SaveCommand
        {
            get
            {
                _saveCommand = _saveCommand ?? new RelayCommand(async () =>
                {
                    try
                    {
                        var startPicture = StartPicture;
                        if (string.IsNullOrEmpty(startPicture))
                        {
                            return;
                        }

                        var file = await _vgtimeFileService.SelectSaveFileAsync(Path.GetFileName(startPicture));
                        if (file == null)
                        {
                            return;
                        }

                        var bytes = await _imageLoader.GetBytesAsync(startPicture);
                        await _vgtimeFileService.WriteAllBytesAsync(file, bytes);
                        _appToastService.ShowMessage(LocalizedStrings.SaveSuccess);
                    }
                    catch (Exception ex)
                    {
                        _appToastService.ShowError(ex.Message);
                    }
                });
                return _saveCommand;
            }
        }

        public string StartPicture => _vgtimeSettings.StartPicture;

        public async void LoadStartPicture()
        {
            try
            {
                var result = await _initService.GetStartpicAsync(Constants.AppVersionName);
                if (result.Retcode == Constants.SuccessCode)
                {
                    _vgtimeSettings.StartPicture = result.Data.StartPicture;
                    RaisePropertyChanged(nameof(StartPicture));
                }
            }
            catch (Exception ex)
            {
                _appToastService.ShowError(ex.Message);
            }
        }
    }
}