using System;
using Windows.ApplicationModel.Activation;

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
    }
}