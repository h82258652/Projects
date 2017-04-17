using System;
using U148.Uwp.Views;
using Windows.UI.Xaml.Data;

namespace U148.Uwp.Converters
{
    public class IsDisplayDetailConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return !(value is EmptyDetailView);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}