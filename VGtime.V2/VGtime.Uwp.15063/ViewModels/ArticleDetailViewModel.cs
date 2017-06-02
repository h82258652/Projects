using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using VGtime.Configuration;
using VGtime.Models.Article;
using VGtime.Services;
using VGtime.Uwp.Messages;
using VGtime.Uwp.Services;
using VGtime.Uwp.ViewParameters;

namespace VGtime.Uwp.ViewModels
{
    public class ArticleDetailViewModel : ViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly INavigationService _navigationService;

        private readonly IPostService _postService;

        private readonly IVGtimeSettings _vgtimeSettings;

        private ArticleDetail _articleDetail;

        private bool _isLoading;

        private RelayCommand _moreCommentCommand;

        private RelayCommand<int> _relatedGameCommand;

        private RelayCommand<(int gameId, int detailType)> _relatedNewsCommand;

        private int _type;

        public ArticleDetailViewModel(IPostService postService, IVGtimeSettings vgtimeSettings, IAppToastService appToastService, INavigationService navigationService)
        {
            _postService = postService;
            _vgtimeSettings = vgtimeSettings;
            _appToastService = appToastService;
            _navigationService = navigationService;
        }

        public ArticleDetail ArticleDetail
        {
            get
            {
                return _articleDetail;
            }
            private set
            {
                Set(ref _articleDetail, value);
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

        public RelayCommand MoreCommentCommand
        {
            get
            {
                _moreCommentCommand = _moreCommentCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.CommentViewKey, new CommentViewParameter(PostId, _type));
                });
                return _moreCommentCommand;
            }
        }

        public int PostId
        {
            get;
            private set;
        }

        public RelayCommand<int> RelatedGameCommand
        {
            get
            {
                _relatedGameCommand = _relatedGameCommand ?? new RelayCommand<int>(gameId =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.GameDetailViewKey, gameId);
                });
                return _relatedGameCommand;
            }
        }

        public RelayCommand<(int gameId, int detailType)> RelatedNewsCommand
        {
            get
            {
                _relatedNewsCommand = _relatedNewsCommand ?? new RelayCommand<(int gameId, int detailType)>(tuple =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.ArticleDetailViewKey, new ArticleDetailViewParameter(tuple.gameId, tuple.detailType));
                });
                return _relatedNewsCommand;
            }
        }

        public void LoadArticleDetail(int postId, int type)
        {
            PostId = postId;
            _type = type;
            LoadArticleDetail();
        }

        private async void LoadArticleDetail()
        {
            try
            {
                IsLoading = true;

                var postId = PostId;
                var result = await _postService.GetDetailAsync(postId, _type, _vgtimeSettings.UserInfo?.UserId);
                if (postId == PostId)
                {
                    if (result.Retcode == Constants.SuccessCode)
                    {
                        var articleDetail = result.Data.Data;
                        ArticleDetail = articleDetail;

                        MessengerInstance.Send(new ArticleDetailLoadedMessage(articleDetail));
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