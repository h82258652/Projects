using System;
using GalaSoft.MvvmLight;
using VGtime.Configuration;
using VGtime.Models.Games;
using VGtime.Services;
using VGtime.Uwp.Services;

namespace VGtime.Uwp.ViewModels.Games
{
    public class GameDetailViewModel : ViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly IGameService _gameService;

        private readonly IVGtimeSettings _vgtimeSettings;

        private GameBase _gameDetail;

        private int _gameId;

        private bool _isLoading;

        public GameDetailViewModel(IGameService gameService, IVGtimeSettings vgtimeSettings, IAppToastService appToastService)
        {
            _gameService = gameService;
            _vgtimeSettings = vgtimeSettings;
            _appToastService = appToastService;
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

        private async void LoadDetailAsync()
        {
            if (IsLoading)
            {
                return;
            }

            IsLoading = true;
            try
            {
                var result = await _gameService.GetDetailAsync(_gameId, _vgtimeSettings.UserInfo?.UserId);
                if (result.Retcode == Constants.SuccessCode)
                {
                    GameDetail = result.Data.Game;
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