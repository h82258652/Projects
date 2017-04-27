using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VGtime.Models;

namespace VGtime.Services
{
    public class PostService : IPostService
    {
        public async Task<ResultBase<CommentList>> GetCommentListAsync(int postId, int type, int page = 1)
        {
            if (page <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(page));
            }

            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/post/commentList.json?postId={postId}&type={type}&page={page}");
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

        public async Task<ResultBase<TopicList>> GetListByTagAsync(int tags)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/homepage/listByTag.json?tags={tags}");
                return JsonConvert.DeserializeObject<ResultBase<TopicList>>(json);
            }
        }
    }
}