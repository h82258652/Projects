using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VGtime.Models;
using VGtime.Utils;

namespace VGtime.Services
{
    public class UserService : IUserService
    {
        public async Task<ResultBase<UserInfo>> GetUserInfoAsync(int userId, string token)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.UrlBase}/vgtime-app/api/v2/common/getUserInfo.json?userId={userId}&token={token}");
                return JsonConvert.DeserializeObject<ResultBase<UserInfo>>(json);
            }
        }

        public async Task<ResultBase<UserInfo>> LoginAsync(string account, string password)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            var postData = new Dictionary<string, string>()
            {
                ["account"] = account
            };
            var passwordAes = EncryptHelper.AesEncryptString(password, Constants.AESEncryptKey);
            var passwordBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(passwordAes + "\n"));
            postData["password"] = passwordBase64;

            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/common/login.json";
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

        public async Task<ResultBase<SearchList<User>>> SearchUserAsync(string text, int page = 1, int pageSize = 20)
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

            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/search.json?text={text}&type=1&page={page}&pageSize={pageSize}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ResultBase<SearchList<User>>>(json);
            }
        }
    }
}