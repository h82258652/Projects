using System.Net.Http;
using System.Threading.Tasks;

namespace VGtime.Services
{
    public class ActionService : IActionService
    {
        public async Task GameListAsync(int page, int pageSize, int targetId, int type, int? userId)
        {
            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/action/gameList.json?page={page}&pageSize={pageSize}&targetId={targetId}&type={type}";
            if (userId.HasValue)
            {
                url += $"&userId={userId}";
            }
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
            }
        }

        public async Task ReportAsync(int postId, int userId, int type)
        {
            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/action/report.json?postId={postId}&userId={userId}&type={type}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
            }
        }

        public async Task ShareAsync(int postId, int type, int userId)
        {
            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/action/share.json?postId={postId}";
            if (type != 0)
            {
                url += $"&type={type}";
            }
            url += $"&userId={userId}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
            }
        }
    }
}