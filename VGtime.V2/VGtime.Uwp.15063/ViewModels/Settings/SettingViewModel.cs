using GalaSoft.MvvmLight;
using VGtime.Configuration;

namespace VGtime.Uwp.ViewModels.Settings
{
    public class SettingViewModel : ViewModelBase
    {
        private readonly IVGtimeSettings _vgtimeSettings;

        public SettingViewModel(IVGtimeSettings vgtimeSettings)
        {
            _vgtimeSettings = vgtimeSettings;
        }
    }
}