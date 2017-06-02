using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using VGtime.Configuration;
using VGtime.Models.Games;
using VGtime.Services;
using VGtime.Uwp.Services;
using VGtime.Uwp.ViewParameters;

namespace VGtime.Uwp.ViewModels.Games
{
    public class GameDetailViewModel : ViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly IGameService _gameService;

        private readonly INavigationService _navigationService;

        private readonly IVGtimeSettings _vgtimeSettings;

        private RelayCommand _forumCommand;

        private GameBase _gameDetail;

        private bool _isLoading;

        private RelayCommand _photoCommand;

        private RelayCommand _postCommand;

        private RelayCommand _questionCommand;

        private RelayCommand _scoreCommand;

        private RelayCommand _strategyCommand;

        public GameDetailViewModel(IGameService gameService, IVGtimeSettings vgtimeSettings, IAppToastService appToastService, INavigationService navigationService)
        {
            _gameService = gameService;
            _vgtimeSettings = vgtimeSettings;
            _appToastService = appToastService;
            _navigationService = navigationService;
        }

        public RelayCommand ForumCommand
        {
            get
            {
                _forumCommand = _forumCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.GameRelationViewKey, new GameRelationViewParameter(GameId, 1));
                });
                return _forumCommand;
            }
        }

        public GameBase GameDetail
        {
            get
            {
                return _gameDetail;
            }
            private set
            {
                Set(ref _gameDetail, value);
            }
        }

        public int GameId
        {
            get;
            private set;
        }

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            private set
            {
                Set(ref _isLoading, value);
            }
        }

        public RelayCommand PhotoCommand
        {
            get
            {
                _photoCommand = _photoCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.GamePhotoViewKey, new GamePhotoViewParameter(GameId, GameDetail.Title));
                });
                return _photoCommand;
            }
        }

        public RelayCommand PostCommand
        {
            get
            {
                _postCommand = _postCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.GameRelationViewKey, new GameRelationViewParameter(GameId, 2));
                });
                return _postCommand;
            }
        }

        public RelayCommand QuestionCommand
        {
            get
            {
                _questionCommand = _questionCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.GameRelationViewKey, new GameRelationViewParameter(GameId, 3));
                });
                return _questionCommand;
            }
        }

        public RelayCommand ScoreCommand
        {
            get
            {
                _scoreCommand = _scoreCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.GameScoreViewKey, GameId);
                });
                return _scoreCommand;
            }
        }

        public RelayCommand StrategyCommand
        {
            get
            {
                _strategyCommand = _strategyCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.GameStrategySetViewKey, GameId);
                });
                return _strategyCommand;
            }
        }

        public void LoadDetail(int gameId)
        {
            GameId = gameId;
            LoadDetail();
        }

        private async void LoadDetail()
        {
            if (IsLoading)
            {
                return;
            }

            try
            {
                IsLoading = true;

                var gameId = GameId;
                var result = await _gameService.GetDetailAsync(gameId, _vgtimeSettings.UserInfo?.UserId);
                if (gameId == GameId)
                {
                    if (result.Retcode == Constants.SuccessCode)
                    {
                        GameDetail = result.Data.Game;
                    }
                    else
                    {
                        _appToastService.ShowError(result.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                _appToastService.ShowError(ex.Message);
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}