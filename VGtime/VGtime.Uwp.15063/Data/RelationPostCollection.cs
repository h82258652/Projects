using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using VGtime.Models;
using VGtime.Services;

namespace VGtime.Uwp.Data
{
    public class RelationPostCollection : IncrementalLoadingCollectionBase<Post>
    {
        private readonly int _gameId;

        private readonly Action<Exception> _onError;

        private readonly IPostService _postService;

        private readonly int _type;

        private int _currentPage;

        public RelationPostCollection(int gameId, int type, IPostService postService, Action<Exception> onError = null)
        {
            _gameId = gameId;
            _type = type;
            _postService = postService;
            _onError = onError;
        }

        protected override async Task<uint> LoadMoreItemsAsync(uint count, CancellationToken cancellationToken)
        {
            IsLoading = true;
            try
            {
                var result = await _postService.GetRelationListAsync(_gameId, _type, _currentPage++);
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