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
            float? score;
            if (value == null)
            {
                score = null;
            }
            else
            {
                score = System.Convert.ToSingle(value);
            }

            Color color;
            if (score.HasValue)
            {
                if (score.Value >= 8f)
                {
                    color = Color.FromArgb(0xE5, 0x42, 0xC4, 0x7A);
                }
                else if (score.Value >= 7f)
                {
                    color = Color.FromArgb(0xE5, 0x96, 0xB2, 0x29);
                }
                else if (score.Value > 0f)
                {
                    color = Color.FromArgb(0xE5, 0xEC, 0x4C, 0x54);
                }
                else
                {
                    color = Colors.Gray;
                    color.A = 0xE5;
                }
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