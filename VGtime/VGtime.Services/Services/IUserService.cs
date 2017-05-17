using System.Threading.Tasks;
using VGtime.Models;

namespace VGtime.Services
{
    public interface IUserService
    {
        Task<ResultBase<UserInfo>> LoginAsync(string account, string password);
    }
}