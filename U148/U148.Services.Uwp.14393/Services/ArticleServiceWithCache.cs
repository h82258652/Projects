using System;
using System.Threading.Tasks;

namespace U148.Services
{
    public class ArticleServiceWithCache : ArticleService, IArticleServiceWithCache
    {
        public long CalculateCacheSize()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllCacheAsync()
        {
            throw new NotImplementedException();
        }

        public string GetCacheFolderPath()
        {
            throw new NotImplementedException();
        }
    }
}