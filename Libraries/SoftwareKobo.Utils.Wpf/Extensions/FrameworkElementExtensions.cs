using System;
using System.Threading.Tasks;
using System.Windows;

namespace SoftwareKobo.Extensions
{
    public static class FrameworkElementExtensions
    {
        public static Task WaitForLoadedAsync(this FrameworkElement frameworkElement)
        {
            if (frameworkElement == null)
            {
                throw new ArgumentNullException(nameof(frameworkElement));
            }

            if (frameworkElement.IsLoaded)
            {
                return Task.CompletedTask;
            }

            var tcs = new TaskCompletionSource<object>();
            RoutedEventHandler handler = null;
            handler = (sender, e) =>
            {
                frameworkElement.Loaded -= handler;
                tcs.SetResult(null);
            };
            frameworkElement.Loaded += handler;
            return tcs.Task;
        }
    }
}