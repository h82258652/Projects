using Windows.UI.Xaml.Navigation;
using VGtime.Uwp.ViewModels.Games;

namespace VGtime.Uwp.Views.Games
{
    public sealed partial class GamePhotoView
    {
        public GamePhotoView()
        {
            InitializeComponent();
        }

        public GamePhotoViewModel ViewModel => (GamePhotoViewModel)DataContext;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            int gameId = (int)e.Parameter;
            if (ViewModel.GameId != gameId)
            {
                ViewModel.LoadPhotos(gameId);
            }
        }
    }
}