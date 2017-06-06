using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using VGtime.Models.Timeline;
using VGtime.Services;
using VGtime.Uwp.Data;
using VGtime.Uwp.ViewParameters;

namespace VGtime.Uwp.ViewModels.Games
{
    public class GamePostViewModel : ViewModelBase
    {
        private readonly IGameService _gameService;

        private readonly INavigationService _navigationService;

        private RelayCommand<TimeLineBase> _postClickCommand;

        private GameRelationCollection _posts;

        public GamePostViewModel(IGameService gameService, INavigationService navigationService)
        {
            _gameService = gameService;
            _navigationService = navigationService;
        }

        public int GameId
        {
            get;
            private set;
        }

        public RelayCommand<TimeLineBase> PostClickCommand
        {
            get
            {
                _postClickCommand = _postClickCommand ?? new RelayCommand<TimeLineBase>(post =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.ArticleDetailViewKey, new ArticleDetailViewParameter(post.PostId, post.DetailType));
                });
                return _postClickCommand;
            }
        }

        public GameRelationCollection Posts
        {
            get
            {
                return _posts;
            }
            private set
            {
                Set(ref _posts, value);
            }
        }

        public void LoadPosts(int gameId)
        {
            GameId = gameId;
            Posts = new GameRelationCollection(gameId, 2, _gameService);
        }
    }
}