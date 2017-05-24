using Windows.UI.Xaml.Navigation;

namespace VGtime.Uwp.Views.Games
{
    public sealed partial class GameScoreView
    {
        public GameScoreView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var gameId = (int)e.Parameter;
        }
    }
}