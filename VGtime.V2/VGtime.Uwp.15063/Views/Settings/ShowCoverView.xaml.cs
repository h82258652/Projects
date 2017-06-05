using Windows.UI.Xaml.Navigation;
using VGtime.Uwp.ViewModels.Settings;

namespace VGtime.Uwp.Views.Settings
{
    public sealed partial class ShowCoverView
    {
        public ShowCoverView()
        {
            InitializeComponent();
        }

        public ShowCoverViewModel ViewModel => (ShowCoverViewModel)DataContext;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (string.IsNullOrEmpty(ViewModel.StartPicture))
            {
                ViewModel.LoadStartPicture();
            }
        }
    }
}