using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using VGtime.Models;
using VGtime.Services;
using VGtime.Uwp.Data;
using VGtime.Uwp.ViewParameters;

namespace VGtime.Uwp.ViewModels
{
    public class OldStrategyViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private RelayCommand<Post> _strategyPostClickCommand;

        public OldStrategyViewModel(IPostService postService, INavigationService navigationService)
        {
            _navigationService = navigationService;

            StrategyPosts = new TagPostCollection(postService, 6);
        }

        public RelayCommand<Post> StrategyPostClickCommand
        {
            get
            {
                _strategyPostClickCommand = _strategyPostClickCommand ?? new RelayCommand<Post>(post =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.ArticleDetailViewKey, new DetailViewParameter(post.PostId, post.DetailType));
                });
                return _strategyPostClickCommand;
            }
        }

        public TagPostCollection StrategyPosts
        {
            get;
        }
    }
}