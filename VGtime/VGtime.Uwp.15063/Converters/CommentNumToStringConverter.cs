using System;
using Windows.UI.Xaml.Data;

namespace VGtime.Uwp.Converters
{
    public class CommentNumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((int)value > 0)
            {
                return value;
            }
            else
            {
                return "评论";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}