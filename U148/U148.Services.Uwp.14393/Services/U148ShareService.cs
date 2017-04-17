using System;
using System.Threading.Tasks;
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
    }
}