using System;
using System.Numerics;
using Windows.Foundation.Metadata;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;
using AppStudio.Uwp.Controls;

namespace VGtime.Uwp.Controls
{
    public sealed partial class HeadpicsControl
    {
        public HeadpicsControl()
        {
            InitializeComponent();

            ConfigureHeadpicsIndicatorAnimation();
        }

        private void ConfigureHeadpicsIndicatorAnimation()
        {
            if (ApiInformation.IsMethodPresent("Windows.UI.Xaml.Hosting.ElementCompositionPreview", nameof(ElementCompositionPreview.GetElementVisual)))
            {
                var compositor = ElementCompositionPreview.GetElementVisual(this).Compositor;

                var showAnimation = compositor.CreateAnimationGroup();
                {
                    var offsetAnimation = compositor.CreateVector3KeyFrameAnimation();
                    offsetAnimation.InsertKeyFrame(0f, new Vector3(12, 0, 0));
                    offsetAnimation.InsertKeyFrame(1f, new Vector3(0, 0, 0));
                    offsetAnimation.Duration = TimeSpan.FromSeconds(0.4);
                    offsetAnimation.Target = nameof(Visual.Offset);

                    var opacityAnimation = compositor.CreateScalarKeyFrameAnimation();
                    opacityAnimation.InsertKeyFrame(0f, 0);
                    opacityAnimation.InsertKeyFrame(1f, 1);
                    opacityAnimation.Duration = TimeSpan.FromSeconds(0.4);
                    opacityAnimation.Target = nameof(Visual.Opacity);

                    showAnimation.Add(offsetAnimation);
                    showAnimation.Add(opacityAnimation);
                }

                var hideAnimation = compositor.CreateAnimationGroup();
                {
                    var offsetAnimation = compositor.CreateVector3KeyFrameAnimation();
                    offsetAnimation.InsertKeyFrame(0f, new Vector3(0, 0, 0));
                    offsetAnimation.InsertKeyFrame(1f, new Vector3(12, 0, 0));
                    offsetAnimation.Duration = TimeSpan.FromSeconds(0.4);
                    offsetAnimation.Target = nameof(Visual.Offset);

                    var opacityAnimation = compositor.CreateScalarKeyFrameAnimation();
                    opacityAnimation.InsertKeyFrame(0f, 1);
                    opacityAnimation.InsertKeyFrame(1f, 0);
                    opacityAnimation.Duration = TimeSpan.FromSeconds(0.4);
                    opacityAnimation.Target = nameof(Visual.Opacity);

                    hideAnimation.Add(offsetAnimation);
                    hideAnimation.Add(opacityAnimation);
                }

                ElementCompositionPreview.SetImplicitShowAnimation(HeadpicsIndicator, showAnimation);
                ElementCompositionPreview.SetImplicitHideAnimation(HeadpicsIndicator, hideAnimation);
            }
        }

        private void HeadpicsCarousel_Loaded(object sender, RoutedEventArgs e)
        {
            var carousel = (Carousel)sender;
            var token = carousel.RegisterPropertyChangedCallback(Carousel.SelectedIndexProperty, (obj, dp) =>
            {
                var selectedIndex = (int)obj.GetValue(dp);
                selectedIndex = Math.Max(0, selectedIndex);
                HeadpicsCarouselSelectedIndexTextControl.Text = (selectedIndex + 1).ToString();
            });
            carousel.Unloaded += delegate
            {
                carousel.UnregisterPropertyChangedCallback(Carousel.SelectedIndexProperty, token);
            };
            {
                var selectedIndex = carousel.SelectedIndex;
                selectedIndex = Math.Max(0, selectedIndex);
                HeadpicsCarouselSelectedIndexTextControl.Text = (selectedIndex + 1).ToString();
            }
        }

        private void HeadpicsControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width <= 640)
            {
                HeadpicsIndicator.Visibility = Visibility.Visible;
            }
            else
            {
                HeadpicsIndicator.Visibility = Visibility.Collapsed;
            }
        }
    }
}