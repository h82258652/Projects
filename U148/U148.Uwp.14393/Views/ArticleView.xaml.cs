using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Messaging;
using U148.Uwp.Messages;
using WinRTXamlToolkit.Controls.Extensions;

namespace U148.Uwp.Views
{
    public sealed partial class ArticleView
    {
        public ArticleView()
        {
            InitializeComponent();
        }

        private void HamburgerMenuButton_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send(new OpenHamburgerMenuMessage());
        }

        private async void ScrollToTopButton_Click(object sender, RoutedEventArgs e)
        {
            var articlePivotSelectedItem = ArticlePivot.SelectedItem;
            if (articlePivotSelectedItem != null)
            {
                var pivotItem = ArticlePivot.ContainerFromItem(articlePivotSelectedItem);
                var itemsControl = pivotItem?.GetFirstDescendantOfType<ItemsControl>();
                var scrollViewer = itemsControl?.GetScrollViewer();
                if (scrollViewer != null)
                {
                    await scrollViewer.ScrollToVerticalOffsetWithAnimationAsync(0, TimeSpan.FromMilliseconds(200));
                }
            }
        }
    }
}