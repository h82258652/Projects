using BingoWallpaper.Models;

namespace BingoWallpaper.Services
{
    public interface IWallpaperService
    {
        string GetUrl(IImage image, WallpaperSize size);
    }
}