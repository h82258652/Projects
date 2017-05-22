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

        public void XXX()
        {
            // TODO
            Comments = new CommentCollection(0, 0, _postService, _vgtimeSettings);
        }
    }
}