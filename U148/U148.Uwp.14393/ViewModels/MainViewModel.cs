using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using U148.Configuration;
using U148.Models;
using U148.Uwp.Messages;
using U148.Uwp.Services;

namespace U148.Uwp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IAppToastService _appToastService;

        private RelayCommand _logoutCommand;

        private IU148Settings _u148Settings;

        public MainViewModel(IU148Settings u148Settings, IAppToastService appToastService)
        {
            _u148Settings = u148Settings;
            _appToastService = appToastService;

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

        public UserInfo UserInfo
        {
            get
            {
                return _u148Settings.UserInfo;
            }
        }

        public override void Cleanup()
        {
            base.Cleanup();

            MessengerInstance.Unregister(this);
        }
    }
}