using System;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace SoftwareKobo.Controls.Extensions
{
    internal static class StoryboardExtensions
    {
        internal static Task BeginAsync(this Storyboard storyboard)
        {
            if (storyboard == null)
            {
                throw new ArgumentNullException(nameof(storyboard));
            }

            var tcs = new TaskCompletionSource<object>();
            EventHandler handler = null;
            handler = delegate
            {
                storyboard.Completed -= handler;
                tcs.SetResult(null);
            };
            storyboard.Completed += handler;
            storyboard.Begin();
            return tcs.Task;
        }
    }
}