using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using VGtime.Uwp.ViewModels.Image;
using VGtime.Uwp.ViewParameters;

namespace VGtime.Uwp.Views.Image
{
    public sealed partial class ImagePagerView
    {
        public ImagePagerView()
        {
            InitializeComponent();
        }

        public ImagePagerViewModel ViewModel => (ImagePagerViewModel)DataContext;

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            var parameter = (ImagePagerViewParameter)e.Parameter;
            Debug.Assert(parameter != null);
            parameter.SelectedIndex = PhotosFlipView.SelectedIndex;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameter = (ImagePagerViewParameter)e.Parameter;
            Debug.Assert(parameter != null);
            ViewModel.Photos = parameter.Photos;
            PhotosFlipView.SelectedIndex = parameter.SelectedIndex;
        }

        private void PhotosFlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PhotosFlipViewIndexTextControl.Text = (PhotosFlipView.SelectedIndex + 1).ToString();
        }
    }
}