using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using VGtime.Configuration;
using VGtime.Models.Timeline;
using VGtime.Services;
using VGtime.Uwp.Data;
using VGtime.Uwp.ViewParameters;

namespace VGtime.Uwp.ViewModels
{
    public class CommentViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private readonly IPostService _postService;

        private readonly IVGtimeSettings _vgtimeSettings;

        private RelayCommand<TimeLineBase> _commentClickCommand;

        private CommentCollection _comments;

        public CommentViewModel(IPostService postService, IVGtimeSettings vgtimeSettings, INavigationService navigationService)
        {
            _postService = postService;
            _vgtimeSettings = vgtimeSettings;
            _navigationService = navigationService;
        }

        public RelayCommand<TimeLineBase> CommentClickCommand
        {
            get
            {
                _commentClickCommand = _commentClickCommand ?? new RelayCommand<TimeLineBase>(comment =>
                {
                    _navigationService.NavigateTo(ViewModelLocator.ArticleDetailViewKey, new ArticleDetailViewParameter(comment.PostId, comment.DetailType));
                });
                return _commentClickCommand;
            }
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