using System;
using System.IO;
using Windows.Storage;

namespace SoftwareKobo.Controls
{
    public partial class ImageExSettings
    {
        private static string _cacheFolderPath = Path.Combine(ApplicationData.Current.LocalCacheFolder.Path, DefaultCacheFolderName);

        public static string CacheFolderPath
        {
            get
            {
                return _cacheFolderPath;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _cacheFolderPath = value;
            }
        }
    }
}