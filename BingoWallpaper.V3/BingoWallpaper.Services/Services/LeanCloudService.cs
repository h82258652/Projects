using System.Net.Http;
using System.Threading.Tasks;
using BingoWallpaper.Models.LeanCloud;

namespace BingoWallpaper.Services
{
    public class LeanCloudService : LeanCloudServiceBase, ILeanCloudService
    {
        public override async Task<Archive> GetArchiveAsync(string objectId)
        {
            // TODO
            using (var client = new HttpClient())
            {
                var baidu = await client.GetStringAsync("http://www.baidu.com/");
            }

            return new Archive();
        }
    }
}