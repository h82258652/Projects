using System;
using System.Net;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SoftwareKobo.ViewModels;
using VGtime.Models;
using VGtime.Services;
using VGtime.Uwp.Services;
using VGtime.Uwp.ViewParameters;

namespace VGtime.Uwp.ViewModels
{
    public class GameDetailViewModel : ViewModelBase, INavigable
    {
        private readonly IAppToastService _appToastService;

        private readonly INavigationService _navigationService;

        private readonly IPostService _postService;

        private RelayCommand _albumCommand;

        private RelayCommand _forumCommand;

        private GameBase _gameDetail;

        private int _gameId;

        private bool _isLoading;

        private RelayCommand _postCommand;

        private RelayCommand _questionCommand;

        private RelayCommand _scoreCommand;

        private RelayCommand _strategyCommand;

        public GameDetailViewModel(IPostService postService, IAppToastService appToastService, INavigationService navigationService)
        {
            _postService = postService;
            _appToastService = appToastService;
            _navigationService = navigationService;
        }

        public RelayCommand AlbumCommand
        {
            get
            {
                _albumCommand = _albumCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.AblumListViewKey, GameDetail);
                });
                return _albumCommand;
            }
        }

        public RelayCommand ForumCommand
        {
            get
            {
                _forumCommand = _forumCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.RelationListViewKey, new RelationListViewParameter(_gameId, 1));
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

        public RelayCommand PostCommand
        {
            get
            {
                _postCommand = _postCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.RelationListViewKey, new RelationListViewParameter(_gameId, 2));
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
                    _navigationService.NavigateTo(ViewModelLocator.RelationListViewKey, new RelationListViewParameter(_gameId, 3));
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
                    _navigationService.NavigateTo(ViewModelLocator.ScoreListViewKey, _gameId);
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
                    _navigationService.NavigateTo(ViewModelLocator.StrategyViewKey, _gameId);
                });
                return _strategyCommand;
            }
        }

        public void Activate(object parameter)
        {
            var gameId = (int)parameter;
            if (_gameId != gameId)
            {
                _gameId = gameId;
                GameDetail = null;

                LoadGameDetail();
            }
        }

        public void Deactivate(object parameter)
        {
        }

        private async void LoadGameDetail()
        {
            if (IsLoading)
            {
                return;
            }

            IsLoading = true;
            try
            {
                var result = await _postService.GetGameDetailAsync(_gameId);
                if (result.ErrorCode == HttpStatusCode.OK)
                {
                    GameDetail = result.Data.Data;
                }
                else
                {
                    _appToastService.ShowError(result.ErrorMessage);
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