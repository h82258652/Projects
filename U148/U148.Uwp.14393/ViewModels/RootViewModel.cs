using GalaSoft.MvvmLight;
using U148.Configuration;
using U148.Models;

namespace U148.Uwp.ViewModels
{
    public class RootViewModel : ViewModelBase
    {
        private readonly IU148UwpSettings _u148UwpSettings;

        public RootViewModel(IU148UwpSettings u148UwpSettings)
        {
            _u148UwpSettings = u148UwpSettings;
        }

        public ThemeMode ThemeMode
        {
            get
            {
                return _u148UwpSettings.ThemeMode;
            }
            set
            {
                _u148UwpSettings.ThemeMode = value;
            }
        }
    }
}