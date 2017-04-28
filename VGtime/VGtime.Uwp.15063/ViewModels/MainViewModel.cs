using System;
using System.Net;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using VGtime.Models;
using VGtime.Services;
using VGtime.Uwp.Data;
using VGtime.Uwp.Services;

namespace VGtime.Uwp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly INavigationService _navigationService;

        private readonly IPostService _postService;

        private Post[] _headPosts;

        private bool _isLoading;

        private RelayCommand<Post> _postClickCommand;

        private RelayCommand _refreshCommand;

        public MainViewModel(IPostService postService, INavigationService navigationService, IAppToastService appToastService)
        {
            _postService = postService;
            _navigationService = navigationService;
            _appToastService = appToastService;

            ListPosts = new ListPostCollection(postService);
            LoadHeadPostsAsync();
        }

        public Post[] HeadPosts
        {
            get
            {
                return _headPosts;
            }
            private set
            {
                Set(ref _headPosts, value);
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

        public ListPostCollection ListPosts
        {
            get;
        }

        public RelayCommand<Post> PostClickCommand
        {
            get
            {
                _postClickCommand = _postClickCommand ?? new RelayCommand<Post>(post =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.DetailViewKey, post);
                });
                return _postClickCommand;
            }
        }

        public RelayCommand RefreshCommand
        {
            get
            {
                _refreshCommand = _refreshCommand ?? new RelayCommand(() =>
                {
                    LoadHeadPostsAsync();
                    ListPosts.Refresh();
                });
                return _refreshCommand;
            }
        }

        public async void LoadHeadPostsAsync()
        {
            if (IsLoading)
            {
                return;
            }

            IsLoading = true;
            try
            {
                var result = await _postService.GetHeadPicAsync();
                if (result.ErrorCode == HttpStatusCode.OK)
                {
                    HeadPosts = result.Data.Data;
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