using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using U148.Models;
using U148.Services;

namespace U148.Uwp.Data
{
    public class ArticleCollection : IncrementalLoadingCollectionBase<Article>
    {
        private readonly IArticleService _articleService;

        private readonly ArticleCategory _category;

        private readonly Action<Exception> _onError;

        private int _currentPage = 1;

        public ArticleCollection(IArticleService articleService, ArticleCategory category, Action<Exception> onError = null)
        {
            if (articleService == null)
            {
                throw new ArgumentNullException(nameof(articleService));
            }
            if (!Enum.IsDefined(typeof(ArticleCategory), category))
            {
                throw new ArgumentOutOfRangeException(nameof(category));
            }

            _articleService = articleService;
            _category = category;
            _onError = onError;
        }

        protected override async Task<uint> LoadMoreItemsAsync(uint count, CancellationToken cancellationToken)
        {
            if (IsLoading)
            {
                return 0;
            }

            IsLoading = true;
            try
            {
                var result = await _articleService.GetArticlesAsync(_category, _currentPage + 1);
                uint loadedCount = 0;
                if (result.ErrorCode == 0)
                {
                    var page = result.Data;
                    if (_currentPage == page.End)
                    {
                        HasMoreItems = false;
                    }
                    else
                    {
                        _currentPage = page.Next;
                    }

                    foreach (var article in page.Data)
                    {
                        if (this.All(temp => temp.Id != article.Id))
                        {
                            Add(article);
                            loadedCount++;
                        }
                    }
                }

                return loadedCount;
            }
            catch (Exception ex)
            {
                _onError?.Invoke(ex);

                HasMoreItems = false;

                return 0;
            }
            finally
            {
                IsLoading = false;
            }
        }

        protected override void OnRefresh()
        {
            base.OnRefresh();

            _currentPage = 1;
        }
    }
}