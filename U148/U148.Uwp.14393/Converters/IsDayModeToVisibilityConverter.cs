using System;
using U148.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace U148.Uwp.Converters
{
    public class IsDayModeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var themeMode = (ThemeMode)value;
            return themeMode == ThemeMode.Day ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}