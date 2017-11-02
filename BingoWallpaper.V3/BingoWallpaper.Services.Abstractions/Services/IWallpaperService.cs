using System;
using System.Collections.Generic;
using System.Text;
using BingoWallpaper.Models;

namespace BingoWallpaper.Services
{
    public interface IWallpaperService
    {
        string GetUrl(IImage image, WallpaperSize size);
    }
}
