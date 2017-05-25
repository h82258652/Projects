using GalaSoft.MvvmLight;
using VGtime.Configuration;
using VGtime.Services;
using VGtime.Uwp.Data;

namespace VGtime.Uwp.ViewModels
{
    public class CommentViewModel : ViewModelBase
    {
        private readonly IPostService _postService;

        private readonly IVGtimeSettings _vgtimeSettings;

        private CommentCollection _comments;

        public CommentViewModel(IPostService postService, IVGtimeSettings vgtimeSettings)
        {
            _postService = postService;
            _vgtimeSettings = vgtimeSettings;
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

        public int PostId
        {
            get;
            private set;
        }

        public void LoadComments(int postId, int detailType)
        {
            PostId = postId;
            Comments = new CommentCollection(postId, detailType, _postService, _vgtimeSettings);
        }
    }
}