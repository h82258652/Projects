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
        private readonly IUserService _userService;

        private readonly IVGtimeSettings _vgtimeSettings;

        private readonly IAppToastService _appToastService;

        private string _account;

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

        public RelayCommand LoginCommand
        {
            get
            {
                _loginCommand = _loginCommand ?? new RelayCommand(async () =>
                {
                    try
                    {
                        var result = await _userService.LoginAsync(Account, Password);
                        if (result.Retcode == Constants.SuccessCode)
                        {
                            var userInfo = result.Data;
                            _vgtimeSettings.UserInfo = userInfo;

                            MessengerInstance.Send(new LoginSuccessMessage(userInfo));
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
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