using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SoftwareKobo.ViewModels;
using VGtime.Models;
using VGtime.Services;
using VGtime.Uwp.Data;
using VGtime.Uwp.ViewModelParameters;

namespace VGtime.Uwp.ViewModels
{
    public class RelationListViewModel : ViewModelBase, INavigable
    {
        private readonly INavigationService _navigationService;

        private readonly IPostService _postService;

        private RelayCommand<Post> _postClickCommand;

        private RelationPostCollection _relationPosts;

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
                    _navigationService.NavigateTo(ViewModelLocator.DetailViewKey, new DetailViewModelParameter(post.PostId, post.DetailType));
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
            var viewModelParameter = (RelationListViewModelParameter)parameter;

            RelationPosts = new RelationPostCollection(viewModelParameter.GameId, viewModelParameter.Type, _postService);
        }

        public void Deactivate(object parameter)
        {
        }
    }
}