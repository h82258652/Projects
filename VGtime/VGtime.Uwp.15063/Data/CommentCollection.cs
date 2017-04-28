using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using VGtime.Models;
using VGtime.Services;

namespace VGtime.Uwp.Data
{
    public class CommentCollection : IncrementalLoadingCollectionBase<Post>
    {
        private readonly Action<Exception> _onError;

        private readonly int _postId;

        private readonly IPostService _postService;

        private int _currentPage;

        public CommentCollection(int postId, IPostService postService, Action<Exception> onError = null)
        {
            if (postService == null)
            {
                throw new ArgumentNullException(nameof(postService));
            }

            _postId = postId;
            _postService = postService;
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
                var result = await _postService.GetCommentListAsync(_postId, 1, _currentPage + 1);
                uint loadedCount = 0;
                if (result.ErrorCode == HttpStatusCode.OK)
                {
                    _currentPage++;

                    var data = result.Data.Data;
                    if (data.Length > 0)
                    {
                        foreach (var post in data)
                        {
                            if (this.All(temp => temp.PostId != post.PostId))
                            {
                                Add(post);
                                loadedCount++;
                            }
                        }
                    }
                    else
                    {
                        HasMoreItems = false;
                    }
                }

                return loadedCount;
            }
            catch (Exception ex)
            {
                _onError?.Invoke(ex);

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