using System.Threading.Tasks;
using BingoWallpaper.Models.Bing;

namespace BingoWallpaper.Services
{
    public interface IBingWallpaperService : IWallpaperService
    {
        Task<BingResult> GetAsync(int daysAgo, int count, string area);
    }
}