using GalaSoft.MvvmLight;
using VGtime.Services;
using VGtime.Uwp.Data;

namespace VGtime.Uwp.ViewModels
{
    public class CommentViewModel : ViewModelBase
    {
        private CommentCollection _comments;

        private IPostService _postService;

        public CommentViewModel(IPostService postService)
        {
            _postService = postService;
        }

        public CommentCollection Comments
        {
            get
            {
                return _comments;
            }
            private set
            {
                Set(ref _comments, value);
            }
        }
    }
}