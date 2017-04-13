using System;
using Windows.ApplicationModel.Activation;

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
    }
}