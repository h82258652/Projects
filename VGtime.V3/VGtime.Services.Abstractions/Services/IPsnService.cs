using System.Threading.Tasks;

namespace VGtime.Services
{
    public interface IPsnService
    {
        Task GamesAsync(int page, int pageSize, int dataId);
    }
}