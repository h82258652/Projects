using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VGtime.Uwp.Views;

namespace VGtime.Uwp.Extensions
{
    internal static class FrameExtensions
    {
        internal static readonly DependencyProperty PreviousPageProperty = DependencyProperty.RegisterAttached("PreviousPage", typeof(AnimatedViewBase), typeof(FrameExtensions), new PropertyMetadata(default(AnimatedViewBase)));

        internal static AnimatedViewBase GetPreviousPage(Frame obj)
        {
            return (AnimatedViewBase)obj.GetValue(PreviousPageProperty);
        }

        internal static void SetPreviousPage(Frame obj, AnimatedViewBase value)
        {
            obj.SetValue(PreviousPageProperty, value);
        }
    }
}