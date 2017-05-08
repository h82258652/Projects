using System;
using System.Collections;
using System.Diagnostics;
using System.Threading.Tasks;
using BingoWallpaper.Models.LeanCloud;
using BingoWallpaper.Uwp.Services;
using BingoWallpaper.Uwp.ViewModels;
using SoftwareKobo.Controls;
using Windows.Devices.Input;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.AwaitableUI;

namespace BingoWallpaper.Uwp.Views
{
    public sealed partial class DetailView
    {
        public DetailView()
        {
            InitializeComponent();
        }

        public DetailViewModel ViewModel => (DetailViewModel)DataContext;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameter = (IDictionary)e.Parameter;
            Debug.Assert(parameter != null);
            ViewModel.Wallpaper = (Wallpaper)parameter["Wallpaper"];
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            if (ViewModel.IsBusy)
            {
                e.Cancel = true;
            }
            else if (OriginalWallpaperGrid.Visibility == Visibility.Visible)
            {
                HideOriginalWallpaperScrollViewerStoryboard.Begin();
                e.Cancel = true;
            }

            base.OnNavigatingFrom(e);
        }

        protected override async Task PlayLeaveAnimationAsync(NavigationMode currentPageNavigationMode)
        {
            var storyboard = new Storyboard();
            {
                var animation = new DoubleAnimation()
                {
                    From = 1,
                    To = 0,
                    Duration = TimeSpan.FromSeconds(0.4)
                };
                Storyboard.SetTarget(animation, TitleGrid);
                Storyboard.SetTargetProperty(animation, "Opacity");
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimation()
                {
                    From = 0,
                    To = -30,
                    Duration = TimeSpan.FromSeconds(0.4),
                    EasingFunction = new QuinticEase()
                    {
                        EasingMode = EasingMode.EaseOut
                    }
                };
                Storyboard.SetTarget(animation, TitleGrid);
                Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(TranslateTransform.Y)");
                storyboard.Children.Add(animation);
            }
            {
                var animation = new ColorAnimation()
                {
                    From = Color.FromArgb(0xFF, 0xE3, 0xE3, 0xE3),
                    To = Colors.Transparent,
                    Duration = TimeSpan.FromSeconds(0.4)
                };
                Storyboard.SetTarget(animation, BackgroundGrid);
                Storyboard.SetTargetProperty(animation, "(Panel.Background).(SolidColorBrush.Color)");
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimationUsingKeyFrames();
                animation.KeyFrames.Add(new DiscreteDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0),
                    Value = 1
                });
                animation.KeyFrames.Add(new LinearDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0.15),
                    Value = 1.05
                });
                animation.KeyFrames.Add(new EasingDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0.4),
                    Value = 0,
                    EasingFunction = new QuadraticEase()
                    {
                        EasingMode = EasingMode.EaseOut
                    }
                });
                Storyboard.SetTarget(animation, ThumbnailImageGrid);
                Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(ScaleTransform.ScaleX)");
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimationUsingKeyFrames();
                animation.KeyFrames.Add(new DiscreteDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0),
                    Value = 1
                });
                animation.KeyFrames.Add(new LinearDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0.15),
                    Value = 1.05
                });
                animation.KeyFrames.Add(new EasingDoubleKeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0.4),
                    Value = 0,
                    EasingFunction = new QuadraticEase()
                    {
                        EasingMode = EasingMode.EaseOut
                    }
                });
                Storyboard.SetTarget(animation, ThumbnailImageGrid);
                Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(ScaleTransform.ScaleY)");
                storyboard.Children.Add(animation);
            }
            {
                var animation = new DoubleAnimation()
                {
                    From = 1,
                    To = 0,
                    Duration = TimeSpan.FromSeconds(0.4)
                };
                Storyboard.SetTarget(animation, AppBar);
                Storyboard.SetTargetProperty(animation, "Opacity");
                storyboard.Children.Add(animation);
            }
            await storyboard.BeginAsync();
        }

        private void DetailView_Loaded(object sender, RoutedEventArgs e)
        {
            //await Task.Delay(TimeSpan.FromSeconds(0.2));
            //await EllipseMask.LightOnAsync();
        }

        private void ThumbnailImage_ImageFailed(object sender, ImageFailedEventArgs e)
        {
            new AppToastService().ShowError(LocalizedStrings.LoadImageFailed);
        }

        private void ThumbnailImageGrid_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            var pointerPoint = e.GetCurrentPoint(null);
            var pointerDevice = pointerPoint.PointerDevice;
            if (pointerDevice.PointerDeviceType == PointerDeviceType.Mouse && pointerPoint.Properties.PointerUpdateKind != PointerUpdateKind.LeftButtonReleased)
            {
                return;
            }

            e.Handled = true;
            ShowOriginalWallpaperScrollViewerStoryboard.Begin();
        }
    }
}