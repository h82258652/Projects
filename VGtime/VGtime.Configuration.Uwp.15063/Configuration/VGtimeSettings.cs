using SoftwareKobo.Configuration;
using Windows.Storage;

namespace VGtime.Configuration
{
    public class VGtimeSettings : AppSettingsBase, IVGtimeSettings
    {
        public string StartPicture
        {
            get
            {
                return Get<string>(nameof(StartPicture), ApplicationDataLocality.Local, () => null);
            }
            set
            {
                Set(nameof(StartPicture), value, ApplicationDataLocality.Local);
                RaisePropertyChanged();
            }
        }
    }
}