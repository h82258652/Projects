using System;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using VGtime.Configuration;
using VGtime.Models.Games;
using VGtime.Models.Timeline;
using VGtime.Models.Users;
using VGtime.Services;
using VGtime.Uwp.Data;
using VGtime.Uwp.Services;
using VGtime.Uwp.ViewParameters;

namespace VGtime.Uwp.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly IGameService _gameService;

        private readonly IInitService _initService;

        private readonly INavigationService _navigationService;

        private readonly IPostService _postService;

        private readonly IUserService _userService;

        private readonly IVGtimeSettings _vgtimeSettings;

        private RelayCommand<TimeLineBase> _articleClickCommand;

        private SearchArticleCollection _articles;

        private SearchForumCollection _forums;

        private RelayCommand<GameBase> _gameClickCommand;

        private SearchGameCollection _games;

        private string[] _hotword;

        private bool _isLoadingHotword;

        private RelayCommand<string> _searchCommand;

        private RelayCommand<UserBase> _userClickCommand;

        private SearchUserCollection _users;

        public SearchViewModel(IInitService initService,
            IPostService postService,
            IUserService userService,
            IGameService gameService,
            IVGtimeSettings vgtimeSettings,
            INavigationService navigationService,
            IAppToastService appToastService)
        {
            _initService = initService;
            _postService = postService;
            _userService = userService;
            _gameService = gameService;
            _vgtimeSettings = vgtimeSettings;
            _navigationService = navigationService;
            _appToastService = appToastService;

            LoadHotword();
        }

        public RelayCommand<TimeLineBase> ArticleClickCommand
        {
            get
            {
                _articleClickCommand = _articleClickCommand ?? new RelayCommand<TimeLineBase>(article =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.ArticleDetailViewKey, new ArticleDetailViewParameter(article.PostId, article.DetailType));
                });
                return _articleClickCommand;
            }
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

        public SearchForumCollection Forums
        {
            get
            {
                return _forums;
            }
            private set
            {
                Set(ref _forums, value);
            }
        }

        public RelayCommand<GameBase> GameClickCommand
        {
            get
            {
                _gameClickCommand = _gameClickCommand ?? new RelayCommand<GameBase>(game =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.GameDetailViewKey, game.GameId);
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

        public string[] Hotword
        {
            get
            {
                return _hotword;
            }
            private set
            {
                Set(ref _hotword, value);
            }
        }

        public bool IsLoadingHotword
        {
            get
            {
                return _isLoadingHotword;
            }
            private set
            {
                Set(ref _isLoadingHotword, value);
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
                        Forums = new SearchForumCollection(text, _postService, _vgtimeSettings);
                        Users = new SearchUserCollection(text, _userService, _vgtimeSettings);
                        Games = new SearchGameCollection(text, _gameService, _vgtimeSettings);
                    }
                });
                return _searchCommand;
            }
        }

        public RelayCommand<UserBase> UserClickCommand
        {
            get
            {
                _userClickCommand = _userClickCommand ?? new RelayCommand<UserBase>(user =>
                {
                    // TODO in next version.
                });
                return _userClickCommand;
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

        private async void LoadHotword()
        {
            while (true)
            {
                try
                {
                    IsLoadingHotword = true;

                    var result = await _initService.GetHotwordAsync();
                    if (result.Retcode == Constants.SuccessCode)
                    {
                        Hotword = result.Data.Data.Select(temp => temp.Keyword).ToArray();
                        break;
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
                finally
                {
                    IsLoadingHotword = false;
                }

                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }
    }
}