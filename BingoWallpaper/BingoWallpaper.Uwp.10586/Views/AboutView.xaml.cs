using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.AwaitableUI;

namespace BingoWallpaper.Uwp.Views
{
    public sealed partial class AboutView
    {
        public AboutView()
        {
            InitializeComponent();
        }

        protected override async Task PlayEnterAnimationAsync()
        {
            var storyboard = new Storyboard();
            {
                var animation = new DoubleAnimation()
                {
                    From = 0,
                    To = 1,
                    Duration = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new BackEase()
                    {
                        EasingMode = EasingMode.EaseOut,
                        Amplitude = 0.1
                    }
                };
                Storyboard.SetTarget(animation, RootGrid);
                Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(TransformGroup.Children)[1].(ScaleTransform.ScaleX)");
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimation()
                {
                    From = 0,
                    To = 1,
                    Duration = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new BackEase()
                    {
                        EasingMode = EasingMode.EaseOut,
                        Amplitude = 0.1
                    }
                };
                Storyboard.SetTarget(animation, RootGrid);
                Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(TransformGroup.Children)[1].(ScaleTransform.ScaleY)");
                storyboard.Children.Add(animation);
            }
            await storyboard.BeginAsync();
        }

        protected override async Task PlayLeaveAnimationAsync(NavigationMode currentPageNavigationMode)
        {
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation()
            {
                From = 0,
                To = RootGrid.ActualWidth,
                Duration = TimeSpan.FromSeconds(0.4),
                EasingFunction = new BackEase()
                {
                    EasingMode = EasingMode.EaseIn,
                    Amplitude = 0.4
                }
            };
            Storyboard.SetTarget(animation, RootGrid);
            Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(TransformGroup.Children)[0].(TranslateTransform.X)");
            storyboard.Children.Add(animation);
            await storyboard.BeginAsync();
        }
    }
}