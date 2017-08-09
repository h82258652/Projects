using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VGtime.Models;

namespace VGtime.Services
{
    public class InitService : IInitService
    {
        public async Task AdAsync(string postId, int type, string channelId)
        {
            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/init/ad.json";
            if (type == 1)
            {
                if (postId == "0")
                {
                    url += $"?channelId={channelId}";
                }
            }
            else if (type == 2)
            {
                url += $"?postId={WebUtility.UrlEncode(postId)}";
            }
            if (url.Contains("?"))
            {
                url += $"&type={type}";
            }
            else
            {
                url += $"?type={type}";
            }
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
            }
        }

        public async Task<ServerBase<StartPic>> StartpicAsync()
        {
            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/init/startpic.json?type=2&versionName={WebUtility.UrlEncode(Constants.AppVersionName)}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ServerBase<StartPic>>(json);
            }
        }

        public async Task VersionAsync(string versionName, int channel)
        {
            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/init/version.json?versionName={WebUtility.UrlEncode(versionName)}&type=1&channel={channel}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
            }
        }
    }
}