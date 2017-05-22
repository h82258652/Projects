using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VGtime.Models.Timeline;
using VGtime.Services;

namespace VGtime.Uwp.Data
{
    public class VglistPostCollection : IncrementalLoadingCollectionBase<TimeLineBase>
    {
        private readonly IHomeService _homeService;

        private readonly Action<Exception> _onError;

        public VglistPostCollection(IHomeService homeService, Action<Exception> onError = null)
        {
            if (homeService == null)
            {
                throw new ArgumentNullException(nameof(homeService));
            }

            _homeService = homeService;
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
                var result = await _homeService.GetVglistAsync(CurrentPage + 1);
                uint loadedCount = 0;
                if (result.Retcode == Constants.SuccessCode)
                {
                    CurrentPage++;

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
    }
}