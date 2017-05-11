using System;
using System.Net;
using GalaSoft.MvvmLight;
using SoftwareKobo.ViewModels;
using VGtime.Models;
using VGtime.Services;
using VGtime.Uwp.Services;

namespace VGtime.Uwp.ViewModels
{
    public class StrategyViewModel : ViewModelBase, INavigable
    {
        private readonly IAppToastService _appToastService;

        private readonly IPostService _postService;

        private bool _isLoading;

        private Post _post;

        private Strategy[] _strategies;

        public StrategyViewModel(IPostService postService, IAppToastService appToastService)
        {
            _postService = postService;
            _appToastService = appToastService;
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

        public void Activate(object parameter)
        {
            _post = (Post)parameter;

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
                var result = await _postService.GetStrategyMenuListAsync(_post.PostId);
                if (result.ErrorCode == HttpStatusCode.OK)
                {
                    this.Strategies = result.Data.Data;
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