using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VGtime.Models;

namespace VGtime.Services
{
    public class PostService : IPostService
    {
        public async Task<ResultBase<AdData>> GetAdAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/init/ad.json?channelId=1&type=1");
                return JsonConvert.DeserializeObject<ResultBase<AdData>>(json);
            }
        }

        public async Task<ResultBase<CommentList>> GetCommentListAsync(int postId, int type, int page = 1, int pageSize = 20)
        {
            if (page <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(page));
            }
            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/post/commentList.json?postId={postId}&type={type}&page={page}&pageSize={pageSize}");
                return JsonConvert.DeserializeObject<ResultBase<CommentList>>(json);
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

        public async Task<ResultBase<PostStatusData>> GetDetailStatusAsync(int postId, int type)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/post/detailStatus.json?postId={postId}&type={type}");
                return JsonConvert.DeserializeObject<ResultBase<PostStatusData>>(json);
            }
        }

        public async Task<ResultBase<HeadPicList>> GetHeadPicAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/homepage/headpic.json");
                return JsonConvert.DeserializeObject<ResultBase<HeadPicList>>(json);
            }
        }

        public async Task<ResultBase<KeywordList>> GetHotwordAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/hotword.json");
                return JsonConvert.DeserializeObject<ResultBase<KeywordList>>(json);
            }
        }

        public async Task<ResultBase<PushList>> GetListAsync(int page = 1)
        {
            if (page <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(page));
            }

            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/homepage/vglist.json?page={page}");
                return JsonConvert.DeserializeObject<ResultBase<PushList>>(json);
            }
        }

        public async Task<ResultBase<TopicList>> GetListByTagAsync(int tags, int page = 1, int pageSize = 20)
        {
            if (page <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(page));
            }
            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/homepage/listByTag.json?tags={tags}&page={page}&pageSize={pageSize}");
                return JsonConvert.DeserializeObject<ResultBase<TopicList>>(json);
            }
        }

        public async Task<ResultBase<StartPicture>> GetStartPicAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/init/startpic.json?type=2&versionName=2.0.8");
                return JsonConvert.DeserializeObject<ResultBase<StartPicture>>(json);
            }
        }

        public async Task<ResultBase<VersionData>> GetVersionAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/init/version.json?type=1&versionName=2.0.8");
                return JsonConvert.DeserializeObject<ResultBase<VersionData>>(json);
            }
        }

        public async Task<ResultBase<SearchList<Post>>> SearchAsync(string text, int type, int? typeTag = null, int page = 1, int pageSize = 20)
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

            var urlBuilder = new StringBuilder();
            urlBuilder.Append($"{Constants.UrlBase}/vgtime-app/api/v2/search.json?text={text}&type={type}");
            if (typeTag.HasValue)
            {
                urlBuilder.Append($"&typeTag={typeTag.Value}");
            }
            urlBuilder.Append($"&page={page}&pageSize={pageSize}");
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(urlBuilder.ToString());
                return JsonConvert.DeserializeObject<ResultBase<SearchList<Post>>>(json);
            }
        }

        public async Task<ResultBase<SearchList<Game>>> SearchGameAsync(string text, int type, int contentType, int page = 1, int pageSize = 20)
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

            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/search.json?text={text}&type={type}&contentType={contentType}&page={page}&pageSize={pageSize}");
                return JsonConvert.DeserializeObject<ResultBase<SearchList<Game>>>(json);
            }
        }

        public async Task<ResultBase<SearchList<User>>> SearchUserAsync(string text, int type, int page = 1, int pageSize = 20)
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

            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/search.json?text={text}&type={type}&page={page}&pageSize={pageSize}");
                return JsonConvert.DeserializeObject<ResultBase<SearchList<User>>>(json);
            }
        }
    }
}