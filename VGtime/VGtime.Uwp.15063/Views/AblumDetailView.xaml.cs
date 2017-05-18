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
    }
}