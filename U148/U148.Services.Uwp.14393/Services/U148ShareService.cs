using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using MicroMsg.sdk;
using SoftwareKobo.Social.SinaWeibo;
using SoftwareKobo.Social.SinaWeibo.Models;

namespace U148.Services
{
    public class U148ShareService : IU148ShareService
    {
        public void ClearSinaWeiboAuthorization()
        {
            var client = new SinaWeiboClient(Constants.SinaWeiboAppKey, Constants.SinaWeiboAppSecret, Constants.SinaWeiboRedirectUri);
            client.ClearAuthorization();
        }

        public async Task ShareToQQAsync(string url, string title, string summary)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            var builder = new StringBuilder();
            builder.Append("http://connect.qq.com/widget/shareqq/index.html?url=");
            builder.Append(WebUtility.UrlEncode(url));
            if (title != null)
            {
                builder.Append("&title=");
                builder.Append(WebUtility.UrlEncode(title));
            }
            if (summary != null)
            {
                builder.Append("&summary=");
                builder.Append(WebUtility.UrlEncode(summary));
            }
            await Launcher.LaunchUriAsync(new Uri(builder.ToString()));
        }

        public async Task ShareToQZoneAsync(string url, string title, string summary)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            var builder = new StringBuilder();
            builder.Append("http://sns.qzone.qq.com/cgi-bin/qzshare/cgi_qzshare_onekey?url=");
            builder.Append(WebUtility.UrlEncode(url));
            if (title != null)
            {
                builder.Append("&title=");
                builder.Append(WebUtility.UrlEncode(title));
            }
            if (summary != null)
            {
                builder.Append("&summary=");
                builder.Append(WebUtility.UrlEncode(summary));
            }
            await Launcher.LaunchUriAsync(new Uri(builder.ToString()));
        }

        public async Task<ModelBase> ShareToSinaWeiboAsync(byte[] image, string text)
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            var client = new SinaWeiboClient(Constants.SinaWeiboAppKey, Constants.SinaWeiboAppSecret, Constants.SinaWeiboRedirectUri);
            return await client.ShareAsync(text, image);
        }

        public async Task ShareToWechatAsync(string url, string title, string summary)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            const int scene = SendMessageToWX.Req.WXSceneChooseByUser;
            var message = new WXWebpageMessage()
            {
                WebpageUrl = url,
                Title = title,
                Description = summary
            };
            var req = new SendMessageToWX.Req(message, scene);
            var api = WXAPIFactory.CreateWXAPI(Constants.WechatAppId);
            var isValid = await api.SendReq(req);
        }
    }
}