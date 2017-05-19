using System.Threading.Tasks;
using VGtime.Models;

namespace VGtime.Services
{
    public interface IHomeService
    {
        Task<ServerBase<PushList>> GetVglistAsync(int page = 1, int pageSize = 20);
    }
}