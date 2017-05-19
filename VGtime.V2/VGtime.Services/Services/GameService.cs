using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VGtime.Models;
using VGtime.Models.Games;

namespace VGtime.Services
{
    public class GameService : IGameService
    {
        public async Task<ServerBase<AlbumList>> GetAlbumListAsync(int gameId)
        {
            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/game/ablumlist.json?gameId={gameId}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ServerBase<AlbumList>>(json, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
        }

        public async Task<ServerBase<GameData>> GetDetailAsync(int gameId, int? userId = null)
        {
            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/game/detail.json?gameId={gameId}";
            if (userId.HasValue)
            {
                url = url + $"&userId={userId}";
            }
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ServerBase<GameData>>(json, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
        }

        public async Task<ServerBase<GameList>> GetScoreListAsync(int gameId, int page = 1, int pageSize = 20)
        {
            if (page <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(page));
            }
            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/game/scorelist.json?gameId={gameId}&page={page}&pageSize={pageSize}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ServerBase<GameList>>(json, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
        }

        public async Task<ServerBase<StrategyList>> GetStrategyMenuListAsync(int gameId)
        {
            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/strategy/gameMenuList.json?gameId={gameId}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ServerBase<StrategyList>>(json);
            }
        }

        public async Task<ServerBase<SearchList<GameBase>>> SearchAsync(string text, int? userId = null, int page = 1, int pageSize = 20)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            if (page <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(page));
            }
            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/search.json?text={WebUtility.UrlEncode(text)}&type=2&contentType=4&page={page}&pageSize={pageSize}";
            if (userId.HasValue)
            {
                url = url + $"&userId={userId}";
            }
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ServerBase<SearchList<GameBase>>>(json, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
        }
    }
}