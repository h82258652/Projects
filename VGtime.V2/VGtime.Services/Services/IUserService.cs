using System.Threading.Tasks;
using VGtime.Models;
using VGtime.Models.Users;

namespace VGtime.Services
{
    public interface IUserService
    {
        Task<ServerBase<object>> GetCodeAsync(string account, int type);

        Task<ServerBase<UserBase>> GetUserInfoAsync(int userId, string token);

        Task<ServerBase<UserBase>> LoginAsync(string account, string password);

        Task<ServerBase<object>> RegisterAsync(string account, string password, string code);

        Task<ServerBase<SearchList<UserBase>>> SearchAsync(string text, int? userId = null, int page = 1, int pageSize = 20);

        Task<ServerBase<object>> VerifyCodeAsync(string account, string code);
    }
}