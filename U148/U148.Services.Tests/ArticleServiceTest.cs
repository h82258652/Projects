using System.Threading.Tasks;
using NUnit.Framework;
using U148.Models;

namespace U148.Services.Tests
{
    [TestFixture]
    public class ArticleServiceTest
    {
        private IArticleService _articleService;

        [SetUp]
        public void SetUp()
        {
            _articleService = new ArticleService();
        }

        [Test]
        public async Task TestGetArticleDetailAsync()
        {
            var result = await _articleService.GetArticleDetailAsync(141135);
            Assert.AreEqual(result.ErrorCode, 0);
        }

        [Test]
        public async Task TestGetArticlesAsync()
        {
            var result = await _articleService.GetArticlesAsync(ArticleCategory.Home);
            Assert.AreEqual(result.ErrorCode, 0);
        }

        [Test]
        public async Task TestSearchAsync()
        {
            var result = await _articleService.SearchAsync(string.Empty);
            Assert.AreEqual(result.ErrorCode, 0);
        }
    }
}