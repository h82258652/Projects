using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using VGtime.Models.Timeline;
using VGtime.Services;
using VGtime.Uwp.Data;
using VGtime.Uwp.ViewParameters;

namespace VGtime.Uwp.ViewModels
{
    public class OldGameStrategyViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private RelayCommand<TimeLineBase> _strategyPostClickCommand;

        public OldGameStrategyViewModel(IHomeService homeService, INavigationService navigationService)
        {
            _navigationService = navigationService;

            StrategyPosts = new TagPostCollection(6, homeService);
        }

        public RelayCommand<TimeLineBase> StrategyPostClickCommand
        {
            get
            {
                _strategyPostClickCommand = _strategyPostClickCommand ?? new RelayCommand<TimeLineBase>(strategyPost =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.ArticleDetailViewKey, new ArticleDetailViewParameter(strategyPost.PostId, strategyPost.DetailType));
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