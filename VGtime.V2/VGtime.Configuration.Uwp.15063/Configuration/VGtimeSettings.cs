using System;
using Newtonsoft.Json;
using SoftwareKobo.Configuration;
using VGtime.Models.Users;
using Windows.Storage;

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

        public UserBase UserInfo
        {
            get
            {
                var json = Get<string>(nameof(UserInfo), ApplicationDataLocality.Local);
                if (json == null)
                {
                    return null;
                }
                try
                {
                    return JsonConvert.DeserializeObject<UserBase>(json);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            set
            {
                Set(nameof(UserInfo), JsonConvert.SerializeObject(value), ApplicationDataLocality.Local);
            }
        }
    }
}