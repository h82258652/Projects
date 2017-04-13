using System.Threading.Tasks;
using U148.Models;

namespace U148.Services
{
    public interface IUserService
    {
        Task<ResultBase> AddFavoriteAsync(int id, string token);

        Task<ResultBase> DeleteFavoriteAsync(int id, string token);

        Task<ResultBase<Page<FavoriteArticle>>> GetFavoritesAsync(string token, int page = 1);

        Task<ResultBase<UserInfo>> LoginAsync(string email, string password);

        Task<ResultBase<UserInfo>> RegisterAsync(string email, string password, string nickname);
    }
}