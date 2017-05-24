using System;
using System.IO;

namespace SoftwareKobo.Controls
{
    public partial class ImageExSettings
    {
        private static string _cacheFolderPath = Path.Combine(Path.GetTempPath(), DefaultCacheFolderName);

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