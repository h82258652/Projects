using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using VGtime.Configuration;
using VGtime.Services;
using VGtime.Uwp.Messages;
using VGtime.Uwp.Services;

namespace VGtime.Uwp.ViewModels.Users
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly IUserService _userService;

        private readonly IVGtimeSettings _vgtimeSettings;

        private string _account;

        private bool _isBusy;

        private RelayCommand _loginCommand;

        private string _password;

        public LoginViewModel(IUserService userService, IVGtimeSettings vgtimeSettings, IAppToastService appToastService)
        {
            _userService = userService;
            _vgtimeSettings = vgtimeSettings;
            _appToastService = appToastService;
        }

        public string Account
        {
            get
            {
                return _account;
            }
            set
            {
                Set(ref _account, value);
            }
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                Set(ref _isBusy, value);
            }
        }

        public RelayCommand LoginCommand
        {
            get
            {
                _loginCommand = _loginCommand ?? new RelayCommand(async () =>
                {
                    if (IsBusy)
                    {
                        return;
                    }
                    try
                    {
                        IsBusy = true;

                        var result = await _userService.LoginAsync(Account, Password);
                        if (result.Retcode == Constants.SuccessCode)
                        {
                            var userInfo = result.Data;
                            _vgtimeSettings.UserInfo = userInfo;

                            MessengerInstance.Send(new LoginSuccessMessage(userInfo));
                        }
                        else
                        {
                            _appToastService.ShowError(result.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        _appToastService.ShowError(ex.Message);
                    }
                    finally
                    {
                        IsBusy = false;
                    }
                });
                return _loginCommand;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                Set(ref _password, value);
            }
        }
    }
}