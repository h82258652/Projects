using System.Threading.Tasks;

namespace BingoWallpaper.Services
{
    public interface ILeanCloudWallpaperServiceWithCache : ILeanCloudWallpaperService
    {
        Task DeleteAllCacheAsync();

        string GetCacheFolderPath();

        long CalculateSize();
    }
}