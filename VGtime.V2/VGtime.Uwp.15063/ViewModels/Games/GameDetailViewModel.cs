﻿using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
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

        private readonly INavigationService _navigationService;

        private readonly IVGtimeSettings _vgtimeSettings;

        private GameBase _gameDetail;

        private bool _isLoading;

        private RelayCommand _photoCommand;

        private RelayCommand _scoreCommand;

        private RelayCommand _strategyCommand;

        public GameDetailViewModel(IGameService gameService, IVGtimeSettings vgtimeSettings, IAppToastService appToastService, INavigationService navigationService)
        {
            _gameService = gameService;
            _vgtimeSettings = vgtimeSettings;
            _appToastService = appToastService;
            _navigationService = navigationService;
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
                    _navigationService.NavigateTo(ViewModelLocator.GamePhotoViewKey, GameId);
                });
                return _photoCommand;
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