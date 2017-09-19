using System.Threading.Tasks;

namespace BingoWallpaper.Services
{
    public interface IBingoWallpaperFileService
    {
        Task<bool> SaveFileAsync(string suggestedFileName, byte[] bytes);
    }
}