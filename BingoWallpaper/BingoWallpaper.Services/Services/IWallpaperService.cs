using System.Collections.Generic;
using BingoWallpaper.Models;

namespace BingoWallpaper.Services
{
    public interface IWallpaperService
    {
        IReadOnlyList<string> GetSupportedAreas();

        IReadOnlyList<WallpaperSize> GetSupportedWallpaperSizes();

        string GetUrl(IImage image, WallpaperSize size);
    }
}