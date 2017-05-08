using U148.Models;

namespace U148.Uwp.AppThemes
{
    public interface IThemeModeManager
    {
        ThemeMode CurrentTheme
        {
            get;
            set;
        }
    }
}