using System;
using System.Net;
using GalaSoft.MvvmLight;
using SoftwareKobo.ViewModels;
using VGtime.Models;
using VGtime.Services;

namespace VGtime.Uwp.ViewModels
{
    public class StrategyViewModel : ViewModelBase, INavigable
    {
        private readonly IPostService _postService;

        private StrategyList _strategyList;

        public StrategyViewModel(IPostService postService)
        {
            _postService = postService;
        }

        public StrategyList StrategyList
        {
            get
            {
                return _strategyList;
            }
            private set
            {
                Set(ref _strategyList, value);
            }
        }

        public void Activate(object parameter)
        {
            _post = (Post)parameter;

            LoadStrategyList();
        }

        private Post _post;

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

        private bool _isLoading;

        private async void LoadStrategyList()
        {
            IsLoading = true;
            try
            {
                var result = await _postService.GetStrategyMenuListAsync(_post.PostId);
                if (result.ErrorCode == HttpStatusCode.OK)
                {
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        public void Deactivate(object parameter)
        {
        }
    }
}