using System.Collections.Generic;
using System.Threading.Tasks;
using BingoWallpaper.Models.LeanCloud;

namespace BingoWallpaper.Services
{
    public interface ILeanCloudService
    {
        Task<Archive> GetArchiveAsync(string objectId);

        Task<LeanCloudResultCollection<Archive>> GetArchivesAsync(IEnumerable<string> objectIds);

        Task<LeanCloudResultCollection<Archive>> GetArchivesAsync(int page = 1, int pageSize = 20, string[] areas = null);

        Task<Image> GetImageAsync(string objectId);

        Task<LeanCloudResultCollection<Image>> GetImagesAsync(IEnumerable<string> objectIds);

        Task<Wallpaper> GetWallpaperAsync(string objectId);

        Task<IEnumerable<Wallpaper>> GetWallpapersAsync(IEnumerable<string> objectIds);

        Task<IEnumerable<Wallpaper>> GetWallpapersAsync(int page = 1, int pageSize = 20, string[] areas = null);
    }
}