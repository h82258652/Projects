using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VGtime.Models;
using VGtime.Models.Users;
using VGtime.Utils;

namespace VGtime.Services
{
    public class UserService : IUserService
    {
        public async Task<ServerBase<UserBase>> GetUserInfoAsync(int userId, string token)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/common/getUserInfo.json?userId={userId}&token={token}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ServerBase<UserBase>>(json);
            }
        }

        public async Task<ServerBase<UserBase>> LoginAsync(string account, string password)
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
            var passwordAes = EncryptHelper.AesEncryptString(password, Constants.PasswordEncryptKey);
            var passwordBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(passwordAes + "\n"));
            postData["password"] = passwordBase64;

            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/common/login.json";
            using (var client = new HttpClient())
            {
                using (var postContent = new FormUrlEncodedContent(postData))
                {
                    var response = await client.PostAsync(url, postContent);
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ServerBase<UserBase>>(json);
                }
            }
        }
    }
}