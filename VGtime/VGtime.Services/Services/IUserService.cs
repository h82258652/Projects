using System.Threading.Tasks;
using VGtime.Models;

namespace VGtime.Services
{
    public interface IUserService
    {
        Task<ResultBase<UserInfo>> GetUserInfoAsync(int userId, string token);

        Task<ResultBase<UserInfo>> LoginAsync(string account, string password);

        Task<ResultBase<SearchList<UserBase>>> SearchUserAsync(string text, int page = 1, int pageSize = 20);
    }
}