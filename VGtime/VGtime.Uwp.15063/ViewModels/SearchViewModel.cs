using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using VGtime.Models;
using VGtime.Services;
using VGtime.Uwp.Data;
using VGtime.Uwp.ViewModelParameters;

namespace VGtime.Uwp.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private readonly IPostService _postService;

        private SearchPostCollection _forumPosts;

        private RelayCommand<Game> _gameClickCommand;
        private SearchGameCollection _games;

        private RelayCommand<string> _searchCommand;

        private RelayCommand<Post> _topicPostClickCommand;

        private SearchPostCollection _topicPosts;

        private SearchUserCollection _users;

        public SearchViewModel(IPostService postService, INavigationService navigationService)
        {
            _postService = postService;
            _navigationService = navigationService;
        }

        public SearchPostCollection ForumPosts
        {
            get
            {
                return _forumPosts;
            }
            private set
            {
                Set(ref _forumPosts, value);
            }
        }

        public RelayCommand<Game> GameClickCommand
        {
            get
            {
                _gameClickCommand = _gameClickCommand ?? new RelayCommand<Game>(game =>
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

        public RelayCommand<string> SearchCommand
        {
            get
            {
                _searchCommand = _searchCommand ?? new RelayCommand<string>(text =>
                {
                    if (!string.IsNullOrEmpty(text))
                    {
                        TopicPosts = new SearchPostCollection(text, 2, 2, _postService);
                        ForumPosts = new SearchPostCollection(text, 2, 3, _postService);
                        Users = new SearchUserCollection(text, 1, _postService);
                        Games = new SearchGameCollection(text, 2, 4, _postService);
                    }
                });
                return _searchCommand;
            }
        }

        public RelayCommand<Post> TopicPostClickCommand
        {
            get
            {
                _topicPostClickCommand = _topicPostClickCommand ?? new RelayCommand<Post>(post =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.DetailViewKey, new DetailViewModelParameter(post.PostId, post.DetailType));
                });
                return _topicPostClickCommand;
            }
        }

        public SearchPostCollection TopicPosts
        {
            get
            {
                return _topicPosts;
            }
            private set
            {
                Set(ref _topicPosts, value);
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