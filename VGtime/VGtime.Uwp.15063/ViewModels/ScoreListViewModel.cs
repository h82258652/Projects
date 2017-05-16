using GalaSoft.MvvmLight;
using SoftwareKobo.ViewModels;
using VGtime.Services;
using VGtime.Uwp.Data;

namespace VGtime.Uwp.ViewModels
{
    public class ScoreListViewModel : ViewModelBase, INavigable
    {
        private readonly IPostService _postService;

        private ScoreInfoCollection _scoreInfos;

        public ScoreListViewModel(IPostService postService)
        {
            _postService = postService;
        }

        public ScoreInfoCollection ScoreInfos
        {
            get
            {
                return _scoreInfos;
            }
            private set
            {
                Set(ref _scoreInfos, value);
            }
        }

        public void Activate(object parameter)
        {
            var gameId = (int)parameter;

            ScoreInfos = new ScoreInfoCollection(gameId, _postService);
        }

        public void Deactivate(object parameter)
        {
        }
    }
}