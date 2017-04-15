using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using U148.Models;
using U148.Services;

namespace U148.Uwp.Data
{
    public class CommentCollection : IncrementalLoadingCollectionBase<Comment>
    {
        private readonly int _articleId;

        private readonly ICommentService _commentService;

        private readonly Action<Exception> _onError;

        private int _currentPage;

        public CommentCollection(ICommentService commentService, int articleId, Action<Exception> onError = null)
        {
            if (commentService == null)
            {
                throw new ArgumentNullException(nameof(commentService));
            }

            _commentService = commentService;
            _articleId = articleId;
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
                var result = await _commentService.GetCommentsAsync(_articleId, _currentPage);
                uint loadedCount = 0;
                if (result.ErrorCode == 0)
                {
                    _currentPage++;

                    foreach (var comment in result.Data.Data)
                    {
                        if (this.All(temp => temp.Id != comment.Id))
                        {
                            Add(comment);
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

            _currentPage = 0;
        }
    }
}