using System;

namespace SoftwareKobo.Controls
{
    public static partial class ImageExSettings
    {
        private const string DefaultCacheFolderName = "ImageExCache";

        private static Func<IImageLoader> _loader = () => DefaultImageLoader.Instance;

        public static Func<IImageLoader> Loader
        {
            get
            {
                return _loader;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _loader = value;
            }
        }
    }
}