using System;

namespace SoftwareKobo.Controls
{
    public static class ImageExSettings
    {
        private static Func<IImageLoader> _loader = () => DefaultImageLoader.Instance;

        public static Func<IImageLoader> Loader
        {
            get
            {
                return _loader;
            }
            set
            {
                if (_loader == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _loader = value;
            }
        }
    }
}