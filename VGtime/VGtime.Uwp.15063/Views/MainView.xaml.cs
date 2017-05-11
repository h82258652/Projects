using System;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Controls.Extensions;

namespace VGtime.Uwp.Views
{
    public sealed partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void HeadPostsCarousel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var headPostsIndicator = ((DependencyObject)sender).GetSiblings().OfType<FrameworkElement>().FirstOrDefault(temp => temp.Name == "HeadPostsIndicator");
            if (headPostsIndicator != null)
            {
                if (e.NewSize.Width <= 640)
                {
                    headPostsIndicator.Visibility = Visibility.Visible;
                }
                else
                {
                    headPostsIndicator.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void VideoPostsGridView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var itemsControl = (ItemsControl)sender;
            var itemsWrapGrid = (ItemsWrapGrid)itemsControl.ItemsPanelRoot;
            Debug.Assert(itemsWrapGrid != null);
            var width = e.NewSize.Width - itemsControl.Padding.Left;
            var column = Math.Ceiling(width / 640);
            itemsWrapGrid.ItemWidth = width / column;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OldStrategyView));
        }
    }
}