using System;
using System.Reflection;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace VGtime.Uwp.Converters
{
    public class ScoreToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double? score;
            if (value == null)
            {
                score = null;
            }
            else
            {
                score = System.Convert.ToDouble(value);
            }

            Color color;
            if (score.HasValue)
            {
                if (score.Value >= 8)
                {
                    color = Colors.Green;
                }
                else if (score.Value >= 7)
                {
                    color = Colors.Yellow;
                }
                else if (score.Value > 0)
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