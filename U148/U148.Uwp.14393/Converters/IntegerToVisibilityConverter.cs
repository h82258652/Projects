using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace U148.Uwp.Converters
{
    public class IntegerToVisibilityConverter : IValueConverter
    {
        public bool IsInversed
        {
            get;
            set;
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var integer = (long)System.Convert.ChangeType(value, typeof(long));
            if (IsInversed)
            {
                return integer == 0 ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                return integer == 0 ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}