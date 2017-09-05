using System.Collections.Generic;
using System.Threading.Tasks;
using BingoWallpaper.Models.LeanCloud;

namespace BingoWallpaper.Services
{
    public interface ILeanCloudService
    {
        Task<Archive> GetArchiveAsync(string objectId);

        Task<LeanCloudResultCollection<Archive>> GetArchivesAsync(IEnumerable<string> objectIds);

        Task<Image> GetImageAsync(string objectId);

        Task<LeanCloudResultCollection<Image>> GetImagesAsync(IEnumerable<string> objectIds);

        Task<Wallpaper> GetWallpaperAsync(string objectId);

        Task<IEnumerable<Wallpaper>> GetWallpapersAsync(IEnumerable<string> objectIds);
    }
}