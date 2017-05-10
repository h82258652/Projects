using System;
using Windows.UI.Xaml.Data;

namespace VGtime.Uwp.Converters
{
    public class TimeAgoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTimeOffset timeOffset;
            if (value is DateTime)
            {
                timeOffset = (DateTime)value;
            }
            else if (value is DateTimeOffset)
            {
                timeOffset = (DateTimeOffset)value;
            }
            else
            {
                return value;
            }

            var expired = DateTimeOffset.Now - timeOffset;
            if (expired.TotalSeconds < 1)
            {
                return "1秒前";
            }
            else if (expired.TotalSeconds < 60)
            {
                return string.Format("{0}秒前", (long)Math.Floor(expired.TotalSeconds));
            }
            else if (expired.TotalMinutes < 60)
            {
                return string.Format("{0}分钟前", (long)Math.Floor(expired.TotalMinutes));
            }
            else if (expired.TotalHours < 24)
            {
                return string.Format("{0}小时前", (long)Math.Floor(expired.TotalHours));
            }
            else if (expired.TotalDays < 30)
            {
                return string.Format("{0}天前", (long)Math.Floor(expired.TotalDays));
            }
            else
            {
                return string.Format("{0}月前", (long)Math.Floor(expired.TotalDays / 30));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}