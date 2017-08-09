using System.Net.Http;
using System.Threading.Tasks;

namespace VGtime.Services
{
    public class UserService : IUserService
    {
        public async Task UnfollowAsync(int targetId, int userId)
        {
            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/user/unfollow.json?targetId={targetId}&userId={userId}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
            }
        }
    }
}