using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using U148.Models;
using WinRTXamlToolkit.Tools;

namespace U148.Uwp.ViewModels
{
    public class ArticleViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private RelayCommand<Article> _articleClickCommand;

        public ArticleViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            var dict = new Dictionary<ArticleCategory, IEnumerable<Article>>();
            foreach (var articleCategory in EnumExtensions.GetValues<ArticleCategory>())
            {
                // TODO
                dict[articleCategory] = new List<Article>();
            }
            Categories = dict;
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
            get;
        }
    }
}