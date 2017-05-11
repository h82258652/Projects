using System;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using VGtime.Uwp.ViewModels;
using WinRTXamlToolkit.AwaitableUI;

namespace VGtime.Uwp.Views
{
    public sealed partial class SplashScreenView
    {
        private readonly TaskCompletionSource<object> _logoImageOpenedTcs = new TaskCompletionSource<object>();

        private readonly TaskCompletionSource<object> _splashScreenImageOpenedTcs = new TaskCompletionSource<object>();

        public SplashScreenView()
        {
            InitializeComponent();
        }

        public event EventHandler InitializeCompleted;

        public SplashScreenViewModel ViewModel
        {
            get { return (SplashScreenViewModel)DataContext; }
        }

        public async Task DismissAsync()
        {
            var storyboard = new Storyboard();
            {
                var animation = new DoubleAnimation()
                {
                    From = 1,
                    To = 0,
                    Duration = TimeSpan.FromSeconds(0.4)
                };
                Storyboard.SetTarget(animation, RootGrid);
                Storyboard.SetTargetProperty(animation, "Opacity");
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimation()
                {
                    From = 1,
                    To = 1.3,
                    Duration = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new ExponentialEase()
                    {
                        EasingMode = EasingMode.EaseOut,
                        Exponent = 5
                    }
                };
                Storyboard.SetTarget(animation, RootGrid);
                Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(ScaleTransform.ScaleX)");
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimation()
                {
                    From = 1,
                    To = 1.3,
                    Duration = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new ExponentialEase()
                    {
                        EasingMode = EasingMode.EaseOut,
                        Exponent = 5
                    }
                };
                Storyboard.SetTarget(animation, RootGrid);
                Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(ScaleTransform.ScaleY)");
                storyboard.Children.Add(animation);
            }
            await storyboard.BeginAsync();
        }

        private static void InitializeTitleBar()
        {
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            var accentColor = (Color)Application.Current.Resources["VGtimeAccentColor"];
            var accentLightColor = (Color)Application.Current.Resources["VGtimeAccentLightColor"];
            var accentDarkColor = (Color)Application.Current.Resources["VGtimeAccentDarkColor"];
            titleBar.BackgroundColor = accentColor;
            titleBar.ForegroundColor = Colors.White;
            titleBar.InactiveBackgroundColor = accentColor;
            titleBar.InactiveForegroundColor = Colors.White;
            titleBar.ButtonBackgroundColor = accentColor;
            titleBar.ButtonForegroundColor = Colors.White;
            titleBar.ButtonHoverBackgroundColor = accentLightColor;
            titleBar.ButtonHoverForegroundColor = Colors.White;
            titleBar.ButtonPressedBackgroundColor = accentDarkColor;
            titleBar.ButtonPressedForegroundColor = Colors.White;
            titleBar.ButtonInactiveBackgroundColor = accentColor;
            titleBar.ButtonInactiveForegroundColor = Colors.White;
        }

        private void LogoImage_ImageOpened(object sender, RoutedEventArgs e)
        {
            _logoImageOpenedTcs.SetResult(null);
        }

        private void SplashScreenImage_ImageOpened(object sender, RoutedEventArgs e)
        {
            _splashScreenImageOpenedTcs.SetResult(null);
        }

        private void SplashScreenImage_Loaded(object sender, RoutedEventArgs e)
        {
            if (ViewModel.StartPicture == null)
            {
                _splashScreenImageOpenedTcs.SetResult(null);
            }
        }

        private async void SplashScreenView_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.WhenAll(_splashScreenImageOpenedTcs.Task, _logoImageOpenedTcs.Task);

            InitializeTitleBar();

            Window.Current.Activate();

            await Task.Delay(TimeSpan.FromSeconds(1));

            InitializeCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
}