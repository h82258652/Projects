using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SoftwareKobo.ViewModels;
using U148.Models;
using U148.Services;

namespace U148.Uwp.ViewModels
{
    public class DetailViewModel : ViewModelBase, INavigable
    {
        private readonly IArticleService _articleService;

        private readonly INavigationService _navigationService;

        private Article _article;

        private RelayCommand _commentCommand;

        private bool _isBusy;

        private RelayCommand _refreshCommand;

        public DetailViewModel(IArticleService articleService, INavigationService navigationService)
        {
            _articleService = articleService;
            _navigationService = navigationService;
        }

        public RelayCommand CommentCommand
        {
            get
            {
                _commentCommand = _commentCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.CommentViewKey, _article);
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
            _article = (Article)parameter;
            throw new NotImplementedException();
        }

        public void Deactivate(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}