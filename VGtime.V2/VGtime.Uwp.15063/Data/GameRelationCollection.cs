using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VGtime.Models.Timeline;
using VGtime.Services;

namespace VGtime.Uwp.Data
{
    public class GameRelationCollection : IncrementalLoadingCollectionBase<TimeLineBase>
    {
        private readonly int _gameId;

        private readonly IGameService _gameService;

        private readonly Action<Exception> _onError;

        private readonly int _type;

        public GameRelationCollection(int gameId, int type, IGameService gameService, Action<Exception> onError = null)
        {
            if (gameService == null)
            {
                throw new ArgumentNullException(nameof(gameService));
            }

            _gameId = gameId;
            _type = type;
            _gameService = gameService;
            _onError = onError;
        }

        protected override async Task<uint> LoadMoreItemsAsync(uint count, CancellationToken cancellationToken)
        {
            try
            {
                IsLoading = true;

                var result = await _gameService.GetRelationListAsync(_gameId, _type, CurrentPage + 1);
                uint loadedCount = 0;
                if (result.Retcode == Constants.SuccessCode)
                {
                    CurrentPage++;

                    var data = result.Data.Data;
                    if (data.Length > 0)
                    {
                        foreach (var relation in data)
                        {
                            if (this.All(temp => temp.PostId != relation.PostId))
                            {
                                Add(relation);
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