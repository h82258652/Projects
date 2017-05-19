using System;
using GalaSoft.MvvmLight;
using VGtime.Services;

namespace VGtime.Uwp.ViewModels
{
    public class WelcomeViewModel : ViewModelBase
    {
        private readonly IInitService _initService;

        public WelcomeViewModel(IInitService initService)
        {
            _initService = initService;

            Initialize();
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
                var result = await _initService.GetHotwordAsync();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private async void InitializeStartpic()
        {
            try
            {
                var result = await _initService.GetStartpicAsync(Constants.AppVersionName);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}