using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace VGtime.Uwp.Converters
{
    public class IsNullOrEmptyStringToVisibilityConverter : IValueConverter
    {
        public bool IsInversed
        {
            get;
            set;
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (IsInversed)
            {
                return string.IsNullOrEmpty(value as string) ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                return string.IsNullOrEmpty(value as string) ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}