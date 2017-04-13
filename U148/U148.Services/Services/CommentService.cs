using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using U148.Models;

namespace U148.Services
{
    public class CommentService : ICommentService
    {
        public virtual async Task<ResultBase<Page<Comment>>> GetCommentsAsync(int id, int page = 1)
        {
            if (page < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(page));
            }

            var url = $"{Constants.UrlBase}/json/get_comment/{id}/{page}?t={DateTimeOffset.Now.ToUnixTimeMilliseconds()}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ResultBase<Page<Comment>>>(json);
            }
        }

        public async Task<ResultBase> SendCommentAsync(int id, string token, string content, SimulateDevice device = SimulateDevice.Android, int? reviewId = null)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }
            if (!Enum.IsDefined(typeof(SimulateDevice), device))
            {
                throw new ArgumentOutOfRangeException(nameof(device));
            }

            var postData = new Dictionary<string, string>()
            {
                ["id"] = id.ToString(),
                ["token"] = token
            };
            switch (device)
            {
                case SimulateDevice.Android:
                    postData["client"] = "android";
                    break;

                case SimulateDevice.IPhone:
                    postData["client"] = "iphone";
                    break;
            }
            postData["content"] = content;
            if (reviewId.HasValue)
            {
                postData["review_id"] = reviewId.Value.ToString();
            }

            var url = $"{Constants.UrlBase}/json/comment";
            using (var client = new HttpClient())
            {
                using (var postContent = new FormUrlEncodedContent(postData))
                {
                    var response = await client.PostAsync(url, postContent);
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResultBase>(json);
                }
            }
        }
    }
}