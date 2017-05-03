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
            var reviewScore = (float?)value;

            Color color;
            if (reviewScore.HasValue)
            {
                if (reviewScore.Value >= 8)
                {
                    color = Color.FromArgb(0xCC, 0x00, 0x96, 0x88);
                }
                else if (reviewScore.Value >= 7)
                {
                    color = Color.FromArgb(0xCC, 0x8b, 0xc2, 0x4a);
                }
                else
                {
                    color = Color.FromArgb(0xCC, 0xe8, 0x1e, 0x63);
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