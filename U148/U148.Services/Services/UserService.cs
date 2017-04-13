using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using U148.Models;

namespace U148.Services
{
    public class UserService : IUserService
    {
        public async Task<ResultBase> AddFavoriteAsync(int id, string token)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            var url = $"{Constants.UrlBase}/json/favourite?id={id}&token={token}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ResultBase>(json);
            }
        }

        public async Task<ResultBase> DeleteFavoriteAsync(int id, string token)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            var url = $"{Constants.UrlBase}/json/del_favourite?id={id}&token={token}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ResultBase>(json);
            }
        }

        public virtual async Task<ResultBase<Page<FavoriteArticle>>> GetFavoritesAsync(string token, int page = 1)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }
            if (page < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(page));
            }

            var url = $"{Constants.UrlBase}/json/get_favourite/0/{page}?token={token}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ResultBase<Page<FavoriteArticle>>>(json);
            }
        }

        public async Task<ResultBase<UserInfo>> LoginAsync(string email, string password)
        {
            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            var postData = new Dictionary<string, string>()
            {
                ["email"] = email,
                ["password"] = password
            };

            var url = $"{Constants.UrlBase}/json/login";
            using (var client = new HttpClient())
            {
                using (var postContent = new FormUrlEncodedContent(postData))
                {
                    var response = await client.PostAsync(url, postContent);
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResultBase<UserInfo>>(json);
                }
            }
        }

        public async Task<ResultBase<UserInfo>> RegisterAsync(string email, string password, string nickname)
        {
            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }
            if (nickname == null)
            {
                throw new ArgumentNullException(nameof(nickname));
            }

            var postData = new Dictionary<string, string>()
            {
                ["email"] = email,
                ["password"] = password,
                ["nickname"] = nickname,
                ["client"] = "android"
            };

            var url = $"{Constants.UrlBase}/json/register";
            using (var client = new HttpClient())
            {
                using (var postContent = new FormUrlEncodedContent(postData))
                {
                    var response = await client.PostAsync(url, postContent);
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResultBase<UserInfo>>(json);
                }
            }
        }
    }
}