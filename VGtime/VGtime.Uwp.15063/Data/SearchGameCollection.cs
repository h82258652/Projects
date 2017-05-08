using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VGtime.Models;
using VGtime.Services;

namespace VGtime.Uwp.Data
{
    public class SearchGameCollection : IncrementalLoadingCollectionBase<Game>
    {
        private int _contentType;

        private int _currentPage;

        private Action<Exception> _onError;

        private IPostService _postService;

        private string _text;

        private int _type;

        public SearchGameCollection(string text, int type, int contentType, IPostService postService, Action<Exception> onError = null)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            _text = text;
            _type = type;
            _contentType = contentType;
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
                var result = await _postService.SearchGameAsync(_text, _type, _contentType, _currentPage + 1);
                uint loadedCount = 0;
                if (result.ErrorCode == HttpStatusCode.OK)
                {
                    _currentPage++;

                    var data = result.Data.Data;
                    if (data.Length > 0)
                    {
                        foreach (var game in data)
                        {
                            if (this.All(temp => temp.GameId != game.GameId))
                            {
                                Add(game);
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