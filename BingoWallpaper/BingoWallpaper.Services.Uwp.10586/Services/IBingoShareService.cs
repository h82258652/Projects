using System.Threading.Tasks;

namespace BingoWallpaper.Services
{
    public interface IBingoShareService
    {
        void ClearAuthorization();

        Task<bool> ShareToSinaWeiboAsync(byte[] image, string text);

        Task ShareToSystemAsync(string imageUrl, string text);

        Task ShareToWechatAsync(byte[] image, string text);
    }
}