using System;
using GalaSoft.MvvmLight;
using VGtime.Models.Games;
using VGtime.Services;
using VGtime.Uwp.Services;

namespace VGtime.Uwp.ViewModels.Games
{
    public class GameStrategySetViewModel : ViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly IGameService _gameService;

        private GameStrategy[] _gameStrategies;

        private bool _isLoading;

        public GameStrategySetViewModel(IGameService gameService, IAppToastService appToastService)
        {
            _gameService = gameService;
            _appToastService = appToastService;
        }

        public int GameId
        {
            get;
            private set;
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

                var result = await _gameService.GetStrategyMenuListAsync(GameId);
                if (result.Retcode == Constants.SuccessCode)
                {
                    GameStrategies = result.Data.Data;
                }
                else
                {
                    _appToastService.ShowError(result.Message);
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