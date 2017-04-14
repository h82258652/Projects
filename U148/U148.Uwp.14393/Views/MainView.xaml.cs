using Windows.UI.Xaml;
using GalaSoft.MvvmLight.Messaging;
using U148.Uwp.Messages;

namespace U148.Uwp.Views
{
    public sealed partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void LoginMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send(new ShowLoginViewMessage());
        }
    }
}