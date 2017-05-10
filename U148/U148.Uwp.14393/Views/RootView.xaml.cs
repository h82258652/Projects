using System;
using GalaSoft.MvvmLight.Messaging;
using U148.Uwp.Messages;
using Windows.UI.Xaml;

namespace U148.Uwp.Views
{
    public sealed partial class RootView
    {
        public RootView()
        {
            InitializeComponent();

            var splashScreenView = new SplashScreenView();
            EventHandler initializeCompletedHandler = null;
            initializeCompletedHandler = async (sender, e) =>
            {
                splashScreenView.InitializeCompleted -= initializeCompletedHandler;
                await splashScreenView.DismissAsync();
                RootGrid.Children.Remove(splashScreenView);
            };
            splashScreenView.InitializeCompleted += initializeCompletedHandler;
            RootGrid.Children.Add(splashScreenView);
        }

        private void RootView_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Register<ShowLoginViewMessage>(this, message =>
            {
                var loginView = new LoginView();
                LoginViewHost.Child = loginView;
                loginView.Show();
            });
            Messenger.Default.Register<HideLoginViewMessage>(this, async message =>
            {
                var loginView = LoginViewHost.Child as LoginView;
                if (loginView != null)
                {
                    await loginView.HideAsync();
                }
                LoginViewHost.Child = null;
            });
        }

        private void RootView_Unloaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Unregister(this);
        }
    }
}