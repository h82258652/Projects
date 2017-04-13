using System;
using Windows.ApplicationModel.Activation;
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

        private void SplashScreenImage_ImageOpened(object sender, RoutedEventArgs e)
        {
            Window.Current.Activate();

            Completed?.Invoke(this, EventArgs.Empty);
        }
    }
}