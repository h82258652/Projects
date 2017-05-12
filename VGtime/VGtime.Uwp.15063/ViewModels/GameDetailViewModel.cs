using System;
using System.Net;
using GalaSoft.MvvmLight;
using SoftwareKobo.ViewModels;
using VGtime.Models;
using VGtime.Services;
using VGtime.Uwp.Services;

namespace VGtime.Uwp.ViewModels
{
    public class GameDetailViewModel : ViewModelBase, INavigable
    {
        private readonly IAppToastService _appToastService;

        private readonly IPostService _postService;

        private Game _gameDetail;

        private int _gameId;

        private bool _isLoading;

        public GameDetailViewModel(IPostService postService, IAppToastService appToastService)
        {
            _postService = postService;
            _appToastService = appToastService;
        }

        public Game GameDetail
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

        public void Activate(object parameter)
        {
            _gameId = (int)parameter;
            LoadGameDetail();
        }

        public void Deactivate(object parameter)
        {
        }

        private async void LoadGameDetail()
        {
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