using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VGtime.Utils;

namespace VGtime.Services
{
    public class CommonService : ICommonService
    {
        public async Task GetCodeAsync(string account, int type)
        {
            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/common/getCode.json?account={WebUtility.UrlEncode(account)}&type={type}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
            }
        }

        public async Task LoginAsync(string account, string password)
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
            var passwordBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Concat(passwordAes, "\n")));
            postData["password"] = passwordBase64;

            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/common/login.json";
            using (var client = new HttpClient())
            {
                using (var postContent = new FormUrlEncodedContent(postData))
                {
                    var response = await client.PostAsync(url, postContent);
                    var json = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task RegisterAsync(string account, string password, string code)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }
            if (code == null)
            {
                throw new ArgumentNullException(nameof(code));
            }

            var postData = new Dictionary<string, string>()
            {
                ["account"] = account
            };
            var passwordAes = EncryptHelper.AesEncryptString(password, Constants.PasswordEncryptKey);
            var passwordBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Concat(passwordAes, "\n")));
            postData["password"] = passwordBase64;
            postData["code"] = code;

            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/common/register.json";
            using (var client = new HttpClient())
            {
                using (var postContent = new FormUrlEncodedContent(postData))
                {
                    var response = await client.PostAsync(url, postContent);
                    var json = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task ResetPasswordAsync(string account, string password)
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
            var passwordBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Concat(passwordAes, "\n")));
            postData["password"] = passwordBase64;

            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/common/resetPassword.json";
            using (var client = new HttpClient())
            {
                using (var postContent = new FormUrlEncodedContent(postData))
                {
                    var json = await client.PostAsync(url, postContent);
                }
            }
        }

        public async Task VerifyCodeAsync(string account, string code)
        {
            var url = $"{Constants.UrlBase}/vgtime-app/api/v2/common/verifyCode.json";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
            }
        }
    }
}