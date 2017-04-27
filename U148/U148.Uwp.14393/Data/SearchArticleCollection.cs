using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using U148.Models;
using U148.Services;

namespace U148.Uwp.Data
{
    public class SearchArticleCollection : IncrementalLoadingCollectionBase<Article>
    {
        private readonly IArticleService _articleService;

        private readonly Action<Exception> _onError;

        private readonly string _query;

        private int _currentPage = 1;

        public SearchArticleCollection(IArticleService articleService, string query, Action<Exception> onError = null)
        {
            if (articleService == null)
            {
                throw new ArgumentNullException(nameof(articleService));
            }
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            _articleService = articleService;
            _query = query;
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
                var result = await _articleService.SearchAsync(_query, _currentPage);
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