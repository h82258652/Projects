using System.Collections.Generic;
using System.Threading.Tasks;
using BingoWallpaper.Models.LeanCloud;

namespace BingoWallpaper.Services
{
    public interface ILeanCloudWallpaperService : IWallpaperService
    {
        Task<LeanCloudResultCollection<Archive>> GetArchivesAsync(int pageIndex = 1, int pageSize = 100, params string[] areas);

        Task<LeanCloudResultCollection<Archive>> GetArchivesInMonthAsync(int year, int month, string area);

        Task<Image> GetImageAsync(string objectId);

        Task<LeanCloudResultCollection<Image>> GetImagesAsync(IEnumerable<string> objectIds);

        Task<IEnumerable<Wallpaper>> GetWallpapersInMonthAsync(int year, int month, string area);
    }
}