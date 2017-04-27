using GalaSoft.MvvmLight;
using SoftwareKobo.ViewModels;
using VGtime.Services;

namespace VGtime.Uwp.ViewModels
{
    public class CommentViewModel : ViewModelBase, INavigable
    {
        private readonly IPostService _postService;

        public CommentViewModel(IPostService postService)
        {
            _postService = postService;
        }

        public void Activate(object parameter)
        {
        }

        public void Deactivate(object parameter)
        {
        }
    }
}