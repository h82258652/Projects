using System;
using System.Threading.Tasks;

namespace BingoWallpaper.Services
{
    public interface ILauncherService
    {
        Task<bool> LaunchUriAsync(Uri uri);
    }
}