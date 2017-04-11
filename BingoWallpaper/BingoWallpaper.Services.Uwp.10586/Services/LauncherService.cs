using System;
using System.Threading.Tasks;
using Windows.System;

namespace BingoWallpaper.Services
{
    public class LauncherService : ILauncherService
    {
        public async Task<bool> LaunchUriAsync(Uri uri)
        {
            return await Launcher.LaunchUriAsync(uri);
        }
    }
}