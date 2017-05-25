using VGtime.Uwp.ViewModels.Settings;

namespace VGtime.Uwp.Views.Settings
{
    public sealed partial class SettingView
    {
        public SettingView()
        {
            InitializeComponent();
        }

        public SettingViewModel ViewModel => (SettingViewModel)DataContext;
    }
}