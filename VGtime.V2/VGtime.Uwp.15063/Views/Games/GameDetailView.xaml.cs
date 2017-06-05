using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Messaging;
using VGtime.Uwp.Messages;
using VGtime.Uwp.ViewModels.Games;

namespace VGtime.Uwp.Views.Games
{
    public sealed partial class GameDetailView
    {
        public GameDetailView()
        {
            InitializeComponent();
        }

        public GameDetailViewModel ViewModel => (GameDetailViewModel)DataContext;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Messenger.Default.Register<SinaWeiboShareSelectedMessage>(this, message =>
            {
                ViewModel.SinaWeiboShareCommand.Execute(null);
            });
            Messenger.Default.Register<SystemShareSelectedMessage>(this, message =>
            {
                ViewModel.SystemShareCommand.Execute(null);
            });

            var gameId = (int)e.Parameter;
            if (ViewModel.GameId != gameId)
            {
                ViewModel.LoadDetail(gameId);
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            Messenger.Default.Unregister(this);
        }
    }
}