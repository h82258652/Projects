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

        private int _gameId;

        private GameStrategy[] _gameStrategies;

        private bool _isLoading;

        public GameStrategySetViewModel(IGameService gameService, IAppToastService appToastService)
        {
            _gameService = gameService;
            _appToastService = appToastService;
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

        private async void LoadGameStrategiesAsync()
        {
            if (IsLoading)
            {
                return;
            }

            IsLoading = true;
            try
            {
                var result = await _gameService.GetStrategyMenuListAsync(_gameId);
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