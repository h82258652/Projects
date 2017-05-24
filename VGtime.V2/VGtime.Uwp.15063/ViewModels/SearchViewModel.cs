using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using VGtime.Configuration;
using VGtime.Models.Games;
using VGtime.Services;
using VGtime.Uwp.Data;
using VGtime.Uwp.Services;

namespace VGtime.Uwp.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly IGameService _gameService;

        private readonly INavigationService _navigationService;

        private readonly IPostService _postService;

        private readonly IUserService _userService;

        private readonly IVGtimeSettings _vgtimeSettings;

        private SearchArticleCollection _articles;

        private RelayCommand<GameBase> _gameClickCommand;

        private SearchGameCollection _games;

        private RelayCommand<string> _searchCommand;

        private SearchUserCollection _users;

        public SearchViewModel(IPostService postService, IUserService userService, IGameService gameService, IVGtimeSettings vgtimeSettings, INavigationService navigationService, IAppToastService appToastService)
        {
            _postService = postService;
            _userService = userService;
            _gameService = gameService;
            _vgtimeSettings = vgtimeSettings;
            _navigationService = navigationService;
            _appToastService = appToastService;
        }

        public SearchArticleCollection Articles
        {
            get
            {
                return _articles;
            }
            private set
            {
                Set(ref _articles, value);
            }
        }

        public RelayCommand<GameBase> GameClickCommand
        {
            get
            {
                _gameClickCommand = _gameClickCommand ?? new RelayCommand<GameBase>(game =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.GameDetailViewKey, null);
                });
                return _gameClickCommand;
            }
        }

        public SearchGameCollection Games
        {
            get
            {
                return _games;
            }
            private set
            {
                Set(ref _games, value);
            }
        }

        public RelayCommand<string> SearchCommand
        {
            get
            {
                _searchCommand = _searchCommand ?? new RelayCommand<string>(text =>
                {
                    text = text?.Trim();
                    if (string.IsNullOrEmpty(text))
                    {
                        _appToastService.ShowWarning("搜索内容为空哦");
                    }
                    else
                    {
                        Articles = new SearchArticleCollection(text, _postService, _vgtimeSettings);
                        Users = new SearchUserCollection(text, _userService, _vgtimeSettings);
                        Games = new SearchGameCollection(text, _gameService, _vgtimeSettings);
                    }
                });
                return _searchCommand;
            }
        }

        public SearchUserCollection Users
        {
            get
            {
                return _users;
            }
            private set
            {
                Set(ref _users, value);
            }
        }
    }
}