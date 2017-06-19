using System;
using Windows.UI.Xaml.Media;

namespace SoftwareKobo.Controls
{
    public sealed class ImageSurfaceResult
    {
        public ImageSurfaceResult(LoadedImageSurface imageSurface, LoadedImageSourceLoadStatus status)
        {
            if (!Enum.IsDefined(typeof(LoadedImageSourceLoadStatus), status))
            {
                throw new ArgumentOutOfRangeException(nameof(status));
            }

            Value = imageSurface;
            Status = imageSurface == null ? LoadedImageSourceLoadStatus.Other : status;
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