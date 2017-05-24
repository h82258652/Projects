using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VGtime.Models;
using VGtime.Models.Timeline;

namespace VGtime.Services
{
    public class PostService : IPostService
    {
        public async Task<ServerBase<CommentList>> GetCommentListAsync(int postId, int type, int? userId = null, int page = 1, int pageSize = 20)
        {
            if (page <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(page));
            }
            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/post/commentList.json?postId={postId}&type={type}&page={page}&pageSize={pageSize}";
            if (userId.HasValue)
            {
                url = url + $"&userId={userId}";
            }
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ServerBase<CommentList>>(json, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
        }

        public async Task<ServerBase<PostDetail>> GetDetailAsync(int postId, int type, int? userId = null, int page = 1)
        {
            if (page <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(page));
            }

            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/post/detail.json?postId={postId}&type={type}&page={page}";
            if (userId.HasValue)
            {
                url = url + $"&userId={userId}";
            }
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ServerBase<PostDetail>>(json, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
        }

        public async Task<ServerBase<PostStatus>> GetDetailStatusAsync(int postId, int type, int? userId = null)
        {
            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/post/detailStatus.json?postId={postId}&type={type}";
            if (userId.HasValue)
            {
                url = url + $"&userId={userId}";
            }
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ServerBase<PostStatus>>(json);
            }
        }

        public async Task<ServerBase<SearchList<TimeLineBase>>> SearchArticleAsync(string text, int? userId = null, int page = 1, int pageSize = 20)
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

            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/search.json?text={WebUtility.UrlEncode(text)}&type=2&typeTag=2&page={page}&pageSize={pageSize}";
            if (userId.HasValue)
            {
                url = url + $"&userId={userId}";
            }
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ServerBase<SearchList<TimeLineBase>>>(json);
            }
        }

        public async Task<ServerBase<SearchList<TimeLineBase>>> SearchForumAsync(string text, int? userId = null, int page = 1, int pageSize = 20)
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

            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/search.json?text={WebUtility.UrlEncode(text)}&type=2&typeTag=3&page={page}&pageSize={pageSize}";
            if (userId.HasValue)
            {
                url = url + $"&userId={userId}";
            }
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ServerBase<SearchList<TimeLineBase>>>(json);
            }
        }
    }
}