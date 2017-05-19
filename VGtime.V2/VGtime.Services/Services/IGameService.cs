using System.Threading.Tasks;
using VGtime.Models;

namespace VGtime.Services
{
    public interface IGameService
    {
        Task<ServerBase<AlbumList>> GetAlbumListAsync(int gameId);

        Task<ServerBase<GameData>> GetDetailAsync(int gameId, int? userId = null);

        Task<ServerBase<GameList>> GetScoreListAsync(int gameId, int page = 1, int pageSize = 20);

        Task<ServerBase<StrategyList>> GetStrategyMenuListAsync(int gameId);
    }
}