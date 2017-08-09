using System.Net.Http;
using System.Threading.Tasks;

namespace VGtime.Services
{
    public class VoteService : IVoteService
    {
        public async Task VoteAsync(int objectId, int userId, string item)
        {
            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/vote/vote.json";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
            }
        }
    }
}