using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VGtime.Uwp.Controls;
using VGtime.Uwp.ViewModels;
using WinRTXamlToolkit.AwaitableUI;
using WinRTXamlToolkit.Controls.Extensions;

namespace VGtime.Uwp.Views
{
    public sealed partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        public MainViewModel ViewModel => (MainViewModel)DataContext;

        private async void RootPivot_Loaded(object sender, RoutedEventArgs e)
        {
            // Hack fix.
            RootPivot.Width = RootPivot.ActualWidth + 1;
            await RootPivot.WaitForLayoutUpdateAsync();
            RootPivot.Width = double.NaN;
        }

        private async void RootPivot_SelectedHeaderItemClick(object sender, VGtimePivotSelectedHeaderItemClickEventArgs args)
        {
            ScrollViewer scrollViewer;
            switch (RootPivot.SelectedIndex)
            {
                case 0:
                    scrollViewer = VglistPostsGridView.GetScrollViewer();
                    if (scrollViewer.VerticalOffset <= 0)
                    {
                        ViewModel.VglistPosts.Refresh();
                    }
                    else
                    {
                        await scrollViewer.ScrollToVerticalOffsetWithAnimationAsync(0, TimeSpan.FromMilliseconds(200));
                    }
                    break;

                case 1:
                    scrollViewer = NewsPostsGridView.GetScrollViewer();
                    if (scrollViewer.VerticalOffset <= 0)
                    {
                        ViewModel.NewsPosts.Refresh();
                    }
                    else
                    {
                        await scrollViewer.ScrollToVerticalOffsetWithAnimationAsync(0, TimeSpan.FromMilliseconds(200));
                    }
                    break;

                case 2:
                    scrollViewer = EvaluationPostsGridView.GetScrollViewer();
                    if (scrollViewer.VerticalOffset <= 0)
                    {
                        ViewModel.EvaluationPosts.Refresh();
                    }
                    else
                    {
                        await scrollViewer.ScrollToVerticalOffsetWithAnimationAsync(0, TimeSpan.FromMilliseconds(200));
                    }
                    break;

                case 3:
                    scrollViewer = VideoPostsGridView.GetScrollViewer();
                    if (scrollViewer.VerticalOffset <= 0)
                    {
                        ViewModel.VideoPosts.Refresh();
                    }
                    else
                    {
                        await scrollViewer.ScrollToVerticalOffsetWithAnimationAsync(0, TimeSpan.FromMilliseconds(200));
                    }
                    break;

                case 4:
                    scrollViewer = StrategyPostsGridView.GetScrollViewer();
                    if (scrollViewer.VerticalOffset <= 0)
                    {
                        ViewModel.StrategyPosts.Refresh();
                    }
                    else
                    {
                        await scrollViewer.ScrollToVerticalOffsetWithAnimationAsync(0, TimeSpan.FromMilliseconds(200));
                    }
                    break;

                case 5:
                    scrollViewer = TopicPostsGridView.GetScrollViewer();
                    if (scrollViewer.VerticalOffset <= 0)
                    {
                        ViewModel.TopicPosts.Refresh();
                    }
                    else
                    {
                        await scrollViewer.ScrollToVerticalOffsetWithAnimationAsync(0, TimeSpan.FromMilliseconds(200));
                    }
                    break;
            }
        }
    }
}