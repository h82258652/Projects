using System.Threading.Tasks;
using U148.Models;

namespace U148.Services
{
    public interface IArticleService
    {
        Task<ResultBase<ArticleDetail>> GetArticleDetailAsync(int id);

        Task<ResultBase<Page<Article>>> GetArticlesAsync(ArticleCategory category, int page = 1);

        Task<ResultBase<Page<Article>>> SearchAsync(string keyword, int page = 1);
    }
}