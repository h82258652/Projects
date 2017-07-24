using System.Collections.Generic;
using System.Threading.Tasks;
using BingoWallpaper.Models.LeanCloud;

namespace BingoWallpaper.Services
{
    public interface ILeanCloudWallpaperService : IWallpaperService
    {
        Task<LeanCloudResultCollection<Archive>> GetArchivesInMonthAsync(int year, int month, string area);

        Task<Image> GetImageAsync(string objectId);

        Task<LeanCloudResultCollection<Image>> GetImagesAsync(IEnumerable<string> objectIds);

        Task<IEnumerable<Wallpaper>> GetWallpapersAsync(int year, int month, string area);
    }
}