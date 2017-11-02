using System;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace SoftwareKobo.Extensions
{
    public static class StoryboardExtensions
    {
        public static Task BeginAsync(this Storyboard storyboard)
        {
            if (storyboard == null)
            {
                throw new ArgumentNullException(nameof(storyboard));
            }

            var tcs = new TaskCompletionSource<object>();

            EventHandler handler = null;
            handler = (sender, e) =>
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