using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using VGtime.Models.Timeline;
using VGtime.Services;
using VGtime.Uwp.Data;
using VGtime.Uwp.Services;
using VGtime.Uwp.ViewParameters;

namespace VGtime.Uwp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IAppToastService _appToastService;

        private readonly IHomeService _homeService;

        private readonly INavigationService _navigationService;

        private RelayCommand _aboutCommand;

        private TimeLineBase[] _headpics;

        private bool _isLoadingHeadpic;

        private RelayCommand<TimeLineBase> _postClickCommand;

        private RelayCommand _searchCommand;

        private RelayCommand _settingCommand;

        private RelayCommand<TimeLineBase> _strategyPostClickCommand;

        public MainViewModel(IHomeService homeService, INavigationService navigationService, IAppToastService appToastService)
        {
            _homeService = homeService;
            _navigationService = navigationService;
            _appToastService = appToastService;

            LoadHeadpic();
            VglistPosts = new VglistPostCollection(homeService);
            NewsPosts = new TagPostCollection(1, homeService);
            EvaluationPosts = new TagPostCollection(4, homeService);
            VideoPosts = new TagPostCollection(2, homeService);
            StrategyPosts = new TagPostCollection(3, homeService);
            TopicPosts = new TagPostCollection(5, homeService);
        }

        public RelayCommand AboutCommand
        {
            get
            {
                _aboutCommand = _aboutCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.AboutViewKey);
                });
                return _aboutCommand;
            }
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

        public bool IsLoadingHeadpic
        {
            get
            {
                return _isLoadingHeadpic;
            }
            private set
            {
                Set(ref _isLoadingHeadpic, value);
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

        public RelayCommand SettingCommand
        {
            get
            {
                _settingCommand = _settingCommand ?? new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.SettingViewKey);
                });
                return _settingCommand;
            }
        }

        public RelayCommand<TimeLineBase> StrategyPostClickCommand
        {
            get
            {
                _strategyPostClickCommand = _strategyPostClickCommand ?? new RelayCommand<TimeLineBase>(strategyPost =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.GameStrategySetViewKey, strategyPost.PostId);
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

        private async void LoadHeadpic()
        {
            try
            {
                IsLoadingHeadpic = true;

                var result = await _homeService.GetHeadpicAsync();
                if (result.Retcode == Constants.SuccessCode)
                {
                    Headpics = result.Data.Data;
                }
                else
                {
                    _appToastService.ShowError(result.Message);
                }
            }
            catch (Exception ex)
            {
                _appToastService.ShowError(ex.Message);
            }
            finally
            {
                IsLoadingHeadpic = false;
            }
        }
    }
}