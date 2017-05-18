using GalaSoft.MvvmLight;
using VGtime.Services;

namespace VGtime.Uwp.ViewModels.Users
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IUserService _userService;

        public LoginViewModel(IUserService userService)
        {
            _userService = userService;
        }
    }
}