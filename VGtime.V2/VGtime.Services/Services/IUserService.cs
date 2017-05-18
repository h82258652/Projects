using System.Threading.Tasks;
using VGtime.Models;
using VGtime.Models.Users;

namespace VGtime.Services
{
    public interface IUserService
    {
        Task<ServerBase<UserBase>> GetUserInfoAsync(int userId, string token);

        Task<ServerBase<UserBase>> LoginAsync(string account, string password);
    }
}