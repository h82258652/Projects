using System;
using Windows.ApplicationModel.Activation;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace U148.Uwp.Views
{
    public sealed partial class ExtendedSplashScreenView
    {
        private readonly SplashScreen _splashScreen;

        public ExtendedSplashScreenView()
        {
            InitializeComponent();
        }

        public ExtendedSplashScreenView(SplashScreen splashScreen) : this()
        {
            _splashScreen = splashScreen;
        }

        public event EventHandler Completed;

        private static void InitializeTitleBar()
        {
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            var accentColor = (Color)Application.Current.Resources["U148AccentColor"];
            titleBar.BackgroundColor = accentColor;
            titleBar.ButtonBackgroundColor = accentColor;
        }

        private void SplashScreenImage_ImageOpened(object sender, RoutedEventArgs e)
        {
            Window.Current.Activate();

            InitializeTitleBar();

            Completed?.Invoke(this, EventArgs.Empty);
        }
    }
}