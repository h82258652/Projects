using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using VGtime.Models.Games;
using VGtime.Services;
using VGtime.Uwp.Services;
using VGtime.Uwp.ViewParameters;

namespace VGtime.Uwp.ViewModels.Games
{
    public class GameStrategySetViewModel : ViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly IGameService _gameService;

        private readonly INavigationService _navigationService;

        private int _gameId;

        private GameStrategy[] _gameStrategies;

        private bool _isLoading;

        private RelayCommand<GameStrategyItem> _strategyItemClickCommand;

        public GameStrategySetViewModel(IGameService gameService, IAppToastService appToastService, INavigationService navigationService)
        {
            _gameService = gameService;
            _appToastService = appToastService;
            _navigationService = navigationService;
        }

        public int GameId
        {
            get
            {
                return _gameId;
            }
            private set
            {
                if (_gameId != value)
                {
                    _gameId = value;
                    GameStrategies = null;
                }
            }
        }

        public GameStrategy[] GameStrategies
        {
            get
            {
                return _gameStrategies;
            }
            private set
            {
                Set(ref _gameStrategies, value);
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

        public RelayCommand<GameStrategyItem> StrategyItemClickCommand
        {
            get
            {
                _strategyItemClickCommand = _strategyItemClickCommand ?? new RelayCommand<GameStrategyItem>(strategyItem =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.ArticleDetailViewKey, new ArticleDetailViewParameter(strategyItem.PostId, strategyItem.DetailType));
                });
                return _strategyItemClickCommand;
            }
        }

        public void LoadGameStrategies(int gameId)
        {
            GameId = gameId;
            LoadGameStrategies();
        }

        private async void LoadGameStrategies()
        {
            if (IsLoading)
            {
                return;
            }
            try
            {
                IsLoading = true;

                var gameId = GameId;
                var result = await _gameService.GetStrategyMenuListAsync(gameId);
                if (gameId == GameId)
                {
                    if (result.Retcode == Constants.SuccessCode)
                    {
                        GameStrategies = result.Data.Data;
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