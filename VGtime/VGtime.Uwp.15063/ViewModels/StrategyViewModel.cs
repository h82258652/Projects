using System;
using System.Net;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SoftwareKobo.ViewModels;
using VGtime.Models;
using VGtime.Services;
using VGtime.Uwp.Services;
using GalaSoft.MvvmLight.Views;
using VGtime.Uwp.ViewModelParameters;

namespace VGtime.Uwp.ViewModels
{
    public class StrategyViewModel : ViewModelBase, INavigable
    {
        private readonly IAppToastService _appToastService;

        private readonly IPostService _postService;

        private bool _isLoading;

        private int _gameId;

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

        private readonly INavigationService _navigationService;

        public RelayCommand<StrategyItem> StrategyItemClickCommand
        {
            get
            {
                _strategyItemClickCommand = _strategyItemClickCommand ?? new RelayCommand<StrategyItem>(strategyItem =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.DetailViewKey, new DetailViewModelParameter(strategyItem.PostId, strategyItem.DetailType));
                });
                return _strategyItemClickCommand;
            }
        }

        public void Activate(object parameter)
        {
            _gameId = (int)parameter;

            LoadStrategyList();
        }

        public void Deactivate(object parameter)
        {
        }

        private async void LoadStrategyList()
        {
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