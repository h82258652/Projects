using GalaSoft.MvvmLight.Messaging;
using U148.Uwp.Messages;
using Windows.UI.Xaml;

namespace U148.Uwp.Views
{
    public sealed partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Register<OpenHamburgerMenuMessage>(this, message =>
            {
                HamburgerMenu.IsPaneOpen = true;
            });
        }

        private void MainView_Unloaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Unregister(this);
        }
    }
}