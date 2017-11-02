using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using BingoWallpaper.Extensions;

namespace BingoWallpaper.Behaviors
{
    public class ScrollViewerReachBottomTrigger : TriggerBase<UIElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            var scrollViewer = AssociatedObject as ScrollViewer ?? AssociatedObject.GetFirstDescendantOfType<ScrollViewer>();
            if (scrollViewer != null)
            {
                scrollViewer.ScrollChanged += AssociatedObject_ScrollChanged;
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            var scrollViewer = AssociatedObject as ScrollViewer ?? AssociatedObject.GetFirstDescendantOfType<ScrollViewer>();
            if (scrollViewer != null)
            {
                scrollViewer.ScrollChanged -= AssociatedObject_ScrollChanged;
            }
        }

        private void AssociatedObject_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.VerticalOffset >= e.ExtentHeight - e.ViewportHeight)
            {
                InvokeActions(e);
            }
        }
    }
}