using System;
using AppStudio.Uwp.Commands;
using GalaSoft.MvvmLight;
using VGtime.Services;
using VGtime.Uwp.Data;

namespace VGtime.Uwp.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private readonly IPostService _postService;

        private SearchPostCollection _forumPosts;

        private SearchPostCollection _gamePosts;

        private RelayCommand<string> _searchCommand;

        private SearchPostCollection _topicPosts;

        private SearchPostCollection _userPosts;

        public SearchViewModel(IPostService postService)
        {
            _postService = postService;
        }

        public SearchPostCollection ForumPosts
        {
            get
            {
                return _forumPosts
                    ;
            }
            private set
            {
                Set(ref _forumPosts, value);
            }
        }

        public SearchPostCollection GamePosts
        {
            get
            {
                return _gamePosts;
            }
            private set
            {
                Set(ref _gamePosts, value);
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
                        UserPosts = new SearchPostCollection(text, 1, null, _postService);
                        GamePosts = new SearchPostCollection(text, 2, null, _postService);
                    }
                });
                return _searchCommand;
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

        public SearchPostCollection UserPosts
        {
            get
            {
                return _userPosts;
            }
            private set
            {
                Set(ref _userPosts, value);
            }
        }
    }
}