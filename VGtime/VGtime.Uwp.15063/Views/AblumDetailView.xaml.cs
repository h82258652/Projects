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

            var animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("Ablum");
            animation?.TryStart(AblumFlipView);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);

            var selectedIndex = AblumFlipView.SelectedIndex;
            if (selectedIndex >= 0)
            {
                var image = (UIElement)AblumFlipView.ContainerFromIndex(selectedIndex);
                AblumListView.NavigationBackIndex = selectedIndex;
                ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("AblumBack", image);
            }
        }
    }
}