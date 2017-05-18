using System.Threading.Tasks;
using VGtime.Models;

namespace VGtime.Services
{
    public interface IGameService
    {
        Task<ServerBase<object>> GetAlbumListAsync(int gameId);

        Task<ServerBase<GameData>> GetDetailAsync(int gameId, int? userId = null);
    }
}