using Windows.Storage;
using SoftwareKobo.Configuration;

namespace VGtime.Configuration
{
    public class VGtimeSettings : AppSettingsBase, IVGtimeSettings
    {
        public string StartPicture
        {
            get
            {
                return Get<string>(nameof(StartPicture), ApplicationDataLocality.Local);
            }
            set
            {
                Set(nameof(StartPicture), value, ApplicationDataLocality.Local);
            }
        }
    }
}