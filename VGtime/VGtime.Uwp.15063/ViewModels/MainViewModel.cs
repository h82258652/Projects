using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using VGtime.Models;
using VGtime.Services;

namespace VGtime.Uwp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private readonly IPostService _postService;

        private RelayCommand<Post> _postClickCommand;

        public MainViewModel(IPostService postService, INavigationService navigationService)
        {
            _postService = postService;
            _navigationService = navigationService;
        }

        public Post[] HeadPosts
        {
            get;
            set;
        }

        public RelayCommand<Post> PostClickCommand
        {
            get
            {
                _postClickCommand = _postClickCommand ?? new RelayCommand<Post>(post =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.DetailViewKey, post);
                });
                return _postClickCommand;
            }
        }

        public Post[] TempPosts
        {
            get;
            set;
        }
    }
}