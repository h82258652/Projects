using System.Threading.Tasks;

namespace U148.Services
{
    public interface IServiceWithCache
    {
        long CalculateCacheSize();

        Task DeleteAllCacheAsync();

        string GetCacheFolderPath();
    }
}