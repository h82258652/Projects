using System.Threading.Tasks;
using VGtime.Models;

namespace VGtime.Services
{
    public interface IInitService
    {
        Task AdAsync(string postId, int type, string channelId);

        Task<ServerBase<StartPic>> StartpicAsync();

        Task VersionAsync(string versionName, int channel);
    }
}