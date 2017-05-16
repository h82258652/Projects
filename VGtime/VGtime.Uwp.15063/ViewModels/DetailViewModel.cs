using System;
using System.Net;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SoftwareKobo.ViewModels;
using VGtime.Models;
using VGtime.Services;
using VGtime.Uwp.Messages;
using VGtime.Uwp.Services;
using VGtime.Uwp.ViewParameters;

namespace VGtime.Uwp.ViewModels
{
    public class DetailViewModel : ViewModelBase, INavigable
    {
        private readonly IAppToastService _appToastService;

        private readonly INavigationService _navigationService;

        private readonly IPostService _postService;

        private RelayCommand _commentCommand;

        private bool _isLoading;

        private Post _post;

        private RelayCommand _refreshCommand;

        private DetailViewParameter _viewParameter;

        public DetailViewModel(IPostService postService, INavigationService navigationService, IAppToastService appToastService)
        {
            _postService = postService;
            _navigationService = navigationService;
            _appToastService = appToastService;
        }

        public RelayCommand CommentCommand
        {
            get
            {
                _commentCommand = _commentCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.CommentViewKey, Post);
                });
                return _commentCommand;
            }
        }

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                Set(ref _isLoading, value);
            }
        }

        public Post Post
        {
            get
            {
                return _post;
            }
            private set
            {
                Set(ref _post, value);
            }
        }

        public RelayCommand RefreshCommand
        {
            get
            {
                _refreshCommand = _refreshCommand ?? new RelayCommand(() =>
                {
                    LoadArticleDetail(true);
                });
                return _refreshCommand;
            }
        }

        public void Activate(object parameter)
        {
            _viewParameter = (DetailViewParameter)parameter;

            LoadArticleDetail();
        }

        public void Deactivate(object parameter)
        {
        }

        private async void LoadArticleDetail(bool isRefresh = false)
        {
            if (IsLoading || _viewParameter == null)
            {
                return;
            }

            IsLoading = true;
            try
            {
                var result = await _postService.GetDetailAsync(_viewParameter.PostId, _viewParameter.DetailType);
                if (result.ErrorCode == HttpStatusCode.OK)
                {
                    var post = result.Data.Data;
                    Post = post;
                    MessengerInstance.Send(new PostContentLoadedMessage(post.Content));

                    if (isRefresh)
                    {
                        _appToastService.ShowMessage(LocalizedStrings.RefreshSuccess);
                    }
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