using System.Threading.Tasks;
using SoftwareKobo.Social.SinaWeibo.Models;

namespace U148.Services
{
    public interface IU148ShareService
    {
        void ClearSinaWeiboAuthorization();

        Task ShareToQQAsync(string url, string title, string summary);

        Task ShareToQZoneAsync(string url, string title, string summary);

        Task<ModelBase> ShareToSinaWeiboAsync(byte[] image, string text);

        Task ShareToWechatAsync(string url, string title, string summary);
    }
}