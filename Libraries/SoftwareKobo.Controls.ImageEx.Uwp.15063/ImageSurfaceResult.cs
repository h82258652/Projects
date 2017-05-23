using System;
using Windows.UI.Xaml.Media;

namespace SoftwareKobo.Controls
{
    public sealed class ImageSurfaceResult
    {
        public ImageSurfaceResult(LoadedImageSurface imageSurface, LoadedImageSourceLoadStatus status)
        {
            if (imageSurface == null)
            {
                throw new ArgumentNullException(nameof(imageSurface));
            }
            if (!Enum.IsDefined(typeof(LoadedImageSourceLoadStatus), status))
            {
                throw new ArgumentOutOfRangeException(nameof(status));
            }

            Value = imageSurface;
            Status = status;
        }

        public LoadedImageSourceLoadStatus Status
        {
            get;
        }

        public LoadedImageSurface Value
        {
            get;
        }
    }
}