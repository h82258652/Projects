using System;
using System.Threading.Tasks;
using System.Windows;

namespace SoftwareKobo.Controls.Extensions
{
    internal static class FrameworkElementExtensions
    {
        internal static async Task WaitForNonZeroSizeAsync(this FrameworkElement frameworkElement)
        {
            if (frameworkElement == null)
            {
                throw new ArgumentNullException(nameof(frameworkElement));
            }

            while (frameworkElement.ActualWidth <= 0 && frameworkElement.ActualHeight <= 0)
            {
                var tcs = new TaskCompletionSource<object>();
                SizeChangedEventHandler handler = null;
                handler = (sender, e) =>
                {
                    frameworkElement.SizeChanged -= handler;
                    tcs.SetResult(null);
                };
                frameworkElement.SizeChanged += handler;
                await tcs.Task;
            }
        }
    }
}