using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using U148.Models;
using U148.Services;
using U148.Uwp.Data;
using U148.Uwp.Services;
using WinRTXamlToolkit.Tools;

namespace U148.Uwp.ViewModels
{
    public class ArticleViewModel : ViewModelBase
    {
        private readonly IDictionary<ArticleCategory, ArticleCollection> _categories;

        private readonly INavigationService _navigationService;

        private RelayCommand<Article> _articleClickCommand;

        private RelayCommand<ArticleCategory> _refreshCommand;

        public ArticleViewModel(INavigationService navigationService, IArticleService articleService, IAppToastService appToastService)
        {
            _navigationService = navigationService;

            var categories = new Dictionary<ArticleCategory, ArticleCollection>();
            foreach (var articleCategory in EnumExtensions.GetValues<ArticleCategory>())
            {
                categories[articleCategory] = new ArticleCollection(articleService, articleCategory, exception =>
                {
                    appToastService.ShowError(exception.Message);
                });
            }
            _categories = categories;
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

        public IReadOnlyDictionary<ArticleCategory, IEnumerable<Article>> Categories
        {
            get
            {
                return _categories.ToDictionary(temp => temp.Key, temp => temp.Value as IEnumerable<Article>);
            }
        }

        public RelayCommand<ArticleCategory> RefreshCommand
        {
            get
            {
                _refreshCommand = _refreshCommand ?? new RelayCommand<ArticleCategory>(category =>
                {
                    _categories[category].Refresh();
                });
                return _refreshCommand;
            }
        }
    }
}