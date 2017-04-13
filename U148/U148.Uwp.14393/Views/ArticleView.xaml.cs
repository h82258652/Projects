using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Controls.Extensions;

namespace U148.Uwp.Views
{
    public sealed partial class ArticleView : Page
    {
        public ArticleView()
        {
            InitializeComponent();
        }

        private async void ScrollToTopButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ArticlePivot.SelectedItem;
            // TODO var name
            if (selectedItem != null)
            {
                var pivotItem = ArticlePivot.ContainerFromItem(selectedItem);
                var itemsControl = pivotItem?.GetFirstDescendantOfType<ItemsControl>();
                var scrollViewer = itemsControl?.GetScrollViewer();
                if (scrollViewer != null)
                {
                    await scrollViewer.ScrollToHorizontalOffsetWithAnimationAsync(0, TimeSpan.FromMilliseconds(200));
                }
            }
        }
    }
}