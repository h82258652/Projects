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

        public async void XXX()
        {
            // TODO rename method.
            try
            {
                var result = await _gameService.GetStrategyMenuListAsync(0);// TODO gameId.
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
            }
        }
    }
}