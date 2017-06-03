using System;
using Windows.UI.Xaml.Controls;
using VGtime.Uwp.Controls;
using VGtime.Uwp.ViewModels;
using WinRTXamlToolkit.Controls.Extensions;

namespace VGtime.Uwp.Views
{
    public sealed partial class SearchView
    {
        public SearchView()
        {
            InitializeComponent();
        }

        public SearchViewModel ViewModel => (SearchViewModel)DataContext;

        private async void RootPivot_SelectedHeaderItemClick(object sender, VGtimePivotSelectedHeaderItemClickEventArgs args)
        {
            ScrollViewer scrollViewer;
            switch (RootPivot.SelectedIndex)
            {
                case 0:
                    scrollViewer = ArticlesGridView.GetScrollViewer();
                    if (scrollViewer.VerticalOffset <= 0)
                    {
                        ViewModel.Articles?.Refresh();
                    }
                    else
                    {
                        await scrollViewer.ScrollToVerticalOffsetWithAnimationAsync(0, TimeSpan.FromMilliseconds(200));
                    }
                    break;

                case 1:
                    scrollViewer = ForumsGridView.GetScrollViewer();
                    if (scrollViewer.VerticalOffset <= 0)
                    {
                        ViewModel.Forums?.Refresh();
                    }
                    else
                    {
                        await scrollViewer.ScrollToVerticalOffsetWithAnimationAsync(0, TimeSpan.FromMilliseconds(200));
                    }
                    break;

                case 2:
                    scrollViewer = UsersGridView.GetScrollViewer();
                    if (scrollViewer.VerticalOffset <= 0)
                    {
                        ViewModel.Users?.Refresh();
                    }
                    else
                    {
                        await scrollViewer.ScrollToVerticalOffsetWithAnimationAsync(0, TimeSpan.FromMilliseconds(200));
                    }
                    break;

                case 3:

                    scrollViewer = GamesGridView.GetScrollViewer();
                    if (scrollViewer.VerticalOffset <= 0)
                    {
                        ViewModel.Games?.Refresh();
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