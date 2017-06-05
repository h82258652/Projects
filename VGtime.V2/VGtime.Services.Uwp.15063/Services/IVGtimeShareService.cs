using System.Threading.Tasks;
using SoftwareKobo.Social.SinaWeibo.Models;

namespace VGtime.Services
{
    public interface IVGtimeShareService
    {
        Task<ModelBase> ShareToSinaWeiboAsync(string text, byte[] image);

        Task ShareToSystemAsync(string title, string text, string imageUrl);
    }
}