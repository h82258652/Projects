using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using U148.Configuration;
using U148.Models;
using U148.Uwp.Messages;
using U148.Uwp.Services;

namespace U148.Uwp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly INavigationService _navigationService;

        private readonly IU148Settings _u148Settings;

        private RelayCommand _aboutCommand;

        private RelayCommand _loginCommand;

        private RelayCommand _logoutCommand;

        private RelayCommand _settingCommand;

        public MainViewModel(IU148Settings u148Settings, IAppToastService appToastService, INavigationService navigationService)
        {
            _u148Settings = u148Settings;
            _appToastService = appToastService;
            _navigationService = navigationService;

            MessengerInstance.Register<LoginSuccessMessage>(this, message =>
            {
                RaisePropertyChanged(nameof(UserInfo));
                LogoutCommand.RaiseCanExecuteChanged();
            });
            MessengerInstance.Register<LogoutMessage>(this, message =>
            {
                RaisePropertyChanged(nameof(UserInfo));
                LogoutCommand.RaiseCanExecuteChanged();
            });
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

        public RelayCommand LoginCommand
        {
            get
            {
                _loginCommand = _loginCommand ?? new RelayCommand(() =>
                {
                    MessengerInstance.Send(new ShowLoginViewMessage());
                });
                return _loginCommand;
            }
        }

        public RelayCommand LogoutCommand
        {
            get
            {
                _logoutCommand = _logoutCommand ?? new RelayCommand(() =>
                {
                    _u148Settings.UserInfo = null;
                    MessengerInstance.Send(new LogoutMessage());

                    _appToastService.ShowMessage(LocalizedStrings.LogoutSuccess);
                }, () => UserInfo != null);
                return _logoutCommand;
            }
        }

        public RelayCommand SettingCommand
        {
            get
            {
                _settingCommand = _settingCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.SettingViewKey);
                });
                return _settingCommand;
            }
        }

        public UserInfo UserInfo => _u148Settings.UserInfo;

        public override void Cleanup()
        {
            base.Cleanup();

            MessengerInstance.Unregister(this);
        }
    }
}