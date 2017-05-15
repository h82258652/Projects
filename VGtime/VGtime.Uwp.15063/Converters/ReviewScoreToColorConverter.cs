using System;
using System.Reflection;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace VGtime.Uwp.Converters
{
    public class ReviewScoreToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var reviewScore = (double?)value;

            Color color;
            if (reviewScore.HasValue)
            {
                if (reviewScore.Value >= 8)
                {
                    color = Colors.Green;
                }
                else if (reviewScore.Value >= 7)
                {
                    color = Colors.Yellow;
                }
                else if (reviewScore.Value > 0)
                {
                    color = Colors.Red;
                }
                else
                {
                    color = Colors.Gray;
                }
                color.A = 0xCC;
            }
            else
            {
                color = Colors.Transparent;
            }

            var targetTypeInfo = targetType.GetTypeInfo();
            if (typeof(Color).GetTypeInfo().IsAssignableFrom(targetTypeInfo))
            {
                return color;
            }
            else if (typeof(Brush).GetTypeInfo().IsAssignableFrom(targetTypeInfo))
            {
                return new SolidColorBrush(color);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}