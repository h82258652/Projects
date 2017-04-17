using System.Collections.Generic;
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
            Categories = categories;
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

        public IReadOnlyDictionary<ArticleCategory, ArticleCollection> Categories
        {
            get;
        }

        public RelayCommand<ArticleCategory> RefreshCommand
        {
            get
            {
                _refreshCommand = _refreshCommand ?? new RelayCommand<ArticleCategory>(category =>
                {
                    Categories[category].Refresh();
                });
                return _refreshCommand;
            }
        }
    }
}