using System;
using System.Numerics;
using Windows.UI.Xaml.Data;

namespace U148.Uwp.Converters
{
    public class CommentCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                if (BigInteger.TryParse(value.ToString(), out BigInteger integer))
                {
                    if (integer > 99)
                    {
                        return "99+";
                    }
                    else if (integer >= 0)
                    {
                        return integer;
                    }
                }
            }
            return "...";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}