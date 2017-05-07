using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using VGtime.Models;
using VGtime.Services;

namespace VGtime.Uwp.Data
{
    public class SearchPostCollection : IncrementalLoadingCollectionBase<Post>
    {
        private int _currentPage;

        private Action<Exception> _onError;

        private IPostService _postService;

        private string _text;

        private int _type;

        private int? _typeTag;

        public SearchPostCollection(string text, int type, int? typeTag, IPostService postService, Action<Exception> onError = null)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            _text = text;
            _type = type;
            _typeTag = typeTag;
            _postService = postService;
            _onError = onError;
        }

        protected async override Task<uint> LoadMoreItemsAsync(uint count, CancellationToken cancellationToken)
        {
            if (IsLoading)
            {
                return 0;
            }

            IsLoading = true;
            try
            {
                var result = await _postService.SearchAsync(_text, _type, _typeTag, _currentPage + 1);
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