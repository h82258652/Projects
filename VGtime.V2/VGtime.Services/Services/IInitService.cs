using System.Threading.Tasks;
using VGtime.Models;

namespace VGtime.Services
{
    public interface IInitService
    {
        Task<ServerBase<KeywordList>> GetHotwordAsync();

        Task<ServerBase<StartPic>> GetStartpicAsync(string versionName);

        Task<ServerBase<VersionData>> GetVersionAsync(string versionName, int channel);
    }
}