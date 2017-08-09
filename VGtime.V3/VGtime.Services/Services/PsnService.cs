using System.Net.Http;
using System.Threading.Tasks;

namespace VGtime.Services
{
    public class PsnService : IPsnService
    {
        public async Task GamesAsync(int page, int pageSize, int dataId)
        {
            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/psn/games";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
            }

            throw new System.NotImplementedException();
        }
    }
}