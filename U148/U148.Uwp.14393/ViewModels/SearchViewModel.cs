using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using U148.Models;
using U148.Services;
using U148.Uwp.Data;

namespace U148.Uwp.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private readonly IArticleService _articleService;

        private readonly INavigationService _navigationService;

        private RelayCommand<Article> _articleClickCommand;

        private SearchArticleCollection _articles;

        private RelayCommand<string> _searchCommand;

        public SearchViewModel(IArticleService articleService, INavigationService navigationService)
        {
            _articleService = articleService;
            _navigationService = navigationService;
        }

        public RelayCommand<Article> ArticleClickCommand
        {
            get
            {
                _articleClickCommand = _articleClickCommand ?? new RelayCommand<Article>(article =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.DetailViewKey, article);
                });
                return _articleClickCommand;
            }
        }

        public SearchArticleCollection Articles
        {
            get
            {
                return _articles;
            }
            private set
            {
                Set(ref _articles, value);
            }
        }

        public RelayCommand<string> SearchCommand
        {
            get
            {
                _searchCommand = _searchCommand ?? new RelayCommand<string>(query =>
                {
                    if (!string.IsNullOrEmpty(query))
                    {
                        Articles = new SearchArticleCollection(_articleService, query);
                    }
                });
                return _searchCommand;
            }
        }
    }
}