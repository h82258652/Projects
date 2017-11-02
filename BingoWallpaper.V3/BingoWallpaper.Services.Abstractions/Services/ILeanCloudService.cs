using System.Threading.Tasks;
using BingoWallpaper.Models.LeanCloud;

namespace BingoWallpaper.Services
{
    public interface ILeanCloudService : IWallpaperService
    {
        Task<Archive> GetArchiveAsync(string objectId);

        Task<Image> GetImageAsync(string objectId);

        Task<Wallpaper> GetWallpaperAsync(string objectId);
    }
}