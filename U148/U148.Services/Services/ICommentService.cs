using System.Threading.Tasks;
using U148.Models;

namespace U148.Services
{
    public interface ICommentService
    {
        Task<ResultBase<Page<Comment>>> GetCommentsAsync(int id, int page = 1);

        Task<ResultBase> SendCommentAsync(int id, string token, string content, SimulateDevice device = SimulateDevice.Android, int? reviewId = null);
    }
}