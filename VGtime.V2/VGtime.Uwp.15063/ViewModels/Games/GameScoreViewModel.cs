using GalaSoft.MvvmLight;
using VGtime.Services;
using VGtime.Uwp.Data;

namespace VGtime.Uwp.ViewModels.Games
{
    public class GameScoreViewModel : ViewModelBase
    {
        private readonly IGameService _gameService;

        private GameScoreCollection _scores;

        public GameScoreViewModel(IGameService gameService)
        {
            _gameService = gameService;
        }

        public int GameId
        {
            get;
            private set;
        }

        public GameScoreCollection Scores
        {
            get
            {
                return _scores;
            }
            private set
            {
                Set(ref _scores, value);
            }
        }

        public void LoadScores(int gameId)
        {
            GameId = gameId;
            Scores = new GameScoreCollection(gameId, _gameService);
        }
    }
}