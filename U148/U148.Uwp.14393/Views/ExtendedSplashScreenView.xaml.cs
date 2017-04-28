using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using WinRTXamlToolkit.AwaitableUI;

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
            var accentColor = (Color)Application.Current.Resources["U148AccentColor"];
            titleBar.BackgroundColor = accentColor;
            titleBar.ButtonBackgroundColor = accentColor;
            titleBar.InactiveBackgroundColor = accentColor;
            titleBar.ButtonInactiveBackgroundColor = accentColor;
        }

        private async Task ShowSplashScreenImageAsync()
        {
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.4)
            };
            Storyboard.SetTarget(animation, SplashScreenImage);
            Storyboard.SetTargetProperty(animation, "Opacity");
            storyboard.Children.Add(animation);
            await storyboard.BeginAsync();
        }

        private async void SplashScreenImage_ImageOpened(object sender, RoutedEventArgs e)
        {
            InitializeTitleBar();

            Window.Current.Activate();

            await ShowSplashScreenImageAsync();

            await Task.Delay(TimeSpan.FromSeconds(1));

            Completed?.Invoke(this, EventArgs.Empty);
        }
    }
}