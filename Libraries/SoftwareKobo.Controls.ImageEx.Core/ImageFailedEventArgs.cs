using System;

namespace SoftwareKobo.Controls
{
    public sealed class ImageFailedEventArgs : ExceptionEventArgs
    {
        public ImageFailedEventArgs(string source, Exception failedException) : base(failedException)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            Source = source;
        }

        public string Source
        {
            get;
        }
    }
}