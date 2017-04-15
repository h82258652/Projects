using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SoftwareKobo.ViewModels;
using U148.Models;
using U148.Services;
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

        private bool _isBusy;

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

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            private set
            {
                Set(ref _isBusy, value);
                throw new NotImplementedException();
            }
        }

        public RelayCommand RefreshCommand
        {
            get
            {
                _refreshCommand = _refreshCommand ?? new RelayCommand(() =>
                {
                    throw new NotImplementedException();
                });
                return _refreshCommand;
            }
        }

        public void Activate(object parameter)
        {
            Article = (Article)parameter;
        }

        public void Deactivate(object parameter)
        {
        }

        private async void LoadArticleDetail()
        {
            if (IsBusy || Article == null)
            {
                return;
            }

            IsBusy = true;
            try
            {
                var result = await _articleService.GetArticleDetailAsync(Article.Id);
                if (result.ErrorCode == 0)
                {
                    throw new NotImplementedException();
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
                IsBusy = false;
            }
        }
    }
}