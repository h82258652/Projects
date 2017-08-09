using System.Threading.Tasks;

namespace VGtime.Services
{
    public interface IVoteService
    {
        Task VoteAsync(int objectId, int userId, string item);
    }
}