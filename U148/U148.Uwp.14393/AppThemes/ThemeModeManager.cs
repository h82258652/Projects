using GalaSoft.MvvmLight;
using U148.Configuration;
using U148.Models;

namespace U148.Uwp.AppThemes
{
    public class ThemeModeManager : ObservableObject, IThemeModeManager
    {
        private readonly IU148UwpSettings _u148UwpSettings;

        public ThemeModeManager(IU148UwpSettings u148UwpSettings)
        {
            _u148UwpSettings = u148UwpSettings;
        }

        public ThemeMode CurrentTheme
        {
            get
            {
                return _u148UwpSettings.ThemeMode;
            }
            set
            {
                if (_u148UwpSettings.ThemeMode != value)
                {
                    _u148UwpSettings.ThemeMode = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}