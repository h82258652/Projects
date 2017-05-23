using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Media;

namespace SoftwareKobo.Controls.Extensions
{
    internal static class LoadedImageSurfaceExtensions
    {
        internal static async Task<LoadedImageSourceLoadCompletedEventArgs> WaitForLoadCompletedAsync(this LoadedImageSurface imageSurface)
        {
            if (imageSurface == null)
            {
                throw new ArgumentNullException(nameof(imageSurface));
            }

            var tcs = new TaskCompletionSource<LoadedImageSourceLoadCompletedEventArgs>();

            TypedEventHandler<LoadedImageSurface, LoadedImageSourceLoadCompletedEventArgs> handler = null;
            handler = (sender, args) =>
            {
                imageSurface.LoadCompleted -= handler;
            };
            imageSurface.LoadCompleted += handler;

            return await tcs.Task;
        }
    }
}