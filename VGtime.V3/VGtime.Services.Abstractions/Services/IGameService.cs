using System.Threading.Tasks;
using VGtime.Models;
using VGtime.Models.Games;

namespace VGtime.Services
{
    public interface IGameService
    {
        Task<ServerBase<Ablumlist>> AblumlistAsync(int gameId);

        Task CancelplayAsync(int gameId, int userId);

        Task DetailAsync(int gameId, int? userId);

        Task PlayAsync(string content, int gameId, int score, int type, int userId);
    }
}