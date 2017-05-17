using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SoftwareKobo.ViewModels;
using VGtime.Models;
using VGtime.Services;
using VGtime.Uwp.Data;
using VGtime.Uwp.ViewParameters;

namespace VGtime.Uwp.ViewModels
{
    public class RelationListViewModel : ViewModelBase, INavigable
    {
        private readonly INavigationService _navigationService;

        private readonly IPostService _postService;

        private RelayCommand<Post> _postClickCommand;

        private RelationPostCollection _relationPosts;

        private RelationListViewParameter _viewParameter;

        public RelationListViewModel(IPostService postService, INavigationService navigationService)
        {
            _postService = postService;
            _navigationService = navigationService;
        }

        public RelayCommand<Post> PostClickCommand
        {
            get
            {
                _postClickCommand = _postClickCommand ?? new RelayCommand<Post>(post =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.DetailViewKey, new DetailViewParameter(post.PostId, post.DetailType));
                });
                return _postClickCommand;
            }
        }

        public RelationPostCollection RelationPosts
        {
            get
            {
                return _relationPosts;
            }
            private set
            {
                Set(ref _relationPosts, value);
            }
        }

        public void Activate(object parameter)
        {
            var viewParameter = (RelationListViewParameter)parameter;
            if (_viewParameter == null || _viewParameter.GameId != viewParameter.GameId)
            {
                _viewParameter = viewParameter;

                RelationPosts = new RelationPostCollection(viewParameter.GameId, viewParameter.Type, _postService);
            }
        }

        public void Deactivate(object parameter)
        {
        }
    }
}