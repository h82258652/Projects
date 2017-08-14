using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VGtime.Models;
using VGtime.Models.Games;

namespace VGtime.Services
{
    public class GameService : IGameService
    {
        public async Task<ServerBase<Ablumlist>> AblumlistAsync(int gameId)
        {
            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/game/ablumlist.json?gameId={gameId}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ServerBase<Ablumlist>>(json, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
        }

        public async Task CancelplayAsync(int gameId, int userId)
        {
            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/game/cancelplay.json?gameId={gameId}&userId={userId}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
            }

            throw new System.NotImplementedException();
        }

        public async Task DetailAsync(int gameId, int? userId)
        {
            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/game/detail.json?gameId={gameId}";
            if (userId.HasValue)
            {
                url += $"&userId={userId}";
            }
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
            }
        }

        public Task PlayAsync(string content, int gameId, int score, int type, int userId)
        {
            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/game/play.json";

            //public static void a(String content, int gameId, int score, int type, int userId, Handler handler, int what)
            //{
            //    Map<String, String> map = new HashMap();
            //    map.put("content", content);
            //    map.put(h.q, String.valueOf(gameId));
            //    if (score != 0)
            //    {
            //        map.put("score", String.valueOf(score));
            //    }
            //    map.put("type", String.valueOf(type));
            //    map.put("userId", String.valueOf(userId));
            //    d.a(c.aa, map, handler, what);
            //}
            throw new System.NotImplementedException();
        }
    }
}