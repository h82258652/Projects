using System;
using VGtime.Utils;
using VGtime.Uwp.Views;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace VGtime.Uwp
{
    public sealed partial class App
    {
        public App()
        {
            InitializeComponent();
            Resuming += OnResuming;
            Suspending += OnSuspending;

            UserAgentHelper.SetDefaultUserAgent(Constants.DefaultUserAgent);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            var rootView = Window.Current.Content as RootView;
            if (rootView == null)
            {
                rootView = new RootView();
                rootView.RootFrame.NavigationFailed += OnNavigationFailed;
                Window.Current.Content = rootView;
            }
        }

        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnResuming(object sender, object e)
        {
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            try
            {
            }
            finally
            {
                deferral.Complete();
            }
        }
    }
}