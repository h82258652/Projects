using System;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.AwaitableUI;

namespace BingoWallpaper.Uwp.Views
{
    public sealed partial class SettingView
    {
        public SettingView()
        {
            InitializeComponent();
        }

        protected override async Task PlayEnterAnimationAsync()
        {
            var storyboard = new Storyboard();
            {
                var animation = new DoubleAnimation()
                {
                    From = -72,
                    To = 0,
                    Duration = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new BackEase()
                    {
                        EasingMode = EasingMode.EaseOut,
                        Amplitude = 0.5
                    }
                };
                Storyboard.SetTarget(animation, GearBackgroundControl);
                Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(TranslateTransform.X)");
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimation()
                {
                    From = -72,
                    To = 0,
                    Duration = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new BackEase()
                    {
                        EasingMode = EasingMode.EaseOut,
                        Amplitude = 0.5
                    }
                };
                Storyboard.SetTarget(animation, GearBackgroundControl);
                Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(TranslateTransform.Y)");
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
                        Amplitude = 0.4
                    }
                };
                Storyboard.SetTarget(animation, ContentBackgroundRectangle);
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
                        Amplitude = 0.4
                    }
                };
                Storyboard.SetTarget(animation, ContentBackgroundRectangle);
                Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(TransformGroup.Children)[1].(ScaleTransform.ScaleY)");
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimation()
                {
                    From = 0,
                    To = 1,
                    Duration = TimeSpan.FromSeconds(0.4)
                };
                Storyboard.SetTarget(animation, ContentGrid);
                Storyboard.SetTargetProperty(animation, "Opacity");
                storyboard.Children.Add(animation);
            }
            await storyboard.BeginAsync();
        }

        protected override async Task PlayLeaveAnimationAsync(NavigationMode currentPageNavigationMode)
        {
            var storyboard = new Storyboard();
            {
                var animation = new ColorAnimation()
                {
                    From = Color.FromArgb(0xFF, 0xE3, 0xE3, 0xE3),
                    To = Colors.Transparent,
                    Duration = TimeSpan.FromSeconds(0.3),
                    BeginTime = TimeSpan.FromSeconds(0.3)
                };
                Storyboard.SetTarget(animation, BackgroundGrid);
                Storyboard.SetTargetProperty(animation, "(UIElement.Background).(SolidColorBrush.Color)");
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimation()
                {
                    To = -72,
                    Duration = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new BackEase()
                    {
                        EasingMode = EasingMode.EaseIn,
                        Amplitude = 0.5
                    }
                };
                Storyboard.SetTarget(animation, GearBackgroundControl);
                Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(TranslateTransform.X)");
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimation()
                {
                    To = -72,
                    Duration = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new BackEase()
                    {
                        EasingMode = EasingMode.EaseIn,
                        Amplitude = 0.5
                    }
                };
                Storyboard.SetTarget(animation, GearBackgroundControl);
                Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(TranslateTransform.Y)");
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimation()
                {
                    EnableDependentAnimation = true,
                    From = ContentBackgroundRectangle.ActualWidth,
                    To = 40,
                    Duration = TimeSpan.FromSeconds(0.25)
                };
                Storyboard.SetTarget(animation, ContentBackgroundRectangle);
                Storyboard.SetTargetProperty(animation, "Width");
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimation()
                {
                    EnableDependentAnimation = true,
                    From = ContentBackgroundRectangle.ActualHeight,
                    To = 40,
                    Duration = TimeSpan.FromSeconds(0.25)
                };
                Storyboard.SetTarget(animation, ContentBackgroundRectangle);
                Storyboard.SetTargetProperty(animation, "Height");
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimation()
                {
                    EnableDependentAnimation = true,
                    To = 20,
                    Duration = TimeSpan.FromSeconds(0.25)
                };
                Storyboard.SetTarget(animation, ContentBackgroundRectangle);
                Storyboard.SetTargetProperty(animation, "RadiusX");
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimation()
                {
                    EnableDependentAnimation = true,
                    To = 20,
                    Duration = TimeSpan.FromSeconds(0.25)
                };
                Storyboard.SetTarget(animation, ContentBackgroundRectangle);
                Storyboard.SetTargetProperty(animation, "RadiusY");
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimation()
                {
                    From = 0,
                    To = ActualHeight / 2 + 40,
                    Duration = TimeSpan.FromSeconds(0.55),
                    EasingFunction = new BackEase()
                    {
                        EasingMode = EasingMode.EaseIn,
                        Amplitude = 0.75
                    }
                };
                Storyboard.SetTarget(animation, ContentBackgroundRectangle);
                Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(TransformGroup.Children)[0].(TranslateTransform.Y)");
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimation()
                {
                    From = 1,
                    To = 0,
                    Duration = TimeSpan.FromSeconds(0.2)
                };
                Storyboard.SetTarget(animation, ContentGrid);
                Storyboard.SetTargetProperty(animation, "Opacity");
                storyboard.Children.Add(animation);
            }
            await storyboard.BeginAsync();
        }
    }
}