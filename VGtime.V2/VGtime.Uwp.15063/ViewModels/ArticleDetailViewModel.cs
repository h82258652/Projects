using GalaSoft.MvvmLight;
using VGtime.Services;

namespace VGtime.Uwp.ViewModels
{
    public class ArticleDetailViewModel : ViewModelBase
    {
        public ArticleDetailViewModel(IPostService postService)
        {
            _postService = postService;
        }

        public void X()
        {
            //_postService.GetDetailAsync();
        }

        // input
        public int _postId;

        // input
        public int _type;

        // input
        public int _page;

        private readonly IPostService _postService;
    }
}