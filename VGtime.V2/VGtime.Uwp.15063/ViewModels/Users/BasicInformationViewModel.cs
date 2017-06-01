using GalaSoft.MvvmLight;
using VGtime.Services;

namespace VGtime.Uwp.ViewModels.Users
{
    public class BasicInformationViewModel : ViewModelBase
    {
        private readonly IUserService _userService;

        public BasicInformationViewModel(IUserService userService)
        {
            _userService = userService;
        }
    }
}