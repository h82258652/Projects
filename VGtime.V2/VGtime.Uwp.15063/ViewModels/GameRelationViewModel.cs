using GalaSoft.MvvmLight;
using VGtime.Services;
using VGtime.Uwp.Data;

namespace VGtime.Uwp.ViewModels
{
    public class GameRelationViewModel : ViewModelBase
    {
        private readonly IGameService _gameService;

        private GameRelationCollection _gameRelations;

        public GameRelationViewModel(IGameService gameService)
        {
            _gameService = gameService;
        }

        public int GameId
        {
            get;
            private set;
        }

        public GameRelationCollection GameRelations
        {
            get
            {
                return _gameRelations;
            }
            private set
            {
                Set(ref _gameRelations, value);
            }
        }

        public void LoadGameRelations(int gameId, int type)
        {
            GameId = gameId;
            GameRelations = new GameRelationCollection(gameId, type, _gameService);
        }
    }
}