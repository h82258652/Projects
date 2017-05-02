using System;
using U148.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace U148.Uwp.Converters
{
    public class ThemeModeToRequestedThemeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch ((ThemeMode)value)
            {
                case ThemeMode.Day:
                    return ElementTheme.Light;

                case ThemeMode.Night:
                    return ElementTheme.Dark;

                default:
                    return ElementTheme.Default;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}