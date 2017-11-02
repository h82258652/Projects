using System;
using System.Globalization;
using System.Windows.Data;
using BingoWallpaper.Models;
using BingoWallpaper.Services;
using CommonServiceLocator;

namespace BingoWallpaper.Wpf.Converters
{
    public class WallpaperUrlConverter : IValueConverter
    {
        private readonly IWallpaperService _wallpaperService;

        public WallpaperUrlConverter()
        {
            _wallpaperService = ServiceLocator.Current.GetInstance<IWallpaperService>();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var image = value as IImage;
            var args = (parameter as string)?.Split('x');
            if (image != null && args != null)
            {
                return _wallpaperService.GetUrl(image, new WallpaperSize(int.Parse(args[0]), int.Parse(args[1])));
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}