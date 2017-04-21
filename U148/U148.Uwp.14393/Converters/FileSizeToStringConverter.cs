using System;
using Windows.UI.Xaml.Data;

namespace U148.Uwp.Converters
{
    public class FileSizeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var b = (long)value;
            if (b < 1024)
            {
                return string.Format("{0}B", b);
            }
            var kb = b / 1024.0;
            if (kb < 1024)
            {
                return string.Format("{0:F2}KB", kb);
            }
            var mb = kb / 1024.0;
            if (mb < 1024)
            {
                return string.Format("{0:F2}MB", mb);
            }
            var gb = mb / 1024.0;
            if (gb < 1024)
            {
                return string.Format("{0:F2}GB", gb);
            }
            var tb = gb / 1024.0;
            return string.Format("{0:F2}TB", tb);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}