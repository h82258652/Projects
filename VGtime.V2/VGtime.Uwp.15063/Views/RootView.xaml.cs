using System;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight.Messaging;
using VGtime.Uwp.Controls;
using VGtime.Uwp.Messages;

namespace VGtime.Uwp.Views
{
    public sealed partial class RootView
    {
        public RootView()
        {
            InitializeComponent();

            var welcomeView = new WelcomeView();
            EventHandler initializeCompletedHandler = null;
            initializeCompletedHandler = async (sender, e) =>
            {
                welcomeView.InitializeCompleted -= initializeCompletedHandler;
                RootFrame.Navigate(typeof(MainView));
                await welcomeView.DismissAsync();
                RootGrid.Children.Remove(welcomeView);
            };
            welcomeView.InitializeCompleted += initializeCompletedHandler;
            RootGrid.Children.Add(welcomeView);
        }

        private void RootView_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Register<ShowChooseShareDialogMessage>(this, message =>
            {
                var chooseShareDialog = new ChooseShareDialog();
                ChooseShareDialogHost.Content = chooseShareDialog;
                chooseShareDialog.Show();
            });
            Messenger.Default.Register<HideChooseShareDialogMessage>(this, async message =>
            {
                if (ChooseShareDialogHost.Content is IDialog dialog)
                {
                    await dialog.HideAsync();
                }
                ChooseShareDialogHost.Content = null;
            });
        }

        private void RootView_Unloaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Unregister(this);
        }
    }
}