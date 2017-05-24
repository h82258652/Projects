using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VGtime.Configuration;
using VGtime.Models.Timeline;
using VGtime.Services;

namespace VGtime.Uwp.Data
{
    public class SearchArticleCollection : IncrementalLoadingCollectionBase<TimeLineBase>
    {
        private readonly Action<Exception> _onError;

        private readonly IPostService _postService;

        private readonly string _text;

        private readonly IVGtimeSettings _vgtimeSettings;

        public SearchArticleCollection(string text, IPostService postService, IVGtimeSettings vgtimeSettings, Action<Exception> onError = null)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            if (postService == null)
            {
                throw new ArgumentNullException(nameof(postService));
            }
            if (vgtimeSettings == null)
            {
                throw new ArgumentNullException(nameof(vgtimeSettings));
            }

            _text = text;
            _postService = postService;
            _vgtimeSettings = vgtimeSettings;
            _onError = onError;
        }

        protected override async Task<uint> LoadMoreItemsAsync(uint count, CancellationToken cancellationToken)
        {
            if (IsLoading)
            {
                return 0;
            }

            try
            {
                IsLoading = true;

                var result = await _postService.SearchArticlesAsync(_text, _vgtimeSettings.UserInfo?.UserId, CurrentPage + 1);
                uint loadedCount = 0;
                if (result.Retcode == Constants.SuccessCode)
                {
                    CurrentPage++;

                    var data = result.Data.Data;
                    if (data.Length > 0)
                    {
                        foreach (var article in data)
                        {
                            if (this.All(temp => temp.PostId != article.PostId))
                            {
                                Add(article);
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
    }
}