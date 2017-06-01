using VGtime.Uwp.ViewModels.Settings;

namespace VGtime.Uwp.Views.Settings
{
    public sealed partial class AboutView
    {
        public AboutView()
        {
            InitializeComponent();
        }

        public AboutViewModel ViewModel => (AboutViewModel)DataContext;
    }
}