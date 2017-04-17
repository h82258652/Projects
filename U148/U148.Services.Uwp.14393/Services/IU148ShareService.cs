using System.Threading.Tasks;
using SoftwareKobo.Social.SinaWeibo.Models;

namespace U148.Services
{
    public interface IU148ShareService
    {
        void ClearSinaWeiboAuthorization();

        Task<ModelBase> ShareToSinaWeiboAsync(byte[] image, string text);
    }
}