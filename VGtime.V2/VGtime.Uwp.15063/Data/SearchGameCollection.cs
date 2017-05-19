using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VGtime.Configuration;
using VGtime.Models.Games;
using VGtime.Services;

namespace VGtime.Uwp.Data
{
    public class SearchGameCollection : IncrementalLoadingCollectionBase<GameBase>
    {
        private readonly IGameService _gameService;

        private readonly Action<Exception> _onError;

        private readonly string _text;

        private readonly IVGtimeSettings _vgtimeSettings;

        public SearchGameCollection(string text, IGameService gameService, IVGtimeSettings vgtimeSettings, Action<Exception> onError = null)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            if (gameService == null)
            {
                throw new ArgumentNullException(nameof(gameService));
            }
            if (vgtimeSettings == null)
            {
                throw new ArgumentNullException(nameof(vgtimeSettings));
            }

            _text = text;
            _gameService = gameService;
            _vgtimeSettings = vgtimeSettings;
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
                var result = await _gameService.SearchAsync(_text, _vgtimeSettings.UserInfo?.UserId, CurrentPage + 1);
                uint loadedCount = 0;
                if (result.Retcode == Constants.SuccessCode)
                {
                    CurrentPage++;

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
    }
}