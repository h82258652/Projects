using System;
using Windows.UI.Xaml.Data;

namespace U148.Uwp.Converters
{
    public class IsNullConverter : IValueConverter
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
                return value != null;
            }
            else
            {
                return value == null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}