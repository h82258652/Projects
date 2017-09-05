using System.Threading.Tasks;

namespace BingoWallpaper.Services
{
    public interface IBingoWallpaperFileService
    {
        Task SaveFileAsync(string suggestedFileName, byte[] bytes);
    }
}