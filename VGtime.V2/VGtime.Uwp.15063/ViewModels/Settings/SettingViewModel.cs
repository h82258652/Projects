using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using VGtime.Configuration;

namespace VGtime.Uwp.ViewModels.Settings
{
    public class SettingViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private readonly IVGtimeSettings _vgtimeSettings;

        private RelayCommand _aboutCommand;

        private RelayCommand _showCoverCommand;

        public SettingViewModel(IVGtimeSettings vgtimeSettings, INavigationService navigationService)
        {
            _vgtimeSettings = vgtimeSettings;
            _navigationService = navigationService;
        }

        public RelayCommand AboutCommand
        {
            get
            {
                _aboutCommand = _aboutCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.AboutViewKey);
                });
                return _aboutCommand;
            }
        }

        public RelayCommand ShowCoverCommand
        {
            get
            {
                _showCoverCommand = _showCoverCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.ShowCoverViewKey);
                });
                return _showCoverCommand;
            }
        }
    }
}