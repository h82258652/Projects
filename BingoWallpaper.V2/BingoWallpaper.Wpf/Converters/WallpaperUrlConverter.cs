using System;
using System.Globalization;
using System.Windows.Data;

namespace BingoWallpaper.Wpf.Converters
{
    public class WallpaperUrlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var args = (parameter as string)?.Split('x');
            if (args != null && args.Length == 2)
            {
                return $"{Constants.WallpaperUrlBase}{value}_{args[0]}x{args[1]}.jpg";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}