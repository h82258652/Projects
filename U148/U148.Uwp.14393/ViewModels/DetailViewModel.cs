using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SoftwareKobo.ViewModels;
using U148.Models;
using U148.Services;
using U148.Uwp.Messages;
using U148.Uwp.Services;

namespace U148.Uwp.ViewModels
{
    public class DetailViewModel : ViewModelBase, INavigable
    {
        private readonly IAppToastService _appToastService;

        private readonly IArticleService _articleService;

        private readonly INavigationService _navigationService;

        private Article _article;

        private RelayCommand _commentCommand;

        private bool _isLoading;

        private RelayCommand _refreshCommand;

        public DetailViewModel(IArticleService articleService, INavigationService navigationService, IAppToastService appToastService)
        {
            _articleService = articleService;
            _navigationService = navigationService;
            _appToastService = appToastService;
        }

        public Article Article
        {
            get
            {
                return _article;
            }
            private set
            {
                Set(ref _article, value);
            }
        }

        public RelayCommand CommentCommand
        {
            get
            {
                _commentCommand = _commentCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.CommentViewKey, Article);
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
            private set
            {
                Set(ref _isLoading, value);
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
            Article = (Article)parameter;
            LoadArticleDetail();
        }

        public void Deactivate(object parameter)
        {
        }

        private async void LoadArticleDetail(bool isRefresh = false)
        {
            if (IsLoading || Article == null)
            {
                return;
            }

            IsLoading = true;
            try
            {
                var result = await _articleService.GetArticleDetailAsync(Article.Id);
                if (result.ErrorCode == 0)
                {
                    MessengerInstance.Send(new ArticleContentLoadedMessage(result.Data.Content));

                    if (isRefresh)
                    {
                        _appToastService.ShowMessage("刷新成功");
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