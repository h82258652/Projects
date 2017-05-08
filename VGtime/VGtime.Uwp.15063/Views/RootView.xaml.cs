using System;

namespace VGtime.Uwp.Views
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
                RootFrame.Navigate(typeof(MainView));
                await splashScreenView.DismissAsync();
                RootGrid.Children.Remove(splashScreenView);
            };
            splashScreenView.InitializeCompleted += initializeCompletedHandler;
            RootGrid.Children.Add(splashScreenView);
        }
    }
}