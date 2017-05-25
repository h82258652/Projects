using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using VGtime.Configuration;
using VGtime.Services;
using VGtime.Uwp.Messages;
using VGtime.Uwp.Services;

namespace VGtime.Uwp.ViewModels
{
    public class ArticleDetailViewModel : ViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly INavigationService _navigationService;

        private readonly IPostService _postService;

        private readonly IVGtimeSettings _vgtimeSettings;

        private bool _isLoading;

        private RelayCommand _moreCommentCommand;

        private int _type;

        public ArticleDetailViewModel(IPostService postService, IVGtimeSettings vgtimeSettings, IAppToastService appToastService, INavigationService navigationService)
        {
            _postService = postService;
            _vgtimeSettings = vgtimeSettings;
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

        public RelayCommand MoreCommentCommand
        {
            get
            {
                _moreCommentCommand = _moreCommentCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.CommentViewKey);
                });
                return _moreCommentCommand;
            }
        }

        public void LoadArticleDetail(int postId, int type)
        {
            PostId = postId;
            _type = type;
            LoadArticleDetail();
        }

        public int PostId
        {
            get;
            private set;
        }

        private async void LoadArticleDetail()
        {
            try
            {
                IsLoading = true;

                var result = await _postService.GetDetailAsync(PostId, _type, _vgtimeSettings.UserInfo?.UserId);
                if (result.Retcode == Constants.SuccessCode)
                {
                    var articleDetail = result.Data.Data;

                    MessengerInstance.Send(new ArticleDetailLoadedMessage(articleDetail));
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