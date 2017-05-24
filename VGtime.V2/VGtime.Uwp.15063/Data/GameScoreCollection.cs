using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VGtime.Models.Games;
using VGtime.Services;

namespace VGtime.Uwp.Data
{
    public class GameScoreCollection : IncrementalLoadingCollectionBase<GameScore>
    {
        private readonly int _gameId;

        private readonly IGameService _gameService;

        private readonly Action<Exception> _onError;

        public GameScoreCollection(int gameId, IGameService gameService, Action<Exception> onError = null)
        {
            if (gameService == null)
            {
                throw new ArgumentNullException(nameof(gameService));
            }

            _gameId = gameId;
            _gameService = gameService;
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

                var result = await _gameService.GetScoreListAsync(_gameId, CurrentPage + 1);
                uint loadedCount = 0;
                if (result.Retcode == Constants.SuccessCode)
                {
                    CurrentPage++;

                    var data = result.Data.Data;
                    if (data.Length > 0)
                    {
                        foreach (var gameScore in data)
                        {
                            if (this.All(temp => temp.User.UserId != gameScore.User.UserId))
                            {
                                Add(gameScore);
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