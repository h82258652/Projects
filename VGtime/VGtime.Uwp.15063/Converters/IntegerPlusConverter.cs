using System;
using Windows.UI.Xaml.Data;

namespace VGtime.Uwp.Converters
{
    public class IntegerPlusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (long)System.Convert.ChangeType(value, typeof(long)) + (long)System.Convert.ChangeType(parameter, typeof(long));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}