using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using U148.Models;

namespace U148.Services
{
    public class ArticleService : IArticleService
    {
        public virtual async Task<ResultBase<ArticleDetail>> GetArticleDetailAsync(int id)
        {
            var url = $"{Constants.UrlBase}/json/article/{id}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ResultBase<ArticleDetail>>(json);
            }
        }

        public virtual async Task<ResultBase<Page<Article>>> GetArticlesAsync(ArticleCategory category, int page = 1)
        {
            if (!Enum.IsDefined(typeof(ArticleCategory), category))
            {
                throw new ArgumentOutOfRangeException(nameof(category));
            }
            if (page < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(page));
            }

            var url = $"{Constants.UrlBase}/json/{(int)category}/{page}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ResultBase<Page<Article>>>(json);
            }
        }

        public async Task<ResultBase<Page<Article>>> SearchAsync(string keyword, int page = 1)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException(nameof(keyword));
            }
            if (page < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(page));
            }

            var url = $"{Constants.UrlBase}/json/search/{page}?keyword={keyword}";
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<ResultBase<Page<Article>>>(json);
            }
        }
    }
}