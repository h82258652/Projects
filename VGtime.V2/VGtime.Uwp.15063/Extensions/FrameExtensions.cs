using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VGtime.Uwp.Views;

namespace VGtime.Uwp.Extensions
{
    internal static class FrameExtensions
    {
        internal static readonly DependencyProperty PreviousPageProperty = DependencyProperty.RegisterAttached("PreviousPage", typeof(ViewBase), typeof(FrameExtensions), new PropertyMetadata(default(ViewBase)));

        internal static ViewBase GetPreviousPage(Frame obj)
        {
            return (ViewBase)obj.GetValue(PreviousPageProperty);
        }

        internal static void SetPreviousPage(Frame obj, ViewBase value)
        {
            obj.SetValue(PreviousPageProperty, value);
        }
    }
}