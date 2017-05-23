using System.Threading.Tasks;

namespace SoftwareKobo.Controls
{
    public partial interface IImageLoader
    {
        long CalculateCacheSize();

        bool ContainsCache(string source);

        Task DeleteAllCacheAsync();

        Task<bool> DeleteCacheAsync(string source);

        Task<byte[]> GetBytesAsync(string source);

        string GetCacheFilePath(string source);
    }
}