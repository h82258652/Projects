using System;
using SoftwareKobo.Social.SinaWeibo;

namespace U148.Services
{
    public class U148ShareService : IU148ShareService
    {
        public void ClearAuthorization()
        {
            var client = new SinaWeiboClient(Constants.SinaWeiboAppKey, Constants.SinaWeiboAppSecret, Constants.SinaWeiboRedirectUri);
            client.ClearAuthorization();
        }
    }
}