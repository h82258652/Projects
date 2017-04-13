using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using SoftwareKobo.ViewModels;
using U148.Configuration;
using U148.Services;
using U148.Uwp.Messages;
using U148.Uwp.Services;

namespace U148.Uwp.ViewModels
{
    public class LoginViewModel : VerifiableViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly IU148Settings _u148Settings;

        private readonly IUserService _userService;

        private string _email;

        private bool _isBusy;

        private RelayCommand _loginCommand;

        private string _password;

        public LoginViewModel(IUserService userService, IU148Settings u148Settings, IAppToastService appToastService)
        {
            _userService = userService;
            _u148Settings = u148Settings;
            _appToastService = appToastService;
        }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(LocalizedStrings), ErrorMessageResourceName = "EmailRequired")]
        [EmailAddress(ErrorMessageResourceType = typeof(LocalizedStrings), ErrorMessageResourceName = "EmailFormatError")]
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                Set(ref _email, value);
                LoginCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(nameof(EmailSuggestions));
            }
        }

        public IEnumerable<string> EmailSuggestions
        {
            get
            {
                var email = Email;
                if (email == null)
                {
                    return null;
                }

                var index = email.IndexOf('@');
                if (index < 0)
                {
                    return null;
                }

                var username = email.Substring(0, index);
                return new List<string>()
                {
                    username + "@qq.com",
                    username + "@hotmai.com",
                    username + "@outlook.com",
                    username + "@163.com",
                    username + "@gmail.com",
                    username + "@sina.com"
                }.Where(temp => temp.Contains(email));
            }
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            private set
            {
                Set(ref _isBusy, value);
                LoginCommand.RaiseCanExecuteChanged();
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
                    if (!IsValid)
                    {
                        MessengerInstance.Send(new LoginFailedMessage());
                        return;
                    }

                    IsBusy = true;
                    try
                    {
                        var result = await _userService.LoginAsync(Email, Password);
                        if (result.ErrorCode == 0)
                        {
                            var userInfo = result.Data;
                            _u148Settings.UserInfo = userInfo;
                            MessengerInstance.Send(new LoginSuccessMessage(userInfo));

                            _appToastService.ShowMessage(LocalizedStrings.LoginSuccess);

                            MessengerInstance.Send(new HideLoginViewMessage());
                        }
                        else
                        {
                            _appToastService.ShowError(result.ErrorMessage);
                            MessengerInstance.Send(new LoginFailedMessage());
                        }
                    }
                    catch (Exception ex)
                    {
                        _appToastService.ShowError(ex.Message);
                        MessengerInstance.Send(new LoginFailedMessage());
                    }
                    finally
                    {
                        IsBusy = false;
                    }
                }, () => IsValid && !IsBusy);
                return _loginCommand;
            }
        }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(LocalizedStrings), ErrorMessageResourceName = "PasswordRequired")]
        [StringLength(16, MinimumLength = 6, ErrorMessageResourceType = typeof(LocalizedStrings), ErrorMessageResourceName = "PasswordLengthError")]
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                Set(ref _password, value);
                LoginCommand.RaiseCanExecuteChanged();
            }
        }
    }
}