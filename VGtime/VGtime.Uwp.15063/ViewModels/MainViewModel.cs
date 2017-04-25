using System;
using System.Collections.Generic;
using System.Net;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using VGtime.Models;
using VGtime.Services;

namespace VGtime.Uwp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;

        private readonly INavigationService _navigationService;

        private readonly IPostService _postService;

        private IEnumerable<Post> _headPosts;

        private bool _isLoading;

        private RelayCommand<Post> _postClickCommand;

        public MainViewModel(IPostService postService, INavigationService navigationService, IDialogService dialogService)
        {
            _postService = postService;
            _navigationService = navigationService;
            _dialogService = dialogService;

            LoadHeadPostsAsync();
        }

        public IEnumerable<Post> HeadPosts
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

        public Post[] TempPosts
        {
            get;
            set;
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
                    await _dialogService.ShowError(result.ErrorMessage, string.Empty, null, null);
                }
            }
            catch (Exception ex)
            {
                await _dialogService.ShowError(ex, string.Empty, null, null);
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}