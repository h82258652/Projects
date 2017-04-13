using GalaSoft.MvvmLight.Messaging;
using System;
using U148.Uwp.Messages;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace U148.Uwp.Views
{
    public sealed partial class RootView
    {
        public RootView()
        {
            InitializeComponent();
        }

        public RootView(SplashScreen splashScreen) : this()
        {
            var extendedSplashScreenView = new ExtendedSplashScreenView(splashScreen);
            EventHandler completedHandler = null;
            completedHandler = (sender, e) =>
            {
                extendedSplashScreenView.Completed -= completedHandler;
                RootGrid.Children.Remove(extendedSplashScreenView);
            };
            extendedSplashScreenView.Completed += completedHandler;
            RootGrid.Children.Add(extendedSplashScreenView);
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