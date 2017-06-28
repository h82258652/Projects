using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace VGtime.Uwp.Converters
{
    public class IntegerBiggerThanOneToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var integer = System.Convert.ToInt64(value);
            return integer > 1 ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}