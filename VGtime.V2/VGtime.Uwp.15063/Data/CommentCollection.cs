using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VGtime.Configuration;
using VGtime.Models.Timeline;
using VGtime.Services;

namespace VGtime.Uwp.Data
{
    public class CommentCollection : IncrementalLoadingCollectionBase<TimeLineBase>
    {
        private readonly Action<Exception> _onError;

        private readonly int _postId;

        private readonly IPostService _postService;

        private readonly int _type;

        private readonly IVGtimeSettings _vgtimeSettings;

        public CommentCollection(int postId, int type, IPostService postService, IVGtimeSettings vgtimeSettings, Action<Exception> onError = null)
        {
            if (postService == null)
            {
                throw new ArgumentNullException(nameof(postService));
            }
            if (vgtimeSettings == null)
            {
                throw new ArgumentNullException(nameof(vgtimeSettings));
            }

            _postId = postId;
            _type = type;
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

                var result = await _postService.GetCommentListAsync(_postId, _type, _vgtimeSettings.UserInfo?.UserId, CurrentPage + 1);
                uint loadedCount = 0;
                if (result.Retcode == Constants.SuccessCode)
                {
                    CurrentPage++;

                    var data = result.Data.Data;
                    if (data.Length > 0)
                    {
                        foreach (var comment in data)
                        {
                            if (this.All(temp => temp.PostId != comment.PostId))
                            {
                                Add(comment);
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