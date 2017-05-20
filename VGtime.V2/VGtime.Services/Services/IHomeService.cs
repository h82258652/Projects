using System.Threading.Tasks;
using VGtime.Models;

namespace VGtime.Services
{
    public interface IHomeService
    {
        Task<ServerBase<HeadPicList>> GetHeadpicAsync();

        Task<ServerBase<TopicList>> GetListByTagAsync(int tags, int page = 1, int pageSize = 20);

        Task<ServerBase<PushList>> GetVglistAsync(int page = 1, int pageSize = 20);
    }
}