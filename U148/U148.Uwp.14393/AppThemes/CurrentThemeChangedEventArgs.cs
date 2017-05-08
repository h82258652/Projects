using System;
using U148.Models;

namespace U148.Uwp.AppThemes
{
    public class CurrentThemeChangedEventArgs : EventArgs
    {
        public CurrentThemeChangedEventArgs(ThemeMode currentTheme)
        {
            CurrentTheme = currentTheme;
        }

        public ThemeMode CurrentTheme
        {
            get;
        }
    }
}