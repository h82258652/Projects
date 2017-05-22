using System;

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
    }
}