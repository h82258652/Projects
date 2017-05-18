using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace VGtime.Uwp.Views
{
    public sealed partial class AblumDetailView
    {
        public AblumDetailView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("Album");
            animation?.TryStart(AlbumFlipView);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);

            var selectedIndex = AlbumFlipView.SelectedIndex;
            if (selectedIndex >= 0)
            {
                var image = (UIElement)AlbumFlipView.ContainerFromIndex(selectedIndex);
                AblumListView.NavigationBackIndex = selectedIndex;
                ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("AlbumBack", image);
            }
        }
    }
}