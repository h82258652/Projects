using System;
using BingoWallpaper.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SoftwareKobo.Services;

namespace BingoWallpaper.Uwp.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        private readonly ILauncherService _launcherService;

        private readonly IStoreService _storeService;

        private RelayCommand _rateCommand;

        private RelayCommand _visitWebVersionCommand;

        public AboutViewModel(IStoreService storeService, ILauncherService launcherService)
        {
            _storeService = storeService;
            _launcherService = launcherService;
        }

        public RelayCommand RateCommand
        {
            get
            {
                _rateCommand = _rateCommand ?? new RelayCommand(async () =>
                {
                    await _storeService.OpenCurrentAppReviewPageAsync();
                });
                return _rateCommand;
            }
        }

        public RelayCommand VisitWebVersionCommand
        {
            get
            {
                _visitWebVersionCommand = _visitWebVersionCommand ?? new RelayCommand(async () =>
                {
                    await _launcherService.LaunchUriAsync(new Uri(Constants.WebVersionAddress));
                });
                return _visitWebVersionCommand;
            }
        }
    }
}