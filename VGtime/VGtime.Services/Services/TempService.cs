using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VGtime.Models;

namespace VGtime.Services
{
    public class TempService
    {
        public async Task<ResultBase<object>> GetCommentListAsync(int postId)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"http://app02.vgtime.com:8080/vgtime-app/api/v2/post/commentList.json?postId={postId}");
                return JsonConvert.DeserializeObject<ResultBase<object>>(json);
            }
        }

        public async Task<ResultBase<PostDetail>> GetDetailAsync(int postId, int type)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/post/detail.json?postId={postId}&type={type}");
                return JsonConvert.DeserializeObject<ResultBase<PostDetail>>(json);
            }
        }

        public async Task<ResultBase<object>> GetDetailStatusAsync(int postId, int type)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/post/detailStatus.json?postId={postId}&type={type}");
                return JsonConvert.DeserializeObject<ResultBase<object>>(json);
            }
        }

        public async Task<ResultBase<object>> GetHeadPicAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/homepage/headpic.json");
                return JsonConvert.DeserializeObject<ResultBase<object>>(json);
            }
        }

        public async Task<ResultBase<PushList<Temp>>> GetListAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/homepage/vglist.json");
                return JsonConvert.DeserializeObject<ResultBase<PushList<Temp>>>(json);
            }
        }

        public async Task<ResultBase<object>> GetListByTagAsync(int tags)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/homepage/listByTag.json?tags={tags}");
                return JsonConvert.DeserializeObject<ResultBase<object>>(json);
            }
        }
    }
}