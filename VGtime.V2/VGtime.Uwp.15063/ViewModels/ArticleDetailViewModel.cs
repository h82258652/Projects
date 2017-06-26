﻿using System;
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

        private RelayCommand _moreCommentCommand;

        private int _postId;

        private RelayCommand<int> _relatedGameCommand;

        private RelayCommand<(int gameId, int detailType)> _relatedNewsCommand;

        private RelayCommand _shareCommand;

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
            CurrentPage = page;
            LoadArticleDetail();
        }

        private async void LoadArticleDetail()
        {
            try
            {
                IsLoading = true;

                var postId = PostId;
                var result = await _postService.GetDetailAsync(postId, _type, _vgtimeSettings.UserInfo?.UserId, CurrentPage);
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