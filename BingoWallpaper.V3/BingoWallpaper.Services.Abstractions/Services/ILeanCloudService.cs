using System.Threading.Tasks;
using BingoWallpaper.Models.LeanCloud;

namespace BingoWallpaper.Services
{
    public interface ILeanCloudService
    {
        Task<Archive> GetArchiveAsync(string objectId);
    }
}