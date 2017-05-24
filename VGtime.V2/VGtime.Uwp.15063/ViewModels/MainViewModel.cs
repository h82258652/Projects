using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using VGtime.Models.Timeline;
using VGtime.Services;
using VGtime.Uwp.Data;
using VGtime.Uwp.ViewParameters;

namespace VGtime.Uwp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IHomeService _homeService;

        private readonly INavigationService _navigationService;

        private TimeLineBase[] _headpics;

        private RelayCommand<TimeLineBase> _postClickCommand;

        private RelayCommand _searchCommand;

        private RelayCommand<TimeLineBase> _strategyPostClickCommand;

        public MainViewModel(IHomeService homeService, INavigationService navigationService)
        {
            _homeService = homeService;
            _navigationService = navigationService;

            Initialize();
            VglistPosts = new VglistPostCollection(homeService);
            NewsPosts = new TagPostCollection(1, homeService);
            EvaluationPosts = new TagPostCollection(4, homeService);
            VideoPosts = new TagPostCollection(2, homeService);
            StrategyPosts = new TagPostCollection(3, homeService);
            TopicPosts = new TagPostCollection(5, homeService);
        }

        public TagPostCollection EvaluationPosts
        {
            get;
        }

        public TimeLineBase[] Headpics
        {
            get
            {
                return _headpics;
            }
            private set
            {
                Set(ref _headpics, value);
            }
        }

        public TagPostCollection NewsPosts
        {
            get;
        }

        public RelayCommand<TimeLineBase> PostClickCommand
        {
            get
            {
                _postClickCommand = _postClickCommand ?? new RelayCommand<TimeLineBase>(post =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.ArticleDetailViewKey, new ArticleDetailViewParameter(post.PostId, post.DetailType));
                });
                return _postClickCommand;
            }
        }

        public RelayCommand SearchCommand
        {
            get
            {
                _searchCommand = _searchCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.SearchViewKey);
                });
                return _searchCommand;
            }
        }

        public RelayCommand<TimeLineBase> StrategyPostClickCommand
        {
            get
            {
                _strategyPostClickCommand = _strategyPostClickCommand ?? new RelayCommand<TimeLineBase>(strategyPost =>
                {
                    // TODO
                    _navigationService.NavigateTo(ViewModelLocator.GameStrategySetViewKey, null);
                });
                return _strategyPostClickCommand;
            }
        }

        public TagPostCollection StrategyPosts
        {
            get;
        }

        public TagPostCollection TopicPosts
        {
            get;
        }

        public VglistPostCollection VglistPosts
        {
            get;
        }

        public TagPostCollection VideoPosts
        {
            get;
        }

        private async void Initialize()
        {
            try
            {
                var result = await _homeService.GetHeadpicAsync();
                if (result.Retcode == Constants.SuccessCode)
                {
                    Headpics = result.Data.Data;
                }
                else
                {
                    // TODO
                }
            }
            catch (Exception ex)
            {
                // TODO
            }
            finally
            {
                // TODO
            }
        }
    }
}