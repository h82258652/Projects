using GalaSoft.MvvmLight;
using SoftwareKobo.ViewModels;
using VGtime.Models;
using VGtime.Services;
using VGtime.Uwp.Data;

namespace VGtime.Uwp.ViewModels
{
    public class CommentViewModel : ViewModelBase, INavigable
    {
        private readonly IPostService _postService;

        private CommentCollection _comments;

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

        public void Activate(object parameter)
        {
            var post = (Post)parameter;
            Comments = new CommentCollection(post.PostId, _postService);
        }

        public void Deactivate(object parameter)
        {
        }
    }
}