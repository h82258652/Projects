using System;
using Windows.UI.Xaml;
using AppStudio.Uwp.Controls;

namespace VGtime.Uwp.Controls
{
    public sealed partial class HeadpicsControl
    {
        public HeadpicsControl()
        {
            InitializeComponent();
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
    }
}