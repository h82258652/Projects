using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using VGtime.Configuration;
using VGtime.Models.Games;
using VGtime.Services;
using VGtime.Uwp.Data;

namespace VGtime.Uwp.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private readonly IGameService _gameService;

        private readonly IUserService _userService;

        private readonly IVGtimeSettings _vgtimeSettings;

        private RelayCommand<GameBase> _gameClickCommand;

        private SearchGameCollection _games;

        private RelayCommand<string> _searchCommand;

        private SearchUserCollection _users;

        public SearchViewModel(IUserService userService, IGameService gameService, IVGtimeSettings vgtimeSettings)
        {
            _userService = userService;
            _gameService = gameService;
            _vgtimeSettings = vgtimeSettings;
        }

        public RelayCommand<GameBase> GameClickCommand
        {
            get
            {
                _gameClickCommand = _gameClickCommand ?? new RelayCommand<GameBase>(game =>
                {
                    throw new NotImplementedException();
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
                    if (string.IsNullOrEmpty(text))
                    {
                        // TODO show toast
                        //"搜索内容为空哦"
                    }
                    else
                    {
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