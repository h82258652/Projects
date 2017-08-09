using System.Threading.Tasks;

namespace VGtime.Services
{
    public interface IActionService
    {
        Task GameListAsync(int page, int pageSize, int targetId, int type, int? userId);

        Task ReportAsync(int postId, int userId, int type);

        Task ShareAsync(int postId, int type, int userId);
    }
}