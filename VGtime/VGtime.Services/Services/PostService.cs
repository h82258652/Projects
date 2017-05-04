using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VGtime.Models;

namespace VGtime.Services
{
    public class PostService : IPostService
    {
        public async Task<ResultBase<object>> GetAdAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/init/ad.json");
                return JsonConvert.DeserializeObject<ResultBase<object>>(json);
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

        public async Task<ResultBase<PostStatus>> GetDetailStatusAsync(int postId, int type)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/post/detailStatus.json?postId={postId}&type={type}");
                return JsonConvert.DeserializeObject<ResultBase<PostStatus>>(json);
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

        public async Task<ResultBase<object>> GetStartPicAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/init/startpic.json");
                return JsonConvert.DeserializeObject<ResultBase<object>>(json);
            }
        }

        public async Task<ResultBase<object>> GetVersionAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/init/version.json");
                return JsonConvert.DeserializeObject<ResultBase<object>>(json);
            }
        }
    }
}