using System;
using System.Net.Http;
using System.Threading.Tasks;
using BingoWallpaper.Models.Bing;
using Newtonsoft.Json;

namespace BingoWallpaper.Services
{
    public class BingService : IBingService
    {
        public async Task<BingResult> GetAsync(int daysAgo, int count, string area)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            if (area == null)
            {
                throw new ArgumentNullException(nameof(area));
            }
            if (area.Length <= 0)
            {
                // TODO
                throw new ArgumentException();
            }

            var url = $"{Constants.BingUrlBase}/hpimagearchive.aspx?format=js&idx={daysAgo}&n={count}&mkt={area}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<BingResult>(json);
            }
        }
    }
}