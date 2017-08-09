using System.Threading.Tasks;

namespace VGtime.Services
{
    public interface IUserService
    {
        Task UnfollowAsync(int targetId, int userId);
    }
}