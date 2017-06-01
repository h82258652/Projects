using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VGtime.Models;

namespace VGtime.Services
{
    public class InitService : IInitService
    {
        public async Task<ServerBase<KeywordList>> GetHotwordAsync()
        {
            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/hotword.json";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ServerBase<KeywordList>>(json);
            }
        }

        public async Task<ServerBase<StartPic>> GetStartpicAsync(string versionName)
        {
            if (versionName == null)
            {
                throw new ArgumentNullException(nameof(versionName));
            }

            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/init/startpic.json?type=2&versionName={versionName}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ServerBase<StartPic>>(json);
            }
        }

        public async Task<ServerBase<VersionData>> GetVersionAsync(string versionName, int channel)
        {
            if (versionName == null)
            {
                throw new ArgumentNullException(nameof(versionName));
            }

            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/init/version.json?versionName={versionName}&type=1&channel={channel}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ServerBase<VersionData>>(json);
            }
        }
    }
}