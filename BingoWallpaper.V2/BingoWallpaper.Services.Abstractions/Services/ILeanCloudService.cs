using System.Collections.Generic;
using System.Threading.Tasks;
using BingoWallpaper.Models.LeanCloud;

namespace BingoWallpaper.Services
{
    public interface ILeanCloudService
    {
        Task<Archive> GetArchiveAsync(string objectId);

        Task<object> GetArchivesAsync(IEnumerable<string> objectIds);

        Task<Image> GetImageAsync(string objectId);

        Task<object> GetImagesAsync(IEnumerable<string> objectIds);
    }
}