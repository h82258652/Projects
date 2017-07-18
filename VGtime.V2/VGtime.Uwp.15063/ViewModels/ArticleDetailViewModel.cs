using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SoftwareKobo.Controls;
using SoftwareKobo.Social.SinaWeibo;
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

        private readonly IImageLoader _imageLoader;

        private readonly INavigationService _navigationService;

        private readonly IPostService _postService;

        private readonly IVGtimeSettings _vgtimeSettings;

        private readonly IVGtimeShareService _vgtimeShareService;

        private ArticleDetail _articleDetail;

        private int _currentPage = 1;

        private bool _isLoading;

        private int _postId;

        private RelayCommand _refreshCommand;

        private RelayCommand _shareCommand;

        private RelayCommand _showCommentListCommand;

        private RelayCommand<(int newsPostId, int newsDetailType)> _showNewsCommand;

        private RelayCommand<int> _showRelationGameCommand;

        private RelayCommand _sinaWeiboShareCommand;

        private RelayCommand _systemShareCommand;

        private int _type;

        public ArticleDetailViewModel(IPostService postService, IVGtimeSettings vgtimeSettings, IAppToastService appToastService, INavigationService navigationService, IVGtimeShareService vgtimeShareService, IImageLoader imageLoader)
        {
            _postService = postService;
            _vgtimeSettings = vgtimeSettings;
            _appToastService = appToastService;
            _navigationService = navigationService;
            _vgtimeShareService = vgtimeShareService;
            _imageLoader = imageLoader;
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

        public int CurrentPage
        {
            get
            {
                return _currentPage;
            }
            private set
            {
                Set(ref _currentPage, value);
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

        public int PostId
        {
            get
            {
                return _postId;
            }
            private set
            {
                if (_postId != value)
                {
                    _postId = value;
                    ArticleDetail = null;
                    CurrentPage = 1;
                }
            }
        }

        public RelayCommand RefreshCommand
        {
            get
            {
                _refreshCommand = _refreshCommand ?? new RelayCommand(LoadArticleDetail);
                return _refreshCommand;
            }
        }

        public RelayCommand ShareCommand
        {
            get
            {
                _shareCommand = _shareCommand ?? new RelayCommand(() =>
                {
                    MessengerInstance.Send(new ShowChooseShareDialogMessage());
                });
                return _shareCommand;
            }
        }

        public RelayCommand ShowCommentListCommand
        {
            get
            {
                _showCommentListCommand = _showCommentListCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.CommentViewKey, new CommentViewParameter(PostId, _type));
                });
                return _showCommentListCommand;
            }
        }

        public RelayCommand<(int newsPostId, int newsDetailType)> ShowNewsCommand
        {
            get
            {
                _showNewsCommand = _showNewsCommand ?? new RelayCommand<(int newsPostId, int newsDetailType)>(tuple =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.ArticleDetailViewKey, new ArticleDetailViewParameter(tuple.newsPostId, tuple.newsDetailType));
                });
                return _showNewsCommand;
            }
        }

        public RelayCommand<int> ShowRelationGameCommand
        {
            get
            {
                _showRelationGameCommand = _showRelationGameCommand ?? new RelayCommand<int>(gameId =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.GameDetailViewKey, gameId);
                });
                return _showRelationGameCommand;
            }
        }

        public RelayCommand SinaWeiboShareCommand
        {
            get
            {
                _sinaWeiboShareCommand = _sinaWeiboShareCommand ?? new RelayCommand(async () =>
                {
                    var articleDetail = ArticleDetail;
                    if (articleDetail == null)
                    {
                        return;
                    }

                    try
                    {
                        var imageUrl = articleDetail.Thumbnail.Url;
                        var bytes = await _imageLoader.GetBytesAsync(imageUrl);
                        var text = string.Join(Environment.NewLine, articleDetail.Title, articleDetail.ShareUrl);
                        var result = await _vgtimeShareService.ShareToSinaWeiboAsync(text, bytes);
                        if (result.ErrorCode <= 0)
                        {
                            _appToastService.ShowMessage(LocalizedStrings.ShareSuccess);
                        }
                        else
                        {
                            _appToastService.ShowError(result.ErrorMessage);
                        }
                    }
                    catch (UserCancelAuthorizeException)
                    {
                    }
                    catch (Exception ex)
                    {
                        _appToastService.ShowError(ex.Message);
                    }
                });
                return _sinaWeiboShareCommand;
            }
        }

        public RelayCommand SystemShareCommand
        {
            get
            {
                _systemShareCommand = _systemShareCommand ?? new RelayCommand(async () =>
                {
                    var articleDetail = ArticleDetail;
                    if (articleDetail == null)
                    {
                        return;
                    }

                    await _vgtimeShareService.ShareToSystemAsync(articleDetail.Title, articleDetail.ShareUrl, articleDetail.Thumbnail.Url);
                });
                return _systemShareCommand;
            }
        }

        public void LoadArticleDetail(int postId, int type)
        {
            PostId = postId;
            _type = type;
            LoadArticleDetail();
        }

        public void LoadPage(int page)
        {
            if (CurrentPage != page)
            {
                CurrentPage = page;
                LoadArticleDetail();
            }
        }

        private async void LoadArticleDetail()
        {
            try
            {
                IsLoading = true;

                var postId = PostId;
                var currentPage = CurrentPage;
                var result = await _postService.GetDetailAsync(postId, _type, _vgtimeSettings.UserInfo?.UserId, currentPage);
                if (postId == PostId && currentPage == CurrentPage)
                {
                    if (result.Retcode == Constants.SuccessCode)
                    {
                        var articleDetail = result.Data.Data;
                        ArticleDetail = articleDetail;

                        MessengerInstance.Send(new ArticleDetailLoadedMessage(articleDetail, currentPage));
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