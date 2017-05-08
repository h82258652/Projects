﻿using AppStudio.Uwp.Commands;
using GalaSoft.MvvmLight;
using VGtime.Services;
using VGtime.Uwp.Data;

namespace VGtime.Uwp.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private readonly IPostService _postService;

        private SearchPostCollection _forumPosts;

        private SearchGameCollection _games;

        private RelayCommand<string> _searchCommand;

        private SearchPostCollection _topicPosts;

        private SearchUserCollection _users;

        public SearchViewModel(IPostService postService)
        {
            _postService = postService;
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