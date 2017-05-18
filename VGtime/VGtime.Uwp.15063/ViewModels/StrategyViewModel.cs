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
    public class StrategyViewModel : ViewModelBase, INavigable
    {
        private readonly IAppToastService _appToastService;

        private readonly INavigationService _navigationService;

        private readonly IPostService _postService;

        private int _gameId;

        private bool _isLoading;

        private Strategy[] _strategies;

        private RelayCommand<StrategyItem> _strategyItemClickCommand;

        public StrategyViewModel(IPostService postService, IAppToastService appToastService, INavigationService navigationService)
        {
            _postService = postService;
            _appToastService = appToastService;
            _navigationService = navigationService;
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

        public Strategy[] Strategies
        {
            get
            {
                return _strategies;
            }
            private set
            {
                Set(ref _strategies, value);
            }
        }

        public RelayCommand<StrategyItem> StrategyItemClickCommand
        {
            get
            {
                _strategyItemClickCommand = _strategyItemClickCommand ?? new RelayCommand<StrategyItem>(strategyItem =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.ArticleDetailViewKey, new DetailViewParameter(strategyItem.PostId, strategyItem.DetailType));
                });
                return _strategyItemClickCommand;
            }
        }

        public void Activate(object parameter)
        {
            var gameId = (int)parameter;
            if (_gameId != gameId)
            {
                _gameId = gameId;
                Strategies = null;

                LoadStrategyList();
            }
        }

        public void Deactivate(object parameter)
        {
        }

        private async void LoadStrategyList()
        {
            if (IsLoading)
            {
                return;
            }

            IsLoading = true;
            try
            {
                var result = await _postService.GetStrategyMenuListAsync(_gameId);
                if (result.ErrorCode == HttpStatusCode.OK)
                {
                    Strategies = result.Data.Data;
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