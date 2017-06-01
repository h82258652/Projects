using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using VGtime.Uwp.ViewModels.Image;
using VGtime.Uwp.ViewParameters;

namespace VGtime.Uwp.Views.Image
{
    public sealed partial class ImagePagerView
    {
        private ImagePagerViewParameter _viewParameter;

        public ImagePagerView()
        {
            InitializeComponent();
        }

        public ImagePagerViewModel ViewModel => (ImagePagerViewModel)DataContext;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _viewParameter = (ImagePagerViewParameter)e.Parameter;
            Debug.Assert(_viewParameter != null);
            ViewModel.Photos = _viewParameter.Photos;
            var photoIndex = _viewParameter.PhotoIndex;
            ViewModel.SelectedIndex = photoIndex;

            var connectedAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("GamePhotoView");
            if (connectedAnimation != null)
            {
                connectedAnimation.TryStart(PhotosFlipView);
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);

            _viewParameter.PhotoIndex = PhotosFlipView.SelectedIndex;
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("ImagePagerView", PhotosFlipView);
        }

        private void PhotosFlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PhotosFlipViewIndexTextControl.Text = (PhotosFlipView.SelectedIndex + 1).ToString();
        }
    }
}