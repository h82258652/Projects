using System;
using System.Linq;
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

        private void HamburgerMenuButton_Click(object sender, RoutedEventArgs e)
        {
            var mainView = this.GetFirstAncestorOfType<MainView>();
            var hamburgerMenu = mainView.GetDescendantsOfType<SplitView>().FirstOrDefault(temp => temp.Name == "HamburgerMenu");
            hamburgerMenu.IsPaneOpen = true;
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