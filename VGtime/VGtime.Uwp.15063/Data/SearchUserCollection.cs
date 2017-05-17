using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using VGtime.Models;
using VGtime.Services;

namespace VGtime.Uwp.Data
{
    public class SearchUserCollection : IncrementalLoadingCollectionBase<User>
    {
        private readonly Action<Exception> _onError;

        private readonly IUserService _userService;

        private readonly string _text;

        private int _currentPage;

        public SearchUserCollection(string text, IUserService userService, Action<Exception> onError = null)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            _text = text;
            _userService = userService;
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
                var result = await _userService.SearchUserAsync(_text, _currentPage + 1);
                uint loadedCount = 0;
                if (result.ErrorCode == HttpStatusCode.OK)
                {
                    _currentPage++;

                    var data = result.Data.Data;
                    if (data.Length > 0)
                    {
                        foreach (var user in data)
                        {
                            if (this.All(temp => temp.UserId != user.UserId))
                            {
                                Add(user);
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