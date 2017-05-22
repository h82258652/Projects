using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using VGtime.Uwp.ViewModels;
using WinRTXamlToolkit.AwaitableUI;

namespace VGtime.Uwp.Views
{
    public sealed partial class WelcomeView
    {
        private readonly TaskCompletionSource<object> _logoImageOpenedTcs = new TaskCompletionSource<object>();

        private readonly TaskCompletionSource<object> _welcomeImageOpenedTcs = new TaskCompletionSource<object>();

        public WelcomeView()
        {
            InitializeComponent();
        }

        public event EventHandler InitializeCompleted;

        public WelcomeViewModel ViewModel => (WelcomeViewModel)DataContext;

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
        }

        private void LogoImage_ImageOpened(object sender, RoutedEventArgs e)
        {
            _logoImageOpenedTcs.SetResult(null);
        }

        private void WelcomeImage_ImageOpened(object sender, RoutedEventArgs e)
        {
            _welcomeImageOpenedTcs.SetResult(null);
        }

        private void WelcomeImage_Loaded(object sender, RoutedEventArgs e)
        {
            if (ViewModel.StartPicture == null)
            {
                _welcomeImageOpenedTcs.SetResult(null);
            }
        }

        private async void WelcomeView_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.WhenAll(_welcomeImageOpenedTcs.Task, _logoImageOpenedTcs.Task);

            InitializeTitleBar();

            Window.Current.Activate();

            await Task.Delay(TimeSpan.FromSeconds(1));

            InitializeCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
}